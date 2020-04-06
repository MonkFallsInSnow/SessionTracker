using SessionTracker.Modules.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionTracker.Modules.Data.Database
{
    abstract class BaseWriteCommand : IDatabaseWriteCommand
    {
        protected readonly IDatabase database;

        public BaseWriteCommand(IDatabase database)
        {
            this.database = database;
        }

        public abstract int Execute();

        public virtual int Execute(Func<int> func)
        {
            using (SQLiteTransaction transaction = this.database.Connection.BeginTransaction())
            {
                try
                {
                    int rowCount = func();
                    transaction.Commit();
                    return rowCount;
                }
                catch (SQLiteException ex)
                {
                    transaction.Rollback();
                    throw new SQLiteException(ex.Message);
                }
            }
        }
    }

    class LogSessionCommand : BaseWriteCommand
    {
        private NameValueCollection session;

        public LogSessionCommand(IDatabase database, NameValueCollection session) : base(database)
        {
            this.session = session;
        }

        public override int Execute()
        {
            return this.Execute(() =>
            {
                return this.database.InsertSession(this.session);
            });
        }
    }
}
