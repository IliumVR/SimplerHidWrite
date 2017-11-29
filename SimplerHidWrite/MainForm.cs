// Copyright (c) 2016-2017 Ilium VR, Inc.
// Licensed under the MIT License - https://raw.github.com/IliumVR/SimplerHidWrite/master/LICENSE

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

using IliumVR.Bindings.Win32.Hid;
using IliumVR.Bindings.Win32.SetupApi;
using IliumVR.Bindings.Win32.User32;
using System.Reflection;

namespace IliumVR.Tools.SimplerHidWrite
{
	public partial class MainForm : Form
	{
		private HidDevice currentDevice;

		private TextBox[] byteTextboxes;

		byte[] inBuffer, outBuffer, featureBuffer;

		private int numPackets, numTimeouts;

		private IntPtr notificationHandle;

		private string lastSelectedDevice;

		public MainForm()
		{
			InitializeComponent();

			inBuffer = new byte[0];
			outBuffer = new byte[0];
			featureBuffer = new byte[0];

			//GUID_DEVINTERFACE_HID
			this.notificationHandle = DeviceNotification.Register(this.Handle, new Guid(0x4D1E55B2, 0xF16F, 0x11CF, 0x88, 0xCB, 0x00, 0x11, 0x11, 0x00, 0x00, 0x30), DeviceNotificationFlags.WindowHandle);
		}

		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);

