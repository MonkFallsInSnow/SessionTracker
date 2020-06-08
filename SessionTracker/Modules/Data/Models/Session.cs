using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionTracker.Modules.Data.Models
{
    class Session
    {
        public string ID { get; private set; }
        public DateTime Timestamp { get; set; }
        public string StudentID { get; set; }
        public string CourseID { get; set; }
        public string CampusID { get; set; }
        public string CenterID { get; set; }
        public string TutorID { get; set; }
        public string TopicID { get; set; }
        public string Notes { get; set; }
        public bool IsWorkshop { get; set; }

        public Session(string id)
        {
            this.ID = id;
        }
    }
}
