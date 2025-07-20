using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurex.DataLayer
{
    public class CreateDB
    {
        readonly string path = "Aurex_ai.db";
        public void CreateDBAndTables()
        {
            if (!File.Exists(path))
            {
                SQLiteConnection.CreateFile(path);
                using (var sqlite = new SQLiteConnection(@"Data Source=" + path))
                {
                    sqlite.Open();
                    using (var pragma = new SQLiteCommand("PRAGMA foreign_keys = ON;", sqlite))
                    {
                        pragma.ExecuteNonQuery();
                    }
                    string userTable = @"
                                CREATE TABLE User (
                                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                    NameUser VARCHAR(50),
                                    EmailUser VARCHAR(50),
                                    PasswordUser VARCHAR(50),
                                    Gender VARCHAR(15)
                                );";
                    string commandTable = @"
                                CREATE TABLE Command (
                                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                    IdUser INTEGER,
                                    TypeCommand VARCHAR(50),
                                    Comand VARCHAR(500),
                                    PathCommand VARCHAR(500),
                                    AnswerCommand VARCHAR(500),
                                    FOREIGN KEY (IdUser) REFERENCES User(Id)
                                );";
                    string configTable = @"
                                CREATE TABLE Configuration (
                                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                    IdUser INTEGER,
                                    City NVARCHAR(50),
                                    ZipCode VARCHAR(50),
                                    PortBt VARCHAR(10),
                                    AssistantName VARCHAR(50),
                                    LowBattery VARCHAR(5),
                                    VoiceAssistant VARCHAR(60),
                                    FOREIGN KEY (IdUser) REFERENCES User(Id)
                                );";
                    using (var cmd = new SQLiteCommand(userTable, sqlite))
                        cmd.ExecuteNonQuery();

                    using (var cmd = new SQLiteCommand(commandTable, sqlite))
                        cmd.ExecuteNonQuery();

                    using (var cmd = new SQLiteCommand(configTable, sqlite))
                        cmd.ExecuteNonQuery();
                }
            }
            else
                return;
            
        }
    }
}