			if (m.Msg == 0x0219)    //WM_DEVICECHANGE
			{
				switch (m.WParam.ToInt32())
				{
					case 0x8000:    //DBT_DEVICEARRIVAL
						Thread.Sleep(100);
						UsbAttach(DeviceNotification.GetDeviceName(m.LParam));
						break;
					case 0x8004:    //DBT_DEVICEREMOVECOMPLETE
						UsbDetatch(DeviceNotification.GetDeviceName(m.LParam));
						break;
				}
			}
		}

		private void UsbAttach(string dev)
		{
			ListViewItem item = new ListViewItem();
			item.Tag = dev;

			HidDevice hdev = new HidDevice(dev);
			if (hdev.IsInvalid)
			{
				AddDataListBoxItem("nerr Invalid device attached");
				return;
			}

			Attributes att = hdev.Attributes;

			item.Text = hdev.Product;
			item.SubItems.Add(hdev.Manufacturer);
			item.SubItems.Add(hdev.SerialNumber);
			item.SubItems.Add(att.VendorId.ToString("X4"));
			item.SubItems.Add(att.ProductId.ToString("X4"));

			devicesListView.Items.Add(item);

			hdev.Dispose();

			AddDataListBoxItem("natt Device attached: " + item.Text + " (" + dev + ")");

			if (!string.IsNullOrEmpty(lastSelectedDevice))
			{
				if (lastSelectedDevice.Equals((string)dev, StringComparison.InvariantCultureIgnoreCase))
				{
					item.Selected = true;
				}
			}
		}

		private void UsbDetatch(string dev)
		{
			ListViewItem match = null;
			foreach (ListViewItem item in devicesListView.Items)
			{

				if (dev.Equals((string)item.Tag, StringComparison.InvariantCultureIgnoreCase))
				{
					match = item;
					break;
				}
			}

			if (match == null)
			{
				AddDataListBoxItem("nerr Could not find removed device " + dev);
				return;
			}

			devicesListView.Items.Remove(match);
			AddDataListBoxItem("ndet Device removed: " + match.Text + " (" + dev + ")");
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			dataListBox.MakeDoubleBuffered(true);

			btnRead.Enabled = false;
			btnWrite.Enabled = false;
			btnGetReport.Enabled = false;
			btnSetReport.Enabled = false;
			btnGetFeature.Enabled = false;
			btnSetFeature.Enabled = false;

			tbReportId.Text = "00";

			Point byteTbStart = tbReportId.Location;
			byteTbStart.Y += 28;

			//TODO increase number, some devices > 64
			byteTextboxes = new TextBox[64];
			for (int i = 0; i < byteTextboxes.Length; i++)
			{
				int x = i % 16;
				int y = i / 16;

				TextBox tb = new TextBox();
				tb.Font = tbReportId.Font;
				tb.MaxLength = 2;
				tb.TabIndex = 32 + i;
				tb.Width = 24;
				Point newLocation = new Point(byteTbStart.X + (x * 30), byteTbStart.Y + (y * 28));
				tb.Location = newLocation;
				tb.Visible = false;
				tb.Text = "00";
				tb.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
				tb.KeyPress += textBoxHexKeyPress;
				tb.Enter += textBoxClearText;
				tb.Leave += textBoxFormatText;

				mainSplit.Panel2.Controls.Add(tb);
				byteTextboxes[i] = tb;
			}

			List<string> devs = DeviceInformation.GetAllDevicePaths(HidDevice.Guid, GetClassFlags.Present | GetClassFlags.DeviceInterface);

			foreach (var dev in devs)
			{
				UsbAttach(dev);
			}
		}

		private void devicesListView_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (backgroundReadToolStripMenuItem.Checked)
			{
				if (!CancelBackgroundWorkerAndWait(readThread))
					return;
			}

			if (devicesListView.SelectedIndices.Count == 0)
				return;

			if (currentDevice != null)
			{
				currentDevice.Dispose();
				currentDevice = null;
			}

			lastSelectedDevice = (string)devicesListView.SelectedItems[0].Tag;
			currentDevice = new HidDevice(lastSelectedDevice);
			if (currentDevice.IsInvalid)
			{
				currentDevice.Dispose();
				currentDevice = null;
			}

			Caps caps = currentDevice.PreparsedData.Capabilities;
			int numBytes = caps.InputReportByteLength;
			numBytes = Math.Max(numBytes, caps.OutputReportByteLength);
			numBytes = Math.Max(numBytes, caps.FeatureReportByteLength);
			numBytes -= 1;	//first byte is always report id, 

			for (int i = 0; i < byteTextboxes.Length; i++)
			{
				byteTextboxes[i].Visible = (i < numBytes);
			}

			inBuffer = new byte[caps.InputReportByteLength];
			outBuffer = new byte[caps.OutputReportByteLength];
			featureBuffer = new byte[caps.FeatureReportByteLength];

			btnRead.Enabled = (caps.InputReportByteLength != 0);
			btnWrite.Enabled = (caps.OutputReportByteLength != 0);
			btnGetReport.Enabled = (caps.InputReportByteLength != 0);
			btnSetReport.Enabled = (caps.OutputReportByteLength != 0);
			btnGetFeature.Enabled = (caps.FeatureReportByteLength != 0);
			btnSetFeature.Enabled = (caps.FeatureReportByteLength != 0);

			numPackets = 0;
			numTimeouts = 0;
			toolStripTimeouts.Text = "Timeouts: 0/0";

			if (backgroundReadToolStripMenuItem.Checked && caps.InputReportByteLength != 0)
				readThread.RunWorkerAsync(currentDevice);
		}

		private void readThread_DoWork(object sender, DoWorkEventArgs e)
		{
			HidDevice dev = (HidDevice)e.Argument;

			if (dev == null || dev.IsInvalid)
				return;

			Queue<string> list = new Queue<string>(64);
			byte[] readBuffer = new byte[dev.PreparsedData.Capabilities.InputReportByteLength];

			RingQueue<double> timeQueue = new RingQueue<double>(20);
			long updateMs = 16;
			Stopwatch invokeSw = new Stopwatch(), timeSw = new Stopwatch();
			invokeSw.Start();
			timeSw.Start();

			while (true)
			{
				if (invokeSw.ElapsedMilliseconds >= updateMs)
				{
					Invoke((Action)delegate
					{
						if (dataListBox.Items.Count > 100 || list.Count != 0)
						{
							dataListBox.BeginUpdate();

							while (dataListBox.Items.Count > 100)
							{
								dataListBox.Items.RemoveAt(0);
							}

							foreach (var str in list)
							{
								dataListBox.Items.Add(str);
							}

							dataListBox.TopIndex = dataListBox.Items.Count - 1;

							dataListBox.EndUpdate();
						}

						toolStripTimeouts.Text = "Timeouts: " + numTimeouts + "/" + numPackets;

						if (timeQueue.Count > 0)
							toolStripAvgMinMax.Text = "Avg " + timeQueue.Average() + " Min " + timeQueue.Min() + " Max " + timeQueue.Max();
						//Application.DoEvents();
					});

					list.Clear();
					invokeSw.Restart();
					timeSw.Restart();
				}

				if (readThread.CancellationPending)
					break;

				byte reportId;
				numPackets++;

				if (!dev.Read(out reportId, readBuffer, 16))
				{
					numTimeouts++;
					continue;
				}

				if (readThread.CancellationPending)
					break;

				timeQueue.Push(timeSw.Elapsed.TotalMilliseconds);
				timeSw.Restart();

				list.Enqueue("READ [" + reportId.ToString("X2") + "] " + BitConverter.ToString(readBuffer).Replace('-', ' '));
			}

			//dev.Dispose();
		}

		private void backgroundReadToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			if (!backgroundReadToolStripMenuItem.Checked)
			{
				if (readThread.IsBusy)
				{
					readThread.CancelAsync();
				}
			}
			else if (currentDevice != null && !currentDevice.IsInvalid)
			{
				if (!CancelBackgroundWorkerAndWait(readThread))
					return;

				readThread.RunWorkerAsync(currentDevice);
			}
		}

		private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
		{
			if (currentDevice == null || currentDevice.IsInvalid)
				return;

			DetailsForm df = new DetailsForm(currentDevice);
			df.ShowDialog();
		}

		private void textBoxHexKeyPress(object sender, KeyPressEventArgs e)
		{
			if (
				   (e.KeyChar < '0' || e.KeyChar > '9')
				&& (e.KeyChar < 'a' || e.KeyChar > 'f')
				&& (e.KeyChar < 'A' || e.KeyChar > 'F')
				&& e.KeyChar != (char)Keys.Back
				&& e.KeyChar != (char)Keys.Delete)
			{
				e.Handled = true; //handled prevents input from happening
			}
		}

		private void textBoxClearText(object sender, EventArgs e)
		{
			TextBox tb = sender as TextBox;
			if (tb != null)
			{
				tb.Text = null;
			}
		}

		private void textBoxFormatText(object sender, EventArgs e)
		{
			TextBox tb = sender as TextBox;
			if (tb != null)
			{
				if (tb.TextLength == 0)
					tb.Text = "00";
				else if (tb.TextLength == 1)
					tb.Text = "0" + tb.Text;
			}
		}

		private bool CancelBackgroundWorkerAndWait(BackgroundWorker worker)
		{
			if (!worker.IsBusy)
				return true;

			worker.CancelAsync();

			int iters = 0;
			while (worker.IsBusy && iters++ < 5)
			{
				Thread.Sleep(16);
				Application.DoEvents();
			}

			return !worker.IsBusy;
		}

		private void AddDataListBoxItem(string item)
		{
			dataListBox.Items.Add(item);
			dataListBox.TopIndex = dataListBox.Items.Count - 1;
		}

		private bool ConvertTextboxesToBytes(byte[] buffer, int count)
		{
			if (buffer == null || buffer.Length == 0)
				return false;

			if (!byte.TryParse(tbReportId.Text, NumberStyles.HexNumber, null, out buffer[0]))
				return false;

			int realCount = Math.Min(count, buffer.Length - 1);
			realCount = Math.Min(realCount, byteTextboxes.Length);
			for (int i = 0; i < realCount; i++)
			{
				if (!byte.TryParse(byteTextboxes[i].Text, NumberStyles.HexNumber, null, out buffer[i + 1]))
				{
					return false;
				}
			}

			return true;
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			dataListBox.Items.Clear();
		}

		private void btnSaveOutput_Click(object sender, EventArgs e)
		{
			DialogResult res = saveLogDialog.ShowDialog();

			if (res != DialogResult.OK)
				return;

			try
			{
				using (StreamWriter sw = new StreamWriter(File.Create(saveLogDialog.FileName)))
				{
				
					foreach (var line in dataListBox.Items)
					{
						sw.WriteLine(line.ToString());
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error while trying to save file." + Environment.NewLine + ex.ToString());
			}
		}

		private void btnRead_Click(object sender, EventArgs e)
		{
			if (currentDevice == null)
				return;

			try
			{
				if (currentDevice.Read(inBuffer, 100))
				{
					AddDataListBoxItem("read [" + inBuffer[0].ToString("X2") + "] " + BitConverter.ToString(inBuffer, 1).Replace('-', ' '));
				}
				else
				{
					AddDataListBoxItem("err  Read timed out. Last Error: " + Marshal.GetLastWin32Error());
				}
			}
			catch (Exception ex)
			{
				AddDataListBoxItem("err  " + ex.Message);
			}
		}

		private void btnWrite_Click(object sender, EventArgs e)
		{
			if (currentDevice == null)
				return;

			//TODO get real report length
			if (!ConvertTextboxesToBytes(outBuffer, outBuffer.Length - 1))
			{
				AddDataListBoxItem("err  Bad data in byte textboxes. Last Error: " + Marshal.GetLastWin32Error());
				return;
			}

			try
			{
				if (currentDevice.Write(outBuffer, 100))
				{
					AddDataListBoxItem("writ [" + outBuffer[0].ToString("X2") + "] " + BitConverter.ToString(outBuffer, 1).Replace('-', ' '));
				}
				else
				{
					AddDataListBoxItem("err  Write timed out. Last Error: " + Marshal.GetLastWin32Error());
				}
			}
			catch (Exception ex)
			{
				AddDataListBoxItem("err  " + ex.Message);
			}
		}

		private void btnGetReport_Click(object sender, EventArgs e)
		{
			if (currentDevice == null)
				return;

			if (!ConvertTextboxesToBytes(inBuffer, inBuffer.Length - 1))
			{
				AddDataListBoxItem("err  Bad data in byte textboxes. Last Error: " + Marshal.GetLastWin32Error());
				return;
			}

			try
			{
				if (currentDevice.GetInputReport(inBuffer))
				{
					AddDataListBoxItem("getr [" + inBuffer[0].ToString("X2") + "] " + BitConverter.ToString(inBuffer, 1).Replace('-', ' '));
				}
				else
				{
					AddDataListBoxItem("err  System Error: " + Marshal.GetLastWin32Error());
				}
			}
			catch (Exception ex)
			{
				AddDataListBoxItem("err  " + ex.Message);
			}
		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (notificationHandle != IntPtr.Zero)
				DeviceNotification.Unregister(notificationHandle);
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("IliumVR.Tools.SimplerHidWrite Version " + Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion);
		}

		private void btnSetReport_Click(object sender, EventArgs e)
		{
			if (currentDevice == null)
				return;

			if (!ConvertTextboxesToBytes(outBuffer, outBuffer.Length - 1))
			{
				AddDataListBoxItem("err  Bad data in byte textboxes. Last Error: " + Marshal.GetLastWin32Error());
				return;
			}

			try
			{
				if (currentDevice.SetOutputReport(outBuffer))
				{
					AddDataListBoxItem("setr [" + outBuffer[0].ToString("X2") + "] " + BitConverter.ToString(outBuffer, 1).Replace('-', ' '));
				}
				else
				{
					AddDataListBoxItem("err  System Error: " + Marshal.GetLastWin32Error());
				}
			}
			catch (Exception ex)
			{
				AddDataListBoxItem("err  " + ex.Message);
			}
		}

		private void btnGetFeature_Click(object sender, EventArgs e)
		{
			if (currentDevice == null)
				return;

			if (!ConvertTextboxesToBytes(featureBuffer, featureBuffer.Length - 1))
			{
				AddDataListBoxItem("err  Bad data in byte textboxes. Last Error: " + Marshal.GetLastWin32Error());
				return;
			}

			int reportLength = currentDevice.GetReportLength(ReportType.Feature, featureBuffer[0]);
			if (reportLength == 0)
			{
				AddDataListBoxItem("err  Invalid or 0-length feature report");
				return;
			}

			try
			{
				if (currentDevice.GetFeature(featureBuffer, reportLength + 1))
				{
					AddDataListBoxItem("getf [" + featureBuffer[0].ToString("X2") + "] " + BitConverter.ToString(featureBuffer, 1).Replace('-', ' '));
				}
				else
				{
					AddDataListBoxItem("err  System Error: " + Marshal.GetLastWin32Error());
				}
			}
			catch (Exception ex)
			{
				AddDataListBoxItem("err  " + ex.Message);
			}
		}

		private void btnSetFeature_Click(object sender, EventArgs e)
		{
			if (currentDevice == null)
				return;

			if (currentDevice == null)
				return;

			if (!ConvertTextboxesToBytes(featureBuffer, featureBuffer.Length - 1))
			{
				AddDataListBoxItem("err  Bad data in byte textboxes. Last Error: " + Marshal.GetLastWin32Error());
				return;
			}

			int reportLength = currentDevice.GetReportLength(ReportType.Feature, featureBuffer[0]);
			if (reportLength == 0)
			{
				AddDataListBoxItem("err  Invalid or 0-length feature report");
				return;
			}

			try
			{
				if (currentDevice.SetFeature(featureBuffer, reportLength + 1))
				{
					AddDataListBoxItem("setf [" + featureBuffer[0].ToString("X2") + "] " + BitConverter.ToString(featureBuffer, 1).Replace('-', ' '));
				}
				else
				{
					AddDataListBoxItem("err  System Error: " + Marshal.GetLastWin32Error());
				}
			}
			catch (Exception ex)
			{
				AddDataListBoxItem("err  " + ex.Message);
			}
		}
	}
}
