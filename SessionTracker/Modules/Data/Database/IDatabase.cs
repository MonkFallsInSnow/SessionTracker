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
        IEnumerable<NameValueCollection> QuickLookUp(string columns, string table);
        IEnumerable<NameValueCollection> QuickLookUp(string columns, string table, string whereColumn, string value);
        IEnumerable<NameValueCollection> SelectTutorsByCampus(string campusName);
        IEnumerable<NameValueCollection> SelectTopicsByCourse(string courseName);
        int InsertSession(NameValueCollection session);
    }
}