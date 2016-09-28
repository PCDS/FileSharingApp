using System;
using System.Windows.Forms;
using FileSharingApp;
namespace ServerClient
{
    public partial class AppSettingsForm : Form
    {
        public AppSettingsForm()
        {
            InitializeComponent();
            //txtFilePort.Text = AppSettings.Port.ToString();
            var myIni = new IniFile("Server.ini");
            txtChatPort.Text = myIni.Read("ChatPort");
            txtFilePort.Text = myIni.Read("FilePort");

        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtFilePort.IntValue > 0 && txtFilePort.IntValue < ushort.MaxValue && txtChatPort.IntValue > 0 && txtChatPort.IntValue < ushort.MaxValue )
            {
                var myIni = new IniFile("Server.ini");
                myIni.Write("Chatport", txtChatPort.Text);
                myIni.Write("FilePort", txtFilePort.Text);
                MessageBox.Show("Configuration Saved");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;

            }
            else if (txtFilePort.IntValue > ushort.MaxValue)
            {
                MessageBox.Show("Ports can not be greater than " + ushort.MaxValue);
                return;
            }
            else
            {
                MessageBox.Show("Ports can not be less than or equal to zero");

            }
             
            
        }

    }
}
