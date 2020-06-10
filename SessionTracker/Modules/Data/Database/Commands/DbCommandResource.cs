using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionTracker.Modules.Data.Database.Commands
{
    internal static class DbCommandResource
    {
        internal static readonly string CampusParameterKey = "@campus";
        internal static readonly string TableParameterKey = "@table";
        internal static readonly string CourseParameterKey = "@course";
        internal static readonly string CenterParameterKey = "@center";
        internal static readonly string IdParameterKey = "@id";
        internal static readonly string FirstNameParameterKey = "@fname";
        internal static readonly string LastNameParameterKey = "@lname";
        internal static readonly string NameParameterKey = "@name";

        internal static readonly string SelectTutorsByCampus = "" +
            "select t.ID, t.FName, t.LName, t.IsActive " +
            "from Tutor as t " +
            "join TutorCampus as tc on t.ID = tc.TutorID " +
            "join Campus as c on tc.CampusID = c.ID " +
            "where c.Name = " + CampusParameterKey;
        
        internal static readonly string SelectStudentByName = "" +
            "select * from Student where FName = " + FirstNameParameterKey +
            " and LName = " + LastNameParameterKey;

        internal static readonly string SelectTopicsByCourse = "" +
                    "select t.ID, t.Name " +
                    "from Topic as t " +
                    "join CourseTopic as ct " +
                    "on t.ID = ct.TopicID " +
                    "join Course as c " +
                    "on ct.CourseID = c.ID " +
                    "where c.Name = " + CourseParameterKey;

        internal static readonly string SelectLastRowID = "select seq from sqlite_sequence where Name = " + TableParameterKey;
        internal static readonly string SelectCampus = "select * from Campus where Name = " + CampusParameterKey;
        internal static readonly string SelectCourse = "select * from Course where Name = " + CourseParameterKey;
        internal static readonly string SelectCenter = "select * from Center where Name = " + CenterParameterKey;
        internal static readonly string SelectTopics = "select * from Topic where Name = " + NameParameterKey;
        internal static readonly string SelectStudentByID = "select * from Student where ID = " + IdParameterKey;
        internal static readonly string SelectCampuses = "select ID, Name from Campus";
    }
}
