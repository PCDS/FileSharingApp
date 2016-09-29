using System;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Linq;

namespace ServerClient
{
    public partial class AppSettingsForm : Form
    {
        public AppSettingsForm()
        {
            InitializeComponent();
            LoadConfig();

        }


        public void LoadConfig()
        {

            var xml = XDocument.Load(@"config.xml");

            var query = from c in xml.Root.Descendants("interface")
                        select c.Element("port").Value;
            txtChatPort.Text = string.Join("", query);
            query = from c in xml.Root.Descendants("interface")
                    select c.Element("fileport").Value;
            txtFilePort.Text = string.Join("", query);
        }


        public void SaveConfig()
        {
            string xmlFile = "config.xml";
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.Load(xmlFile);
            xmlDoc.SelectSingleNode("config/interface/port").InnerText = txtChatPort.Text;
            xmlDoc.SelectSingleNode("config/interface/fileport").InnerText = txtFilePort.Text;
            xmlDoc.Save(xmlFile);
            MessageBox.Show("Configuration Saved");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            txtChatPort.Text= int.Parse(txtChatPort.Text).ToString();
            txtFilePort.Text = int.Parse(txtFilePort.Text).ToString();
            if (txtFilePort.IntValue > 0 && txtFilePort.IntValue < ushort.MaxValue && txtChatPort.IntValue > 0 && txtChatPort.IntValue < ushort.MaxValue )
            {


                SaveConfig();
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
