using SessionTracker.Modules.Data;
using System.Collections.Generic;


namespace SessionTracker.Modules.Commands
{
    public interface IDatabaseCommand<T>
    {
        T Execute();
    }

    public interface IDatabaseReadCommand : IDatabaseCommand<IList<object>>
    {
    }

    public interface IDatabaseWriteCommand : IDatabaseCommand<int>
    {
    }

    class GetCampusesCommand : IDatabaseReadCommand
    {
        private readonly IDatabase database;

        public GetCampusesCommand(IDatabase database)
        {
            this.database = database;
        }

        public IList<object> Execute()
        {
            return this.database.GetCampuses();
        }
    }
    
}
