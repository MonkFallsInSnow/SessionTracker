using SessionTracker.Modules.Data.Database.Commands;
using SessionTracker.Modules.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionTracker
{
    public partial class SessionTrackerMainForm
    {
        private IEnumerable<NameValueCollection> GetTutorsByCampus(string campus)
        {
            try
            {
                return this.database.Read(
                    DbCommandResource.SelectTutorsByCampus,
                    new Dictionary<string, string>()
                    {
                    { DbCommandResource.CampusParameterKey, campus }
                    });
            }
            catch (Exception)
            {
                return default;
            }
        }

        private string GetLastSessionID()
        {
            try
            {
                var id = this.database.Read(
                    DbCommandResource.SelectLastRowID,
                    new Dictionary<string, string>()
                    {
                    { DbCommandResource.TableParameterKey, "Session" }
                    })
                    .FirstOrDefault();

                return id == null ? "0" : (Convert.ToInt32(id[0]) + 1).ToString();
            }
            catch (Exception)
            {
                return default;
            }
        }

        private string GetCampusID(string campus)
        {
            try
            {
                return this.database.Read(
                    DbCommandResource.SelectCampus,
                    new Dictionary<string, string>()
                    {
                    { DbCommandResource.CampusParameterKey, campus }
                    })
                    .First()[0]
                    .ToString();
            }
            catch (Exception)
            {
                return default;
            }
        }

        private string GetCourseID(string course)
        {
            try
            {
                return this.database.Read(
                    DbCommandResource.SelectCourse,
                    new Dictionary<string, string>()
                    {
                    { DbCommandResource.CourseParameterKey, course }
                    })
                    .First()[0]
                    .ToString();
            }
            catch (Exception)
            {
                return default;
            }
        }

        private string GetCenterID(string center)
        {
            try
            {
                return this.database.Read(
                    DbCommandResource.SelectCenter,
                    new Dictionary<string, string>()
                    {
                    { DbCommandResource.CenterParameterKey, center }
                    })
                    .First()[0]
                    .ToString();
            }
            catch (Exception)
            {
                return default;
            }
        }

        private int LogSession(NameValueCollection session)
        {
            int rowCount = 0;

            try
            {
                //check to see if student already in database
                string studentID = this.database.Read(
                    DbCommandResource.SelectStudentByID,
                    new Dictionary<string, string>()
                    {
                        { DbCommandResource.IdParameterKey, session["ID"] }
                    })
                    .FirstOrDefault()[0];
                
                if(String.IsNullOrEmpty(studentID))
                {
                    //add student
                }

                
                //add session data to Session table
                //add session topic data to SessionTopic table

                return rowCount;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        private IEnumerable<NameValueCollection> GetTopicsByCourse(string course)
        {
            try
            {
                return this.database.Read(
                    DbCommandResource.SelectTopicsByCourse,
                    new Dictionary<string, string>()
                    {
                    { DbCommandResource.CourseParameterKey, course }
                    });
            }
            catch (Exception)
            {
                return default;
            }
        }
    }
}
