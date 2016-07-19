using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FileSharingAppServer
{

    class DatabaseCon
    {
        private Dictionary<Type, DbType> typeMap;


        public struct UserData
        {
            public bool Exists;
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


        public void CreateDB()
        {
            string database = System.AppDomain.CurrentDomain.BaseDirectory + @"Users.sqlite";
            if (!File.Exists(database))
            {
                SQLiteConnection.CreateFile("Users.sqlite");
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=Users.sqlite;Version=3;");
                m_dbConnection.Open();
                string sql = "create table Users (name varchar(20) PRIMARY KEY,password varchar(100))";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

                m_dbConnection.Close();
            }


        }

        public void CreateUser(string user, string pass)
        {

             UserData userInfo =  GetUserInfo(user);

            if (userInfo.Exists == true)
            {
                MessageBox.Show("That username already exists");
            }
            else if(user == "")
            {
                MessageBox.Show("Please input a username");
            }
            else
            {
                  string hashPass = HashPassword(pass);
                  using (var cn = new SQLiteConnection("Data Source=Users.sqlite;Version=3;"))
                  using (var cmd = new SQLiteCommand())
                  {
                      cn.Open();
                      cmd.Connection = cn;
                      cmd.CommandType = CommandType.Text;
                      cmd.CommandText = "insert into Users (name, password) values (@username , @password)";
                      cmd.Parameters.Add(new SQLiteParameter("@username", user));
                      cmd.Parameters.Add(new SQLiteParameter("@password", hashPass));
                      cmd.ExecuteNonQuery();
                      cn.Close();
                    MessageBox.Show("Successfully added the user");

                }
            }
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
                }else
                {
                    userInfo.Exists = true;
                    int ordUser = reader.GetOrdinal("name");
                    int ordPass = reader.GetOrdinal("password");
                    userInfo.Username = reader.GetString(ordUser);
                    userInfo.Password = reader.GetString(ordPass);
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

