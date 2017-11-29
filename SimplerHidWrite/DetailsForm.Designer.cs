namespace IliumVR.Tools.SimplerHidWrite
{
	partial class DetailsForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.propertyGridCaps = new System.Windows.Forms.PropertyGrid();
			this.listBoxValueCaps = new System.Windows.Forms.ListBox();
			this.listBoxStrings = new System.Windows.Forms.ListBox();
			this.lblValueCaps = new System.Windows.Forms.Label();
			this.lblStrings = new System.Windows.Forms.Label();
			this.lblDevInfo = new System.Windows.Forms.Label();
			this.lblVendName = new System.Windows.Forms.Label();
			this.lblProdName = new System.Windows.Forms.Label();
			this.lblSerialNum = new System.Windows.Forms.Label();
			this.lblVid = new System.Windows.Forms.Label();
			this.lblPid = new System.Windows.Forms.Label();
			this.lblRev = new System.Windows.Forms.Label();
			this.lblFeatureSize = new System.Windows.Forms.Label();
			this.lblOutputSize = new System.Windows.Forms.Label();
			this.lblInputSize = new System.Windows.Forms.Label();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.splitContainer3 = new System.Windows.Forms.SplitContainer();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
			this.splitContainer3.Panel1.SuspendLayout();
			this.splitContainer3.Panel2.SuspendLayout();
			this.splitContainer3.SuspendLayout();
			this.SuspendLayout();
			// 
			// propertyGridCaps
			// 
			this.propertyGridCaps.Dock = System.Windows.Forms.DockStyle.Fill;
			this.propertyGridCaps.HelpVisible = false;
			this.propertyGridCaps.Location = new System.Drawing.Point(0, 0);
			this.propertyGridCaps.Name = "propertyGridCaps";
			this.propertyGridCaps.Size = new System.Drawing.Size(237, 212);
			this.propertyGridCaps.TabIndex = 0;
			// 
			// listBoxValueCaps
			// 
			this.listBoxValueCaps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxValueCaps.FormattingEnabled = true;
			this.listBoxValueCaps.Location = new System.Drawing.Point(6, 29);
			this.listBoxValueCaps.Name = "listBoxValueCaps";
			this.listBoxValueCaps.Size = new System.Drawing.Size(228, 134);
			this.listBoxValueCaps.TabIndex = 1;
			this.listBoxValueCaps.SelectedIndexChanged += new System.EventHandler(this.listBoxValueCaps_SelectedIndexChanged);
			// 
			// listBoxStrings
			// 
			this.listBoxStrings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxStrings.FormattingEnabled = true;
			this.listBoxStrings.Location = new System.Drawing.Point(6, 29);
			this.listBoxStrings.Name = "listBoxStrings";
			this.listBoxStrings.Size = new System.Drawing.Size(227, 355);
			this.listBoxStrings.TabIndex = 2;
			// 
			// lblValueCaps
			// 
			this.lblValueCaps.AutoSize = true;
			this.lblValueCaps.Location = new System.Drawing.Point(3, 9);
			this.lblValueCaps.Name = "lblValueCaps";
			this.lblValueCaps.Size = new System.Drawing.Size(90, 13);
			this.lblValueCaps.TabIndex = 3;
			this.lblValueCaps.Text = "Value Capabilities";
			// 
			// lblStrings
			// 
			this.lblStrings.AutoSize = true;
			this.lblStrings.Location = new System.Drawing.Point(3, 9);
			this.lblStrings.Name = "lblStrings";
			this.lblStrings.Size = new System.Drawing.Size(39, 13);
			this.lblStrings.TabIndex = 4;
			this.lblStrings.Text = "Strings";
			// 
			// lblDevInfo
			// 
			this.lblDevInfo.AutoSize = true;
			this.lblDevInfo.Location = new System.Drawing.Point(12, 9);
			this.lblDevInfo.Name = "lblDevInfo";
			this.lblDevInfo.Size = new System.Drawing.Size(62, 13);
			this.lblDevInfo.TabIndex = 5;
			this.lblDevInfo.Text = "Device Info";
			// 
			// lblVendName
			// 
			this.lblVendName.Location = new System.Drawing.Point(12, 47);
			this.lblVendName.Name = "lblVendName";
			this.lblVendName.Size = new System.Drawing.Size(230, 13);
			this.lblVendName.TabIndex = 6;
			this.lblVendName.Text = "Vendor Name: ";
			// 
			// lblProdName
			// 
			this.lblProdName.Location = new System.Drawing.Point(12, 71);
			this.lblProdName.Name = "lblProdName";
			this.lblProdName.Size = new System.Drawing.Size(230, 13);
			this.lblProdName.TabIndex = 7;
			this.lblProdName.Text = "Product Name: ";
			// 
			// lblSerialNum
			// 
			this.lblSerialNum.Location = new System.Drawing.Point(12, 95);
			this.lblSerialNum.Name = "lblSerialNum";
			this.lblSerialNum.Size = new System.Drawing.Size(230, 13);
			this.lblSerialNum.TabIndex = 8;
			this.lblSerialNum.Text = "Serial Number: ";
			// 
			// lblVid
			// 
			this.lblVid.Location = new System.Drawing.Point(12, 130);
			this.lblVid.Name = "lblVid";
			this.lblVid.Size = new System.Drawing.Size(230, 15);
			this.lblVid.TabIndex = 11;
			this.lblVid.Text = "VID (hex):";
			// 
			// lblPid
			// 
			this.lblPid.Location = new System.Drawing.Point(12, 156);
			this.lblPid.Name = "lblPid";
			this.lblPid.Size = new System.Drawing.Size(230, 13);
			this.lblPid.TabIndex = 12;
			this.lblPid.Text = "PID (hex):";
			// 
			// lblRev
			// 
			this.lblRev.Location = new System.Drawing.Point(12, 182);
			this.lblRev.Name = "lblRev";
			this.lblRev.Size = new System.Drawing.Size(230, 13);
			this.lblRev.TabIndex = 13;
			this.lblRev.Text = "Rev (hex):";
			// 
			// lblFeatureSize
			// 
			this.lblFeatureSize.Location = new System.Drawing.Point(12, 282);
			this.lblFeatureSize.Name = "lblFeatureSize";
			this.lblFeatureSize.Size = new System.Drawing.Size(230, 13);
			this.lblFeatureSize.TabIndex = 16;
			this.lblFeatureSize.Text = "Feature:";
			// 
			// lblOutputSize
			// 
			this.lblOutputSize.Location = new System.Drawing.Point(12, 256);
			this.lblOutputSize.Name = "lblOutputSize";
			this.lblOutputSize.Size = new System.Drawing.Size(230, 13);
			this.lblOutputSize.TabIndex = 15;
			this.lblOutputSize.Text = "Output:";
			// 
			// lblInputSize
			// 
			this.lblInputSize.Location = new System.Drawing.Point(12, 230);
			this.lblInputSize.Name = "lblInputSize";
			this.lblInputSize.Size = new System.Drawing.Size(230, 13);
			this.lblInputSize.TabIndex = 14;
			this.lblInputSize.Text = "Input:";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.lblDevInfo);
			this.splitContainer1.Panel1.Controls.Add(this.lblFeatureSize);
			this.splitContainer1.Panel1.Controls.Add(this.lblVendName);
			this.splitContainer1.Panel1.Controls.Add(this.lblOutputSize);
			this.splitContainer1.Panel1.Controls.Add(this.lblProdName);
			this.splitContainer1.Panel1.Controls.Add(this.lblInputSize);
			this.splitContainer1.Panel1.Controls.Add(this.lblSerialNum);
			this.splitContainer1.Panel1.Controls.Add(this.lblRev);
			this.splitContainer1.Panel1.Controls.Add(this.lblVid);
			this.splitContainer1.Panel1.Controls.Add(this.lblPid);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Size = new System.Drawing.Size(714, 396);
			this.splitContainer1.SplitterDistance = 225;
			this.splitContainer1.TabIndex = 0;
			this.splitContainer1.TabStop = false;
			// 
			// splitContainer2
			// 
			this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.listBoxStrings);
			this.splitContainer2.Panel1.Controls.Add(this.lblStrings);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
			this.splitContainer2.Size = new System.Drawing.Size(485, 396);
			this.splitContainer2.SplitterDistance = 240;
			this.splitContainer2.TabIndex = 5;
			// 
			// splitContainer3
			// 
			this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer3.Location = new System.Drawing.Point(0, 0);
			this.splitContainer3.Name = "splitContainer3";
			this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer3.Panel1
			// 
			this.splitContainer3.Panel1.Controls.Add(this.lblValueCaps);
			this.splitContainer3.Panel1.Controls.Add(this.listBoxValueCaps);
			// 
			// splitContainer3.Panel2
			// 
			this.splitContainer3.Panel2.Controls.Add(this.propertyGridCaps);
			this.splitContainer3.Size = new System.Drawing.Size(241, 396);
			this.splitContainer3.SplitterDistance = 176;
			this.splitContainer3.TabIndex = 4;
			// 
			// DetailsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(714, 396);
			this.Controls.Add(this.splitContainer1);
			this.Name = "DetailsForm";
			this.Text = "Device Details";
			this.Load += new System.EventHandler(this.DetailsForm_Load);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel1.PerformLayout();
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.splitContainer3.Panel1.ResumeLayout(false);
			this.splitContainer3.Panel1.PerformLayout();
			this.splitContainer3.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
			this.splitContainer3.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PropertyGrid propertyGridCaps;
		private System.Windows.Forms.ListBox listBoxValueCaps;
		private System.Windows.Forms.ListBox listBoxStrings;
		private System.Windows.Forms.Label lblValueCaps;
		private System.Windows.Forms.Label lblStrings;
		private System.Windows.Forms.Label lblDevInfo;
		private System.Windows.Forms.Label lblVendName;
		private System.Windows.Forms.Label lblProdName;
		private System.Windows.Forms.Label lblSerialNum;
		private System.Windows.Forms.Label lblVid;
		private System.Windows.Forms.Label lblPid;
		private System.Windows.Forms.Label lblRev;
		private System.Windows.Forms.Label lblFeatureSize;
		private System.Windows.Forms.Label lblOutputSize;
		private System.Windows.Forms.Label lblInputSize;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.SplitContainer splitContainer3;
	}
}