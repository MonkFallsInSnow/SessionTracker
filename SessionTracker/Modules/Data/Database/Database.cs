using SessionTracker.Modules.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SQLite;
using System.Windows.Forms;

namespace SessionTracker.Modules.Data.Database
{
    partial class Database : IDatabase
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
                using (System.IO.FileStream dbFile = System.IO.File.OpenRead(databaseName))
                {

                    if (dbFile.Length == 0)
                    {
                        dbFile.Dispose();
                        this.CreateTables();
                    }
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

        //use this and make sure none of the literals in the commandText are supplied by the user via the UI
        public IEnumerable<NameValueCollection> Read(string commandText, Dictionary<string, string> parameters = null)
        {
            using (SQLiteCommand command = new SQLiteCommand(this.connection))
            {
                command.CommandText = commandText;

                if (parameters != null)
                {
                    foreach (KeyValuePair<string, string> kvp in parameters)
                    {
                        command.Parameters.AddWithValue(kvp.Key, kvp.Value);
                    }
                }

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        yield return reader.GetValues();
                }
            }
        }

        public int Write(string commandText, Dictionary<string, string> parameters = null)
        {
            int rowsAffected = 0;

            using(SQLiteTransaction transaction =  this.connection.BeginTransaction())
            using(SQLiteCommand command = new SQLiteCommand(this.connection))
            {
                try
                {
                    command.CommandText = commandText;

                    if (parameters != null)
                    {
                        foreach (KeyValuePair<string, string> kvp in parameters)
                        {
                            command.Parameters.AddWithValue(kvp.Key, kvp.Value);
                        }
                    }

                    rowsAffected = command.ExecuteNonQuery();
                }
                catch(Exception e)
                {
                    transaction.Rollback();
                    throw new Exception(e.Message);
                }

                transaction.Commit();
                return rowsAffected;
            }
        }

        public void Dispose()
        {
            if (this.connection != null)
            {
                this.connection.Dispose();
            }
        }
    }
}
