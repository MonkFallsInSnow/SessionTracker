using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionTracker.Modules.Data.Database
{
    class DatabaseWriter : IInvoker<IDatabaseWriteCommand, int>
    {
        public IDatabaseWriteCommand Command { get; set; }

        public DatabaseWriter()
        {
        }

        public DatabaseWriter(IDatabaseWriteCommand command)
        {
            this.Command = command;
        }

        public virtual int ExecuteCommand()
        {
            try
            {
                return this.Command.Execute();
            }
            catch (SQLiteException ex)
            {
                throw new SQLiteException(ex.Message);
            }
        }
    }
}
