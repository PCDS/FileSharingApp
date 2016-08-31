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
            this.groupBox1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabChat.SuspendLayout();
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(48, 488);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 87;
            this.label8.Text = "Port:";
            // 
            // txtChatPort
            // 
            this.txtChatPort.Location = new System.Drawing.Point(88, 485);
            this.txtChatPort.Name = "txtChatPort";
            this.txtChatPort.Size = new System.Drawing.Size(62, 20);
            this.txtChatPort.TabIndex = 83;
            this.txtChatPort.Text = "1986";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(451, 485);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '●';
            this.txtPass.Size = new System.Drawing.Size(128, 20);
            this.txtPass.TabIndex = 81;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(380, 488);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 86;
            this.label9.Text = "Password:";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(246, 485);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(128, 20);
            this.txtUser.TabIndex = 80;
            this.txtUser.Text = "New User";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(173, 488);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(67, 13);
            this.lblName.TabIndex = 85;
            this.lblName.Text = "Username:";
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.GreenYellow;
            this.btnConnect.Location = new System.Drawing.Point(585, 483);
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
            this.tabControl.Location = new System.Drawing.Point(12, 10);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(671, 467);
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
            this.tabChat.Size = new System.Drawing.Size(663, 441);
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
            this.txtLog.Size = new System.Drawing.Size(607, 351);
            this.txtLog.TabIndex = 91;
            // 
            // txtMessage
            // 
            this.txtMessage.Enabled = false;
            this.txtMessage.Location = new System.Drawing.Point(35, 389);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(526, 20);
            this.txtMessage.TabIndex = 89;
            this.txtMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMessage_KeyPress);
            // 
            // btnChatSend
            // 
            this.btnChatSend.Location = new System.Drawing.Point(567, 389);
            this.btnChatSend.Name = "btnChatSend";
            this.btnChatSend.Size = new System.Drawing.Size(75, 23);
            this.btnChatSend.TabIndex = 90;
            this.btnChatSend.Text = "Send";
            this.btnChatSend.UseVisualStyleBackColor = true;
            this.btnChatSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(713, 713);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtChatPort);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnConnect);
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
            this.tabControl.ResumeLayout(false);
            this.tabChat.ResumeLayout(false);
            this.tabChat.PerformLayout();
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
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtChatPort;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabChat;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnChatSend;
    }
}

