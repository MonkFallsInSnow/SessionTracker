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
        public int InsertSession(NameValueCollection session)
        {
            try
            {
                using (SQLiteCommand command = new SQLiteCommand(this.connection))
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
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

                    command.CommandText = sb.ToString(); //		sb.ToString()	"insert into Session values (ID, Timestamp, StudentID, CourseID, CampusID, TutorID, Notes, IsWorkshop)0, 4/13/2020 2:19:13 PM, 2196363, 21, 3, adsf, False);"

                    int rowCount1 = command.ExecuteNonQuery();

                    var result = this.QuickLookUp("seq", "sqlite_sequence", "Name", "Session").FirstOrDefault();
                    string lastID = result == null ? "0" : result[0];

                    command.CommandText = "insert into SessionTopic (SessionID, TopicID) values ";
                    string[] topics = session["Topics"].Split(',');

                    for(int i = 0; i < topics.Length; i++)
                    {
                        result = this.QuickLookUp("ID", "Topic", "Name", topics[i]).FirstOrDefault();
                        string topicID = result == null ? "0" : result[0];

                        command.CommandText += $"({lastID}, {topicID}), ";
                    }

                    command.CommandText = command.CommandText.TrimEnd(',', ' ');
                    command.CommandText += ";";
                    int rowCount2 = command.ExecuteNonQuery();

                    return rowCount1 + rowCount2;
                }
            }
            catch (SQLiteException ex)
            {
                throw new SQLiteException(ex.Message);
            }
        }
    }
}
