using FileSharingAppServer;
using System;
using System.Collections;
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
    public partial class Tools : Form
    {

        DatabaseCon UserDB = new DatabaseCon();
        
        public Tools()
        {
            InitializeComponent();

            string names = UserDB.List("Users", "name");
            string[] tokens = names.Split(new[] { "\n" }, StringSplitOptions.None);
            for (int i=0; i < tokens.Length-1; i++)
            {
                userListBox.Items.Add(tokens[i]);
            }
            
        }


        private void userListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked && userListBox.CheckedItems.Count > 0)
            {
                userListBox.ItemCheck -= userListBox_ItemCheck;
                userListBox.SetItemChecked(userListBox.CheckedIndices[0], false);
                userListBox.ItemCheck += userListBox_ItemCheck;
            }
        }


        private void Create_Click(object sender, EventArgs e)
        {
            int admin = 0;
            Form CreateUser = new Form();
            CreateUser.StartPosition = FormStartPosition.CenterScreen;
            CreateUser.FormBorderStyle = FormBorderStyle.FixedDialog;
            CreateUser.Width = 600;
            CreateUser.Height = 200;
            CreateUser.Text = "Create User";
            Label userLabel = new Label() { Left = 50, Top = 15, Text = "Username:" };
            Label passLabel = new Label() { Left = 50, Top = 70, Text = "Password:" };
            CheckBox isAdmin = new CheckBox() { Left = 50, Top = 130, Text = "Is Admin" };
            TextBox username = new TextBox { Left = 50, Top = 40, Width = 300 };
            TextBox password = new TextBox { Left = 50, Top = 95, Width = 300 };
            Button confirmation = new Button() { Text = "Ok", Left = 250, Width = 100, Top = 130 };
            CheckedListBox chanlist = new CheckedListBox() { Left = 400, Width = 160, Height = 150, Top = 15 };
            string cnames = UserDB.List("Channels", "cname");
            string[] tokens = cnames.Split(new[] { "\n" }, StringSplitOptions.None);
            for (int i = 0; i < tokens.Length - 1; i++)
            {
                chanlist.Items.Add(tokens[i]);
            }

            confirmation.Click += (sender2, d) => {
                Console.WriteLine(chanlist.Items.Count);
                string[] chans = new string[chanlist.Items.Count];
                for (int i = 0; i < chanlist.Items.Count; i++)
                {
                    try
                    {
                        if (chanlist.GetItemCheckState(i) == CheckState.Checked)
                        {
                            chans[i] = chanlist.Items[i].ToString();
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                    }
                }
                if (isAdmin.Checked)
                {
                    admin = 1;
                }
                    bool created = UserDB.CreateUser(username.Text, password.Text, admin, chans, false);
                if (created == true)
                {
                    userListBox.Items.Add(username.Text);
                }
                    CreateUser.Close();
            };
            CreateUser.Controls.Add(username);
            CreateUser.Controls.Add(password);
            CreateUser.Controls.Add(isAdmin);
            CreateUser.Controls.Add(confirmation);
            CreateUser.Controls.Add(userLabel);
            CreateUser.Controls.Add(passLabel);
            CreateUser.Controls.Add(chanlist);
            CreateUser.ShowDialog();
        }

        private void Modify_Click(object sender, EventArgs e)
        {
              string name = "";
              int uindex = 0;
              bool created = false;
              for (int i = 0; i < userListBox.Items.Count; i++)
              {
                  if (userListBox.GetItemCheckState(i) == CheckState.Checked)
                  {
                      name = userListBox.Items[i].ToString();
                      uindex = i;
                  }
              }
            if (name != "")
            {
                string userchans = UserDB.List("Permissions", "name", name, "cname");
                DatabaseCon.UserData userInfo = UserDB.GetUserInfo(name);

                string[] usertoks = userchans.Split(new[] { "\n" }, StringSplitOptions.None);
                int admin = 0;
                Form CreateUser = new Form();
                CreateUser.StartPosition = FormStartPosition.CenterScreen;
                CreateUser.FormBorderStyle = FormBorderStyle.FixedDialog;
                CreateUser.Width = 600;
                CreateUser.Height = 200;
                CreateUser.Text = "Create User";
                Label userLabel = new Label() { Left = 50, Top = 15, Text = "Username:" };
                Label passLabel = new Label() { Left = 50, Top = 70, Text = "Password:" };
                CheckBox isAdmin = new CheckBox() { Left = 50, Top = 130, Text = "Is Admin" };
                TextBox username = new TextBox { Left = 50, Top = 40, Width = 300 , Text = name };
                TextBox password = new TextBox { Left = 50, Top = 95, Width = 300 };
                Button confirmation = new Button() { Text = "Ok", Left = 250, Width = 100, Top = 130 };
                CheckedListBox chanlist = new CheckedListBox() { Left = 400, Width = 160, Height = 150, Top = 15 };
                string cnames = UserDB.List("Channels", "cname");
                string[] tokens = cnames.Split(new[] { "\n" }, StringSplitOptions.None);
                for (int i = 0; i < tokens.Length - 1; i++)
                {
                    chanlist.Items.Add(tokens[i]);
                    for (int k = 0; k < usertoks.Length - 1; k++)
                    {
                        if (tokens[i].Trim() == usertoks[k].Trim())
                        {
                            chanlist.SetItemCheckState(i, CheckState.Checked);
                        }
                    }
                }

                if (userInfo.IsAdmin == 1)
                {
                    isAdmin.Checked = true;
                }

                confirmation.Click += (sender2, d) =>
                {
                    if (UserDB.Check(username.Text) == true)
                    {
                        UserDB.DeleteUser(name);
                        userListBox.Items.RemoveAt(uindex);
                        string[] chans = new string[chanlist.Items.Count];
                        for (int i = 0; i < chanlist.Items.Count; i++)
                        {
                            try
                            {
                                if (chanlist.GetItemCheckState(i) == CheckState.Checked)
                                {
                                    chans[i] = chanlist.Items[i].ToString();
                                }
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                            }
                        }
                        if (isAdmin.Checked)
                        {
                            admin = 1;
                        }
                        if (password.Text != "" && password.Text != null)
                        {
                            created = UserDB.CreateUser(username.Text, password.Text, admin, chans, false);
                        }
                        else
                        {
                            created = UserDB.CreateUser(username.Text, userInfo.Password, admin, chans, true);
                        }

                        if (created == true)
                        {
                            userListBox.Items.Add(username.Text);
                        }
                        CreateUser.Close();
                    }
                    };
                    CreateUser.Controls.Add(username);
                    CreateUser.Controls.Add(password);
                    CreateUser.Controls.Add(isAdmin);
                    CreateUser.Controls.Add(confirmation);
                    CreateUser.Controls.Add(userLabel);
                    CreateUser.Controls.Add(passLabel);
                    CreateUser.Controls.Add(chanlist);
                    CreateUser.ShowDialog();
            }
        }





    private void Delete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < userListBox.Items.Count; i++)
            {
                if(userListBox.GetItemCheckState(i) == CheckState.Checked)
                {
                    UserDB.DeleteUser(userListBox.Items[i].ToString());
                    userListBox.Items.RemoveAt(i);
                }
            }

        }


    }
}
