using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document
{
    class Program
    {
        static void Main(string[] args)
        {
            DocumentManagement manager = new DocumentManagement();
            bool continueProgram = true;
            while (continueProgram)
            {
                int choice;
                do
                {
                    Console.WriteLine("------MENU------");
                    Console.WriteLine("1. Add new document\n2. Display documents\' information");
                    Console.WriteLine("3. Search document\n4. Exit");
                    Console.Write("Your choice: ");
                    choice = Convert.ToInt32(Console.ReadLine());
                    if (choice < 1 || choice > 4)
                    {
                        Console.WriteLine("Please choose again");
                    }
                } while (choice < 1 || choice > 4);

                switch (choice)
                {
                    case 1:
                        manager.AddNewDocument();
                        break;
                    case 2:
                        manager.DisplayInfo();
                        Console.ReadLine();
                        break;
                    case 3:
                        manager.SearchDocument();
                        break;
                    case 4:
                        continueProgram = false;
                        break;
                }

                Console.Clear();
            }
        }
    }
}
