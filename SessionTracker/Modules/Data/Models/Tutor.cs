using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionTracker.Modules.Data.Models
{
    public class Tutor
    {
        public int ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public bool IsActive { get; set; }

        public Tutor(int id, string fname, string lname, bool isActive = true)
        {
            this.ID = id;
            this.FName = fname;
            this.LName = lname;
            this.IsActive = isActive;
        }

        public override string ToString()
        {
            return $"{this.FName} {this.LName}";
        }
    }
}
