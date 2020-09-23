using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program2
{
    class Program
    {
        static void Main(string[] args)
        {
            int Length = int.Parse(Console.ReadLine());

            float[] Array = new float[Length];

            string[] InputElements = Console.ReadLine().Split();

            //Intialize array elements with user input 
            for(int i = 0; i < Length; i++)
            {
                Array[i] = float.Parse(InputElements[i]);
            }

            HeapSort(Array);

            //Print sorted array
            for (int i = 0; i < Length; i++)
            {
                Console.Write(Array[i] + " ");
            }
            
        }

        public static void HeapSort(float[] Array)
        { 
            //Make heap 
            for (int i = Array.Length / 2 - 1; i >= 0; i--)
                Heapify(Array, Array.Length, i);

            //Go through each element in heap
            for (int i = Array.Length - 1; i > 0; i--)
            {
                Swap(Array, 0, i);  //Swap current root to move to the end 
                Heapify(Array, i, 0);
            }
        }

        static void Heapify(float[] Array, int ArrayLength, int root)
        {
            int Largest = root; 
            int Left = 2 * root + 1;
            int Right = 2 * root + 2;

            if(Left < ArrayLength && Array[Left] > Array[Largest])
            {
                Largest = Left;
            }
         
            if(Right < ArrayLength && Array[Right] > Array[Largest])
            {
                Largest = Right;
            }
                
            if(Largest != root)
            {
                Swap(Array, root, Largest);
                Heapify(Array, ArrayLength, Largest);
            }
        }

        static void Swap(float[] Array, int index1, int index2)
        {
            float temp = Array[index1];
            Array[index1] = Array[index2];
            Array[index2] = temp;
        }
    }
}
