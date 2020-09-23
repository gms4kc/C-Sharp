using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWPF
{
    //Course Number 1000-4999 are undergraduate courses.
    //Course Number 5000-9999 are graduate courses.

    class Course
    {
        public List<List<Course>> Courses = new List<List<Course>>();

        private string courseName;
        private int courseNumber;
        private int creditHours;
        private double gpa; 

        public Course()
        {

        }

        public string CourseName
        {
            get
            {
                return courseName;
            }
            set
            {
                courseName = value;
            }
        }

        public int CourseNumber
        {
            get
            {
                return courseNumber;
            }
            set
            {
                courseNumber = value;
            }
        }

        public int CreditHours
        {
            get
            {
                return creditHours;
            }
            set
            {
                creditHours = value;
            }
        }

        public double GPA
        {
            get
            {
                return gpa;
            }
            set
            {
                gpa = value;
            }
        }
    }
}
