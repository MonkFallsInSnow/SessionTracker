using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

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
            return this.database.QuickLookUp("ID, Name", "Campus");
        }
    }

    class GetTutorsByCampusCommand : BaseReadCommand
    {
        private string campusName;

        public GetTutorsByCampusCommand(IDatabase database, string campusName) : base(database)
        {
            this.campusName = campusName;
        }

        public override IEnumerable<NameValueCollection> Execute()
        {
            return this.database.SelectTutorsByCampus(campusName);
            
        }
    }

    class GetTopicsCommand : BaseReadCommand
    {
        //private string courseID;

        public GetTopicsCommand(IDatabase database) : base(database)
        {
        }

        public override IEnumerable<NameValueCollection> Execute()
        {
            return this.database.QuickLookUp("ID, Description, CourseID", "Topic");
        }
        /*
        public GetTopicsCommand(IDatabase database, int courseID) : base(database)
        {
            this.courseID = courseID.ToString();
        }

        public GetTopicsCommand(IDatabase database, string courseName) : base(database)
        {
            NameValueCollection id = this.database.QuickLookUp("ID", "Course", "Name", courseName).FirstOrDefault();
            this.courseID = id["ID"] == null ? string.Empty : id["ID"];
        }

        public override IEnumerable<NameValueCollection> Execute()
        {
            return this.database.QuickLookUp("ID, Description, CourseID", "Topic", "CourseID", this.courseID);
        }
        */
    }

    class GetReferenceIDCommand : BaseReadCommand
    {
        private string column;
        private string identifier;

        public GetReferenceIDCommand(IDatabase database, string column, string identifier) : base(database)
        {
            this.column = column;
            this.identifier = identifier;
        }

        public override IEnumerable<NameValueCollection> Execute()
        {
            return this.database.QuickLookUp("ID", column, "Name", identifier);
        }
    }

    class GetLastInsertedRowIDCommand : BaseReadCommand
    {
        private string table;

        public GetLastInsertedRowIDCommand(IDatabase database, string table) : base(database)
        {
            this.table = table;
        }

        public override IEnumerable<NameValueCollection> Execute()
        {
            return this.database.QuickLookUp("seq", "sqlite_sequence", "Name", table);
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
