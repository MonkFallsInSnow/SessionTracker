using System.Collections.Generic;

namespace SessionTracker.Modules.Data.Database
{
    class DatabaseReader : IInvoker<IDatabaseReadCommand, IList<object>>
    {
        public IDatabaseReadCommand Command { get; set; }
        
        public DatabaseReader()
        {
        }

        public DatabaseReader(IDatabaseReadCommand command)
        {
            this.Command = command;
        }

        public virtual IList<object> ExecuteCommand()
        {
            return this.Command.Execute();
        }
    }
}
