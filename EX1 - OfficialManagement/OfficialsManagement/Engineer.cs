using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficialsManagement
{
    class Engineer : Official
    {
        private string profession;
        public string Profession
        {
            get
            {
                return profession;
            }
            set
            {
                profession = value;
            }
        }

        public Engineer(string name, int yearOfBirth, GENDER gender, string address, string profession)
            : base(name, yearOfBirth, gender, address)
        {
            this.profession = profession;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine("Profession: " + profession);
        }
    }
}
