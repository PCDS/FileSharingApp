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
            this.btnGetFile = new System.Windows.Forms.Button();
            this.txtServerAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lbProgress = new System.Windows.Forms.Label();
            this.lbDownloading = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCompressed = new System.Windows.Forms.RadioButton();
            this.btnNotCompressed = new System.Windows.Forms.RadioButton();
            this.lstUsers = new System.Windows.Forms.ListBox();
            this.btnChatSend = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNick = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtChannel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.LabelPort = new System.Windows.Forms.Label();
            this.LabelServer = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGetFile
            // 
            this.btnGetFile.Enabled = false;
            this.btnGetFile.Location = new System.Drawing.Point(451, 644);
            this.btnGetFile.Name = "btnGetFile";
            this.btnGetFile.Size = new System.Drawing.Size(166, 44);
            this.btnGetFile.TabIndex = 2;
            this.btnGetFile.Text = "Get Data";
            this.btnGetFile.UseVisualStyleBackColor = true;
            this.btnGetFile.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // txtServerAddress
            // 
            this.txtServerAddress.Location = new System.Drawing.Point(336, 534);
            this.txtServerAddress.Name = "txtServerAddress";
            this.txtServerAddress.Size = new System.Drawing.Size(281, 20);
            this.txtServerAddress.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(228, 534);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Server Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 575);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Text File Location";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(336, 572);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(281, 20);
            this.txtFileName.TabIndex = 6;
            this.toolTip1.SetToolTip(this.txtFileName, "Enter text file name like mydata.txt");
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipTitle = "ToolTip";
            // 
            // lbProgress
            // 
            this.lbProgress.AutoSize = true;
            this.lbProgress.Location = new System.Drawing.Point(72, 631);
            this.lbProgress.Name = "lbProgress";
            this.lbProgress.Size = new System.Drawing.Size(0, 13);
            this.lbProgress.TabIndex = 13;
            // 
            // lbDownloading
            // 
            this.lbDownloading.AutoSize = true;
            this.lbDownloading.Location = new System.Drawing.Point(72, 675);
            this.lbDownloading.Name = "lbDownloading";
            this.lbDownloading.Size = new System.Drawing.Size(0, 13);
            this.lbDownloading.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCompressed);
            this.groupBox1.Controls.Add(this.btnNotCompressed);
            this.groupBox1.Location = new System.Drawing.Point(51, 524);
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
            // lstUsers
            // 
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.IntegralHeight = false;
            this.lstUsers.Location = new System.Drawing.Point(463, 77);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(119, 288);
            this.lstUsers.Sorted = true;
            this.lstUsers.TabIndex = 91;
            // 
            // btnChatSend
            // 
            this.btnChatSend.Enabled = false;
            this.btnChatSend.Location = new System.Drawing.Point(382, 369);
            this.btnChatSend.Name = "btnChatSend";
            this.btnChatSend.Size = new System.Drawing.Size(75, 23);
            this.btnChatSend.TabIndex = 90;
            this.btnChatSend.Text = "Send";
            this.btnChatSend.UseVisualStyleBackColor = true;
            this.btnChatSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtSend
            // 
            this.txtSend.Enabled = false;
            this.txtSend.Location = new System.Drawing.Point(121, 371);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(255, 20);
            this.txtSend.TabIndex = 89;
            // 
            // rtbOutput
            // 
            this.rtbOutput.Location = new System.Drawing.Point(121, 77);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.ReadOnly = true;
            this.rtbOutput.Size = new System.Drawing.Size(336, 288);
            this.rtbOutput.TabIndex = 88;
            this.rtbOutput.Text = "";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(356, 439);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(100, 20);
            this.txtPass.TabIndex = 102;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(296, 442);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 101;
            this.label3.Text = "Password:";
            // 
            // txtNick
            // 
            this.txtNick.Location = new System.Drawing.Point(167, 439);
            this.txtNick.Name = "txtNick";
            this.txtNick.Size = new System.Drawing.Size(100, 20);
            this.txtNick.TabIndex = 100;
            this.txtNick.Text = "Guest";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(129, 442);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 99;
            this.label4.Text = "Nick:";
            // 
            // txtChannel
            // 
            this.txtChannel.Location = new System.Drawing.Point(410, 465);
            this.txtChannel.Name = "txtChannel";
            this.txtChannel.Size = new System.Drawing.Size(93, 20);
            this.txtChannel.TabIndex = 98;
            this.txtChannel.Text = "#chat";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(355, 468);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 97;
            this.label5.Text = "Channel:";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(509, 463);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(72, 23);
            this.btnConnect.TabIndex = 96;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // LabelPort
            // 
            this.LabelPort.AutoSize = true;
            this.LabelPort.Location = new System.Drawing.Point(273, 468);
            this.LabelPort.Name = "LabelPort";
            this.LabelPort.Size = new System.Drawing.Size(29, 13);
            this.LabelPort.TabIndex = 95;
            this.LabelPort.Text = "Port:";
            // 
            // LabelServer
            // 
            this.LabelServer.AutoSize = true;
            this.LabelServer.Location = new System.Drawing.Point(120, 467);
            this.LabelServer.Name = "LabelServer";
            this.LabelServer.Size = new System.Drawing.Size(41, 13);
            this.LabelServer.TabIndex = 94;
            this.LabelServer.Text = "Server:";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(308, 465);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(44, 20);
            this.txtPort.TabIndex = 93;
            this.txtPort.Text = "6667";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(167, 465);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(100, 20);
            this.txtServer.TabIndex = 92;
            this.txtServer.Text = "localhost";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(713, 713);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNick);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtChannel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.LabelPort);
            this.Controls.Add(this.LabelServer);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.lstUsers);
            this.Controls.Add(this.btnChatSend);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.rtbOutput);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbDownloading);
            this.Controls.Add(this.lbProgress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtServerAddress);
            this.Controls.Add(this.btnGetFile);
            this.Name = "MainForm";
            this.Text = "HTTP Client (Raw)";
            this.Load += new System.EventHandler(this.MainForm_Load_1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGetFile;
        private System.Windows.Forms.TextBox txtServerAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.ToolTip toolTip1;

        private NumericTextBox txtDataSize;
        private System.Windows.Forms.Label lbProgress;
        private System.Windows.Forms.Label lbDownloading;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton btnCompressed;
        private System.Windows.Forms.RadioButton btnNotCompressed;
        private System.Windows.Forms.ListBox lstUsers;
        private System.Windows.Forms.Button btnChatSend;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNick;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtChannel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label LabelPort;
        private System.Windows.Forms.Label LabelServer;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtServer;
    }
}

