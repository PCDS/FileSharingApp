namespace FileSharingAppServer
{
    partial class ServerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerForm));
            this.btnListen = new System.Windows.Forms.Button();
            this.txtFilePort = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ipAddress = new System.Windows.Forms.TextBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.lbIp = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtChatPort = new System.Windows.Forms.TextBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.saveConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnListen
            // 
            this.btnListen.BackColor = System.Drawing.Color.White;
            this.btnListen.Location = new System.Drawing.Point(279, 51);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(100, 27);
            this.btnListen.TabIndex = 15;
            this.btnListen.Text = "Start Listening";
            this.btnListen.UseVisualStyleBackColor = false;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // txtFilePort
            // 
            this.txtFilePort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilePort.Location = new System.Drawing.Point(152, 84);
            this.txtFilePort.Name = "txtFilePort";
            this.txtFilePort.Size = new System.Drawing.Size(100, 20);
            this.txtFilePort.TabIndex = 13;
            this.txtFilePort.Text = "2255";
            this.txtFilePort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "File Share Listening Port";
            // 
            // ipAddress
            // 
            this.ipAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ipAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipAddress.Location = new System.Drawing.Point(152, 39);
            this.ipAddress.Name = "ipAddress";
            this.ipAddress.ReadOnly = true;
            this.ipAddress.Size = new System.Drawing.Size(100, 13);
            this.ipAddress.TabIndex = 28;
            this.ipAddress.Text = "0.0.0.0";
            this.ipAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ipAddress.TextChanged += new System.EventHandler(this.ipAddress_TextChanged);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(35, 123);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(344, 180);
            this.txtLog.TabIndex = 27;
            // 
            // lbIp
            // 
            this.lbIp.AutoSize = true;
            this.lbIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIp.Location = new System.Drawing.Point(51, 39);
            this.lbIp.Name = "lbIp";
            this.lbIp.Size = new System.Drawing.Size(95, 13);
            this.lbIp.TabIndex = 26;
            this.lbIp.Text = "Server IP Address:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Chat Listening Port";
            // 
            // txtChatPort
            // 
            this.txtChatPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChatPort.Location = new System.Drawing.Point(152, 58);
            this.txtChatPort.Name = "txtChatPort";
            this.txtChatPort.Size = new System.Drawing.Size(100, 20);
            this.txtChatPort.TabIndex = 29;
            this.txtChatPort.Text = "1986";
            this.txtChatPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip2.Size = new System.Drawing.Size(416, 25);
            this.toolStrip2.TabIndex = 75;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveConfigurationToolStripMenuItem,
            this.loadConfigurationToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(38, 22);
            this.toolStripButton2.Text = "File";
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
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(416, 334);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtChatPort);
            this.Controls.Add(this.ipAddress);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.lbIp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnListen);
            this.Controls.Add(this.txtFilePort);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Sharing App";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.txtFilePort, 0);
            this.Controls.SetChildIndex(this.btnListen, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.lbIp, 0);
            this.Controls.SetChildIndex(this.txtLog, 0);
            this.Controls.SetChildIndex(this.ipAddress, 0);
            this.Controls.SetChildIndex(this.txtChatPort, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.toolStrip2, 0);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.TextBox txtFilePort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ipAddress;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label lbIp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtChatPort;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton2;
        private System.Windows.Forms.ToolStripMenuItem saveConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

