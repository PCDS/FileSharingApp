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
using System.Net.Sockets;
using httpMethodsApp;
using System.Threading;

namespace ClientRaw
{
    public enum Timing { totalTime, transferTimeOnly }


    public partial class MainForm : Form
    {
        private const string RawFormatOutputFileName = "Raw";

        private string RawFormatFileName = "";
        private string fileNameToDownload = "";
        private string serverAddress = "http://localhost:5556/01.txt";
        private int port = 5556;
        private Timing timingType = Timing.totalTime;
        private long fileDownloadingTime = 0;
        Stopwatch stopwatch;
        private long autoDataSize = 1024 * 1024;
        private double[] autoDataElementsRatios;
        private RatioTypeEnum ratioType = RatioTypeEnum.Automatic;
        public string decodedFileName { get; set; }
        private bool compressData = false;
        ExtendedWebClient webClient;

        // Added for Chat Server
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



        private Color[] chartColors = new Color[] { Color.FromArgb(0, 60, 130), Color.FromArgb(135, 0, 0), Color.FromArgb(0, 128, 0) };

        public MainForm()
        {
            Application.ApplicationExit += new EventHandler(Exit_Click);
            InitializeComponent();
            this.webClient = new ExtendedWebClient();
            webClient.timeout = 1000 * 60 * 1; // wait for ten minutes
            webClient.CachePolicy = null;
            webClient.DownloadProgressChanged += webClient_DownloadFileProgress;
            webClient.DownloadFileCompleted += webClient_DownloadFileComplete;
            txtServerAddress.Text = "localhost";
            this.txtDataSize = new NumericTextBox();
            this.txtDataSize.AllowSpace = false;
            this.txtDataSize.Location = new Point(323, 569);
            this.txtDataSize.Name = "txtDataSize";
            this.txtDataSize.Size = new System.Drawing.Size(161, 20);
            this.txtDataSize.TabIndex = 5;
            this.Controls.Add(txtDataSize);
            this.txtDataSize.Enabled = false;
            this.comBoxDataSize.SelectedIndex = 0;
            this.comBoxDataSize.Enabled = false;
            autoDataElementsRatios = FormatData.randomRatios(FormatData.specialChars.Length);
        }

        /*---------------------------------------CHAT APP--------------------------------------------*/
        private void Exit_Click(object sender, EventArgs e)
        {
            Disconnect();
            Application.Exit();
        }


        private void Disconnect()
        {
            if (Connected == true)
            {
                // Closes the connections, streams, etc.
                Connected = false;
                swSender.Close();
                srReceiver.Close();
                tcpServer.Close();
                thrMessaging.Abort();
            }
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
                e.Handled = true;
                btnChatSend.PerformClick();

            }
        }



