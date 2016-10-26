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
            string cnames = UserDB.List("Channels","cname");
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
            CheckedListBox userlist = new CheckedListBox() { Left = 400, Width = 160, Height = 150, Top = 15 };
            string names = UserDB.List("Users", "name");
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
                    chanListBox.Items.Add("#"+channame.Text);
                }
                CreateUser.Close();
            };
            CreateUser.Controls.Add(channame);
            CreateUser.Controls.Add(confirmation);
            CreateUser.Controls.Add(chanLabel);
            CreateUser.Controls.Add(userlist);
            CreateUser.ShowDialog();


        }



        private void Modify_Click(object sender, EventArgs e)
        {
            string cname ="";
            int cindex = 0;

            for (int i = 0; i < chanListBox.Items.Count; i++)
            {
                if (chanListBox.GetItemCheckState(i) == CheckState.Checked)
                {
                    cname = chanListBox.Items[i].ToString();
                    cindex = i;
                }
            }
            if (cname != "")
            {
                string chanusers = UserDB.List("Permissions", "cname", cname,"name");


                string[] chantoks = chanusers.Split(new[] { "\n" }, StringSplitOptions.None);

                Form CreateUser = new Form();
                CreateUser.StartPosition = FormStartPosition.CenterScreen;
                CreateUser.FormBorderStyle = FormBorderStyle.FixedDialog;
                CreateUser.Width = 600;
                CreateUser.Height = 200;
                CreateUser.Text = "Create Channel";
                Label chanLabel = new Label() { Left = 50, Top = 15, Text = "Channel:" };
                TextBox channame = new TextBox { Left = 50, Top = 40, Width = 300, Text = cname.Substring(1) };
                Button confirmation = new Button() { Text = "Ok", Left = 250, Width = 100, Top = 130 };
                CheckedListBox userlist = new CheckedListBox() { Left = 400, Width = 160, Height = 150, Top = 15 };
                string names = UserDB.List("Users", "name");
                string[] tokens = names.Split(new[] { "\n" }, StringSplitOptions.None);
                for (int i = 0; i < tokens.Length - 1; i++)
                {
                    userlist.Items.Add(tokens[i]);
                    for (int k = 0; k < chantoks.Length - 1; k++)
                    {
                        if (tokens[i].Trim() == chantoks[k].Trim())
                        {
                            userlist.SetItemCheckState(i, CheckState.Checked);
                        }
                    }
                }

                confirmation.Click += (sender2, d) =>
                {
                    if (UserDB.Check(channame.Text) == true)
                    {
                        UserDB.DeleteChannel(cname);
                        chanListBox.Items.RemoveAt(cindex);


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
                            chanListBox.Items.Add("#"+channame.Text);
                        }
                        CreateUser.Close();
                    }
                };
                CreateUser.Controls.Add(channame);
                CreateUser.Controls.Add(confirmation);
                CreateUser.Controls.Add(chanLabel);
                CreateUser.Controls.Add(userlist);
                CreateUser.ShowDialog();
            }
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
