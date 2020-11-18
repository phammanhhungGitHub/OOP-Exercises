using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficialsManagement
{
    enum GENDER
    {
        MALE,
        FEMALE,
    }
    class Official
    {
        protected string name;
        protected int yearOfBirth;
        protected GENDER gender;
        protected string address;

        public Official(string name, int yearOfBirth, GENDER gender, string address)
        {
            this.name = name;
            YearOfBirth = yearOfBirth;
            this.gender = gender;
            this.address = address;
        }

        public string Name 
        {
            set
            {
                name = value;
            }
            get
            {
                return name;
            }
        }
        public int YearOfBirth
        {
            set
            {
                if (value <= 0)
                {
                    yearOfBirth = 1950;
                    Console.WriteLine("Invalid year. The year would be set to 1950");
                }
                else
                {
                    yearOfBirth = value;
                }
            }
            get
            {
                return yearOfBirth;
            }
        }
        public GENDER Gender
        {
            set
            {
                gender = value;
            }
            get
            {
                return gender;
            }
        }
        public string Address 
        {
            set
            {
                address = value;
            }
            get
            {
                return address;
            }
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Name: {name}\nYear of birth: {yearOfBirth}\n" +
                                $"Gender: {Render.Gender(gender)}\nAddress: {address}");
        }


    }
}
