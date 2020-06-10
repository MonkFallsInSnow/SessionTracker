using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionTracker.Modules.Data.Models
{
    public class IDNamePair
    {
        public string ID { get; private set; }
        public string Name { get; private set; }

        public IDNamePair(string id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
