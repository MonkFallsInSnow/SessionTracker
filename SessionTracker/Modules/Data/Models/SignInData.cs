using System;

namespace SessionTracker.Modules.Data.Models
{
    public class SignInData
    {
        public readonly DateTime Timestamp;
        public readonly string StudentID;
        public readonly string FName;
        public readonly string LName;
        public readonly string Course;
        public readonly string Center;
        public readonly string Campus;

        public SignInData(string id, string fname, string lname, string course, string center, string campus)
        {
            this.Timestamp = DateTime.Now;
            this.StudentID = id;
            this.FName = fname;
            this.LName = lname;
            this.Course = course;
            this.Center = center;
            this.Campus = campus;
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

            //TODO: consider adding timestamp to this
            return this.StudentID == data.StudentID && this.Course == data.Course;
        }
    }
}

