using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWPF
{
    //Course Number 5000-9999 are graduate courses.
    class GraduateStudent: Person
    {
        public List<string> GradStudentID = new List<string>();

        private string studentID;

        public GraduateStudent()
        {

        }

        public string StudentID
        {
            get
            {
                return studentID;
            }
            set
            {
                studentID = value;
            }
        }
    }
}
