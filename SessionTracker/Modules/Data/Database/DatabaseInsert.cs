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
                //TODO: refactor so that topics are inserted into the sessiontopic table
                using (SQLiteCommand command = new SQLiteCommand())
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("insert into Session values ");
                    sb.Append("ID, Timestamp, StudentID, CourseID, CampusID, TutorID, Notes, IsWorkshop)");
                    sb.Append(session["ID"] + ", ");
                    sb.Append(session["Timestamp"] + ", ");
                    sb.Append(session["StudentID"] + ", ");
                    sb.Append(session["CourseID"] + ", ");
                    sb.Append(session["TutorID"] + ", ");
                    sb.Append(session["Notes"] + ", ");
                    sb.Append(session["IsWorkshop"] + ");");

                    command.CommandText = sb.ToString();

                    return command.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                throw new SQLiteException(ex.Message);
            }
        }
    }
}
