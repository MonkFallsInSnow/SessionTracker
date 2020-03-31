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
        public IEnumerable<NameValueCollection> LookUp(string columns, string table)
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

        //TODO: this is open to sqlinjection attack (whereClause param)
        public IEnumerable<NameValueCollection> LookUpWhere(string columns, string table, string whereClause)
        {
            using (SQLiteCommand command = new SQLiteCommand(this.connection))
            {
                command.CommandText = $"select {columns} from {table} {whereClause}";

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        yield return reader.GetValues();
                }
            }
        }

        public SQLiteDataReader LookUpComplex(string commandText)
        {
            using (SQLiteCommand command = new SQLiteCommand(this.connection))
            {
                command.CommandText = commandText;
                return command.ExecuteReader();
            }
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
    }
}
