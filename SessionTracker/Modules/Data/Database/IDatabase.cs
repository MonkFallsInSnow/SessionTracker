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
        IEnumerable<NameValueCollection> Read(string commandText, Dictionary<string, string> parameters = null);
        int Write(string commandText, Dictionary<string, string> parameters = null);

    }
}