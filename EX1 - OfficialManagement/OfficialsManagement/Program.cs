using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficialsManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            OfficialsManagement manager = new OfficialsManagement();
            while (true)
            {
                Console.WriteLine("--------MENU--------");
                Console.WriteLine("1. Add new official");
                Console.WriteLine("2. Search official by name");
                Console.WriteLine("3. Show all officials\' infomation");
                Console.WriteLine("4. Exit");
                Console.Write("Your choice : ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        manager.AddOfficial();
                        break;
                    case 2:
                        break;
                    case 3:
                        manager.DisplayListOfOfficials();
                        Console.ReadLine();
                        break;
                    case 4:
                        return;
                }

                Console.Clear();
            }


        }
    }
}
