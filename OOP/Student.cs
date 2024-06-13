using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Student
    {
        public string name;
        public string major;
        public double gpa;

        public Student(string name, string major, double gpa)
        {
            this.name = name;
            this.major = major;
            this.gpa = gpa;
        }

        // OBJECT METHOD
        // find out if student is honor student
        public bool HasHonors()
        {
            if (this.gpa >= 3.5)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
