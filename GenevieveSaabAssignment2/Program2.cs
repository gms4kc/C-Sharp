using System;
using System.Collections.Generic;
using System.Reflection;

namespace Program2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] userInput = Console.ReadLine().Split();
            int numOfBooks = int.Parse(userInput[0]);
            int option = int.Parse(userInput[1]);

            List<Book> books = new List<Book>();

            for (int i = 0; i < numOfBooks; i++)
            {
                string title = Console.ReadLine();
                string author = Console.ReadLine();
                double price = double.Parse(Console.ReadLine());
                string isbn = Console.ReadLine();

                books.Add(new Book(title, author, price, isbn));
            }

            if (option == 1)
            {
                for(int i = 0; i < books.Count - 1; i++)
                {
                    for(int j = 0; j < books.Count - i - 1; j++)
                    {
                        if(books[j].Price > books[j + 1].Price)
                        {
                            Book temp = books[j];
                            books[j] = books[j + 1];
                            books[j + 1] = temp;
                        }
                    }
                }

            }

            if(option == 2)
            {
                for (int i = 0; i < books.Count - 1; i++)
                {
                    for (int j = 0; j < books.Count - i - 1; j++)
                    {
                        if (books[j].Title[0] > books[j + 1].Title[0])
                        {
                            Book temp = books[j];
                            books[j] = books[j + 1];
                            books[j + 1] = temp;
                        }
                        else if(books[j].Title[1] > books[j + 1].Title[1])
                        {
                            Book temp = books[j];
                            books[j] = books[j + 1];
                            books[j + 1] = temp;
                        }
                        else if(books[j].Title[2] > books[j + 1].Title[2])
                        {
                            Book temp = books[j];
                            books[j] = books[j + 1];
                            books[j + 1] = temp;
                        }
                    }
                }

            }

            for(int i = 0; i < books.Count; i++)
            {
                books[i].PrintInformation();
                Console.WriteLine();
            }
        }
    }

    class Book
    {
        private string title;
        private string author;
        private double price;
        private string isbn;

        public Book(string title, string author, double price, string isbn)
        {
            Title = title;
            Author = author;
            Price = price;
            ISBN = isbn;
        }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public string Author
        {
            get
            {
                return author;
            }
            set
            {
                author = value;
            }
        }

        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }

        public string ISBN
        {
            get
            {
                return isbn;
            }
            set
            {
                isbn = value;
            }
        }

        public void PrintInformation()
        {
            Console.WriteLine(Title + " written by " + Author + " is " + Price + " dollars, with ISBN " + ISBN);
        }
    }
}
