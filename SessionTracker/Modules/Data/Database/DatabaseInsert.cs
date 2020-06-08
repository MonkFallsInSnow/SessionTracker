using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionTracker.Modules.Data.Database
{
    partial class Database
    {
        /*
        public int InsertSession(NameValueCollection session)
        {
            try
            {
                using (SQLiteCommand command = new SQLiteCommand(this.connection))
                {
                    int rowCount = this.AddStudent(session, command);
                    rowCount = this.AddSession(session, command);
                    rowCount += this.AddSessionTopic(session, command);

                    return rowCount;
                }
            }
            catch (SQLiteException ex)
            {
                throw new SQLiteException(ex.Message);
            }
        }

        //TODO: partition InsertSession function into the following helper functions
        private int AddSession(NameValueCollection session, SQLiteCommand command)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into Session ");
            sb.Append("(ID, Timestamp, StudentID, CourseID, CampusID, CenterID, TutorID, Notes, IsWorkshop) ");
            sb.Append("values (");
            sb.Append(session["ID"] + ", ");
            sb.Append("\"");
            sb.Append(session["Timestamp"]);
            sb.Append("\", ");
            sb.Append("\"");
            sb.Append(session["StudentID"]);
            sb.Append("\", ");
            sb.Append(session["CourseID"] + ", ");
            sb.Append(session["CampusID"] + ", ");
            sb.Append(session["CenterID"] + ", ");
            sb.Append(session["TutorID"] + ", ");
            sb.Append("\"");
            sb.Append(session["Notes"]);
            sb.Append("\", ");
            sb.Append(session["IsWorkshop"] + ");");

            command.CommandText = sb.ToString();

            return command.ExecuteNonQuery();
        }

        private int AddSessionTopic(NameValueCollection session, SQLiteCommand command)
        {
            var result = this.QuickLookUp("seq", "sqlite_sequence", "Name", "Session").FirstOrDefault();
            string lastID = result == null ? "0" : result[0];

            command.CommandText = "insert into SessionTopic (SessionID, TopicID) values ";
            string[] topics = session["Topics"].Split(',');

            for (int i = 0; i < topics.Length; i++)
            {
                result = this.QuickLookUp("ID", "Topic", "Name", topics[i]).FirstOrDefault();
                string topicID = result == null ? "0" : result[0];

                command.CommandText += $"({lastID}, {topicID}), ";
            }

            command.CommandText = command.CommandText.TrimEnd(',', ' ');
            command.CommandText += ";";

            return command.ExecuteNonQuery();
        }

        private int AddStudent(NameValueCollection session, SQLiteCommand command)
        {
            int rowCount = 0;
            StringBuilder sb = new StringBuilder();
            string queryCommand = "select StudentID from Student";
            var result = this.Read(queryCommand);//this.QuickLookUp("StudentID", "Student").FirstOrDefault();

            if (result == null)
            {
                sb.Append("insert into Student (StudentID, FName, LName) values (");
                sb.Append("\"" + session["StudentID"] + "\", ");
                sb.Append("\"" + session["FName"] + "\", ");
                sb.Append("\"" + session["LName"] + "\"");
                sb.Append(");");

                command.CommandText = sb.ToString();
                rowCount = command.ExecuteNonQuery();
            }

            return rowCount;
        }
        */
    }
}
