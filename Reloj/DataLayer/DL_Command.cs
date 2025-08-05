using Aurex.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aurex.DataLayer
{
    public class DL_Command
    {
        readonly string cs = @"URI=file:" + Application.StartupPath + "\\Aurex_ai.db";
        private static DL_Command _instance = null;

        public static DL_Command Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DL_Command();
                }
                return _instance;
            }
        }

        public bool SaveCommand(Command obj)
        {
            bool answer = true;
            using (SQLiteConnection connection = new SQLiteConnection(cs))
            {
                connection.Open();
                using (var pragma = new SQLiteCommand("PRAGMA foreign_keys = ON;", connection))
                {
                    pragma.ExecuteNonQuery();
                }
                string query = "insert into Command(" +
                    "IdUser,TypeCommand,Comand,PathCommand,AnswerCommand)" +
                    "values(" +
                    "@iduser,@type,@command,@path,@answer)";
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                cmd.Parameters.AddWithValue("@iduser", obj.IdUser);
                cmd.Parameters.AddWithValue("@type", obj.Type);
                cmd.Parameters.AddWithValue("@command", obj.Comand);
                cmd.Parameters.AddWithValue("@path", obj.Path);
                cmd.Parameters.AddWithValue("@answer", obj.Answer);
                cmd.CommandType = CommandType.Text;
                if (cmd.ExecuteNonQuery() < 1)
                {
                    answer = false;
                }
            }
            return answer;
        }

        public List<Command> LoadCommand(int IdUser)
        {
            List<Command> commands = new List<Command>();
            using (SQLiteConnection connection = new SQLiteConnection(cs))
            {
                connection.Open();
                using (var pragma = new SQLiteCommand("PRAGMA foreign_keys = ON;", connection))
                {
                    pragma.ExecuteNonQuery();
                }

                string query = "select Id,TypeCommand,Comand,PathCommand,AnswerCommand" +
                    " from Command where IdUser=@id";
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", IdUser);
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        commands.Add(new Command
                        {
                            Id = int.Parse(reader[0].ToString()),
                            Type = reader[1].ToString(),
                            Comand = reader[2].ToString(),
                            Path = reader[3].ToString(),
                            Answer = reader[4].ToString()
                        });
                    }
                }

            }
            return commands;
        }

        public bool UpdateCommand(Command obj)
        {
            bool answer = true;
            using (SQLiteConnection connection = new SQLiteConnection(cs))
            {
                connection.Open();
                using (var pragma = new SQLiteCommand("PRAGMA foreign_keys = ON;", connection))
                {
                    pragma.ExecuteNonQuery();
                }

                string query = @"update Command set TypeCommand=@type,Comand=@command,
                                PathCommand=@path,AnswerCommand=@answer 
                                where Id=@id";
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", obj.Id);
                cmd.Parameters.AddWithValue("@type", obj.Type);
                cmd.Parameters.AddWithValue("@command", obj.Comand);
                cmd.Parameters.AddWithValue("@path", obj.Path);
                cmd.Parameters.AddWithValue("@answer", obj.Answer);
                cmd.CommandType = CommandType.Text;
                if (cmd.ExecuteNonQuery() < 1)
                {
                    answer = false;
                }
            }
            return answer;

        }
        
        public bool DeleteCommand(int obj) {
            bool answer = true;
            using (SQLiteConnection connection = new SQLiteConnection(cs))
            {
                connection.Open();
                using (var pragma = new SQLiteCommand("PRAGMA foreign_keys = ON;", connection))
                {
                    pragma.ExecuteNonQuery();
                }

                string query = @"delete from Command where Id=@id";
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", obj);
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
