using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficialsManagement
{
    class OfficialsManagement
    {
        private List<Official> officialList = new List<Official>();

        public void AddOfficial()
        {
            int choice;
            do
            {
                Console.WriteLine("Who do you want to add : "); ;
                Console.WriteLine("1. Worker\n2. Engineer\n3. Staff");
                Console.Write("Your choice : ");
                choice = int.Parse(Console.ReadLine());
                if (choice < 1 && choice > 3)
                {
                    Console.WriteLine("Enter your choice again");
                }
            } while (choice < 1 && choice > 3);
            
            string name;
            int yearOfBirth;
            GENDER gender;
            string address;
            int choiceGender;

            Console.Write("Name: ");
            name = Console.ReadLine();
            Console.Write("Year of birth: ");
            yearOfBirth = int.Parse(Console.ReadLine());
            do
            {
                Console.Write("Gender: 1. Female  2. Male ");
                choiceGender = int.Parse(Console.ReadLine());
                if (choiceGender != 1 && choiceGender != 2)
                {
                    Console.WriteLine("Enter gender again");
                } 
            } while (choiceGender != 1 && choiceGender != 2);

            if (choiceGender == 1)
            {
                gender = GENDER.FEMALE;
            }
            else
            {
                gender = GENDER.MALE;
            }

            Console.Write("Address: "); ;
            address = Console.ReadLine();

            switch (choice)
            {
                case 1:
                    int level;
                    do
                    {
                        Console.Write("Level (1-7): ");
                        level = int.Parse(Console.ReadLine());
                        if (level < 1 && level > 7)
                        {
                            Console.WriteLine("Enter level again");
                        }
                    } while (level < 1 && level > 7);
                    Worker.LEVELWORKER levelOfWorker = (Worker.LEVELWORKER)level;
                    Worker aWorker = new Worker(name, yearOfBirth, gender, address, levelOfWorker);
                    officialList.Add(aWorker);
                    break;

                case 2:
                    Console.Write("Profession: ");
                    string profession = Console.ReadLine();
                    Engineer anEngineer = new Engineer(name, yearOfBirth, gender, address, profession);
                    officialList.Add(anEngineer);
                    break;

                case 3:
                    Console.Write("Affair: ");
                    string affair = Console.ReadLine();
                    Staff aStaff = new Staff(name, yearOfBirth, gender, address, affair);
                    officialList.Add(aStaff);
                    break;
            }
        }

        public void SearchOfficialByName()
        {
            Console.WriteLine("Enter the name: ");
            string name = Console.ReadLine();

            foreach (Official official in officialList)
            {
                if (official.Name == name)
                {
                    official.DisplayInfo();
                    Console.WriteLine("\n");
                }
            }
        }

        public void DisplayListOfOfficials()
        {
            Console.WriteLine("Officials List:");
            foreach (Official offical in officialList)
            {
                offical.DisplayInfo();
                Console.WriteLine("\n");
            }
        }
    }
}
