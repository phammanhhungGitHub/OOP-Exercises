using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOKMANAGER.ConsoleApp.Framework
{
    public static class ViewHelp
    {
        /// <summary>
        /// Xuất thông tin ra console với màu sắc rồi xuống dòng
        /// </summary>
        /// <param name="message">thông tin cần xuất</param>
        /// <param name="color">màu chữ</param>
        /// <param name="resetColor">trả lại màu mặc định hay không</param>
        public static void WriteLine(string message, ConsoleColor color = ConsoleColor.White, bool resetColor = true)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            if (resetColor)
                Console.ResetColor();
        }


        /// <summary>
        /// Xuất thông tin ra console với màu sắc
        /// </summary>
        /// <param name="message">thông tin cần xuất</param>
        /// <param name="color">màu chữ</param>
        /// <param name="resetColor">trả lại màu mặc định hay không</param>
        public static void Write(string message, ConsoleColor color = ConsoleColor.White, bool resetColor = true)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            if (resetColor)
                Console.ResetColor();
        }

        /// <summary>
        /// In ra thông báo và nhận chuỗi kí tự người dùng nhập rồi chuyển về kiểu bool 
        /// </summary>
        /// <param name="label">dòng thông báo</param>
        /// <param name="labelColor">màu chữ thông báo</param>
        /// <param name="valueColor">màu chữ người dùng nhập</param>
        /// <returns></returns>
        public static bool InputBool(string label, ConsoleColor labelColor = ConsoleColor.Magenta, ConsoleColor valueColor = ConsoleColor.White)
        {
            Write($"{label} [y/n] : ", labelColor);
            Console.ForegroundColor = valueColor;
            ConsoleKeyInfo key = Console.ReadKey();
            Console.WriteLine();

            bool yesNo = key.KeyChar == 'y' || key.KeyChar == 'Y' ? true : false;
            Console.ResetColor();
            return yesNo;
        }

        /// <summary>
        /// Cập nhật giá trị mới kiểu bool, nếu nhấn enter mà không nhập giá trị mới thì trả về giá trị cũ
        /// </summary>
        /// <param name="label">dòng thông báo</param>
        /// <param name="oldValue">giá trị cũ</param>
        /// <param name="labelColor">màu chữ thông báo</param>
        /// <param name="valueColor">màu chữ người dùng nhập</param>
        /// <returns></returns>
        public static bool InputBool(string label, bool oldValue, ConsoleColor labelColor = ConsoleColor.Magenta, ConsoleColor valueColor = ConsoleColor.White)
        {
            Write($"{label} : ", labelColor);

            // sử dụng phương thức mở rộng của ToString
            WriteLine(oldValue.ToString("y/n"), ConsoleColor.Yellow);

            // nhập giá trị mới
            Write($"New value >>> ", ConsoleColor.Green);
            Console.ForegroundColor = valueColor;
            string newValue = Console.ReadLine();
            if (string.IsNullOrEmpty(newValue.Trim())) return oldValue;

            // sử dụng phương thức mở rộng ToBool
            return newValue.ToBool();

        }


        /// <summary>
        /// In ra thông báo và nhận chuỗi kí tự người dùng nhập và chuyển về kiểu int
        /// </summary>
        /// <param name="label">dòng thông báo</param>
        /// <param name="labelColor">màu chữ thông báo</param>
        /// <param name="valueColor">màu chữ người dùng nhập</param>
        /// <returns></returns>
        public static int InputInt(string label, ConsoleColor labelColor = ConsoleColor.Magenta, ConsoleColor valueColor = ConsoleColor.White)
        {
            while (true)
            {
                string text = InputString(label, labelColor, valueColor);
                bool isSuccessfull = int.TryParse(text, out int i);
                if (isSuccessfull)
                    return i;
            }
        }


        /// <summary>
        /// Cập nhật giá trị mới kiểu int, nếu nhấn enter mà không nhập giá trị mới thì trả về giá trị cũ
        /// </summary>
        /// <param name="label">dòng thông báo</param>
        /// <param name="oldValue">giá trị cũ</param>
        /// <param name="labelColor">màu chữ thông báo</param>
        /// <param name="valueColor">màu chữ người dùng nhập</param>
        /// <returns></returns>
        public static int InputInt(string label, int oldValue, ConsoleColor labelColor = ConsoleColor.Magenta, ConsoleColor valueColor = ConsoleColor.White)
        {
            Write($"{label} : ", labelColor);
            //hiển thị giá trị cũ
            WriteLine($"{oldValue}", ConsoleColor.Yellow);
            //nhập giá trị mới
            Write("New value >>> ", ConsoleColor.Green);
            Console.ForegroundColor = valueColor;
            string newValue = Console.ReadLine();
            Console.ResetColor();

            if (string.IsNullOrEmpty(newValue.Trim())) return oldValue;
            if (int.TryParse(newValue, out int i))
                return i;
            return oldValue;
        }

        /// <summary>
        /// In ra thông báo và tiếp nhận chuỗi người dùng nhập
        /// </summary>
        /// <param name="label">dòng thông báo</param>
        /// <param name="labelColor">màu chữ thông báo</param>
        /// <param name="valueColor">màu chữ người dùng nhập</param>
        /// <returns></returns>
        public static string InputString(string label, ConsoleColor labelColor = ConsoleColor.Magenta, ConsoleColor valueColor = ConsoleColor.White)
        {
            Write($"{label} : ", labelColor);
            Console.ForegroundColor = valueColor;
            string text = Console.ReadLine();
            Console.ResetColor();
            return text;
        }


        /// <summary>
        /// Cập nhật giá trị kiểu string, nếu nhấn enter mà không nhập giá trị mới thì trả về giá trị ban đầu
        /// </summary>
        /// <param name="label">dòng thông báo</param>
        /// <param name="oldValue">giá trị cũ</param>
        /// <param name="labelColor">màu chữ thông báo</param>
        /// <param name="valueColor">màu chữ người dùng nhập</param>
        /// <returns></returns>
        public static string InputString(string label, string oldValue, ConsoleColor labelColor = ConsoleColor.Magenta, ConsoleColor valueColor = ConsoleColor.White)
        {
            Write($"{label} : ", labelColor);
            // hiển thị giá trị cũ
            WriteLine(oldValue, ConsoleColor.Yellow);

            // nhập giá trị mới
            Write("New value >>> ", ConsoleColor.Green);
            Console.ForegroundColor = valueColor;
            string newValue = Console.ReadLine();
            Console.ResetColor();

            return (!string.IsNullOrEmpty(newValue.Trim())) ? newValue : oldValue;
        }
    }
}
