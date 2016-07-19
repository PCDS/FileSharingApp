using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace FileSharingAppServer
{

    class DatabaseCon
    {
        private Dictionary<Type, DbType> typeMap;

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
                string sql = "create table Users (name varchar(20),password varchar(100))";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

                m_dbConnection.Close();
                CreateUser("giggles", "monkey");
            }


        }

        public void CreateUser(string user, string pass)
        {
            string hashPass = HashPassword(pass);
            File.WriteAllText("salt.txt", hashPass);
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

            }

        }

        public bool CheckPass(string currUser, string currPass)          
        {
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=Users.sqlite;Version=3;");
            m_dbConnection.Open();
            string sql = "select * from Users";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if ((string)reader["name"] == currUser)
                {

                    byte[] hashBytes = Convert.FromBase64String((string)reader["password"]);
                    byte[] salt = new byte[16];
                    Array.Copy(hashBytes, 0, salt, 0, 16);
                    var pbkdf2 = new Rfc2898DeriveBytes(currPass, salt, 10000);
                    byte[] hash = pbkdf2.GetBytes(20);
                    Debug.WriteLine("Name: " + reader["name"] + "\tPassword: " + reader["password"]);
                    for (int i = 0; i < 20; i++)
                    {
                        if (hashBytes[i + 16] != hash[i])
                            return false;
                    }
                     return true;
                }
            }
            return false;
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

            //  // Generate the hash, with an automatic 32 byte salt
            //  Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, 32);
            //  rfc2898DeriveBytes.IterationCount = 1000;
            //  byte[] hash = rfc2898DeriveBytes.GetBytes(20);
            //  byte[] salt = rfc2898DeriveBytes.Salt;
            //  //Return the salt and the hash
            //  return Convert.ToBase64String(salt) + "|" + Convert.ToBase64String(hash);
        }




        public class Users
        {
            [MaxLength(100)]
            public string name { get; set; }
            public string password { get; set; }
        }




    
    }
                    



}

