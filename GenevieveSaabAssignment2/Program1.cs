using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1
{
    struct Date
    {
        int year;
        int month;
        int day;

        public Date(int year, int month, int day)
        {
            this.year = year;
            this.month = month;
            this.day = day;
        }
        public Date(string dateString)
        {
            string[] dateInfo = dateString.Split('/');
            month = int.Parse(dateInfo[0]);
            day = int.Parse(dateInfo[1]);
            year = int.Parse(dateInfo[2]);
        }

        public void PrintInformation()
        {
            string[] months = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", 
                                                "Jul", "Aug", "Sept", "Oct", "Nov", "Dec"};
            
            Console.WriteLine("Today is " + months[month - 1] + ", "+ day + ", " + year); 
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int option = int.Parse(Console.ReadLine());

            if(option == 1)
            {
                string inputString = Console.ReadLine();
                string[] inputElements = inputString.Split();

                int year = int.Parse(inputElements[0]);
                int month = int.Parse(inputElements[1]);
                int day = int.Parse(inputElements[2]);

                Date d = new Date(year, month, day);

                d.PrintInformation();
            }

            if(option == 2)
            {
                string inputString = Console.ReadLine();

                Date d = new Date(inputString);

                d.PrintInformation();
            }
        }
    }
}