        private void btnConnect_Click(object sender, EventArgs e)
        {
            // If we are not currently connected but awaiting to connect
            if (Connected == false)
            {
                // Initialize the connection
                InitializeConnection();
                btnGetFile.Enabled = true;
            }
            else // We are connected, thus disconnect
            {
                CloseConnection("Disconnected at user's request.");
                btnGetFile.Enabled = false;
            }

        }
        private void InitializeConnection()
        {
            // Parse the IP address from the TextBox into an IPAddress object
            try
            {

                ipAddr = IPAddress.Parse(txtServerAddress.Text);

            }
            catch (FormatException)
            {
                // Attempting to pull the IP address from the DNS name
                IPAddress a = Dns.GetHostAddresses(txtServerAddress.Text)[0];
                IPAddress b = Dns.GetHostAddresses(txtServerAddress.Text)[1];
                if (IPAddress.Parse(a.ToString()).AddressFamily == AddressFamily.InterNetwork)
                    ipAddr = Dns.GetHostAddresses(txtServerAddress.Text)[0];
                if (IPAddress.Parse(b.ToString()).AddressFamily == AddressFamily.InterNetwork)
                    ipAddr = Dns.GetHostAddresses(txtServerAddress.Text)[1];

                // If the IP is localhost then gets the external IP address
                if (ipAddr.ToString() == "127.0.0.1")
                {
                    string localIP = "";
                    using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
                    {
                        socket.Connect("10.0.2.4", 65530);
                        IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                        localIP = endPoint.Address.ToString();
                    }
                    ipAddr = IPAddress.Parse(localIP);
                }
            }
            try
            {
                // Start a new TCP connections to the chat server
                tcpServer = new TcpClient();
                tcpServer.Connect(ipAddr, int.Parse(txtChatPort.Text));

                // Helps us track whether we're connected or not
                Connected = true;
                // Prepare the form
                UserName = txtUser.Text;
                // Disable and enable the appropriate fields
                txtServerAddress.Enabled = false;
                txtUser.Enabled = false;
                txtChatPort.Enabled = false;
                txtLog.Enabled = true;
                txtMessage.Enabled = true;
                btnConnect.Text = "logout";
                txtPass.Enabled = false;
                btnConnect.BackColor = Color.LightSalmon;
                // Send the desired username to the server
                swSender = new StreamWriter(tcpServer.GetStream());
                swSender.WriteLine(txtUser.Text);
                swSender.Flush();

                swSender = new StreamWriter(tcpServer.GetStream());
                swSender.WriteLine(txtPass.Text);
                swSender.Flush();

                // Start the thread for receiving messages and further communication
                thrMessaging = new Thread(new ThreadStart(ReceiveMessages));
                thrMessaging.Start();
            }
            catch (SocketException)
            {
                MessageBox.Show("Port is in use or unavailable");
            }
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
                try
                {
                    if (!srReceiver.EndOfStream && Connected)
                    {
                        ConResponse = srReceiver.ReadLine();
                        // Show the messages in the log TextBox
                        this.Invoke(new UpdateLogCallback(this.UpdateLog), new object[] { ConResponse });
                    }
                }
                catch (System.IO.IOException)
                {
                    this.Invoke(new CloseConnectionCallback(this.CloseConnection), new object[] { "Lost connection to server" });
                    btnGetFile.Enabled = false;
                }
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
            txtServerAddress.Enabled = true;
            txtUser.Enabled = true;
            txtMessage.Enabled = false;
            txtChatPort.Enabled = true;
            txtPass.Enabled = true;
            btnGetFile.Enabled = false;
            btnConnect.Text = "Login";
            btnConnect.BackColor = Color.GreenYellow;
            Disconnect();

        }



        /*---------------------------------------GTTP CODE--------------------------------------------*/

        private void configChartToDefault()
        {
            chart1.Legends.Clear();
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            var area1 = chart1.ChartAreas.Add("filesize");
            var area2 = chart1.ChartAreas.Add("time");
            area1.AxisY.Title = "File Size (bytes)";
            area2.AxisY.Title = "Time (milliseconds)";

            var legend1 = chart1.Legends.Add("Legend1");
            var legend2 = chart1.Legends.Add("Legend2");
            legend1.DockedToChartArea = "filesize";
            legend1.IsDockedInsideChartArea = false;
            legend2.DockedToChartArea = "time";
            legend2.IsDockedInsideChartArea = false;


            var series1 = chart1.Series.Add("dataSize");
            series1.LegendText = "Received Compressed Data";
            var series2 = chart1.Series.Add("DecompressedDataSize");
            series2.LegendText = "Original data";

            var series3 = chart1.Series.Add("downloadingdataTime");
            series3.ChartArea = "time";
            series3.Legend = "Legend2";

            var series4 = chart1.Series.Add("totaldataTime");
            series4.ChartArea = "time";
            series4.Legend = "Legend2";

            series1.Color = chartColors[1]; // red color
            series2.Color = chartColors[0]; // blue color
            series3.Color = chartColors[2]; // green color

            foreach (var series in chart1.Series)
            {
                series.IsValueShownAsLabel = true;
            }
        }

        private void showRawDataEncodingInfo()
        {
            this.btnGetFile.Text = "Stop";

            configChartToDefault();
            showStatistic(null);

            // download file with gzip compression
            getRawFormatFile();


        }
        private void getRawFormatFile()
        {
            // decoding char to 2bits
            string getFileName = RawFormatFileName;

            chart1.Series["downloadingdataTime"].LegendText = "Time for downloading Raw File";
            chart1.Series["totaldataTime"].LegendText = "Time for downloading , (decompressing) Raw File";


            if (timingType == Timing.transferTimeOnly)
            {
                if (!getFileName.Contains("Auto"))
                    getFileName = "Preconfig" + getFileName;
                chart1.Series["dataTime"].LegendText = "Time for downloading Raw File";


            }

            if (getFileName.Contains("Auto"))
            {
                chart1.Series["downloadingdataTime"].LegendText = "Time for downloading Raw Data";
                chart1.Series["totaldataTime"].LegendText = "Time for downloading and decompressing Raw Data";
            }

            this.stopwatch = Stopwatch.StartNew();
            this.webClient.startDownloadingFile(serverAddress + "/" + getFileName);

        }

