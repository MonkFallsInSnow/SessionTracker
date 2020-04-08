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
        public string Name { get; set; }

        public Topic(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
