// Copyright (c) 2016-2017 Ilium VR, Inc.
// Licensed under the MIT License - https://raw.github.com/IliumVR/SimplerHidWrite/master/LICENSE

using System;
using System.ComponentModel;
using System.Windows.Forms;

using IliumVR.Bindings.Win32.Hid;

namespace IliumVR.Tools.SimplerHidWrite
{
	public partial class DetailsForm : Form
	{
		private class ValueCapEntry
		{
			public ValueCapsWrapper Value { get; set; }
			public string Text { get; set; }
		}

		[TypeConverter(typeof(ExpandableObjectConverter))]
		private class CapsRangeWrapper
		{
			public ushort UsageMin { get; set; }
			public ushort UsageMax { get; set; }
			public ushort StringMin { get; set; }
			public ushort StringMax { get; set; }
			public ushort DesignatorMin { get; set; }
			public ushort DesignatorMax { get; set; }
			public ushort DataIndexMin { get; set; }
			public ushort DataIndexMax { get; set; }

			public override string ToString()
			{
				return "{ " +
					"Usage = " + UsageMin + "-" + UsageMax + ", " +
					"String = " + StringMin + "-" + StringMax + ", " +
					"Designator = " + DesignatorMin + "-" + DesignatorMax + ", " +
					"DataIndex = " + DataIndexMin + "-" + DataIndexMax + " }";
			}
		}

		[TypeConverter(typeof(ExpandableObjectConverter))]
		private class CapsNotRangeWrapper
		{
			public ushort Usage { get; set; }

			[Browsable(false)]
			public ushort Reserved1 { get; set; }

			public ushort StringIndex { get; set; }

			[Browsable(false)]
			public ushort Reserved2 { get; set; }

			public ushort DesignatorIndex { get; set; }

			[Browsable(false)]
			public ushort Reserved3 { get; set; }

			public ushort DataIndex { get; set; }

			[Browsable(false)]
			public ushort Reserved4 { get; set; }

			public override string ToString()
			{
				return "{ " +
					"Usage = " + Usage + ", " +
					"String = " + StringIndex + ", " +
					"Designator = " + DesignatorIndex + ", " +
					"DataIndex = " + DataIndex + " }";
			}
		}

		[TypeConverter(typeof(ExpandableObjectConverter))]
		private class CapsRangeUnionWrapper
		{
			public CapsRangeWrapper Range { get; set; }

			public CapsNotRangeWrapper NotRange { get; set; }

			public override string ToString()
			{
				return "{ Range = " + (Range?.ToString() ?? "null") + ", NotRange = " + (NotRange?.ToString() ?? "null") + " }";
			}
		}

		[ReadOnly(true)]
		private class ValueCapsWrapper
		{
			public ushort UsagePage { get; set; }

			public byte ReportID { get; set; }

			public bool IsAlias { get; set; }

			public ushort BitField { get; set; }

			public ushort LinkCollection { get; set; }

			public ushort LinkUsage { get; set; }

			public ushort LinkUsagePage { get; set; }

			public bool IsRange { get; set; }

			public bool IsStringRange { get; set; }

			public bool IsDesignatorRange { get; set; }

			public bool IsAbsolute { get; set; }

			public bool HasNull { get; set; }

			[Browsable(false)]
			public byte Reserved { get; set; }

			public ushort BitSize { get; set; }

			public ushort ReportCount { get; set; }

			[Browsable(false)]
			public ushort[] Reserved2 { get; set; }

			public uint UnitsExp { get; set; }

			public uint Units { get; set; }

			public int LogicalMin { get; set; }

			public int LogicalMax { get; set; }

			public int PhysicalMin { get; set; }

			public int PhysicalMax { get; set; }

			public CapsRangeUnionWrapper RangeUnion { get; set; }

			public ValueCapsWrapper()
			{

			}

