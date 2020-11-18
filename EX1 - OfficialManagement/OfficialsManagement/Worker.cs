using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficialsManagement
{
    class Worker : Official
    {
        public enum LEVELWORKER
        {
            ONE = 1,
            TWO,
            THREE,
            FOUR,
            FIVE,
            SIX,
            SEVEN,
        }
        private LEVELWORKER level;
        public LEVELWORKER Level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
            }
        }

        public Worker(string name, int yeafOfBirth, GENDER gender, string address, LEVELWORKER level)
            : base(name, yeafOfBirth, gender, address)
        {
            this.level = level;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine("Level: " + Render.LevelWorker(level));
        }

    }
}
