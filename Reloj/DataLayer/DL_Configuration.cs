using Aurex.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aurex.DataLayer
{
    public class DL_Configuration
    {
        readonly string cs = @"URI=file:" + Application.StartupPath + "\\Aurex_ai.db";
        private static DL_Configuration _instance = null;
       
        public static DL_Configuration Instance
        {
            get { 
                if (_instance == null)
                {
                    _instance = new DL_Configuration();
                }
                return _instance;
            }
        }

        public bool SaveConfiguration(Configuration obj)
        {
            bool answer = true;
            using (SQLiteConnection connection = new SQLiteConnection(cs)) {
                connection.Open();
                using (var pragma = new SQLiteCommand("PRAGMA foreign_keys = ON;", connection))
                {
                    pragma.ExecuteNonQuery();
                }
                string query = "insert into Configuration(" +
                    "IdUser,City,ZipCode,PortBt,AssistantName,LowBattery,VoiceAssistant)" +
                    "values(" +
                    "@iduser,@city,@zipCode,@portBt,@assistantName,@lowBattery,@voiceAssistant)";
                SQLiteCommand cmd = new SQLiteCommand(query,connection);
                cmd.Parameters.AddWithValue("@iduser", obj.IdUser);
                cmd.Parameters.AddWithValue("@city", obj.City);
                cmd.Parameters.AddWithValue("@zipCode", obj.ZipCode);
                cmd.Parameters.AddWithValue("@portBt", obj.PortBt);
                cmd.Parameters.AddWithValue("@assistantName", obj.AssistantName);
                cmd.Parameters.AddWithValue("@lowBattery", obj.LowBattery);
                cmd.Parameters.AddWithValue("@voiceAssistant", obj.VoiceAssistant);
                cmd.CommandType = CommandType.Text;
                if (cmd.ExecuteNonQuery()<1)
                {
                    answer = false;
                }
            }
            return answer;
        }

        public Configuration LoadConfiguration(int IdUser)
        {
            Configuration _conf= new Configuration();
            using(SQLiteConnection connection=new SQLiteConnection(cs))
            {
                connection.Open();
                using (var pragma = new SQLiteCommand("PRAGMA foreign_keys = ON;", connection))
                {
                    pragma.ExecuteNonQuery();
                }

                string query = "select Id,City,ZipCode,PortBt,AssistantName,LowBattery,VoiceAssistant" +
                    " from Configuration where IdUser=@id";
                SQLiteCommand cmd=new SQLiteCommand(query,connection);
                cmd.CommandType=CommandType.Text;
                cmd.Parameters.AddWithValue("@id", IdUser);
                using (SQLiteDataReader reader = cmd.ExecuteReader()) {
                    while (reader.Read()) {
                        _conf.Id = int.Parse(reader[0].ToString());
                        _conf.City = reader[1].ToString();
                        _conf.ZipCode = reader[2].ToString();
                        _conf.PortBt = reader[3].ToString();
                        _conf.AssistantName = reader[4].ToString();
                        _conf.LowBattery = reader[5].ToString();
                        _conf.VoiceAssistant = reader[6].ToString();
                    }
                }

            }
            return _conf;
        }

        public bool UpdateConfiguration(Configuration obj)
        {
            bool answer = true;
            using (SQLiteConnection connection = new SQLiteConnection(cs))
            {
                connection.Open();
                using (var pragma = new SQLiteCommand("PRAGMA foreign_keys = ON;", connection))
                {
                    pragma.ExecuteNonQuery();
                }
                string query = @"update Configuration set City=@city,ZipCode=@zipCode,
                                PortBt=@portBt,AssistantName=@assistantName,LowBattery=@lowBattery,
                                VoiceAssistant=@voiceAssistant where Id=@id";
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", obj.Id);
                cmd.Parameters.AddWithValue("@city", obj.City);
                cmd.Parameters.AddWithValue("@zipCode", obj.ZipCode);
                cmd.Parameters.AddWithValue("@portBt", obj.PortBt);
                cmd.Parameters.AddWithValue("@assistantName", obj.AssistantName);
                cmd.Parameters.AddWithValue("@lowBattery", obj.LowBattery);
                cmd.Parameters.AddWithValue("@voiceAssistant", obj.VoiceAssistant);
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
