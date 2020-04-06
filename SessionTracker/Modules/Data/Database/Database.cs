using SessionTracker.Modules.Messaging;
using System;
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
                System.IO.FileStream dbFile = System.IO.File.OpenRead(databaseName);

                if (dbFile.Length == 0)
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

        public void Dispose()
        {
            if (this.connection != null)
            {
                this.connection.Dispose();
            }
        }

        public int InsertSession(NameValueCollection session)
        {
            try
            {
                using (SQLiteCommand command = new SQLiteCommand())
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("insert into Session values ");
                    sb.Append("ID, Timestamp, StudentID, CourseID, CampusID, TutorID, TopicID, Notes, IsWorkshop)");
                    sb.Append(session["ID"] + ", ");
                    sb.Append(session["Timestamp"] + ", ");
                    sb.Append(session["StudentID"] + ", ");
                    sb.Append(session["CourseID"] + ", ");
                    sb.Append(session["TutorID"] + ", ");
                    sb.Append(session["TopicID"] + ", ");
                    sb.Append(session["Notes"] + ", ");
                    sb.Append(session["IsWorkshop"] + ");");

                    command.CommandText = sb.ToString();

                    return command.ExecuteNonQuery();
                }
            }
            catch(SQLiteException ex)
            {
                throw new SQLiteException(ex.Message);
            }
        }
    }
}
