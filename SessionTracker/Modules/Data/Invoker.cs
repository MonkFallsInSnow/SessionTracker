using SessionTracker.Modules.Commands;
using System.Collections.Generic;

namespace SessionTracker.Modules.Data
{
    class Invoker<T>
    {
        public IDatabaseCommand Command { get; set; }

        public object ExecuteCommand()
        {
            return this.Command.Execute();
        }

    }
}
