using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficialsManagement
{
    class Staff : Official
    {
        private string affair;
        public string Affair
        {
            get
            {
                return affair;
            }
            set
            {
                affair = value;
            }
        }

        public Staff(string name, int yearOfBirth, GENDER gender, string address, string affair)
            : base(name, yearOfBirth, gender, address)
        {
            this.affair = affair;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine("Affair: " + affair);
        }
    }
}