        private void btnGetData_Click(object sender, EventArgs e)
        {

            if (btnGetFile.Text == "Stop")
            {
                btnGetFile.Text = "Get Data";
                webClient.stop();
                return;

            }

            if (txtServerAddress.Text == "")
            {
                MessageBox.Show("You should write the server address ");
                return;
            }
            this.serverAddress = "http://" + txtServerAddress.Text + ":" + port.ToString();
            this.autoDataSize = this.txtDataSize.LongValue * 1024;

            // we dont need to ask for a file name , just ask for data auto generated 
            if (ckboxAutoGenerate.Checked)
            {
                if (comBoxDataSize.Text.ToUpper() == "MB")
                {
                    this.autoDataSize = this.txtDataSize.LongValue * 1024 * 1024;

                }
                else if ((comBoxDataSize.Text.ToUpper() == "GB"))
                {
                    this.autoDataSize = this.txtDataSize.LongValue * 1024 * 1024 * 1024;

                }
                RawFormatFileName = "Auto" + RawFormatOutputFileName;
                fileNameToDownload = "Auto.txt";
                formatHeader(autoDataSize);

                showRawDataEncodingInfo();

                return;

            }

            else
            {

                if (txtFileName.Text == "")
                {
                    MessageBox.Show("Please write the textfile name to be downloaded, for example mydata.txt");
                    return;

                }
            }

            string filePath = txtFileName.Text;
            try
            {
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(filePath);
                fileNameToDownload = fileNameWithoutExt + ".txt";
                RawFormatFileName = fileNameWithoutExt + RawFormatOutputFileName + ".txt";
                formatHeader(0);

                showRawDataEncodingInfo();
            }
            catch (Exception ex)
            {
                if (btnGetFile.Text == "Stop")
                {
                    btnGetFile.Text = "Get Data";
                    webClient.stop();
                }
                MessageBox.Show(ex.Message);
            }

        }

        private void webClient_DownloadFileProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            //update data


            lbDownloading.Text = "Total downloaded bytes : " + e.BytesReceived.ToString();

