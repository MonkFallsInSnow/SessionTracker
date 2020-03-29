using SessionTracker.Modules.Commands;
using System.Collections.Generic;

namespace SessionTracker.Modules.Data
{
    public interface Invoker<T, U>
    {
        T Command { get; set; }
        U ExecuteCommand();
    }

    class DatabaseReader : Invoker<IDatabaseReadCommand, IList<object>>
    {
        public IDatabaseReadCommand Command { get; set; }
        
        public DatabaseReader(IDatabaseReadCommand command)
        {
            this.Command = command;
        }

        public virtual IList<object> ExecuteCommand()
        {
            return this.Command.Execute();
        }
    }

    class DatabaseWriter : Invoker<IDatabaseWriteCommand, int>
    {
        public IDatabaseWriteCommand Command { get; set; }

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
