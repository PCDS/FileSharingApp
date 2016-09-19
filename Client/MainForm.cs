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
using TechLifeForum;

namespace ClientRaw
{
    public enum Timing { totalTime, transferTimeOnly }


    public partial class MainForm : Form
    {
        private const string RawFormatOutputFileName = "Raw";
        IrcClient client;
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
        // Needed to update the form with messages from another thread
        private delegate void UpdateLogCallback(string strMessage);
        // Needed to set the form to a "disconnected" state from another thread
        private delegate void CloseConnectionCallback(string strReason);



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
            this.txtDataSize.Enabled = false;
            autoDataElementsRatios = FormatData.randomRatios(FormatData.specialChars.Length);
        }

        /*---------------------------------------CHAT APP--------------------------------------------*/
        private void Exit_Click(object sender, EventArgs e)
        {
           
            Application.Exit();
        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            Random r = new Random();

            for (int i = 0; i < 3; i++)
                txtNick.AppendText(r.Next(10).ToString());
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text == "Connect")
                DoConnect();
            else
                DoDisconnect();
        }
        private void DoConnect()
        {
            if (String.IsNullOrEmpty(txtServerAddress.Text.Trim()))
            {
                MessageBox.Show("Please specify a server");
                return;
            }
            if (String.IsNullOrEmpty(txtChannel.Text.Trim()))
            {
                MessageBox.Show("Please specify a channel");
                return;
            }
            if (String.IsNullOrEmpty(txtNick.Text.Trim()))
            {
                MessageBox.Show("Please specify a nick");
                return;
            }
            if (String.IsNullOrEmpty(txtPass.Text.Trim()))
            {
                MessageBox.Show("Please use a password");
                return;
            }

            int port;
            if (Int32.TryParse(txtPort.Text, out port))
                client = new IrcClient(txtServerAddress.Text.Trim(), port);
            else
                client = new IrcClient(txtServerAddress.Text.Trim());

            AddEvents();
            client.Nick = txtNick.Text.Trim();
            client.ServerPass = txtPass.Text.Trim();
            btnConnect.Enabled = false;
            txtChannel.Enabled = false;
            txtPort.Enabled = false;
            txtServerAddress.Enabled = false;
            txtNick.Enabled = false;
            txtPass.Enabled = false;
            rtbOutput.Clear(); // in case they reconnect and have old stuff there
            btnChatSend.Enabled = true;
            btnGetFile.Enabled = true;
            client.Connect();
        }
        private void DoDisconnect()
        {
            btnChatSend.Enabled = false;
            btnConnect.Enabled = true;
            txtChannel.Enabled = true;
            txtPort.Enabled = true;
            txtServerAddress.Enabled = true;
            txtNick.Enabled = true;
            txtPass.Enabled = true;
            lstUsers.Items.Clear();
            txtSend.Enabled = false;
            client.Disconnect();
            client = null;
            btnGetFile.Enabled = false;

            btnConnect.Text = "Connect";
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (client.Connected && !String.IsNullOrEmpty(txtSend.Text.Trim()) && lstUsers.Items.Count != 0)
            {
                if (txtChannel.Text.StartsWith("#"))
                    client.SendMessage(txtChannel.Text.Trim(), txtSend.Text.Trim());
                else
                    client.SendMessage("#" + txtChannel.Text.Trim(), txtSend.Text.Trim());

                AddToChatWindow("Me: " + txtSend.Text.Trim());
                txtSend.Clear();
                txtSend.Focus();
            }
            else
            {
                MessageBox.Show("Unable to send to channel, please reconnect");
            }
        }

        private void AddToChatWindow(string message)
        {
            rtbOutput.AppendText(message + "\n");
            rtbOutput.ScrollToCaret();
        }







        private void txtMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            // If the key is Enter
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                btnChatSend.PerformClick();

            }
        }



        private void AddEvents()
        {
            client.ChannelMessage += client_ChannelMessage;
            client.ExceptionThrown += client_ExceptionThrown;
            client.NoticeMessage += client_NoticeMessage;
            client.OnConnect += client_OnConnect;
            client.PrivateMessage += client_PrivateMessage;
            client.ServerMessage += client_ServerMessage;
            client.UpdateUsers += client_UpdateUsers;
            client.UserJoined += client_UserJoined;
            client.UserLeft += client_UserLeft;
            client.UserNickChange += client_UserNickChange;
        }


        #region Event Listeners

        void client_OnConnect(object sender, EventArgs e)
        {
            txtSend.Enabled = true;
            txtSend.Focus();

            btnConnect.Text = "Disconnect";
            btnConnect.Enabled = true;

            if (txtChannel.Text.StartsWith("#"))
                client.JoinChannel(txtChannel.Text.Trim());
            else
                client.JoinChannel("#" + txtChannel.Text.Trim());

        }

        void client_UserNickChange(object sender, UserNickChangedEventArgs e)
        {
            lstUsers.Items[lstUsers.Items.IndexOf(e.Old)] = e.New;
        }

        void client_UserLeft(object sender, UserLeftEventArgs e)
        {
            lstUsers.Items.Remove(e.User);
        }

        void client_UserJoined(object sender, UserJoinedEventArgs e)
        {
            lstUsers.Items.Add(e.User);

        }

        void client_UpdateUsers(object sender, UpdateUsersEventArgs e)
        {
            lstUsers.Items.Clear();
            lstUsers.Items.AddRange(e.UserList);

        }

        void client_ServerMessage(object sender, StringEventArgs e)
        {
            Console.WriteLine(e.Result);
        }

        void client_PrivateMessage(object sender, PrivateMessageEventArgs e)
        {
            AddToChatWindow("PM FROM " + e.From + ": " + e.Message);
        }

        void client_NoticeMessage(object sender, NoticeMessageEventArgs e)
        {
            AddToChatWindow("NOTICE FROM " + e.From + ": " + e.Message);
        }

        void client_ExceptionThrown(object sender, ExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }

        void client_ChannelMessage(object sender, ChannelMessageEventArgs e)
        {
            AddToChatWindow(e.From + ": " + e.Message);
        }

        #endregion




        /*---------------------------------------GTTP CODE--------------------------------------------*/

        //private void configChartToDefault()
        //{
        //    chart1.Legends.Clear();
        //    chart1.Series.Clear();
        //    chart1.ChartAreas.Clear();
        //
        //    var area1 = chart1.ChartAreas.Add("filesize");
        //    var area2 = chart1.ChartAreas.Add("time");
        //    area1.AxisY.Title = "File Size (bytes)";
        //    area2.AxisY.Title = "Time (milliseconds)";
        //
        //    var legend1 = chart1.Legends.Add("Legend1");
        //    var legend2 = chart1.Legends.Add("Legend2");
        //    legend1.DockedToChartArea = "filesize";
        //    legend1.IsDockedInsideChartArea = false;
        //    legend2.DockedToChartArea = "time";
        //    legend2.IsDockedInsideChartArea = false;
        //
        //
        //    var series1 = chart1.Series.Add("dataSize");
        //    series1.LegendText = "Received Compressed Data";
        //    var series2 = chart1.Series.Add("DecompressedDataSize");
        //    series2.LegendText = "Original data";
        //
        //    var series3 = chart1.Series.Add("downloadingdataTime");
        //    series3.ChartArea = "time";
        //    series3.Legend = "Legend2";
        //
        //    var series4 = chart1.Series.Add("totaldataTime");
        //    series4.ChartArea = "time";
        //    series4.Legend = "Legend2";
        //
        //    series1.Color = chartColors[1]; // red color
        //    series2.Color = chartColors[0]; // blue color
        //    series3.Color = chartColors[2]; // green color
        //
        //    foreach (var series in chart1.Series)
        //    {
        //        series.IsValueShownAsLabel = true;
        //    }
        //}

        private void showRawDataEncodingInfo()
        {
            this.btnGetFile.Text = "Stop";

        //    configChartToDefault();
        //    showStatistic(null);

            // download file with gzip compression
            getRawFormatFile();


        }
        private void getRawFormatFile()
        {
            // decoding char to 2bits
            string getFileName = RawFormatFileName;

         //   chart1.Series["downloadingdataTime"].LegendText = "Time for downloading Raw File";
         //   chart1.Series["totaldataTime"].LegendText = "Time for downloading , (decompressing) Raw File";
         //
         //
         //   if (timingType == Timing.transferTimeOnly)
         //   {
         //       if (!getFileName.Contains("Auto"))
         //           getFileName = "Preconfig" + getFileName;
         //       chart1.Series["dataTime"].LegendText = "Time for downloading Raw File";
         //
         //
         //   }
         //
         //   if (getFileName.Contains("Auto"))
         //   {
         //       chart1.Series["downloadingdataTime"].LegendText = "Time for downloading Raw Data";
         //       chart1.Series["totaldataTime"].LegendText = "Time for downloading and decompressing Raw Data";
         //   }

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
            this.serverAddress = "http://"+txtNick+":"+txtPass +"@"+ txtServerAddress.Text + ":" + port.ToString();
            this.autoDataSize = this.txtDataSize.LongValue * 1024;

                if (txtFileName.Text == "")
                {
                    MessageBox.Show("Please write the textfile name to be downloaded, for example mydata.txt");
                    return;

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
                //chart1.Series.Clear();
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
            // chart1.Series["downloadingdataTime"].Points.AddY(fileDownloadingTime);
            //
            // if (fileNameToDownload == "Auto.txt")
            // {
            //     fileNameToDownload = downloadedFileName.Replace("AutoData", "AutoData" + RawFormatOutputFileName);
            //
            //     if (downloadedFileName.Contains("compressed.txt"))
            //         fileNameToDownload = fileNameToDownload.Replace("compressed", "");
            //     
            // }
            fileInfo = new FileInfo(downloadedFileName);
            // chart1.Series["dataSize"].Points.AddY(fileInfo.Length);
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
                    //chart1.Series["DecompressedDataSize"].Points.AddY(decompressedFileInfo.Length);
                }
                else
                {
                    // var series1 = chart1.Series["dataSize"];
                    //series1.LegendText = "Received Data";
                    //chart1.Series["DecompressedDataSize"].IsVisibleInLegend = false;
                }



            }

            //if (compressedData)
            //{
            //    chart1.Series["totaldataTime"].Points.AddY(fileDownloadingTime);
            //}
            //else
            //{
            //    chart1.Series["totaldataTime"].IsVisibleInLegend = false;
            //}
            //
            //Dictionary<char, long> itemCounts = FormatData.getStatisticFromGenomeFile(decompressedFile);
            //showStatistic(itemCounts);

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

       // private void showStatistic(Dictionary<char, long> counts)
       // {
       //     if (counts != null && counts.Count >= 4)
       //     {
       //         lbACount.Text = counts['A'].ToString();
       //         lbCCount.Text = counts['C'].ToString();
       //         lbGCount.Text = counts['G'].ToString();
       //         lbTCount.Text = counts['T'].ToString();
       //     }
       //
       //     else
       //     {
       //         lbACount.Text = "0";
       //         lbCCount.Text = "0";
       //         lbGCount.Text = "0";
       //         lbTCount.Text = "0";
       //     }
       //
       // }

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
      //      showStatistic(null);

        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {
     //       showStatistic(null);

        }

        private void txtChannel_TextChanged(object sender, EventArgs e)
        {

        }
    }
}



