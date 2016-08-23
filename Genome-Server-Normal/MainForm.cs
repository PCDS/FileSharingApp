using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using ServerClient;
using FileSharingAppServer;
using FileSharingApp;
using System.Net.Sockets;

namespace httpMethodsApp
{
    public enum encodingType { Origin, TwoBitEncoding, HuffmanWithSampling, HuffmanWithoutSampling, Huffman };
    public partial class MainForm : Base
    {
        private string filesDirectory = "";
        private HttpServerController httpServerController;
        private bool useStandardHeaders = true;
        public delegate void FileRecievedEventHandler(object source, string fileName);
        private delegate void UpdateStatusCallback(string strMessage);
        DatabaseCon UserDB = new DatabaseCon();


        public MainForm()
        {
            UserDB.CreateDB();
            string path = AppDomain.CurrentDomain.BaseDirectory + @"ReceivedFiles";
            MessageBox.Show(path);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            InitializeComponent();
            
        }


        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();


            if (folderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.filesDirectory = folderBrowser.SelectedPath;
                if (httpServerController != null)
                {
                    httpServerController._httpServer.includingPath = this.filesDirectory;
                }

            }
        }

      
        private void MainForm_Load(object sender, EventArgs e)
        {
            setUPServer();

        }

        /*---------------------------------------CHAT APP--------------------------------------------*/






        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;
            Process.GetCurrentProcess().Kill();

        }


        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Process.GetCurrentProcess().Kill();

        }

        private void Create_Click(object sender, EventArgs e)
        {
            Form CreateUser = new Form();
            CreateUser.StartPosition = FormStartPosition.CenterScreen;
            CreateUser.FormBorderStyle = FormBorderStyle.FixedDialog;
            CreateUser.Width = 400;
            CreateUser.Height = 200;
            CreateUser.Text = "Create User";
            Label userLabel = new Label() { Left = 50, Top = 15, Text = "Username:" };
            Label passLabel = new Label() { Left = 50, Top = 70, Text = "Password:" };

            TextBox username = new TextBox { Left = 50, Top = 40, Width = 300 };
            TextBox password = new TextBox { Left = 50, Top = 95, Width = 300 };
            Button confirmation = new Button() { Text = "Ok", Left = 250, Width = 100, Top = 130 };
            confirmation.Click += (sender2, d) => {
                UserDB.CreateUser(username.Text, password.Text);
                CreateUser.Close();
            };
            CreateUser.Controls.Add(username);
            CreateUser.Controls.Add(password);
            CreateUser.Controls.Add(confirmation);
            CreateUser.Controls.Add(userLabel);
            CreateUser.Controls.Add(passLabel);
            CreateUser.ShowDialog();

        }


        private void Delete_Click(object sender, EventArgs e)
        {
            Form CreateUser = new Form();
            CreateUser.StartPosition = FormStartPosition.CenterScreen;
            CreateUser.FormBorderStyle = FormBorderStyle.FixedDialog;
            CreateUser.Width = 400;
            CreateUser.Height = 150;
            CreateUser.Text = "Delete User";
            Label userLabel = new Label() { Left = 50, Top = 15, Text = "Username:" };

            TextBox username = new TextBox { Left = 50, Top = 40, Width = 300 };
            Button confirmation = new Button() { Text = "Ok", Left = 250, Width = 100, Top = 70 };
            confirmation.Click += (sender2, d) => {
                UserDB.DeleteUser(username.Text);
                CreateUser.Close();
            };
            CreateUser.Controls.Add(username);
            CreateUser.Controls.Add(confirmation);
            CreateUser.Controls.Add(userLabel);
            CreateUser.ShowDialog();
        }


        private void btnListen_Click()
        {
            //int port = int.Parse(txtFilePort.Text);

            string localIP;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("10.0.2.4", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address.ToString();
            }
            ipAddress.Text = localIP;
            // Parse the server's IP address out of the TextBox
            IPAddress ipAddr = IPAddress.Parse(localIP);
            // Create a new instance of the ChatServer object

            Debug.WriteLine(localIP);

            FileSharingAppServer.ChatServer mainServer = new FileSharingAppServer.ChatServer(ipAddr);
            // Hook the StatusChanged event handler to mainServer_StatusChanged
            global::FileSharingAppServer.ChatServer.StatusChanged += new StatusChangedEventHandler(mainServer_StatusChanged);
            // Start listening for connections
            mainServer.StartListening(txtChatPort.Text);
            // Show that we started to listen for connections
            txtLog.AppendText("Monitoring for connections...\r\n");

        }

        public void mainServer_StatusChanged(object sender, StatusChangedEventArgs e)
        {
            // Call the method that updates the form
            this.Invoke(new UpdateStatusCallback(this.UpdateStatus), new object[] { e.EventMessage });
        }

        private void UpdateStatus(string strMessage)
        {
            // Updates the log with the message
            txtLog.AppendText(strMessage + "\r\n");
        }




        /*---------------------------------------GTTP CODE--------------------------------------------*/

        private void setUPServer()
        {
            
            httpServerController = new HttpServerController(AppSettings.Port);
            httpServerController._httpServer.useStandardHeaders = this.useStandardHeaders;

            if (filesDirectory != "")
            {
                httpServerController._httpServer.includingPath = Path.GetDirectoryName(filesDirectory);
            }
        }
        private void btnStartServer_Click(object sender, EventArgs e)
        {

            if (btnStartServer.Text == "Start Server")
            {

                if (filesDirectory != "")
                {
                    httpServerController._httpServer.includingPath = filesDirectory;
                }
                httpServerController._httpServer.startedListeningCallback = new StartedListening(ServerhasStarted);

                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                httpServerController.start();
                btnListen_Click();

            }
            else
            {
                httpServerController.stop();
                btnStartServer.Text = "Start Server";

                MessageBox.Show("The Server has stopped");


            }



        }
        private void ServerhasStarted(bool started, String errorMessage)
        {
            if (InvokeRequired)
            {


                this.Invoke((MethodInvoker)delegate()
                {
                    this.Cursor = System.Windows.Forms.Cursors.Default;

                    if (started)
                    {
                        btnStartServer.Text = "Stop Server";

                        MessageBox.Show("The Server has started");
                    }
                    else
                    {
                        MessageBox.Show(errorMessage);
                    }

                });
            }
        }
        
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (httpServerController != null)
            {
                httpServerController.stop();
            }
        }


        private void rdStandardHeaders_CheckedChanged(object sender, EventArgs e)
        {
            if( rdStandardHeaders.Checked ) useStandardHeaders = true;
        }

        private void rdModifiedHeaders_CheckedChanged(object sender, EventArgs e)
        {
            if (rdModifiedHeaders.Checked) useStandardHeaders = false;
        }


        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppSettingsForm appSettingForm = new AppSettingsForm();
            if (appSettingForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                httpServerController._httpServer.PortNumber = AppSettings.Port;
            }
        }
    }
}




