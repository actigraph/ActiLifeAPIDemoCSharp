namespace ActiLifeAPITester
{
	partial class TestForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestForm));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.grpTests = new System.Windows.Forms.GroupBox();
            this.btnPopulateTest = new System.Windows.Forms.Button();
            this.grpConnection = new System.Windows.Forms.GroupBox();
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.tmrConnected = new System.Windows.Forms.Timer(this.components);
            this.menuContextResponse = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlSendReceive = new SplitContainerEx();
            this.txtRequest = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSend = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlFlowStatus = new System.Windows.Forms.FlowLayoutPanel();
            this.lblResponseStatus = new System.Windows.Forms.Label();
            this.imgStatus = new System.Windows.Forms.PictureBox();
            this.txtResponse = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpTests.SuspendLayout();
            this.grpConnection.SuspendLayout();
            this.menuContextResponse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSendReceive)).BeginInit();
            this.pnlSendReceive.Panel1.SuspendLayout();
            this.pnlSendReceive.Panel2.SuspendLayout();
            this.pnlSendReceive.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlFlowStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(261, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // grpTests
            // 
            this.grpTests.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTests.Controls.Add(this.btnPopulateTest);
            this.grpTests.Controls.Add(this.comboBox1);
            this.grpTests.Enabled = false;
            this.grpTests.Location = new System.Drawing.Point(494, 6);
            this.grpTests.Name = "grpTests";
            this.grpTests.Size = new System.Drawing.Size(358, 47);
            this.grpTests.TabIndex = 1;
            this.grpTests.TabStop = false;
            this.grpTests.Text = "Built In Tests";
            // 
            // btnPopulateTest
            // 
            this.btnPopulateTest.AutoSize = true;
            this.btnPopulateTest.Image = global::ActiLifeAPITester.Properties.Resources.wand;
            this.btnPopulateTest.Location = new System.Drawing.Point(273, 17);
            this.btnPopulateTest.Name = "btnPopulateTest";
            this.btnPopulateTest.Size = new System.Drawing.Size(79, 23);
            this.btnPopulateTest.TabIndex = 1;
            this.btnPopulateTest.Text = "Populate";
            this.btnPopulateTest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPopulateTest.UseVisualStyleBackColor = true;
            // 
            // grpConnection
            // 
            this.grpConnection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpConnection.Controls.Add(this.lblConnectionStatus);
            this.grpConnection.Controls.Add(this.btnConnect);
            this.grpConnection.Location = new System.Drawing.Point(12, 6);
            this.grpConnection.Name = "grpConnection";
            this.grpConnection.Size = new System.Drawing.Size(326, 47);
            this.grpConnection.TabIndex = 7;
            this.grpConnection.TabStop = false;
            this.grpConnection.Text = "Connection Status";
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblConnectionStatus.Location = new System.Drawing.Point(88, 22);
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(232, 13);
            this.lblConnectionStatus.TabIndex = 1;
            // 
            // btnConnect
            // 
            this.btnConnect.AutoSize = true;
            this.btnConnect.Image = global::ActiLifeAPITester.Properties.Resources.connect;
            this.btnConnect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConnect.Location = new System.Drawing.Point(6, 17);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(76, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConnect.UseVisualStyleBackColor = true;
            // 
            // tmrConnected
            // 
            this.tmrConnected.Enabled = true;
            this.tmrConnected.Interval = 500;
            // 
            // menuContextResponse
            // 
            this.menuContextResponse.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearLogToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveLogToolStripMenuItem});
            this.menuContextResponse.Name = "menuContextResponse";
            this.menuContextResponse.Size = new System.Drawing.Size(125, 54);
            // 
            // clearLogToolStripMenuItem
            // 
            this.clearLogToolStripMenuItem.Image = global::ActiLifeAPITester.Properties.Resources.cell_clear;
            this.clearLogToolStripMenuItem.Name = "clearLogToolStripMenuItem";
            this.clearLogToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.clearLogToolStripMenuItem.Text = "Clear Log";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
            // 
            // saveLogToolStripMenuItem
            // 
            this.saveLogToolStripMenuItem.Image = global::ActiLifeAPITester.Properties.Resources.table_save;
            this.saveLogToolStripMenuItem.Name = "saveLogToolStripMenuItem";
            this.saveLogToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.saveLogToolStripMenuItem.Text = "Save Log";
            // 
            // pnlSendReceive
            // 
            this.pnlSendReceive.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSendReceive.Enabled = false;
            this.pnlSendReceive.Location = new System.Drawing.Point(12, 66);
            this.pnlSendReceive.Name = "pnlSendReceive";
            this.pnlSendReceive.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // pnlSendReceive.Panel1
            // 
            this.pnlSendReceive.Panel1.Controls.Add(this.txtRequest);
            this.pnlSendReceive.Panel1.Controls.Add(this.panel1);
            this.pnlSendReceive.Panel1.Controls.Add(this.label1);
            // 
            // pnlSendReceive.Panel2
            // 
            this.pnlSendReceive.Panel2.Controls.Add(this.pnlFlowStatus);
            this.pnlSendReceive.Panel2.Controls.Add(this.txtResponse);
            this.pnlSendReceive.Panel2.Controls.Add(this.label2);
            this.pnlSendReceive.Size = new System.Drawing.Size(840, 362);
            this.pnlSendReceive.SplitterDistance = 170;
            this.pnlSendReceive.SplitterWidth = 10;
            this.pnlSendReceive.TabIndex = 8;
            // 
            // txtRequest
            // 
            this.txtRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRequest.Location = new System.Drawing.Point(0, 28);
            this.txtRequest.MaxLength = 0;
            this.txtRequest.Multiline = true;
            this.txtRequest.Name = "txtRequest";
            this.txtRequest.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRequest.Size = new System.Drawing.Size(840, 109);
            this.txtRequest.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSend);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 137);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(840, 33);
            this.panel1.TabIndex = 7;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSend.Enabled = false;
            this.btnSend.Image = global::ActiLifeAPITester.Properties.Resources.send_receive_all_folders;
            this.btnSend.Location = new System.Drawing.Point(267, 4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(307, 25);
            this.btnSend.TabIndex = 6;
            this.btnSend.Text = "Send Request";
            this.btnSend.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSend.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 10);
            this.label1.Size = new System.Drawing.Size(112, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "Request (to ActiLife):";
            // 
            // pnlFlowStatus
            // 
            this.pnlFlowStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFlowStatus.Controls.Add(this.lblResponseStatus);
            this.pnlFlowStatus.Controls.Add(this.imgStatus);
            this.pnlFlowStatus.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlFlowStatus.Location = new System.Drawing.Point(139, 0);
            this.pnlFlowStatus.Name = "pnlFlowStatus";
            this.pnlFlowStatus.Size = new System.Drawing.Size(701, 38);
            this.pnlFlowStatus.TabIndex = 7;
            // 
            // lblResponseStatus
            // 
            this.lblResponseStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResponseStatus.AutoEllipsis = true;
            this.lblResponseStatus.AutoSize = true;
            this.lblResponseStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblResponseStatus.Location = new System.Drawing.Point(695, 0);
            this.lblResponseStatus.Name = "lblResponseStatus";
            this.lblResponseStatus.Padding = new System.Windows.Forms.Padding(3, 15, 0, 10);
            this.lblResponseStatus.Size = new System.Drawing.Size(3, 38);
            this.lblResponseStatus.TabIndex = 6;
            this.lblResponseStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // imgStatus
            // 
            this.imgStatus.Location = new System.Drawing.Point(676, 0);
            this.imgStatus.Margin = new System.Windows.Forms.Padding(3, 0, 0, 10);
            this.imgStatus.Name = "imgStatus";
            this.imgStatus.Padding = new System.Windows.Forms.Padding(3, 15, 0, 10);
            this.imgStatus.Size = new System.Drawing.Size(16, 16);
            this.imgStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgStatus.TabIndex = 7;
            this.imgStatus.TabStop = false;
            // 
            // txtResponse
            // 
            this.txtResponse.ContextMenuStrip = this.menuContextResponse;
            this.txtResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResponse.Location = new System.Drawing.Point(0, 38);
            this.txtResponse.MaxLength = 0;
            this.txtResponse.Multiline = true;
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.ReadOnly = true;
            this.txtResponse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResponse.Size = new System.Drawing.Size(840, 144);
            this.txtResponse.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 15, 0, 10);
            this.label2.Size = new System.Drawing.Size(133, 38);
            this.label2.TabIndex = 4;
            this.label2.Text = "Response (from ActiLife):";
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 440);
            this.Controls.Add(this.grpConnection);
            this.Controls.Add(this.grpTests);
            this.Controls.Add(this.pnlSendReceive);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(880, 479);
            this.Name = "TestForm";
            this.Text = "ActiLife API Tester";
            this.grpTests.ResumeLayout(false);
            this.grpTests.PerformLayout();
            this.grpConnection.ResumeLayout(false);
            this.grpConnection.PerformLayout();
            this.menuContextResponse.ResumeLayout(false);
            this.pnlSendReceive.Panel1.ResumeLayout(false);
            this.pnlSendReceive.Panel1.PerformLayout();
            this.pnlSendReceive.Panel2.ResumeLayout(false);
            this.pnlSendReceive.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSendReceive)).EndInit();
            this.pnlSendReceive.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlFlowStatus.ResumeLayout(false);
            this.pnlFlowStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgStatus)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.GroupBox grpTests;
		private System.Windows.Forms.Button btnPopulateTest;
		private System.Windows.Forms.TextBox txtRequest;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtResponse;
		private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.GroupBox grpConnection;
		private SplitContainerEx pnlSendReceive;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblConnectionStatus;
		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.FlowLayoutPanel pnlFlowStatus;
		private System.Windows.Forms.Label lblResponseStatus;
		private System.Windows.Forms.Timer tmrConnected;
		private System.Windows.Forms.ContextMenuStrip menuContextResponse;
		private System.Windows.Forms.ToolStripMenuItem clearLogToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem saveLogToolStripMenuItem;
		private System.Windows.Forms.PictureBox imgStatus;
	}
}