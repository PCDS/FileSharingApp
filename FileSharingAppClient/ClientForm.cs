using FileSharingApp;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using MyProgFileSharingAppClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSharingAppClient
{
    public partial class ClientForm : Base
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
            // On application exit, don't forget to disconnect first
            Application.ApplicationExit += new EventHandler(OnApplicationExit);
            InitializeComponent();
            ToolStripManager.Merge(toolStrip1, toolStrip2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            configLoad("Client.ini");
            updateCheck();
        }

        public void OnApplicationExit(object sender, EventArgs e)
        {
            if (Connected == true)
            {
                // Closes the connections, streams, etc.
                Connected = false;
                swSender.Close();
                srReceiver.Close();
                tcpServer.Close();
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            if (Connected == true)
            {
                // Closes the connections, streams, etc.
                Connected = false;
                swSender.Close();
                srReceiver.Close();
                tcpServer.Close();
            }
            Application.Exit();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            var myIni = new IniFile("Client.ini");
            myIni.Write("Username", txtUser.Text);
            myIni.Write("Host", txtHost.Text);
           // myIni.Write("Chatport", txtChatport.Text);
            myIni.Write("FilePort", txtFilePort.Text);
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
               // txtChatport.Text = myIni.Read("Chatport");
            }

            if (!myIni.KeyExists("FilePort"))
            {
                myIni.Write("FilePort", "2225");
            }
            else
            {
              //  txtFilePort.Text = myIni.Read("FilePort");
            }

        }




        /*---------------------------------------CHAT APP--------------------------------------------*/
        private void btnConnect_Click(object sender, EventArgs e)
        {
            // If we are not currently connected but awaiting to connect
            if (Connected == false)
            {
                // Initialize the connection
                InitializeConnection();
                btnSend.Enabled = true;
            }
            else // We are connected, thus disconnect
            {
                CloseConnection("Disconnected at user's request.");
                btnSend.Enabled = false;
            }

        }
        private void InitializeConnection()
        {
            // Parse the IP address from the TextBox into an IPAddress object
            ipAddr = IPAddress.Parse(txtHost.Text);
            // Start a new TCP connections to the chat server
            tcpServer = new TcpClient();
            tcpServer.Connect(ipAddr, 1986);

            // Helps us track whether we're connected or not
            Connected = true;
            // Prepare the form
            UserName = txtUser.Text;

            // Disable and enable the appropriate fields
            txtHost.Enabled = false;
            txtUser.Enabled = false;
            txtMessage.Enabled = true;
            btnSend.Enabled = true;
            btnConnect.Text = "Disconnect";

            // Send the desired username to the server
            swSender = new StreamWriter(tcpServer.GetStream());
            swSender.WriteLine(txtUser.Text);
            swSender.Flush();

            // Start the thread for receiving messages and further communication
            thrMessaging = new Thread(new ThreadStart(ReceiveMessages));
            thrMessaging.Start();
        }
        private void ReceiveMessages()
        {
            // Receive the response from the server
            srReceiver = new StreamReader(tcpServer.GetStream());
            // If the first character of the response is 1, connection was successful
            string ConResponse = srReceiver.ReadLine();
            // If the first character is a 1, connection was successful
            if (ConResponse[0] == '1')
            {
                // Update the form to tell it we are now connected
                this.Invoke(new UpdateLogCallback(this.UpdateLog), new object[] { "Connected Successfully!" });
            }
            else // If the first character is not a 1 (probably a 0), the connection was unsuccessful
            {
                string Reason = "Not Connected: ";
                // Extract the reason out of the response message. The reason starts at the 3rd character
                Reason += ConResponse.Substring(2, ConResponse.Length - 2);
                // Update the form with the reason why we couldn't connect
                this.Invoke(new CloseConnectionCallback(this.CloseConnection), new object[] { Reason });
                // Exit the method
                return;
            }
            // While we are successfully connected, read incoming lines from the server
            while (Connected)
            {
                // Show the messages in the log TextBox
                this.Invoke(new UpdateLogCallback(this.UpdateLog), new object[] { srReceiver.ReadLine() });
            }
        }

        // This method is called from a different thread in order to update the log TextBox
        private void UpdateLog(string strMessage)
        {
            // Append text also scrolls the TextBox to the bottom each time
            txtLog.AppendText(strMessage + "\r\n");
        }

        // Closes a current connection
        private void CloseConnection(string Reason)
        {
            // Show the reason why the connection is ending
            txtLog.AppendText(Reason + "\r\n");
            // Enable and disable the appropriate controls on the form
            txtHost.Enabled = true;
            txtUser.Enabled = true;
            txtMessage.Enabled = false;
            btnSend.Enabled = false;
            btnConnect.Text = "Connect";

            // Close the objects
            Connected = false;
            swSender.Close();
            srReceiver.Close();
            tcpServer.Close();
        }

        // Sends the message typed in to the server
        private void SendMessage()
        {
            if (txtMessage.Lines.Length >= 1)
            {
                swSender.WriteLine(txtMessage.Text);
                swSender.Flush();
                txtMessage.Lines = null;
            }
            txtMessage.Text = "";
        }

        // We want to send the message when the Send button is clicked
        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        // But we also want to send the message once Enter is pressed
        private void txtMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            // If the key is Enter
            if (e.KeyChar == (char)13)
            {
                SendMessage();
            }
        }




        /*---------------------------------------FILE SHARING APP--------------------------------------------*/


        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "File Sharing Client";
            dlg.ShowDialog();
            txtFile.Text = dlg.FileName;
            fileName = dlg.FileName;
            shortFileName = dlg.SafeFileName;
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            if (txtHost.Text != "0.0.0.0")
            {
                string ipAddress = txtHost.Text;
                int port = int.Parse(txtFilePort.Text);
                string fileName = txtFile.Text;
                Task.Factory.StartNew(() => SendFile(ipAddress, port, fileName, shortFileName));
                MessageBox.Show("File Sent");
            }
            else
            {
                MessageBox.Show("Please Connect With A Valid IP Address");
            }
        }

        public void SendFile(string remoteHostIP, int remoteHostPort, string longFileName, string shortFileName)
        {
            try
            {
                if (!string.IsNullOrEmpty(remoteHostIP))
                {
                    byte[] fileNameByte = Encoding.ASCII.GetBytes(shortFileName);
                    byte[] fileData = File.ReadAllBytes(longFileName);
                    byte[] clientData = new byte[4 + fileNameByte.Length + fileData.Length];
                    byte[] fileNameLen = BitConverter.GetBytes(fileNameByte.Length);
                    fileNameLen.CopyTo(clientData, 0);
                    fileNameByte.CopyTo(clientData, 4);
                    fileData.CopyTo(clientData, 4 + fileNameByte.Length);
                    TcpClient clientSocket = new TcpClient(remoteHostIP, remoteHostPort);
                    NetworkStream networkStream = clientSocket.GetStream();
                    networkStream.Write(clientData, 0, clientData.GetLength(0));
                    networkStream.Close();
                }
            }
            catch
            {
                MessageBox.Show("unable to send");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

    }
}