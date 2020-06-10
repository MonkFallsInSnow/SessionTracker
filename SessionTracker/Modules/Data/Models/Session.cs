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
        public string FName { get; set; }
        public string LName { get; set; }
        public IDNamePair Course { get; set; }
        public IDNamePair Campus { get; set; }
        public IDNamePair Center { get; set; }
        public Tutor Tutor { get; set; }
        public List<IDNamePair> Topics { get; set; }
        public string Notes { get; set; }
        public bool IsWorkshop { get; set; }

        public Session(string id)
        {
            this.ID = id;
            this.Topics = new List<IDNamePair>();
        }
    }
}
