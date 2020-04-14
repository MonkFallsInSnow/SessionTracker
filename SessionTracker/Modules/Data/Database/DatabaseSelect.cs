using SessionTracker.Modules.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionTracker.Modules.Data.Database
{
    partial class Database
    {
        public IEnumerable<NameValueCollection> QuickLookUp(string columns, string table)
        {
            using (SQLiteCommand command = new SQLiteCommand(this.connection))
            {
                command.CommandText = $"select {columns} from {table}";

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                        yield return reader.GetValues();
                }
            }
        }

        public IEnumerable<NameValueCollection> QuickLookUp(string columns, string table, string whereColumn, string value)
        {
            using (SQLiteCommand command = new SQLiteCommand(this.connection))
            {
                command.CommandText = $"select {columns} from {table} where {whereColumn} = @value;";
                command.Parameters.AddWithValue("@value", value);

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        yield return reader.GetValues();
                }
            }
        }

        public IEnumerable<NameValueCollection> QuickLookUp(string columns, string table, string whereExpression)
        {
            using (SQLiteCommand command = new SQLiteCommand(this.connection))
            {
                command.CommandText = $"select {columns} from {table} where {whereExpression}";

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        yield return reader.GetValues();
                }
            }
        }

        public IEnumerable<NameValueCollection> SelectTutorsByCampus(string campusName)
        {
            using (SQLiteCommand command = new SQLiteCommand(this.connection))
            {
                command.CommandText = "" +
                    "select t.ID, t.FName, t.LName, t.IsActive " +
                    "from Tutor as t " +
                    "join TutorCampus as tc on t.ID = tc.TutorID " +
                    "join Campus as c on tc.CampusID = c.ID " +
                    "where c.Name = @campusName";

                command.Parameters.AddWithValue("@campusName", campusName);

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        yield return reader.GetValues();
                }
            }
        }

        public IEnumerable<NameValueCollection> SelectTopicsByCourse(string courseName)
        {
            using (SQLiteCommand command = new SQLiteCommand(this.connection))
            {
                command.CommandText = "" +
                    "select t.ID, t.Name " +
                    "from Topic as t " +
                    "join CourseTopic as ct " +
                    "on t.ID = ct.TopicID " +
                    "join Course as c " +
                    "on ct.CourseID = c.ID " +
                    "where c.Name = @courseName;";

                command.Parameters.AddWithValue("@courseName", courseName);

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        yield return reader.GetValues();
                }
            }
        }
    }
}
