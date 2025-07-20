using Aurex.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurex.DataLayer
{
    public class DL_User
    {
        readonly string cs = @"URI=file:" + Application.StartupPath + "\\Aurex_ai.db";
        private static DL_User _instance = null;

        public static DL_User Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DL_User();
                }
                return _instance;
            }
        }

        public bool SaveUser(User obj)
        {
            bool answer = true;
            using (SQLiteConnection connection = new SQLiteConnection(cs))
            {
                connection.Open();
                string query = "insert into User(" +
                    "Id,NameUser,EmailUser,PasswordUser,Gender)" +
                    "values(" +
                    "@Id,@NameUser,@EmailUser,@PasswordUser,@Gender)";
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", obj.Id);
                cmd.Parameters.AddWithValue("@NameUser", obj.Name);
                cmd.Parameters.AddWithValue("@EmailUser", obj.Email);
                cmd.Parameters.AddWithValue("@PasswordUser", obj.Password);
                cmd.Parameters.AddWithValue("@Gender", obj.Gender);
                cmd.CommandType = CommandType.Text;
                if (cmd.ExecuteNonQuery() < 1)
                {
                    answer = false;
                }
            }
            return answer;
        }

        public List<User> LoadUser()
        {
            List<User> _users = new List<User>();
            using (SQLiteConnection connection = new SQLiteConnection(cs))
            {
                connection.Open();

                string query = "select Id,NameUser,EmailUser,PasswordUser,Gender from User";
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                cmd.CommandType = CommandType.Text;
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _users.Add(new User {
                            Id = int.Parse(reader[0].ToString()),
                            Name = reader[1].ToString(),
                            Email = reader[2].ToString(),
                            Password = reader[3].ToString(),
                            Gender = reader[4].ToString()
                        });
                        
                    }
                }

            }
            return _users;
        }

        public bool UpdateUser(User obj)
        {
            bool answer = true;
            using (SQLiteConnection connection = new SQLiteConnection(cs))
            {
                connection.Open();
                string query = "update User set NameUser=@NameUser,EmailUser=@EmailUser," +
                    "PasswordUser=@PasswordUser,Gender=@Gender where Id=@Id)";
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", obj.Id);
                cmd.Parameters.AddWithValue("@NameUser", obj.Name);
                cmd.Parameters.AddWithValue("@EmailUser", obj.Email);
                cmd.Parameters.AddWithValue("@PasswordUser", obj.Password);
                cmd.Parameters.AddWithValue("@Gender", obj.Gender);
                cmd.CommandType = CommandType.Text;
                if (cmd.ExecuteNonQuery() < 1)
                {
                    answer = false;
                }
            }
            return answer;
        }
    }
}
