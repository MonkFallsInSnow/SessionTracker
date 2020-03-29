using SessionTracker.Modules.Data.Models;
using SessionTracker.Modules.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.Windows.Forms;

namespace SessionTracker.Modules.Data
{
    class Database : IDatabase
    {
        private SQLiteConnection connection;
        private readonly string databaseName;
        private readonly IMessageHandler errorHandler;

        public SQLiteConnection Connection
        {
            get
            {
                if (this.connection == null)
                {
                    string dbPath = System.IO.Path.Combine(Environment.CurrentDirectory, databaseName);
                    string connectionString = string.Format("Data Source={0}", dbPath);
                    connection = new SQLiteConnection(connectionString);
                }

                return connection;
            }
        }


        public Database(string databaseName, IMessageHandler errorHandler)
        {
            this.databaseName = databaseName;
            this.errorHandler = errorHandler;

            if (!System.IO.File.Exists(databaseName))
            {
                SQLiteConnection.CreateFile(databaseName);
                this.CreateTables();
            }
        }

        private void CreateTables()
        {
            using (this.connection)
            {
                this.connection.Open();

                try
                {
                    SQLiteCommand command = new SQLiteCommand(this.Connection)
                    {
                        CommandText = System.IO.File.ReadAllText(@"../../Data/SQL/createTables.sql")
                    };

                    command.ExecuteNonQuery();
                }
                catch (System.IO.FileNotFoundException)
                {
                    this.errorHandler.ShowDialog("Database Error", "Failed to create database tables.", MessageBoxIcon.Error);
                }
            }
        }

        public void Dispose()
        {
            if (this.connection != null)
                this.connection.Dispose();
        }

        public IList<object> GetCampuses()
        {
            IList<object> campuses = new BindingList<object>();

            using (SQLiteCommand command = new SQLiteCommand(this.connection))
            {
                command.CommandText = "select ID, Name from Campus";

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        campuses.Add(new
                        {
                            ID = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        });
                    }
                }
            }

            return campuses;
        }
    }
}
