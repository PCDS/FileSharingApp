using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace FileSharingAppServer
{

    class DatabaseCon
    {
        private Dictionary<Type, DbType> typeMap;


        public struct UserData
        {
            public bool Exists;
            public int IsAdmin;
            public string Username;
            public string Password;
        }

        public DatabaseCon()
        {
            typeMap = new Dictionary<Type, DbType>();
            typeMap[typeof(byte)] = DbType.Byte;
            typeMap[typeof(sbyte)] = DbType.SByte;
            typeMap[typeof(short)] = DbType.Int16;
            typeMap[typeof(ushort)] = DbType.UInt16;
            typeMap[typeof(int)] = DbType.Int32;
            typeMap[typeof(uint)] = DbType.UInt32;
            typeMap[typeof(long)] = DbType.Int64;
            typeMap[typeof(ulong)] = DbType.UInt64;
            typeMap[typeof(float)] = DbType.Single;
            typeMap[typeof(double)] = DbType.Double;
            typeMap[typeof(decimal)] = DbType.Decimal;
            typeMap[typeof(bool)] = DbType.Boolean;
            typeMap[typeof(string)] = DbType.String;
            typeMap[typeof(char)] = DbType.StringFixedLength;
            typeMap[typeof(Guid)] = DbType.Guid;
            typeMap[typeof(DateTime)] = DbType.DateTime;
            typeMap[typeof(DateTimeOffset)] = DbType.DateTimeOffset;
            typeMap[typeof(byte[])] = DbType.Binary;
            typeMap[typeof(byte?)] = DbType.Byte;
            typeMap[typeof(sbyte?)] = DbType.SByte;
            typeMap[typeof(short?)] = DbType.Int16;
            typeMap[typeof(ushort?)] = DbType.UInt16;
            typeMap[typeof(int?)] = DbType.Int32;
            typeMap[typeof(uint?)] = DbType.UInt32;
            typeMap[typeof(long?)] = DbType.Int64;
            typeMap[typeof(ulong?)] = DbType.UInt64;
            typeMap[typeof(float?)] = DbType.Single;
            typeMap[typeof(double?)] = DbType.Double;
            typeMap[typeof(decimal?)] = DbType.Decimal;
            typeMap[typeof(bool?)] = DbType.Boolean;
            typeMap[typeof(char?)] = DbType.StringFixedLength;
            typeMap[typeof(Guid?)] = DbType.Guid;
            typeMap[typeof(DateTime?)] = DbType.DateTime;
            typeMap[typeof(DateTimeOffset?)] = DbType.DateTimeOffset;

        }

        //######################################################### Base Functions ###################################################################
        public void CreateDB()
        {
            string database = System.AppDomain.CurrentDomain.BaseDirectory + @"Users.sqlite";
            if (!File.Exists(database))
            {
                SQLiteConnection.CreateFile("Users.sqlite");
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=Users.sqlite;Version=3;");
                m_dbConnection.Open();
               // string sql = "create table Users (name varchar(20) PRIMARY KEY,password varchar(100),admin INTEGER)";
                SQLiteCommand command = new SQLiteCommand("create table Users (name varchar(20) PRIMARY KEY,password varchar(100),admin INTEGER)", m_dbConnection);
                command.ExecuteNonQuery();
                command = new SQLiteCommand("create table Channels (cname varchar(20) NOT NULL, PRIMARY KEY(cname) )", m_dbConnection);
               // sql = "create table Channels (cname varchar(20) NOT NULL, PRIMARY KEY(`cname`) ))";
                command.ExecuteNonQuery();
                command = new SQLiteCommand("create table Permissions (name varchar(20) PRIMARY KEY,cname varchar(20), FOREIGN KEY(name) REFERENCES Users(name))", m_dbConnection);
                command.ExecuteNonQuery();
                m_dbConnection.Close();
            }
        }

        public string List(string table, string colname)
        {
            string mylist = "";
            int count = 0;
            SQLiteConnection sqConnection = new SQLiteConnection("Data Source=Users.sqlite;Version=3;");
            SQLiteCommand sqCommand = new SQLiteCommand("select " + colname + " from " + table, sqConnection);
            sqConnection.Open();
            try
            {
                SQLiteDataReader sqReader = sqCommand.ExecuteReader();
                while (sqReader.Read())
                {
                    mylist = mylist + sqReader.GetString(sqReader.GetOrdinal(colname)) + "\n";
                    count = count + 1;
                }
                sqReader.Close();
            }
            finally
            {
                sqConnection.Close();
            }

            return mylist;
        }


        public string List(string table, string colname, string targetval, string targetcol)
        {

            string mylist = "";
            int count = 0;
            using (var cn = new SQLiteConnection("Data Source=Users.sqlite;Version=3;"))
            using (var cmd = new SQLiteCommand())
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from " + table + " WHERE " + colname + "=@channel";
                cmd.Parameters.Add(new SQLiteParameter("@channel", targetval));
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    mylist = mylist + reader.GetString(reader.GetOrdinal(targetcol)) + "\n";
                    count = count + 1;
                }
                reader.Close();
                cn.Close();

            }


            return mylist;
        }


        public bool Check(string strcheck)
        {
            Regex r = new Regex("^[a-zA-Z0-9]*$");

            if (strcheck == "")
            {
                MessageBox.Show("Please input a name");
            }
            else if (!r.IsMatch(strcheck))
            {
                MessageBox.Show("Please only user letters and numbers");
            }
            else if (strcheck.Length>19)
            {
                MessageBox.Show("Please keep name to 20 characters or less");
            }
            else
            {
                return true;
            }
            return false;
        }



        //######################################################### Channel Tools ###################################################################

        public bool GetChanInfo(string currChannel)
        {
            bool exists;
            using (var cn = new SQLiteConnection("Data Source=Users.sqlite;Version=3;"))
            using (var cmd = new SQLiteCommand())
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Channels WHERE cname=@channel";
                cmd.Parameters.Add(new SQLiteParameter("@channel", currChannel));
                SQLiteDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    exists = false;
                }
                else
                {
                    exists = true;
                }
                reader.Close();
                cn.Close();
                return exists;
            }
        }

        public bool CheckChannel(string currUser, string currChannel)
        {
            UserData userInfo = GetUserInfo(currUser);
            if (userInfo.Exists == true)
            {
                if (userInfo.IsAdmin == 1)
                {
                    return true;
                }
                using (var cn = new SQLiteConnection("Data Source=Users.sqlite;Version=3;"))
                using (var cmd = new SQLiteCommand())
                    try
                    {
                        cn.Open();
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select * from Permissions WHERE name=@username";
                        cmd.Parameters.Add(new SQLiteParameter("@username", currUser));
                        SQLiteDataReader reader = cmd.ExecuteReader();
                        while (reader.HasRows)
                        {
                            if (!reader.Read())
                            {
                                userInfo.Exists = false;
                                return false;
                            }
                            else
                            {

                                int ordUser = reader.GetOrdinal("name");
                                int ordChan = reader.GetOrdinal("cname");
                                string uname = reader.GetString(ordUser);
                                string cname = reader.GetString(ordChan);
                                if (uname == currUser && currChannel == cname)
                                {
                                    return true;
                                }
                            }
                        }
                        reader.Close();
                        cn.Close();
                        return false;
                    }
                    catch { }
            }
            else
            {
                return false;
            }

            return false;
        }


        public bool CreateChannel(string chan, string[] users)
        {

            bool created = false;
            bool exists = GetChanInfo("#"+chan);
            if (exists == true)
            {
                MessageBox.Show("That chat room already exists");
            }
            else
            {
                if (Check(chan) == true)
                {
                    using (var cn = new SQLiteConnection("Data Source=Users.sqlite;Version=3;"))
                    using (var cmd = new SQLiteCommand())
                    {
                        cn.Open();
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "insert into Channels (cname) values (@channel)";
                        cmd.Parameters.Add(new SQLiteParameter("@channel", "#" + chan));
                        cmd.ExecuteNonQuery();

                        for (int i = 0; i < users.Length; i++)
                        {
                            if (users[i] != null)
                            {
                                cmd.Parameters.Clear();
                                cmd.CommandText = "insert into Permissions (name, cname) values (@username , @channel)";
                                cmd.Parameters.Add(new SQLiteParameter("@username", users[i]));
                                cmd.Parameters.Add(new SQLiteParameter("@channel", "#" + chan));
                                cmd.ExecuteNonQuery();
                            }
                        }
                        cn.Close();
                        MessageBox.Show("Successfully added the chat room");
                        created = true;
                    }
                }
            }
            return created;
        }


        public void DeleteChannel(string chan)
        {
            bool exists = GetChanInfo(chan);
            if (exists == false)
            {
                MessageBox.Show("That chat room doesn't exists");
            }
            else
            {
                using (var cn = new SQLiteConnection("Data Source=Users.sqlite;Version=3;"))
                using (var cmd = new SQLiteCommand())
                {
                    cn.Open();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE from Permissions WHERE cname=@channel";
                    cmd.Parameters.Add(new SQLiteParameter("@channel", chan));
                    cmd.ExecuteNonQuery();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE from Channels WHERE cname=@channel";
                    cmd.Parameters.Add(new SQLiteParameter("@channel", chan));
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Successfully deleted the chat room");

                }
            }
        }


        //######################################################### User Tools ###################################################################

        public bool CreateUser(string user, string pass, int admin, string[] chans, bool hashed)
        {
            UserData userInfo = GetUserInfo(user);
            Regex r = new Regex("^[a-zA-Z0-9]*$");
            bool created = false;
            if (userInfo.Exists == true)
            {
                MessageBox.Show("That username already exists");
            }
            else
            {
                if (Check(user) == true)
                {
                    string hashPass = "";
                    if (hashed == false)
                    {
                        hashPass = HashPassword(pass);
                    }
                    else
                    {
                        hashPass = pass;
                    }

                    using (var cn = new SQLiteConnection("Data Source=Users.sqlite;Version=3;"))
                    using (var cmd = new SQLiteCommand())
                    {
                        cn.Open();
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "insert into Users (name, password, admin) values (@username , @password, @admin)";
                        cmd.Parameters.Add(new SQLiteParameter("@username", user));
                        cmd.Parameters.Add(new SQLiteParameter("@password", hashPass));
                        cmd.Parameters.Add(new SQLiteParameter("@admin", admin));
                        cmd.ExecuteNonQuery();

                        for (int i = 0; i < chans.Length; i++)
                        {
                            if (chans[i] != null)
                            {
                                cmd.Parameters.Clear();
                                cmd.CommandText = "insert into Permissions (name, cname) values (@username , @channel)";
                                cmd.Parameters.Add(new SQLiteParameter("@username", user));
                                cmd.Parameters.Add(new SQLiteParameter("@channel", chans[i]));
                                cmd.ExecuteNonQuery();
                            }
                        }
                        cn.Close();
                        MessageBox.Show("Successfully added the user");
                        created = true;
                    }
                }
            }
            return created;
        }

        public void DeleteUser(string user)
        {

            UserData userInfo = GetUserInfo(user);

            if (userInfo.Exists == false)
            {
                MessageBox.Show("That username doesn't exists");
            }
            else
            {
                using (var cn = new SQLiteConnection("Data Source=Users.sqlite;Version=3;"))
                using (var cmd = new SQLiteCommand())
                {
                    cn.Open();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE from Permissions WHERE name=@username";
                    cmd.Parameters.Add(new SQLiteParameter("@username", user));
                    cmd.ExecuteNonQuery();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE from Users WHERE name=@username";
                    cmd.Parameters.Add(new SQLiteParameter("@username", user));
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Successfully deleted the user");

                }
            }
        }





        public bool CheckPass(string currUser, string currPass)
        {
            UserData userInfo = GetUserInfo(currUser);
            if (userInfo.Exists == true)
            {
                byte[] hashBytes = Convert.FromBase64String(userInfo.Password);
                byte[] salt = new byte[16];
                Array.Copy(hashBytes, 0, salt, 0, 16);
                var pbkdf2 = new Rfc2898DeriveBytes(currPass, salt, 10000);
                byte[] hash = pbkdf2.GetBytes(20);
                for (int i = 0; i < 20; i++)
                {
                    if (hashBytes[i + 16] != hash[i])
                        return false;
                }
                return true;
            }

            return false;

        }



        public UserData GetUserInfo(string currUser)
        {
            UserData userInfo = new UserData();

            using (var cn = new SQLiteConnection("Data Source=Users.sqlite;Version=3;"))
            using (var cmd = new SQLiteCommand())
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Users WHERE name=@username";
                cmd.Parameters.Add(new SQLiteParameter("@username", currUser));
                SQLiteDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    userInfo.Exists = false;
                }
                else
                {
                    userInfo.Exists = true;
                    int ordUser = reader.GetOrdinal("name");
                    int ordPass = reader.GetOrdinal("password");
                    int ordAdmin = reader.GetOrdinal("admin");
                    userInfo.Username = reader.GetString(ordUser);
                    userInfo.Password = reader.GetString(ordPass);
                    userInfo.IsAdmin = reader.GetInt16(ordAdmin);

                }
                reader.Close();
                cn.Close();
                return userInfo;
            }
        }

        public static string HashPassword(string password)
        {

            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            return Convert.ToBase64String(hashBytes);
        }



    }

}

