using System.Collections.Generic;


namespace SessionTracker.Modules.Data.Database
{
    abstract class BaseReadCommand : IDatabaseReadCommand
    {
        protected readonly IDatabase database;

        public BaseReadCommand(IDatabase database)
        {
            this.database = database;
        }

        public abstract IList<object> Execute();
    }

    class GetCampusesCommand : BaseReadCommand
    {
        public GetCampusesCommand(IDatabase database) : base(database)
        {
        }

        public override IList<object> Execute()
        {
            return this.database.GetCampuses();
        }
    }

    class GetTutorsCommand : BaseReadCommand
    {
        public GetTutorsCommand(IDatabase database) : base(database)
        {
        }

        public override IList<object> Execute()
        {
            return this.database.GetTutors();
        }
    }

    class GetTopicsCommand : BaseReadCommand
    {
        public GetTopicsCommand(IDatabase database) : base(database)
        {
        }

        public override IList<object> Execute()
        {
            return this.database.GetTopics();
        }
    }

}
