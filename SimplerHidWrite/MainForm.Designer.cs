namespace IliumVR.Tools.SimplerHidWrite
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.mainSplit = new System.Windows.Forms.SplitContainer();
			this.devicesListView = new System.Windows.Forms.ListView();
			this.productColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.mfgColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.serialNumColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.vidColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.pidColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btnSaveOutput = new System.Windows.Forms.Button();
			this.btnSetFeature = new System.Windows.Forms.Button();
			this.btnGetFeature = new System.Windows.Forms.Button();
			this.btnSetReport = new System.Windows.Forms.Button();
			this.btnGetReport = new System.Windows.Forms.Button();
			this.btnRead = new System.Windows.Forms.Button();
			this.btnWrite = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.dataListBox = new System.Windows.Forms.ListBox();
			this.tbReportId = new System.Windows.Forms.TextBox();
			this.lblReportId = new System.Windows.Forms.Label();
			this.readThread = new System.ComponentModel.BackgroundWorker();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripTimeouts = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripAvgMinMax = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripSpacing = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripDetailsButton = new System.Windows.Forms.ToolStripSplitButton();
			this.toolStripSettingsDropDown = new System.Windows.Forms.ToolStripDropDownButton();
			this.backgroundReadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveLogDialog = new System.Windows.Forms.SaveFileDialog();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.mainSplit)).BeginInit();
			this.mainSplit.Panel1.SuspendLayout();
			this.mainSplit.Panel2.SuspendLayout();
			this.mainSplit.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainSplit
			// 
			this.mainSplit.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainSplit.Location = new System.Drawing.Point(0, 0);
			this.mainSplit.Name = "mainSplit";
			this.mainSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// mainSplit.Panel1
			// 
			this.mainSplit.Panel1.Controls.Add(this.devicesListView);
			// 
			// mainSplit.Panel2
			// 
			this.mainSplit.Panel2.Controls.Add(this.btnSaveOutput);
			this.mainSplit.Panel2.Controls.Add(this.btnSetFeature);
			this.mainSplit.Panel2.Controls.Add(this.btnGetFeature);
			this.mainSplit.Panel2.Controls.Add(this.btnSetReport);
			this.mainSplit.Panel2.Controls.Add(this.btnGetReport);
			this.mainSplit.Panel2.Controls.Add(this.btnRead);
			this.mainSplit.Panel2.Controls.Add(this.btnWrite);
			this.mainSplit.Panel2.Controls.Add(this.btnClear);
			this.mainSplit.Panel2.Controls.Add(this.dataListBox);
			this.mainSplit.Panel2.Controls.Add(this.tbReportId);
			this.mainSplit.Panel2.Controls.Add(this.lblReportId);
			this.mainSplit.Size = new System.Drawing.Size(504, 488);
			this.mainSplit.SplitterDistance = 134;
			this.mainSplit.TabIndex = 0;
			// 
			// devicesListView
			// 
			this.devicesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.productColumnHeader,
            this.mfgColumnHeader,
            this.serialNumColumnHeader,
            this.vidColumnHeader,
            this.pidColumnHeader});
			this.devicesListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.devicesListView.FullRowSelect = true;
			this.devicesListView.HideSelection = false;
			this.devicesListView.Location = new System.Drawing.Point(0, 0);
			this.devicesListView.MultiSelect = false;
			this.devicesListView.Name = "devicesListView";
			this.devicesListView.Size = new System.Drawing.Size(504, 134);
			this.devicesListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.devicesListView.TabIndex = 0;
			this.devicesListView.UseCompatibleStateImageBehavior = false;
			this.devicesListView.View = System.Windows.Forms.View.Details;
			this.devicesListView.SelectedIndexChanged += new System.EventHandler(this.devicesListView_SelectedIndexChanged);
			// 
			// productColumnHeader
			// 
			this.productColumnHeader.Text = "Product";
			this.productColumnHeader.Width = 150;
			// 
			// mfgColumnHeader
			// 
			this.mfgColumnHeader.Text = "Manufacturer";
			this.mfgColumnHeader.Width = 110;
			// 
			// serialNumColumnHeader
			// 
			this.serialNumColumnHeader.Text = "Serial";
			this.serialNumColumnHeader.Width = 120;
			// 
			// vidColumnHeader
			// 
			this.vidColumnHeader.Text = "VID";
			this.vidColumnHeader.Width = 50;
			// 
			// pidColumnHeader
			// 
			this.pidColumnHeader.Text = "PID";
			this.pidColumnHeader.Width = 50;
			// 
			// btnSaveOutput
			// 
			this.btnSaveOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSaveOutput.Location = new System.Drawing.Point(336, 154);
			this.btnSaveOutput.Name = "btnSaveOutput";
			this.btnSaveOutput.Size = new System.Drawing.Size(75, 23);
			this.btnSaveOutput.TabIndex = 3;
			this.btnSaveOutput.Text = "Save As...";
			this.btnSaveOutput.UseVisualStyleBackColor = true;
			this.btnSaveOutput.Click += new System.EventHandler(this.btnSaveOutput_Click);
			// 
			// btnSetFeature
			// 
			this.btnSetFeature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnSetFeature.Location = new System.Drawing.Point(417, 295);
			this.btnSetFeature.Name = "btnSetFeature";
			this.btnSetFeature.Size = new System.Drawing.Size(75, 23);
			this.btnSetFeature.TabIndex = 105;
			this.btnSetFeature.Text = "Set Feature";
			this.btnSetFeature.UseVisualStyleBackColor = true;
			this.btnSetFeature.Click += new System.EventHandler(this.btnSetFeature_Click);
			// 
			// btnGetFeature
			// 
			this.btnGetFeature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnGetFeature.Location = new System.Drawing.Point(336, 295);
			this.btnGetFeature.Name = "btnGetFeature";
			this.btnGetFeature.Size = new System.Drawing.Size(75, 23);
			this.btnGetFeature.TabIndex = 104;
			this.btnGetFeature.Text = "Get Feature";
			this.btnGetFeature.UseVisualStyleBackColor = true;
			this.btnGetFeature.Click += new System.EventHandler(this.btnGetFeature_Click);
			// 
			// btnSetReport
			// 
			this.btnSetReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnSetReport.Location = new System.Drawing.Point(255, 295);
			this.btnSetReport.Name = "btnSetReport";
			this.btnSetReport.Size = new System.Drawing.Size(75, 23);
			this.btnSetReport.TabIndex = 103;
			this.btnSetReport.Text = "Set Report";
			this.btnSetReport.UseVisualStyleBackColor = true;
			this.btnSetReport.Click += new System.EventHandler(this.btnSetReport_Click);
			// 
			// btnGetReport
			// 
			this.btnGetReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnGetReport.Location = new System.Drawing.Point(174, 295);
			this.btnGetReport.Name = "btnGetReport";
			this.btnGetReport.Size = new System.Drawing.Size(75, 23);
			this.btnGetReport.TabIndex = 102;
			this.btnGetReport.Text = "Get Report";
			this.btnGetReport.UseVisualStyleBackColor = true;
			this.btnGetReport.Click += new System.EventHandler(this.btnGetReport_Click);
			// 
			// btnRead
			// 
			this.btnRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnRead.Location = new System.Drawing.Point(12, 295);
			this.btnRead.Name = "btnRead";
			this.btnRead.Size = new System.Drawing.Size(75, 23);
			this.btnRead.TabIndex = 100;
			this.btnRead.Text = "Read";
			this.btnRead.UseVisualStyleBackColor = true;
			this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
			// 
			// btnWrite
			// 
			this.btnWrite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnWrite.Location = new System.Drawing.Point(93, 295);
			this.btnWrite.Name = "btnWrite";
			this.btnWrite.Size = new System.Drawing.Size(75, 23);
			this.btnWrite.TabIndex = 101;
			this.btnWrite.Text = "Write";
			this.btnWrite.UseVisualStyleBackColor = true;
			this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
			// 
			// btnClear
			// 
			this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClear.Location = new System.Drawing.Point(417, 154);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 23);
			this.btnClear.TabIndex = 4;
			this.btnClear.Text = "Clear";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// dataListBox
			// 
			this.dataListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataListBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dataListBox.HorizontalScrollbar = true;
			this.dataListBox.ItemHeight = 16;
			this.dataListBox.Location = new System.Drawing.Point(0, 0);
			this.dataListBox.Name = "dataListBox";
			this.dataListBox.ScrollAlwaysVisible = true;
			this.dataListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
			this.dataListBox.Size = new System.Drawing.Size(504, 148);
			this.dataListBox.TabIndex = 2;
			// 
			// tbReportId
			// 
			this.tbReportId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.tbReportId.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbReportId.Location = new System.Drawing.Point(12, 155);
			this.tbReportId.MaxLength = 2;
			this.tbReportId.Name = "tbReportId";
			this.tbReportId.Size = new System.Drawing.Size(24, 22);
			this.tbReportId.TabIndex = 5;
			this.tbReportId.Enter += new System.EventHandler(this.textBoxClearText);
			this.tbReportId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxHexKeyPress);
			this.tbReportId.Leave += new System.EventHandler(this.textBoxFormatText);
			// 
			// lblReportId
			// 
			this.lblReportId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblReportId.AutoSize = true;
			this.lblReportId.Location = new System.Drawing.Point(39, 159);
			this.lblReportId.Name = "lblReportId";
			this.lblReportId.Size = new System.Drawing.Size(53, 13);
			this.lblReportId.TabIndex = 6;
			this.lblReportId.Text = "Report ID";
			// 
			// readThread
			// 
			this.readThread.WorkerSupportsCancellation = true;
			this.readThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.readThread_DoWork);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTimeouts,
            this.toolStripAvgMinMax,
            this.toolStripSpacing,
            this.toolStripDetailsButton,
            this.toolStripSettingsDropDown});
			this.statusStrip1.Location = new System.Drawing.Point(0, 464);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(504, 24);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripTimeouts
			// 
			this.toolStripTimeouts.Name = "toolStripTimeouts";
			this.toolStripTimeouts.Size = new System.Drawing.Size(86, 19);
			this.toolStripTimeouts.Text = "Timeouts: 0 / 0";
			// 
			// toolStripAvgMinMax
			// 
			this.toolStripAvgMinMax.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
			this.toolStripAvgMinMax.Name = "toolStripAvgMinMax";
			this.toolStripAvgMinMax.Size = new System.Drawing.Size(108, 19);
			this.toolStripAvgMinMax.Text = "Avg 0 Min 0 Max 0";
			// 
			// toolStripSpacing
			// 
			this.toolStripSpacing.Name = "toolStripSpacing";
			this.toolStripSpacing.Size = new System.Drawing.Size(155, 19);
			this.toolStripSpacing.Spring = true;
			// 
			// toolStripDetailsButton
			// 
			this.toolStripDetailsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripDetailsButton.DropDownButtonWidth = 0;
			this.toolStripDetailsButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDetailsButton.Image")));
			this.toolStripDetailsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripDetailsButton.Name = "toolStripDetailsButton";
			this.toolStripDetailsButton.Size = new System.Drawing.Size(47, 22);
			this.toolStripDetailsButton.Text = "Details";
			this.toolStripDetailsButton.ButtonClick += new System.EventHandler(this.toolStripSplitButton1_ButtonClick);
			// 
			// toolStripSettingsDropDown
			// 
			this.toolStripSettingsDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripSettingsDropDown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.backgroundReadToolStripMenuItem});
			this.toolStripSettingsDropDown.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSettingsDropDown.Image")));
			this.toolStripSettingsDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripSettingsDropDown.Name = "toolStripSettingsDropDown";
			this.toolStripSettingsDropDown.Size = new System.Drawing.Size(62, 22);
			this.toolStripSettingsDropDown.Text = "Settings";
			// 
			// backgroundReadToolStripMenuItem
			// 
			this.backgroundReadToolStripMenuItem.Checked = true;
			this.backgroundReadToolStripMenuItem.CheckOnClick = true;
			this.backgroundReadToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.backgroundReadToolStripMenuItem.Name = "backgroundReadToolStripMenuItem";
			this.backgroundReadToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.backgroundReadToolStripMenuItem.Text = "Background Read";
			this.backgroundReadToolStripMenuItem.CheckedChanged += new System.EventHandler(this.backgroundReadToolStripMenuItem_CheckedChanged);
			// 
			// saveLogDialog
			// 
			this.saveLogDialog.DefaultExt = "txt";
			this.saveLogDialog.FileName = "hid_log";
			this.saveLogDialog.InitialDirectory = ".";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.aboutToolStripMenuItem.Text = "About...";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(504, 488);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.mainSplit);
			this.DoubleBuffered = true;
			this.MinimumSize = new System.Drawing.Size(520, 400);
			this.Name = "MainForm";
			this.Text = "SimplerHidWrite";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.mainSplit.Panel1.ResumeLayout(false);
			this.mainSplit.Panel2.ResumeLayout(false);
			this.mainSplit.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.mainSplit)).EndInit();
			this.mainSplit.ResumeLayout(false);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.SplitContainer mainSplit;
		private System.ComponentModel.BackgroundWorker readThread;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripAvgMinMax;
		private System.Windows.Forms.ToolStripStatusLabel toolStripTimeouts;
		private System.Windows.Forms.ToolStripStatusLabel toolStripSpacing;
		private System.Windows.Forms.ToolStripDropDownButton toolStripSettingsDropDown;
		private System.Windows.Forms.ToolStripMenuItem backgroundReadToolStripMenuItem;
		private System.Windows.Forms.TextBox tbReportId;
		private System.Windows.Forms.Label lblReportId;
		private System.Windows.Forms.ToolStripSplitButton toolStripDetailsButton;
		private System.Windows.Forms.ListView devicesListView;
		private System.Windows.Forms.ColumnHeader productColumnHeader;
		private System.Windows.Forms.ColumnHeader serialNumColumnHeader;
		private System.Windows.Forms.ColumnHeader vidColumnHeader;
		private System.Windows.Forms.ColumnHeader pidColumnHeader;
		private System.Windows.Forms.ColumnHeader mfgColumnHeader;
		private System.Windows.Forms.ListBox dataListBox;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Button btnSaveOutput;
		private System.Windows.Forms.Button btnSetFeature;
		private System.Windows.Forms.Button btnGetFeature;
		private System.Windows.Forms.Button btnSetReport;
		private System.Windows.Forms.Button btnGetReport;
		private System.Windows.Forms.Button btnRead;
		private System.Windows.Forms.Button btnWrite;
		private System.Windows.Forms.SaveFileDialog saveLogDialog;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
	}
}

