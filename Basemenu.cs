﻿using System;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;

public class Basemenu
{
	public Basemenu()
	{

        this.Menu = new MainMenu();
        MenuItem file = new MenuItem("File");
        this.Menu.MenuItems.Add(file);
        MenuItem help = new MenuItem("Help");
        this.Menu.MenuItems.Add(help);
        help.MenuItems.Add("Check For Updates", new EventHandler(Update_Click));
        help.MenuItems.Add("Online Resources", new EventHandler(Save_Click));


    }

    public MainMenu Menu { get; private set; }

    public void Save_Click(object sender, EventArgs e)
    {
        System.Diagnostics.Process.Start("https://pcds.github.io/FileSharingApp/");
    }


    private void Update_Click(object sender, EventArgs e)
    {
        updateCheck();
    }

    private void updateCheck()
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
}
