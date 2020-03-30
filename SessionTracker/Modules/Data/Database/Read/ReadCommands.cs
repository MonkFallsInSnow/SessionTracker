using System.Collections.Generic;


namespace SessionTracker.Modules.Data.Database
{
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
