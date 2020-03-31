using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SQLite;

namespace SessionTracker.Modules.Data.Database
{
    abstract class BaseReadCommand : IDatabaseReadCommand
    {
        protected readonly IDatabase database;

        public BaseReadCommand(IDatabase database)
        {
            this.database = database;
        }

        public abstract IEnumerable<NameValueCollection> Execute();
    }

    class GetCampusesCommand : BaseReadCommand
    {
        public GetCampusesCommand(IDatabase database) : base(database)
        {
        }

        public override IEnumerable<NameValueCollection> Execute()
        {
            return this.database.LookUp("ID, Name", "Campus");
        }
    }

    class GetTutorsCommand : BaseReadCommand
    {
        public GetTutorsCommand(IDatabase database) : base(database)
        {
        }

        public override IEnumerable<NameValueCollection> Execute()
        {
            return this.database.LookUpWhere("ID, FName, LName, IsActive", "Tutor", "where IsActive = 1");
        }
    }

    class GetTopicsCommand : BaseReadCommand
    {
        public GetTopicsCommand(IDatabase database) : base(database)
        {
        }

        public override IEnumerable<NameValueCollection> Execute()
        {
            return this.database.LookUp("ID, Description, CourseID", "Topic");
        }
    }
    /*
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
    */
}
