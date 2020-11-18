using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOKMANAGER.ConsoleApp.Framework
{
    public static class Extension
    {

        /// <summary>
        /// Biến đổi các chuỗi y, Y, true, True -> true, còn lại thành false
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ToBool(this string value)
        {
            string v = value.ToLower();
            if (v == "y" || v == "true")
                return true;
            return false;
        }


        /// <summary>
        /// chuyển đổi true/false thành chuỗi Yes/No, Có/Không hoặc True/False
        /// </summary>
        /// <param name="value"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string ToString(this bool value, string format)
        {
            if (format == "y/n")
                return value ? "Yes" : "No";
            if (format == "c/k")
                return value ? "Có" : "Không";
            return value ? "True" : "False";
        }
    }
}
