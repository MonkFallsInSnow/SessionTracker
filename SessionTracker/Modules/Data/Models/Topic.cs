using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionTracker.Modules.Data.Models
{
    public class Topic
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int CourseID { get; set; }

        public Topic(int id, string description, int courseID)
        {
            this.ID = id;
            this.Description = description;
            this.CourseID = courseID;
        }

        public override string ToString()
        {
            return $"{this.Description}";
        }
    }
}
