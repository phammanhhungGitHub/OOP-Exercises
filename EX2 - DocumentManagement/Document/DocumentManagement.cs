using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Document
{
    class DocumentManagement
    {
        private List<Book> bookList = new List<Book>();
        private List<Magazine> magazinesList = new List<Magazine>();

        public void AddNewDocument()
        {
            int choiceDocument;
            do
            {
                Console.WriteLine("Choose type of document: 1. Book  2. Magazine");
                Console.Write("Your choice: ");
                choiceDocument = Convert.ToInt32(Console.ReadLine());
                if (choiceDocument != 1 && choiceDocument != 2)
                {
                    Console.WriteLine("Please choose again!");
                }
            } while (choiceDocument != 1 && choiceDocument != 2);

            Console.Write("ID: ");
            string id = Console.ReadLine();
            Console.Write("Publisher: ");
            string publisher = Console.ReadLine();
            Console.Write("Number: ");
            int number = Convert.ToInt32(Console.ReadLine());
            if (choiceDocument == 1)
            {
                Console.Write("Author: ");
                string author = Console.ReadLine();
                Console.WriteLine("Pages: ");
                int pages = Convert.ToInt32(Console.ReadLine());
                Book book = new Book(id, publisher, number, author, pages);
                bookList.Add(book);
            }
            else
            {
                Console.WriteLine("Issue: ");
                int issue = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Month: ");
                int month = Convert.ToInt32(Console.ReadLine());
                Magazine magazine = new Magazine(id, publisher, number, issue, month);
                magazinesList.Add(magazine);
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Book: ");
            if (bookList.Count() != 0)
            {
                Console.WriteLine();
                foreach (Book book in bookList)
                {
                    book.Display();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("0 book\n");
            }

            Console.WriteLine("Magazines: ");
            if (magazinesList.Count() != 0)
            {
                Console.WriteLine();
                foreach (Magazine magazine in magazinesList)
                {
                    magazine.Display();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("0 magazine\n");
            }
        }

        public void SearchDocument()
        {
            int choiceDocument;
            do
            {
                Console.WriteLine("Choose type of document: 1. Book  2. Magazine");
                Console.Write("Your choice: ");
                choiceDocument = Convert.ToInt32(Console.ReadLine());
                if (choiceDocument != 1 && choiceDocument != 2)
                {
                    Console.WriteLine("Please choose again!");
                }
            } while (choiceDocument != 1 && choiceDocument != 2);

            Console.WriteLine("ID: ");
            string id = Console.ReadLine();
            if (choiceDocument == 1)
            {
                foreach (Book book in bookList)
                {
                    if (book.ID == id)
                    {
                        book.Display();
                        return;
                    }
                }
            }
            else
            {
                foreach (Magazine magazine in magazinesList)
                {
                    if (magazine.ID == id)
                    {
                        magazine.Display();
                        return;
                    }
                }
            }
            Console.WriteLine("Not found");
        }
    }
}
