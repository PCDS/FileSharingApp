namespace ClientRaw
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint9 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 8D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint10 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 5D);
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint11 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 10D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint12 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 12D);
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnGetFile = new System.Windows.Forms.Button();
            this.txtServerAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdTransferTime = new System.Windows.Forms.RadioButton();
            this.rdTotalTime = new System.Windows.Forms.RadioButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ckboxAutoGenerate = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comBoxDataSize = new System.Windows.Forms.ComboBox();
            this.lbProgress = new System.Windows.Forms.Label();
            this.lbDownloading = new System.Windows.Forms.Label();
            this.btnRatio = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbTCount = new System.Windows.Forms.Label();
            this.lbGCount = new System.Windows.Forms.Label();
            this.lbCCount = new System.Windows.Forms.Label();
            this.lbACount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCompressed = new System.Windows.Forms.RadioButton();
            this.btnNotCompressed = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.txtChatPort = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabChat = new System.Windows.Forms.TabPage();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnChatSend = new System.Windows.Forms.Button();
            this.tabStats = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabChat.SuspendLayout();
            this.tabStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.FrameThin1;
            this.chart1.Location = new System.Drawing.Point(6, 14);
            this.chart1.Name = "chart1";
            series7.Name = "Series1";
            dataPoint9.AxisLabel = "Original Data";
            dataPoint9.IsValueShownAsLabel = true;
            dataPoint9.Label = "";
            dataPoint10.AxisLabel = "";
            dataPoint10.Label = "5";
            series7.Points.Add(dataPoint9);
            series7.Points.Add(dataPoint10);
            series8.IsValueShownAsLabel = true;
            series8.LabelAngle = 90;
            series8.Name = "Series3";
            series9.Name = "Series4";
            dataPoint11.AxisLabel = "Coded";
            dataPoint11.Label = "10";
            dataPoint12.AxisLabel = "Encoded Data";
            dataPoint12.Label = "Compressed";
            series9.Points.Add(dataPoint11);
            series9.Points.Add(dataPoint12);
            this.chart1.Series.Add(series7);
            this.chart1.Series.Add(series8);
            this.chart1.Series.Add(series9);
            this.chart1.Size = new System.Drawing.Size(517, 411);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            title3.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            title3.Name = "Title1";
            title3.Text = "Diagram to show file before and after coding and compression";
            this.chart1.Titles.Add(title3);
            // 
            // btnGetFile
            // 
            this.btnGetFile.Location = new System.Drawing.Point(376, 648);
            this.btnGetFile.Name = "btnGetFile";
            this.btnGetFile.Size = new System.Drawing.Size(166, 44);
            this.btnGetFile.TabIndex = 2;
            this.btnGetFile.Text = "Get Data";
            this.btnGetFile.UseVisualStyleBackColor = true;
            this.btnGetFile.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // txtServerAddress
            // 
            this.txtServerAddress.Location = new System.Drawing.Point(329, 494);
            this.txtServerAddress.Name = "txtServerAddress";
            this.txtServerAddress.Size = new System.Drawing.Size(442, 20);
            this.txtServerAddress.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(210, 494);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Server Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 535);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Text File Location";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(329, 535);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(442, 20);
            this.txtFileName.TabIndex = 6;
            this.toolTip1.SetToolTip(this.txtFileName, "Enter text file name like mydata.txt");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdTransferTime);
            this.groupBox2.Controls.Add(this.rdTotalTime);
            this.groupBox2.Location = new System.Drawing.Point(25, 494);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(130, 77);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Timing";
            // 
            // rdTransferTime
            // 
            this.rdTransferTime.AutoSize = true;
            this.rdTransferTime.Location = new System.Drawing.Point(6, 48);
            this.rdTransferTime.Name = "rdTransferTime";
            this.rdTransferTime.Size = new System.Drawing.Size(108, 17);
            this.rdTransferTime.TabIndex = 1;
            this.rdTransferTime.Text = "Transfer time only";
            this.rdTransferTime.UseVisualStyleBackColor = true;
            this.rdTransferTime.CheckedChanged += new System.EventHandler(this.rdTransferTime_CheckedChanged);
            // 
            // rdTotalTime
            // 
            this.rdTotalTime.AutoSize = true;
            this.rdTotalTime.Checked = true;
            this.rdTotalTime.Location = new System.Drawing.Point(6, 21);
            this.rdTotalTime.Name = "rdTotalTime";
            this.rdTotalTime.Size = new System.Drawing.Size(71, 17);
            this.rdTotalTime.TabIndex = 0;
            this.rdTotalTime.TabStop = true;
            this.rdTotalTime.Text = "Total time";
            this.rdTotalTime.UseVisualStyleBackColor = true;
            this.rdTotalTime.CheckedChanged += new System.EventHandler(this.rdTotalTime_CheckedChanged);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipTitle = "ToolTip";
            // 
            // ckboxAutoGenerate
            // 
            this.ckboxAutoGenerate.AutoSize = true;
            this.ckboxAutoGenerate.Location = new System.Drawing.Point(213, 599);
            this.ckboxAutoGenerate.Name = "ckboxAutoGenerate";
            this.ckboxAutoGenerate.Size = new System.Drawing.Size(210, 17);
            this.ckboxAutoGenerate.TabIndex = 8;
            this.ckboxAutoGenerate.Text = "Get Auto Generated Data  From Server";
            this.ckboxAutoGenerate.UseVisualStyleBackColor = true;
            this.ckboxAutoGenerate.CheckedChanged += new System.EventHandler(this.ckboxAutoGenerate_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(210, 625);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Data Size";
            // 
            // comBoxDataSize
            // 
            this.comBoxDataSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comBoxDataSize.FormattingEnabled = true;
            this.comBoxDataSize.Items.AddRange(new object[] {
            "MB",
            "GB"});
            this.comBoxDataSize.Location = new System.Drawing.Point(263, 622);
            this.comBoxDataSize.Name = "comBoxDataSize";
            this.comBoxDataSize.Size = new System.Drawing.Size(38, 21);
            this.comBoxDataSize.TabIndex = 12;
            // 
            // lbProgress
            // 
            this.lbProgress.AutoSize = true;
            this.lbProgress.Location = new System.Drawing.Point(579, 81);
            this.lbProgress.Name = "lbProgress";
            this.lbProgress.Size = new System.Drawing.Size(0, 13);
            this.lbProgress.TabIndex = 13;
            // 
            // lbDownloading
            // 
            this.lbDownloading.AutoSize = true;
            this.lbDownloading.Location = new System.Drawing.Point(579, 125);
            this.lbDownloading.Name = "lbDownloading";
            this.lbDownloading.Size = new System.Drawing.Size(0, 13);
            this.lbDownloading.TabIndex = 14;
            // 
            // btnRatio
            // 
            this.btnRatio.Enabled = false;
            this.btnRatio.Location = new System.Drawing.Point(598, 599);
            this.btnRatio.Name = "btnRatio";
            this.btnRatio.Size = new System.Drawing.Size(97, 29);
            this.btnRatio.TabIndex = 15;
            this.btnRatio.Text = "Ratios";
            this.btnRatio.UseVisualStyleBackColor = true;
            this.btnRatio.Click += new System.EventHandler(this.btnRatio_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbTCount);
            this.groupBox3.Controls.Add(this.lbGCount);
            this.groupBox3.Controls.Add(this.lbCCount);
            this.groupBox3.Controls.Add(this.lbACount);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(536, 193);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 200);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Statistic";
            // 
            // lbTCount
            // 
            this.lbTCount.AutoSize = true;
            this.lbTCount.Location = new System.Drawing.Point(33, 143);
            this.lbTCount.Name = "lbTCount";
            this.lbTCount.Size = new System.Drawing.Size(14, 13);
            this.lbTCount.TabIndex = 7;
            this.lbTCount.Text = "T";
            // 
            // lbGCount
            // 
            this.lbGCount.AutoSize = true;
            this.lbGCount.Location = new System.Drawing.Point(33, 106);
            this.lbGCount.Name = "lbGCount";
            this.lbGCount.Size = new System.Drawing.Size(15, 13);
            this.lbGCount.TabIndex = 6;
            this.lbGCount.Text = "G";
            // 
            // lbCCount
            // 
            this.lbCCount.AutoSize = true;
            this.lbCCount.Location = new System.Drawing.Point(33, 72);
            this.lbCCount.Name = "lbCCount";
            this.lbCCount.Size = new System.Drawing.Size(14, 13);
            this.lbCCount.TabIndex = 5;
            this.lbCCount.Text = "C";
            // 
            // lbACount
            // 
            this.lbACount.AutoSize = true;
            this.lbACount.Location = new System.Drawing.Point(33, 36);
            this.lbACount.Name = "lbACount";
            this.lbACount.Size = new System.Drawing.Size(14, 13);
            this.lbACount.TabIndex = 4;
            this.lbACount.Text = "A";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "T :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "G :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "C :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "A :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCompressed);
            this.groupBox1.Controls.Add(this.btnNotCompressed);
            this.groupBox1.Location = new System.Drawing.Point(25, 599);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(130, 81);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Compression";
            // 
            // btnCompressed
            // 
            this.btnCompressed.AutoSize = true;
            this.btnCompressed.Location = new System.Drawing.Point(6, 44);
            this.btnCompressed.Name = "btnCompressed";
            this.btnCompressed.Size = new System.Drawing.Size(83, 17);
            this.btnCompressed.TabIndex = 1;
            this.btnCompressed.Text = "Compressed";
            this.btnCompressed.UseVisualStyleBackColor = true;
            this.btnCompressed.CheckedChanged += new System.EventHandler(this.btnCompressed_CheckedChanged);
            // 
            // btnNotCompressed
            // 
            this.btnNotCompressed.AutoSize = true;
            this.btnNotCompressed.Checked = true;
            this.btnNotCompressed.Location = new System.Drawing.Point(6, 22);
            this.btnNotCompressed.Name = "btnNotCompressed";
            this.btnNotCompressed.Size = new System.Drawing.Size(102, 17);
            this.btnNotCompressed.TabIndex = 0;
            this.btnNotCompressed.TabStop = true;
            this.btnNotCompressed.Text = "Not compressed";
            this.btnNotCompressed.UseVisualStyleBackColor = true;
            this.btnNotCompressed.CheckedChanged += new System.EventHandler(this.btnNotCompressed_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(73, 728);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 87;
            this.label8.Text = "Port:";
            // 
            // txtChatPort
            // 
            this.txtChatPort.Location = new System.Drawing.Point(113, 725);
            this.txtChatPort.Name = "txtChatPort";
            this.txtChatPort.Size = new System.Drawing.Size(62, 20);
            this.txtChatPort.TabIndex = 83;
            this.txtChatPort.Text = "1986";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(476, 725);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '●';
            this.txtPass.Size = new System.Drawing.Size(128, 20);
            this.txtPass.TabIndex = 81;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(405, 728);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 86;
            this.label9.Text = "Password:";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(271, 725);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(128, 20);
            this.txtUser.TabIndex = 80;
            this.txtUser.Text = "New User";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(198, 728);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(67, 13);
            this.lblName.TabIndex = 85;
            this.lblName.Text = "Username:";
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnConnect.Location = new System.Drawing.Point(610, 722);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(73, 23);
            this.btnConnect.TabIndex = 82;
            this.btnConnect.Text = "Login";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabChat);
            this.tabControl.Controls.Add(this.tabStats);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(759, 467);
            this.tabControl.TabIndex = 88;
            // 
            // tabChat
            // 
            this.tabChat.Controls.Add(this.txtLog);
            this.tabChat.Controls.Add(this.txtMessage);
            this.tabChat.Controls.Add(this.btnChatSend);
            this.tabChat.Location = new System.Drawing.Point(4, 22);
            this.tabChat.Name = "tabChat";
            this.tabChat.Padding = new System.Windows.Forms.Padding(3);
            this.tabChat.Size = new System.Drawing.Size(751, 441);
            this.tabChat.TabIndex = 0;
            this.tabChat.Text = "Chat";
            this.tabChat.UseVisualStyleBackColor = true;
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.SystemColors.Window;
            this.txtLog.Enabled = false;
            this.txtLog.Location = new System.Drawing.Point(35, 29);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(666, 351);
            this.txtLog.TabIndex = 91;
            // 
            // txtMessage
            // 
            this.txtMessage.Enabled = false;
            this.txtMessage.Location = new System.Drawing.Point(35, 389);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(585, 20);
            this.txtMessage.TabIndex = 89;
            this.txtMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMessage_KeyPress);
            // 
            // btnChatSend
            // 
            this.btnChatSend.Location = new System.Drawing.Point(626, 386);
            this.btnChatSend.Name = "btnChatSend";
            this.btnChatSend.Size = new System.Drawing.Size(75, 23);
            this.btnChatSend.TabIndex = 90;
            this.btnChatSend.Text = "Send";
            this.btnChatSend.UseVisualStyleBackColor = true;
            this.btnChatSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // tabStats
            // 
            this.tabStats.Controls.Add(this.groupBox3);
            this.tabStats.Controls.Add(this.chart1);
            this.tabStats.Location = new System.Drawing.Point(4, 22);
            this.tabStats.Name = "tabStats";
            this.tabStats.Padding = new System.Windows.Forms.Padding(3);
            this.tabStats.Size = new System.Drawing.Size(751, 441);
            this.tabStats.TabIndex = 1;
            this.tabStats.Text = "Stats";
            this.tabStats.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 757);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtChatPort);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRatio);
            this.Controls.Add(this.lbDownloading);
            this.Controls.Add(this.lbProgress);
            this.Controls.Add(this.comBoxDataSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ckboxAutoGenerate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtServerAddress);
            this.Controls.Add(this.btnGetFile);
            this.Name = "MainForm";
            this.Text = "HTTP Client (Raw)";
            this.Load += new System.EventHandler(this.MainForm_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabChat.ResumeLayout(false);
            this.tabChat.PerformLayout();
            this.tabStats.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btnGetFile;
        private System.Windows.Forms.TextBox txtServerAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdTransferTime;
        private System.Windows.Forms.RadioButton rdTotalTime;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox ckboxAutoGenerate;

        private NumericTextBox txtDataSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comBoxDataSize;
        private System.Windows.Forms.Label lbProgress;
        private System.Windows.Forms.Label lbDownloading;
        private System.Windows.Forms.Button btnRatio;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbTCount;
        private System.Windows.Forms.Label lbGCount;
        private System.Windows.Forms.Label lbCCount;
        private System.Windows.Forms.Label lbACount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton btnCompressed;
        private System.Windows.Forms.RadioButton btnNotCompressed;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtChatPort;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabChat;
        private System.Windows.Forms.TabPage tabStats;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnChatSend;
    }
}

