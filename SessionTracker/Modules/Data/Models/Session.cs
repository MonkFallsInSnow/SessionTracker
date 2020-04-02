using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionTracker.Modules.Data.Models
{
    class Session
    {
        public int ID { get; private set; }
        public DateTime Timestamp { get; set; }
        public string StudentID { get; set; }
        public int CourseID { get; set; }
        public int CampusID { get; set; }
        public int CenterID { get; set; }
        public int TutorID { get; set; }
        public int TopicID { get; set; }
        public string Notes { get; set; }
        public bool IsWorkshop { get; set; }

        public Session(int id)
        {
            this.ID = id;
        }
    }
}
