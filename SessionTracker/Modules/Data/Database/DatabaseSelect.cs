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

        /*
        public int GetReferenceID(string sourceTable, string referenceTable, string filterColumn, string filterValue)
        {
            using (SQLiteCommand command = new SQLiteCommand(this.connection))
            {
                command.CommandText = $"select ID from @referenceTable " +
                    "join @referenceTable on @referenceTable.ID = @sourceTable.ID " +
                    "where @sourceTable.@filterColumn = @filterValue;";

                command.Parameters.AddWithValue("@referenceTable", referenceTable);
                command.Parameters.AddWithValue("@sourceTable", sourceTable);
                command.Parameters.AddWithValue("@filterColumn", filterColumn);
                command.Parameters.AddWithValue("@filterValue", filterValue);

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    return reader.GetInt32(0);
                }
            }
        }
        */
        /*
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

        public IList<object> GetTutors()
        {
            IList<object> tutors = new BindingList<object>();

            using (SQLiteCommand command = new SQLiteCommand(this.connection))
            {
                command.CommandText = "select ID, FName, Lname, IsActive from Tutor";

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tutors.Add(new Tutor(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetBoolean(3)));
                    }
                }
            }

            return tutors;
        }

        public IList<object> GetTopics()
        {
            IList<object> topics = new BindingList<object>();

            using (SQLiteCommand command = new SQLiteCommand(this.connection))
            {
                command.CommandText = "select ID, Description from Topic";

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        topics.Add(new Topic(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(0)));
                    }
                }
            }

            return topics;
        }
        */
    }
}
