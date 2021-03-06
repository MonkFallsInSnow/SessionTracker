﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SessionTracker.Modules.Data.Models
{
    public class SignInData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string center;
        private string campus;
        private string fname;
        private string lname;
        private string studentID;
        private string course;

        public DateTime Timestamp { get; private set; }

        public string StudentID
        {
            get => this.studentID;
            set
            {
                this.studentID = value;
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

        public string FName
        {
            get => this.fname;
            set
            {
                this.fname = value;
                NotifyPropertyChanged();
            }
        }

        public string Campus
        {
            get => this.campus;
            set
            {
                this.campus = value;
                NotifyPropertyChanged();
            }
        }

        public string Center
        {
            get => this.center;
            set
            {
                this.center = value;
                NotifyPropertyChanged();
            }
        }

        public string Course
        {
            get => this.course;
            set
            {
                this.course = value;
                NotifyPropertyChanged();
            }
        }

        public SignInData(string center, string campus, string id, string fname, string lname, string course)
        {
            this.Timestamp = DateTime.Now;
            this.Center = center;
            this.Campus = campus;
            this.StudentID = id;
            this.FName = fname;
            this.LName = lname;
            this.Course = course;
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public static bool operator ==(SignInData a, SignInData b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(SignInData a, SignInData b)
        {
            return !a.Equals(b);
        }

        public override int GetHashCode()
        {
            return this.StudentID.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            SignInData data = (SignInData)obj;

            return this.StudentID == data.studentID &&
                this.FName == data.FName &&
                this.LName == data.LName &&
                this.Course == data.Course;
        }
    }
}

