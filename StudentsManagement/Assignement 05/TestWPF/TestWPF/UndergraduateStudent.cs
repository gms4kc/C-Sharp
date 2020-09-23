using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWPF
{
    //Course Number 1000-4999 are undergraduate courses.
    class UndergraduateStudent: Person 
    {
        public List<string> UndergradStudentID = new List<string>();
        
        private string studentID;

        public UndergraduateStudent()
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
