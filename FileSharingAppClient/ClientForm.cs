using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using MyProgFileSharingAppClient;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FileSharingApp
{
    public partial class ClientForm : FileSharingApp.Base
    {

        private static string shortFileName = "";
        private static string fileName = "";
        // Will hold the user name
        private string UserName = "Unknown";
        private StreamWriter swSender;
        private StreamReader srReceiver;
        private TcpClient tcpServer;
        // Needed to update the form with messages from another thread
        private delegate void UpdateLogCallback(string strMessage);
        // Needed to set the form to a "disconnected" state from another thread
        private delegate void CloseConnectionCallback(string strReason);
        private Thread thrMessaging;
        private IPAddress ipAddr;
        private bool Connected;

        public ClientForm()
        {
            InitializeComponent();
           ToolStripManager.Merge(toolStrip1, toolStrip2);

        }


        private void ClientForm_Load(object sender, EventArgs e)
        {


            // global::Basemenu test = new global::Basemenu();
            // this.Menu= test.Menu;

            configLoad("Client.ini");
            base.updateCheck();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            var myIni = new IniFile("Client.ini");
            myIni.Write("Username", txtUser.Text);
            myIni.Write("Host", txtHost.Text);
            myIni.Write("Chatport", txtChatport.Text);
            myIni.Write("Fileport", txtFileport.Text);
            MessageBox.Show("Configuration Saved");

        }
        private void Load_Click(object sender, EventArgs e)
        {

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Load Configuration";
            dlg.ShowDialog();
            fileName = dlg.FileName;
            shortFileName = dlg.SafeFileName;
            if (Operators.LikeString(fileName, "*.ini", CompareMethod.Text))
            {
                configLoad(fileName);
            }
            else
            {
                MessageBox.Show("Please select a .ini file");
            }

        }
        public void configLoad(string iniFile)
        {
            var myIni = new IniFile(iniFile);
            if (!myIni.KeyExists("Username"))
            {
                myIni.Write("Username", "New User");
            }
            else
            {
                txtUser.Text = myIni.Read("Username");
            }
            if (!myIni.KeyExists("Host"))
            {
                myIni.Write("Host", "");
            }
            else
            {
                txtHost.Text = myIni.Read("Host");
            }

            if (!myIni.KeyExists("Chatport"))
            {
                myIni.Write("Chatport", "1986");
            }
            else
            {
                txtChatport.Text = myIni.Read("Chatport");
            }

            if (!myIni.KeyExists("Fileport"))
            {
                myIni.Write("Fileport", "2225");
            }
            else
            {
                txtFileport.Text = myIni.Read("Fileport");
            }

        }


    }
}
