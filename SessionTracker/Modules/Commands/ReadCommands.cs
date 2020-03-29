using SessionTracker.Modules.Data;
using SessionTracker.Modules.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionTracker.Modules.Commands
{
    public interface IDatabaseCommand
    {
        object Execute();
    }

    class GetCampusesCommand : IDatabaseCommand
    {
        private readonly IDatabase database;

        public GetCampusesCommand(IDatabase database)
        {
            this.database = database;
        }

        public object Execute()
        {
            return this.database.GetCampuses();
        }
    }
    
}
