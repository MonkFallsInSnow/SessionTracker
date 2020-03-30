using System;
using System.Collections.Generic;
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
            return this.Command.Execute();
        }
    }
}
