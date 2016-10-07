using FileSharingAppServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenomeServerNormal
{

    public partial class ChanTools : Form
    {
        DatabaseCon UserDB = new DatabaseCon();
        public ChanTools()
        {
            InitializeComponent();
            string cnames = UserDB.ListChannels();
            string[] tokens = cnames.Split(new[] { "\n" }, StringSplitOptions.None);
            for (int i = 0; i < tokens.Length - 1; i++)
            {
                chanListBox.Items.Add(tokens[i]);
            }
        }


        private void chanListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked && chanListBox.CheckedItems.Count > 0)
            {
                chanListBox.ItemCheck -= chanListBox_ItemCheck;
                chanListBox.SetItemChecked(chanListBox.CheckedIndices[0], false);
                chanListBox.ItemCheck += chanListBox_ItemCheck;
            }
        }


        private void Create_Click(object sender, EventArgs e)
        {
            Form CreateUser = new Form();
            CreateUser.StartPosition = FormStartPosition.CenterScreen;
            CreateUser.FormBorderStyle = FormBorderStyle.FixedDialog;
            CreateUser.Width = 600;
            CreateUser.Height = 200;
            CreateUser.Text = "Create Channel";
            Label chanLabel = new Label() { Left = 50, Top = 15, Text = "Channel:" };
            TextBox channame = new TextBox { Left = 50, Top = 40, Width = 300 };
            Button confirmation = new Button() { Text = "Ok", Left = 250, Width = 100, Top = 130 };
            CheckedListBox userlist = new CheckedListBox() { Left = 400, Width = 125, Top = 15 };
            string names = UserDB.ListUsers();
            string[] tokens = names.Split(new[] { "\n" }, StringSplitOptions.None);
            for (int i = 0; i < tokens.Length - 1; i++)
            {
                userlist.Items.Add(tokens[i]);
            }

            confirmation.Click += (sender2, d) => {
                string[] users = new string[userlist.Items.Count];
                for (int i = 0; i < userlist.Items.Count; i++)
                {
                    try
                    {
                        if (userlist.GetItemCheckState(i) == CheckState.Checked)
                        {
                            users[i] = userlist.Items[i].ToString();
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                    }
                }
               bool created = UserDB.CreateChannel(channame.Text, users);
                if (created == true)
                {
                    chanListBox.Items.Add(channame.Text);
                }
                CreateUser.Close();
            };
            CreateUser.Controls.Add(channame);
            CreateUser.Controls.Add(confirmation);
            CreateUser.Controls.Add(chanLabel);
            CreateUser.Controls.Add(userlist);
            CreateUser.ShowDialog();


        }

           private void Delete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chanListBox.Items.Count; i++)
            {
                if(chanListBox.GetItemCheckState(i) == CheckState.Checked)
                {
                    UserDB.DeleteChannel(chanListBox.Items[i].ToString());
                    chanListBox.Items.RemoveAt(i);
                }
            }

        }


























    }
}
