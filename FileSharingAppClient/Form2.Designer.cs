namespace FileSharingAppClient
{
    partial class Form2
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
            this.mytest = new System.Windows.Forms.MenuStrip();
            this.asdhkjToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dasdsaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mytest.SuspendLayout();
            this.SuspendLayout();
            // 
            // mytest
            // 
            this.mytest.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asdhkjToolStripMenuItem,
            this.dasdsaToolStripMenuItem});
            this.mytest.Location = new System.Drawing.Point(0, 0);
            this.mytest.Name = "mytest";
            this.mytest.Size = new System.Drawing.Size(547, 24);
            this.mytest.TabIndex = 0;
            this.mytest.Text = "menuStrip1";
            // 
            // asdhkjToolStripMenuItem
            // 
            this.asdhkjToolStripMenuItem.Name = "asdhkjToolStripMenuItem";
            this.asdhkjToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.asdhkjToolStripMenuItem.Text = "asdhkj";
            // 
            // dasdsaToolStripMenuItem
            // 
            this.dasdsaToolStripMenuItem.Name = "dasdsaToolStripMenuItem";
            this.dasdsaToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.dasdsaToolStripMenuItem.Text = "dasdsa";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 49);
            this.Controls.Add(this.mytest);
            this.MainMenuStrip = this.mytest;
            this.Name = "Form2";
            this.Text = "Form2";
            this.mytest.ResumeLayout(false);
            this.mytest.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mytest;
        private System.Windows.Forms.ToolStripMenuItem asdhkjToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dasdsaToolStripMenuItem;
    }
}