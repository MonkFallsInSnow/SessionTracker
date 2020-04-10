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

    class GetTopicsByCourseCommand : BaseReadCommand
    {
        private string courseName;

        public GetTopicsByCourseCommand(IDatabase database, string courseName) : base(database)
        {
            this.courseName = courseName;
        }

        public override IEnumerable<NameValueCollection> Execute()
        {
            return this.database.SelectTopicsByCourse(courseName);
        }
        
    }

    class GetReferenceIDCommand : BaseReadCommand
    {
        private string table;
        private string where;
        private string value;

        public GetReferenceIDCommand(IDatabase database, string table, string where, string value) : base(database)
        {
            this.table = table;
            this.where = where;
            this.value = value;
        }

        public override IEnumerable<NameValueCollection> Execute()
        {
            return this.database.QuickLookUp("ID", table, where, value);
        }
    }

    class GetReferenceIDComplexCommand : BaseReadCommand
    {
        private string table;
        private string whereExpression;

        public GetReferenceIDComplexCommand(IDatabase database, string table, string whereExpression) : base(database)
        {
            this.table = table;
            this.whereExpression = whereExpression;
        }

        public override IEnumerable<NameValueCollection> Execute()
        {
            return this.database.QuickLookUp("ID", table, whereExpression);
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
   
}
