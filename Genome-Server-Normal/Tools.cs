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

            string names = UserDB.ListUsers();
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
            RadioButton isAdmin = new RadioButton() { Left = 50, Top = 130, Text = "Is Admin" };
            TextBox username = new TextBox { Left = 50, Top = 40, Width = 300 };
            TextBox password = new TextBox { Left = 50, Top = 95, Width = 300 };
            Button confirmation = new Button() { Text = "Ok", Left = 250, Width = 100, Top = 130 };
            CheckedListBox chanlist = new CheckedListBox() { Left = 400, Width = 125, Top = 15 };
            string cnames = UserDB.ListChannels();
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
                bool created = UserDB.CreateUser(username.Text, password.Text, admin, chans);
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

            Console.WriteLine(userListBox.Items.Count);
            for (int i = 0; i < userListBox.Items.Count - 1; i++)
            {
                if (userListBox.GetItemCheckState(i) == CheckState.Checked)
                {
                    //Modify();
                    //UserDB.DeleteUser(userListBox.Items[i].ToString());
                }
            }

        }

       // private void Modify()
       // {
       //     int admin = 0;
       //     Form CreateUser = new Form();
       //     CreateUser.StartPosition = FormStartPosition.CenterScreen;
       //     CreateUser.FormBorderStyle = FormBorderStyle.FixedDialog;
       //     CreateUser.Width = 600;
       //     CreateUser.Height = 200;
       //     CreateUser.Text = "Create User";
       //     Label userLabel = new Label() { Left = 50, Top = 15, Text = "Username:" };
       //     Label passLabel = new Label() { Left = 50, Top = 70, Text = "Password:" };
       //     RadioButton isAdmin = new RadioButton() { Left = 50, Top = 130, Text = "Is Admin" };
       //     TextBox username = new TextBox { Left = 50, Top = 40, Width = 300 };
       //     TextBox password = new TextBox { Left = 50, Top = 95, Width = 300 };
       //     Button confirmation = new Button() { Text = "Ok", Left = 250, Width = 100, Top = 130 };
       //     CheckedListBox chanlist = new CheckedListBox() { Left = 400, Width = 125, Top = 15 };
       //     string cnames = UserDB.ListChans();
       //     string[] tokens = cnames.Split(new[] { "\n" }, StringSplitOptions.None);
       //     for (int i = 0; i < tokens.Length - 1; i++)
       //     {
       //         chanlist.Items.Add(tokens[i]);
       //     }
       //
       //     confirmation.Click += (sender2, d) => {
       //         Console.WriteLine(chanlist.Items.Count);
       //         string[] chans = new string[chanlist.Items.Count];
       //         for (int i = 0; i < chanlist.Items.Count; i++)
       //         {
       //             if (chanlist.GetItemCheckState(i) == CheckState.Checked)
       //             {
       //                 chans[i] = userListBox.Items[i].ToString();
       //             }
       //         }
       //         UserDB.CreateUser(username.Text, password.Text, admin, chans);
       //         userListBox.Items.Add(username.Text);
       //         CreateUser.Close();
       //     };
       //     CreateUser.Controls.Add(username);
       //     CreateUser.Controls.Add(password);
       //     CreateUser.Controls.Add(isAdmin);
       //     CreateUser.Controls.Add(confirmation);
       //     CreateUser.Controls.Add(userLabel);
       //     CreateUser.Controls.Add(passLabel);
       //     CreateUser.Controls.Add(chanlist);
       //     CreateUser.ShowDialog();
       //
       //
       // }



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
