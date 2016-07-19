using FileSharingApp;
using System;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileSharingAppServer;


namespace FileSharingAppServer
{
    public partial class ServerForm : Base
    {

        public delegate void FileRecievedEventHandler(object source, string fileName);
        private delegate void UpdateStatusCallback(string strMessage);

        public event FileRecievedEventHandler NewFileRecieved;
        DatabaseCon UserDB = new DatabaseCon();

        public ServerForm()
        {
            UserDB.CreateDB();
            string path = AppDomain.CurrentDomain.BaseDirectory+@"ReceivedFiles";
            MessageBox.Show(path);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            InitializeComponent();
            ToolStripManager.Merge(toolStrip1, toolStrip2);
        }




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
            Label passLabel = new Label() { Left = 50, Top = 70, Text = "Password:"};

            TextBox username = new TextBox { Left = 50, Top = 40, Width = 300 };
            TextBox password = new TextBox { Left = 50, Top = 95, Width = 300 };
            Button confirmation = new Button() { Text = "Ok", Left = 250, Width = 100, Top = 130 };
            confirmation.Click += (sender2, d) => {
                UserDB.CreateUser(username.Text, password.Text);
                CreateUser.Close(); };
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

        private void Save_Click(object sender, EventArgs e)
        {
            var myIni = new IniFile("Server.ini");
            // myIni.Write("Chatport", txtChatport.Text);
            myIni.Write("FilePort", txtFilePort.Text);
            MessageBox.Show("Configuration Saved");

        }



        private void Form1_Load(object sender, EventArgs e)
        {
            this.NewFileRecieved += new FileRecievedEventHandler(Form1_NewFileRecieved);
        }

        private void Form1_NewFileRecieved(object sender, string fileName)
        {
            this.BeginInvoke(
            new Action(
            delegate()
            {
                MessageBox.Show("New File Recieved\n" + fileName);
                System.Diagnostics.Process.Start("explorer", AppDomain.CurrentDomain.BaseDirectory + @"ReceivedFiles");
            }));
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            int port = int.Parse(txtFilePort.Text);
            Task.Factory.StartNew(() => HandleIncomingFile(port));

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

            btnListen.Enabled = false;

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

        public void HandleIncomingFile(int port)
        {
            try
            {
                TcpListener tcpListener = new TcpListener(port);
                tcpListener.Start();
                while (true)
                {
                    Socket handlerSocket = tcpListener.AcceptSocket();
                    if (handlerSocket.Connected)
                    {
                        string fileName = string.Empty;
                        NetworkStream networkStream = new NetworkStream(handlerSocket);
                        int thisRead = 0;
                        int blockSize = 1024;
                        Byte[] dataByte = new Byte[blockSize];
                        lock (this)
                        {
                            string folderPath = AppDomain.CurrentDomain.BaseDirectory + @"ReceivedFiles\";
                            handlerSocket.Receive(dataByte);
                            int fileNameLen = BitConverter.ToInt32(dataByte, 0);
                            fileName = Encoding.ASCII.GetString(dataByte, 4, fileNameLen);
                            Stream fileStream = File.OpenWrite(folderPath + fileName);
                            fileStream.Write(dataByte, 4 + fileNameLen, (1024 - (4 + fileNameLen)));
                            while (true)
                            {
                                thisRead = networkStream.Read(dataByte, 0, blockSize);
                                fileStream.Write(dataByte, 0, thisRead);
                                if (thisRead == 0)
                                    break;
                            }
                            fileStream.Close();
                        }
                        if (NewFileRecieved != null)
                        {
                            NewFileRecieved(this, fileName);
                        }
                        handlerSocket = null;
                    }
                }
            }
            catch
            {
            }
        }

    }
}