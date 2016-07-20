using System;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;

namespace FileSharingApp
{
    public partial class Base : Form
    {
        public Base()
        {
            InitializeComponent();
        }

        private void Base_Load(object sender, EventArgs e)
        {

        }


        public void updateCheck()
        {
            String versioninfo;
            WebClient web = new WebClient();
            System.IO.Stream stream = web.OpenRead("https://pcds.github.io/FileSharingApp/versioninfo.html");
            using (System.IO.StreamReader reader = new System.IO.StreamReader(stream))
            {
                versioninfo = reader.ReadToEnd();
            }
            string[] ssize = versioninfo.Split(null);
            System.Version currentversion = new System.Version(ssize[1]);
            System.Version myversion = new System.Version(Application.ProductVersion);
            int test = currentversion.CompareTo(myversion);
            string result = Convert.ToString(test);
            if (test == 1)
            {
                DialogResult dialogResult = MessageBox.Show("Your software needs to be updated.\nWould you like to restart the application and update now?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var path = AppDomain.CurrentDomain.BaseDirectory + "Updater.bat";
                    Process.Start(path);
                }

            }
            else
            {
                MessageBox.Show("You are up to date\nVersion: " + myversion);
            }

        }

 

        private void Update_Click(object sender, EventArgs e)
        {
            updateCheck();
        }


        private void Online_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://pcds.github.io/FileSharingApp/");
        }


        private void Report_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please create details of the error and a screenshot to blake.j.wrege@wmich.edu");
            System.Diagnostics.Process.Start("mailto:blake.j.wrege@wmich.edu");

        }

        private void About_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.Show();
        }
    }
}