			public ValueCapsWrapper(ValueCaps caps)
			{
				this.UsagePage = caps.UsagePage;
				this.ReportID = caps.ReportID;
				this.IsAlias = caps.IsAlias;
				this.BitField = caps.BitField;
				this.LinkCollection = caps.LinkCollection;
				this.LinkUsage = caps.LinkUsage;
				this.LinkUsagePage = caps.LinkUsagePage;
				this.IsRange = caps.IsRange;
				this.IsStringRange = caps.IsStringRange;
				this.IsDesignatorRange = caps.IsDesignatorRange;
				this.IsAbsolute = caps.IsAbsolute;
				this.HasNull = caps.HasNull;
				this.Reserved = caps.Reserved;
				this.BitSize = caps.BitSize;
				this.ReportCount = caps.ReportCount;
				this.Reserved2 = caps.Reserved2;
				this.UnitsExp = caps.UnitsExp;
				this.Units = caps.Units;
				this.LogicalMin = caps.LogicalMin;
				this.LogicalMax = caps.LogicalMax;
				this.PhysicalMin = caps.PhysicalMin;
				this.PhysicalMax = caps.PhysicalMax;

				this.RangeUnion = new CapsRangeUnionWrapper();
				RangeUnion.Range = new CapsRangeWrapper();

				RangeUnion.Range.UsageMin = caps.RangeUnion.Range.UsageMin;
				RangeUnion.Range.UsageMax = caps.RangeUnion.Range.UsageMax;
				RangeUnion.Range.StringMin = caps.RangeUnion.Range.StringMin;
				RangeUnion.Range.StringMax = caps.RangeUnion.Range.StringMax;
				RangeUnion.Range.DesignatorMin = caps.RangeUnion.Range.DesignatorMin;
				RangeUnion.Range.DesignatorMax = caps.RangeUnion.Range.DesignatorMax;
				RangeUnion.Range.DataIndexMin = caps.RangeUnion.Range.DataIndexMin;
				RangeUnion.Range.DataIndexMax = caps.RangeUnion.Range.DataIndexMax;

				RangeUnion.NotRange = new CapsNotRangeWrapper();

				RangeUnion.NotRange.Usage = caps.RangeUnion.NotRange.Usage;
				RangeUnion.NotRange.Reserved1 = caps.RangeUnion.NotRange.Reserved1;
				RangeUnion.NotRange.StringIndex = caps.RangeUnion.NotRange.StringIndex;
				RangeUnion.NotRange.Reserved2 = caps.RangeUnion.NotRange.Reserved2;
				RangeUnion.NotRange.DesignatorIndex = caps.RangeUnion.NotRange.DesignatorIndex;
				RangeUnion.NotRange.Reserved3 = caps.RangeUnion.NotRange.Reserved3;
				RangeUnion.NotRange.DataIndex = caps.RangeUnion.NotRange.DataIndex;
				RangeUnion.NotRange.Reserved4 = caps.RangeUnion.NotRange.Reserved4;
			}
		}

		public DetailsForm(HidDevice dev)
		{
			InitializeComponent();

			if (dev == null || dev.IsInvalid)
			{
				Close();
				return;
			}

			lblProdName.Text += " " + dev.Product;
			lblVendName.Text += " " + dev.Manufacturer;
			lblSerialNum.Text += " " + dev.SerialNumber;

			Attributes att = dev.Attributes;

			lblVid.Text += " " + att.VendorId.ToString("X4");
			lblPid.Text += " " + att.ProductId.ToString("X4");
			lblRev.Text += " " + att.VersionNumber.ToString("X4");

			Caps caps = dev.PreparsedData.Capabilities;

			lblInputSize.Text += " " + caps.InputReportByteLength + " bytes";
			lblOutputSize.Text += " " + caps.OutputReportByteLength + " bytes";
			lblFeatureSize.Text += " " + caps.FeatureReportByteLength + " bytes";

			listBoxValueCaps.DisplayMember = "Text";

			foreach (var inCap in dev.InputValueCaps)
				AddValueCap(inCap, "Input Report");

			foreach (var outCap in dev.OutputValueCaps)
				AddValueCap(outCap, "Output Report");

			foreach (var featCap in dev.FeatureValueCaps)
				AddValueCap(featCap, "Feature Report");

			for (uint i = 1; i < 255; i++)
			{
				string str = dev.GetIndexedString(i);
				if (!string.IsNullOrEmpty(str))
				{
					listBoxStrings.Items.Add(i.ToString() + ": " + str);
				}
				else
					break; //HACK Logitech G105 keyboard crashes unless this is here
			}
		}

		private void AddValueCap(ValueCaps cap, string preText)
		{
			ValueCapEntry entry = new ValueCapEntry();
			entry.Value = new ValueCapsWrapper(cap);
			entry.Text = preText + " " + cap.ReportID.ToString("X2") + " / Usage Page " + cap.UsagePage.ToString("X4");

			listBoxValueCaps.Items.Add(entry);
		}

		private void DetailsForm_Load(object sender, EventArgs e)
		{
			
		}

		private void listBoxValueCaps_SelectedIndexChanged(object sender, EventArgs e)
		{
			ValueCapEntry cap = listBoxValueCaps.SelectedItem as ValueCapEntry;

			if (cap == null)
				return;

			propertyGridCaps.SelectedObject = cap.Value;
		}
	}
}
