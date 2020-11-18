using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document
{
    class Document
    {
        protected string id;
        protected string publisher;
        protected int number;

        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public string Publisher
        {
            get
            {
                return publisher;
            }
            set
            {
                publisher = value;
            }
        }
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                if (value <= 0)
                {
                    number = 1;
                    Console.WriteLine("Invalid! Number is set to 1");
                }
                else
                {
                    number = value;
                }
            }
        }

        public Document(string id, string publisher, int number)
        {
            this.id = id;
            this.publisher = publisher;
            this.Number = number;
        }

        public virtual void Display()
        {
            Console.WriteLine($"ID: {id}\nPublisher: {publisher}\nNumber: {number}");
        }
    }
}
