using SessionTracker.Modules.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SQLite;

namespace SessionTracker.Modules.Data
{
    public interface IDatabase : IDisposable
    {
        SQLiteConnection Connection { get; }
        IList<object> GetCampuses();
        IList<object> GetTutors();
        IList<object> GetTopics();
        IEnumerable<NameValueCollection> LookUp(string columns, string table);
        IEnumerable<NameValueCollection> LookUpWhere(string columns, string table, string whereClause);
    }
}