using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficialsManagement
{
    class Render
    {
        public static string Gender (GENDER gender)
        {
            if (gender == GENDER.MALE)
                return "MALE";
            else
                return "FEMALE";
        }

        public static string LevelWorker(Worker.LEVELWORKER level)
        {
            switch (level)
            {
                case Worker.LEVELWORKER.ONE:
                    return "1/7";
                case Worker.LEVELWORKER.TWO:
                    return "2/7";
                case Worker.LEVELWORKER.THREE:
                    return "3/7";
                case Worker.LEVELWORKER.FOUR:
                    return "4/7";
                case Worker.LEVELWORKER.FIVE:
                    return "5/7";
                case Worker.LEVELWORKER.SIX:
                    return "6/7";
                default:
                    return "7/7";
            }
        }


    }
}
