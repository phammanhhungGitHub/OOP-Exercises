using System;
using System.Collections.Generic;


namespace BOOKMANAGER.ConsoleApp.Framework
{

    /// <summary>
    /// Lưu các cặp khóa giá trị người dùng nhập
    /// Chuỗi tham số cần viết ở dạng khóa = giá trị
    /// nếu có nhiều tham số thì viết cách nhau bởi dấu &
    /// </summary>
    public class Parameter
    {
        private Dictionary<string, string> _pairs = new Dictionary<string, string>();

        /// <summary>
        /// Nạp chồng toán tử index [], cho phép truy xuất giá trị theo kiểu biến [khóa] = giá trị
        /// </summary>
        /// <param name="key">khóa</param>
        /// <returns>giá trị tương ứng</returns>
        public string this[string key]
        {
            get
            {
                if (_pairs.ContainsKey(key))
                    return _pairs[key];
                else
                    return null;
            }
            set => _pairs[key] = value;
        }


        /// <summary>
        /// Kiểm tra xem 1 khóa có trong danh sách tham số không
        /// </summary>
        /// <param name="key">khóa cần kiểm tra</param>
        /// <returns></returns>
        public bool IsContain(string key)
        {
            return _pairs.ContainsKey(key);
        }


        /// <summary>
        /// Nhận chuỗi kí tự và phân tích, chuyển thành các cặp khóa giá trị
        /// </summary>
        /// <param name="parameter"></param>
        public Parameter(string parameter)
        {
            // cắt chuỗi kí tự theo các mốc &
            // kết quả nhận được là 1 mảng theo định dạng khóa = giá trị
            string[] pairs = parameter.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string pair in pairs)
            {
                // cắt mỗi phần tử theo mốc =
                string[] p = pair.Split('=');
                if (p.Length == 2)
                {
                    string key = p[0].Trim();
                    string value = p[1].Trim();
                    this[key] = value;
                }

            }
        }
    }
}
