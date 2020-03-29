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
        private static readonly string CreateStatementsLocation = @"../../Modules/Data/SQL/create.sql";

        private SQLiteConnection connection;
        private readonly string databaseName;
        private readonly IMessageHandler errorHandler;

        public SQLiteConnection Connection
        {
            get
            {
                if (this.connection == null)
                {
                    this.connection = this.CreateConnection();
                }

                return connection;
            }
        }


        public Database(string databaseName, IMessageHandler errorHandler)
        {
            this.databaseName = databaseName;
            this.errorHandler = errorHandler;
            this.connection = this.CreateConnection();

            if (System.IO.File.Exists(databaseName))
            {
                System.IO.FileStream dbFile = System.IO.File.OpenRead(databaseName);
                
                if(dbFile.Length == 0)
                {
                    dbFile.Dispose();
                    this.CreateTables();
                }
            }
            else
            {
                SQLiteConnection.CreateFile(databaseName);
                this.CreateTables();
            }
        }

        private SQLiteConnection CreateConnection()
        {
            string dbPath = System.IO.Path.Combine(Environment.CurrentDirectory, databaseName);
            string connectionString = string.Format("Data Source={0}", dbPath);
            return new SQLiteConnection(connectionString);
        }

        private void CreateTables()
        {
            //using (this.connection)
            {
                this.connection.Open();

                try
                {
                    SQLiteCommand command = new SQLiteCommand(this.connection)
                    {
                        CommandText = System.IO.File.ReadAllText(CreateStatementsLocation)
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
            {
                this.connection.Dispose();
            }

            //this.Dispose();
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
                        campuses.Add(new Campus(reader.GetInt32(0), reader.GetString(1)));
                    }
                }
            }

            return campuses;
        }
    }
}
