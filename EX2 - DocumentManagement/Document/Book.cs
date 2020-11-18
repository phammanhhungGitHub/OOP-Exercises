using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document
{
    class Book : Document
    {
        private string author;
        private int pages;

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
        public int Pages
        {
            get
            {
                return pages;
            }
            set
            {
                if (value <= 0)
                {
                    pages = 1;
                    Console.WriteLine("Invalid! Number of pages is set to 1");
                }
                else
                {
                    pages = value;
                }
            }
        }

        public Book(string id, string publisher, int number, string author, int pages)
            : base(id, publisher, number)
        {
            this.Author = author;
            this.Pages = pages;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Author: {author}\nPages: {pages}");
        }
    }
}
