using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document
{
    class Magazine : Document
    {
        private int issue;
        private int month;

        public int Issue
        {
            get
            {
                return issue;
            }
            set
            {
                if (value <= 0)
                {
                    issue = 1;
                    Console.WriteLine("Invalid! Issue is set to 1");
                }
                else
                {
                    issue = value;
                }
            }
        }
        public int Month
        {
            get
            {
                return month;
            }
            set
            {
                if (value <= 0 || month > 12)
                {
                    month = 1;
                    Console.WriteLine("Invalid! Month is set to 1");
                }
                else
                {
                    month = value;
                }
            }
        }

        public Magazine(string id, string publisher, int number, int issue, int month)
            : base(id, publisher, number)
        {
            this.Issue = issue;
            this.Month = month;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Issue: {issue}\nMonth: {month}");
        }
    }
}
