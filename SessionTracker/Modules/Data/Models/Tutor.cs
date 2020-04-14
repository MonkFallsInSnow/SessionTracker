using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SessionTracker.Modules.Data.Models
{
    public class Tutor : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int id;
        private string fname;
        private string lname;
        private bool isActive;

        public int ID
        {
            get => this.id;
            set
            {
                this.id = value;
                NotifyPropertyChanged();
            }
        }

        public string FName
        {
            get => this.fname;
            set
            {
                this.fname = value;
                NotifyPropertyChanged();
            }
        }

        public string LName
        {
            get => this.lname;
            set
            {
                this.lname = value;
                NotifyPropertyChanged();
            }
        }

        public string FullName
        {
            get => this.fname + " " + this.lname;
        }

        public bool IsActive
        {
            get => this.isActive;
            set
            {
                this.isActive = value;
                NotifyPropertyChanged();
            }
        }

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

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
