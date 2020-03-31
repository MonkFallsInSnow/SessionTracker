using SessionTracker.Modules.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionTracker.Modules.Data.Database
{
    partial class Database
    {
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
            return null;
        }

        public IList<object> GetTopics()
        {
            return null;
        }
    }
}
