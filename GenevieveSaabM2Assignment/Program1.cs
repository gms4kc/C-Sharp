using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1
{
    class Program
    {
        static void Main(string[] args)
        {
            int InputNumber = int.Parse(Console.ReadLine());
            List<int> PrimeNumbers = new List<int>();

            for(int Integer = 2; Integer <= InputNumber; Integer++)
            {
                //Check if prime
                if(IsPrime(Integer) == true)
                {
                    PrimeNumbers.Add(Integer);
                }
            } 

            //Print PrimeNumbers
            for(int Index = 0; Index < PrimeNumbers.Count; Index++)
            {
                Console.Write(PrimeNumbers[Index] + " ");
            }

        }

        public static bool IsPrime(int number)
        {
            for(int Integer = 2; Integer < number; Integer++)
            {
                if(number % Integer == 0)
                {
                    return false;
                }
            }

            return true; 
        }
    }
}
