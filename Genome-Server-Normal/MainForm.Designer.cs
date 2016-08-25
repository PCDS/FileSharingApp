namespace httpMethodsApp
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
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdModifiedHeaders = new System.Windows.Forms.RadioButton();
            this.rdStandardHeaders = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtChatPort = new System.Windows.Forms.TextBox();
            this.ipAddress = new System.Windows.Forms.TextBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.lbIp = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.settingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.showUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(64, 103);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(239, 27);
            this.btnSelectFile.TabIndex = 2;
            this.btnSelectFile.Text = "Select Data File";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // btnStartServer
            // 
            this.btnStartServer.Location = new System.Drawing.Point(64, 136);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(239, 27);
            this.btnStartServer.TabIndex = 4;
            this.btnStartServer.Text = "Start Server";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdModifiedHeaders);
            this.groupBox2.Controls.Add(this.rdStandardHeaders);
            this.groupBox2.Location = new System.Drawing.Point(326, 58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(239, 93);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Response Headers";
            // 
            // rdModifiedHeaders
            // 
            this.rdModifiedHeaders.AutoSize = true;
            this.rdModifiedHeaders.Location = new System.Drawing.Point(6, 66);
            this.rdModifiedHeaders.Name = "rdModifiedHeaders";
            this.rdModifiedHeaders.Size = new System.Drawing.Size(65, 17);
            this.rdModifiedHeaders.TabIndex = 1;
            this.rdModifiedHeaders.Text = "Modified";
            this.rdModifiedHeaders.UseVisualStyleBackColor = true;
            this.rdModifiedHeaders.CheckedChanged += new System.EventHandler(this.rdModifiedHeaders_CheckedChanged);
            // 
            // rdStandardHeaders
            // 
            this.rdStandardHeaders.AutoSize = true;
            this.rdStandardHeaders.Checked = true;
            this.rdStandardHeaders.Location = new System.Drawing.Point(6, 31);
            this.rdStandardHeaders.Name = "rdStandardHeaders";
            this.rdStandardHeaders.Size = new System.Drawing.Size(68, 17);
            this.rdStandardHeaders.TabIndex = 0;
            this.rdStandardHeaders.TabStop = true;
            this.rdStandardHeaders.Text = "Standard";
            this.rdStandardHeaders.UseVisualStyleBackColor = true;
            this.rdStandardHeaders.CheckedChanged += new System.EventHandler(this.rdStandardHeaders_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(61, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Chat Listening Port";
            // 
            // txtChatPort
            // 
            this.txtChatPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChatPort.Location = new System.Drawing.Point(162, 67);
            this.txtChatPort.Name = "txtChatPort";
            this.txtChatPort.Size = new System.Drawing.Size(100, 20);
            this.txtChatPort.TabIndex = 35;
            this.txtChatPort.Text = "1986";
            this.txtChatPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ipAddress
            // 
            this.ipAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ipAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipAddress.Location = new System.Drawing.Point(162, 48);
            this.ipAddress.Name = "ipAddress";
            this.ipAddress.ReadOnly = true;
            this.ipAddress.Size = new System.Drawing.Size(100, 13);
            this.ipAddress.TabIndex = 34;
            this.ipAddress.Text = "0.0.0.0";
            this.ipAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(45, 196);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(481, 178);
            this.txtLog.TabIndex = 33;
            // 
            // lbIp
            // 
            this.lbIp.AutoSize = true;
            this.lbIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIp.Location = new System.Drawing.Point(61, 48);
            this.lbIp.Name = "lbIp";
            this.lbIp.Size = new System.Drawing.Size(95, 13);
            this.lbIp.TabIndex = 32;
            this.lbIp.Text = "Server IP Address:";
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripDropDownButton1});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip2.Size = new System.Drawing.Size(565, 25);
            this.toolStrip2.TabIndex = 76;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem1,
            this.saveConfigurationToolStripMenuItem,
            this.loadConfigurationToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(38, 22);
            this.toolStripButton2.Text = "File";
            // 
            // settingsToolStripMenuItem1
            // 
            this.settingsToolStripMenuItem1.Name = "settingsToolStripMenuItem1";
            this.settingsToolStripMenuItem1.Size = new System.Drawing.Size(177, 22);
            this.settingsToolStripMenuItem1.Text = "Settings";
            this.settingsToolStripMenuItem1.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // saveConfigurationToolStripMenuItem
            // 
            this.saveConfigurationToolStripMenuItem.Name = "saveConfigurationToolStripMenuItem";
            this.saveConfigurationToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.saveConfigurationToolStripMenuItem.Text = "Save Configuration";
            // 
            // loadConfigurationToolStripMenuItem
            // 
            this.loadConfigurationToolStripMenuItem.Name = "loadConfigurationToolStripMenuItem";
            this.loadConfigurationToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.loadConfigurationToolStripMenuItem.Text = "Load Configuration";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.Exit_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showUsersToolStripMenuItem,
            this.createUserToolStripMenuItem,
            this.deleteUserToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(48, 22);
            this.toolStripDropDownButton1.Text = "Tools";
            // 
            // showUsersToolStripMenuItem
            // 
            this.showUsersToolStripMenuItem.Name = "showUsersToolStripMenuItem";
            this.showUsersToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.showUsersToolStripMenuItem.Text = "Show Users";
            this.showUsersToolStripMenuItem.Click += new System.EventHandler(this.Show_Click);
            // 
            // createUserToolStripMenuItem
            // 
            this.createUserToolStripMenuItem.Name = "createUserToolStripMenuItem";
            this.createUserToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.createUserToolStripMenuItem.Text = "Create User";
            this.createUserToolStripMenuItem.Click += new System.EventHandler(this.Create_Click);
            // 
            // deleteUserToolStripMenuItem
            // 
            this.deleteUserToolStripMenuItem.Name = "deleteUserToolStripMenuItem";
            this.deleteUserToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteUserToolStripMenuItem.Text = "Delete User";
            this.deleteUserToolStripMenuItem.Click += new System.EventHandler(this.Delete_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 414);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtChatPort);
            this.Controls.Add(this.ipAddress);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.lbIp);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnStartServer);
            this.Controls.Add(this.btnSelectFile);
            this.Name = "MainForm";
            this.Text = "Genome Server Normal";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Controls.SetChildIndex(this.btnSelectFile, 0);
            this.Controls.SetChildIndex(this.btnStartServer, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.lbIp, 0);
            this.Controls.SetChildIndex(this.txtLog, 0);
            this.Controls.SetChildIndex(this.ipAddress, 0);
            this.Controls.SetChildIndex(this.txtChatPort, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.toolStrip2, 0);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdModifiedHeaders;
        private System.Windows.Forms.RadioButton rdStandardHeaders;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtChatPort;
        private System.Windows.Forms.TextBox ipAddress;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label lbIp;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton2;
        private System.Windows.Forms.ToolStripMenuItem saveConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem createUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem showUsersToolStripMenuItem;
    }
}

