using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FileSharingAppClient
{
    public partial class ClientForm : FileSharingAppClient.Base
    {
        public ClientForm()
        {
            InitializeComponent();
          // Base mybase = new Base();
           ToolStripManager.Merge(toolStrip1, toolStrip2);

        }
    }
}