            lbProgress.Text = "Downloading in progress";
            ExtendedWebClient webClient = (ExtendedWebClient)sender;
        }

        private void webClient_DownloadFileComplete(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {

                var message = e.Error.Message;
                chart1.Series.Clear();
                lbDownloading.Text = "";
                lbProgress.Text = "";
                if (e.Cancelled)
                {
                    if (webClient.stoppedByUser)
                        return;
                    message = "The connection with the server has been disconnected";
                }

                MessageBox.Show(message);

                if (btnGetFile.Text == "Stop")
                {
                    btnGetFile.Text = "Get Data";

                }
                return;

            }

            lbProgress.Text = "File has been Downloaded";
            Application.DoEvents();
            stopwatch.Stop();
            this.fileDownloadingTime = stopwatch.ElapsedMilliseconds;
            if ((String)this.webClient.ResponseHeaders["Content-Encoding"] == "gzip")
            {
                RawFormatShowResults(true);

            }
            else
            {
                RawFormatShowResults(false);

            }
            btnGetFile.Text = "Get Data";

        }

        private void RawFormatShowResults(bool compressedData)
        {
            FileInfo fileInfo;
            FileInfo decompressedFileInfo;
            string downloadedFileName = this.webClient.downloadedFileName;
            chart1.Series["downloadingdataTime"].Points.AddY(fileDownloadingTime);

            if (fileNameToDownload == "Auto.txt")
            {
                fileNameToDownload = downloadedFileName.Replace("AutoData", "AutoData" + RawFormatOutputFileName);

                if (downloadedFileName.Contains("compressed.txt"))
                    fileNameToDownload = fileNameToDownload.Replace("compressed", "");

            }
            fileInfo = new FileInfo(downloadedFileName);
            chart1.Series["dataSize"].Points.AddY(fileInfo.Length);
            string decompressedFile = downloadedFileName;

            if (timingType == Timing.totalTime)
            {
                stopwatch = Stopwatch.StartNew();

                if (compressedData)
                {

                    decompressedFile = downloadedFileName.Replace("compressed.txt", "Raw.txt");
                    FormatData.uncompressAndSaveData(downloadedFileName, decompressedFile);
                    stopwatch.Stop();
                    fileDownloadingTime += stopwatch.ElapsedMilliseconds;

                    decompressedFileInfo = new FileInfo(decompressedFile);
                    chart1.Series["DecompressedDataSize"].Points.AddY(decompressedFileInfo.Length);
                }
                else
                {
                    var series1 = chart1.Series["dataSize"];
                    series1.LegendText = "Received Data";
                    chart1.Series["DecompressedDataSize"].IsVisibleInLegend = false;
                }



            }

            if (compressedData)
            {
                chart1.Series["totaldataTime"].Points.AddY(fileDownloadingTime);
            }
            else
            {
                chart1.Series["totaldataTime"].IsVisibleInLegend = false;
            }

            Dictionary<char, long> itemCounts = FormatData.getStatisticFromGenomeFile(decompressedFile);
            showStatistic(itemCounts);

        }



        private void rdTotalTime_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTotalTime.Checked)
            {
                timingType = Timing.totalTime;
            }
        }

        private void rdTransferTime_CheckedChanged(object sender, EventArgs e)
        {
            ckboxAutoGenerate.Enabled = !rdTransferTime.Checked;
            enableAutoData(false);
            if (rdTransferTime.Checked)
            {
                timingType = Timing.transferTimeOnly;
            }
        }

        private void enableComparisionRadioButton(bool enable)
        {


            this.txtFileName.Enabled = enable;
            this.enableAutoData(!enable);

        }

        private void enableAutoData(bool enable)
        {

            this.txtDataSize.Enabled = enable;
            this.comBoxDataSize.Enabled = enable;
        }
        private void ckboxAutoGenerate_CheckedChanged(object sender, EventArgs e)
        {
            enableComparisionRadioButton(!ckboxAutoGenerate.Checked);
            rdTransferTime.Enabled = !ckboxAutoGenerate.Checked;
            btnRatio.Enabled = ckboxAutoGenerate.Checked;
        }

        private void btnRatio_Click(object sender, EventArgs e)
        {
            RatioForm form = new RatioForm();
            form.RatioType = ratioType;
            if (ratioType == RatioTypeEnum.Manual)
            {
                form.ratios = autoDataElementsRatios;
            }

            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                autoDataElementsRatios = form.ratios;
                ratioType = form.RatioType;

            }
        }


        private void formatHeader(long dataSize)
        {
            webClient.Headers.Clear();
            if (compressData)
                webClient.Headers.Add("Accept-Encoding", "gzip");

            if (ratioType == RatioTypeEnum.Automatic)
            {
                webClient.Headers.Add("RatioType", "Automatic");

            }

            else
            {
                webClient.Headers.Add("RatioType", "Manual");
                webClient.Headers.Add("A", autoDataElementsRatios[0].ToString());
                webClient.Headers.Add("C", autoDataElementsRatios[1].ToString());
                webClient.Headers.Add("G", autoDataElementsRatios[2].ToString());
                webClient.Headers.Add("T", autoDataElementsRatios[3].ToString());


            }

            webClient.Headers.Add("DataSize", dataSize.ToString());


        }

        private void showStatistic(Dictionary<char, long> counts)
        {
            if (counts != null && counts.Count >= 4)
            {
                lbACount.Text = counts['A'].ToString();
                lbCCount.Text = counts['C'].ToString();
                lbGCount.Text = counts['G'].ToString();
                lbTCount.Text = counts['T'].ToString();
            }

            else
            {
                lbACount.Text = "0";
                lbCCount.Text = "0";
                lbGCount.Text = "0";
                lbTCount.Text = "0";
            }

        }

        private void btnNotCompressed_CheckedChanged(object sender, EventArgs e)
        {
            compressData = false;

        }

        private void btnCompressed_CheckedChanged(object sender, EventArgs e)
        {
            compressData = true;

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            showStatistic(null);

        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {
            showStatistic(null);

        }

    }
}



