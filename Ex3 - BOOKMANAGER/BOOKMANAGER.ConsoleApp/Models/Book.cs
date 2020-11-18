using System;

namespace BOOKMANAGER.ConsoleApp.Models
{
    /// <summary>
    /// Lớp mô tả sách điện tử
    /// </summary>
    [Serializable]
    public class Book
    {
        private int _id = 1;
        /// <summary>
        /// Số định danh duy nhất cho mỗi object
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { if (value >= 1) _id = value; }    // id chỉ nhận giá trị >= 1
        }

        private string _authors = "Unknown authors";
        /// <summary>
        /// Tên tác giả hoặc nhóm tác giả, không nhận xâu rỗng
        /// </summary>
        public string Authors
        {
            get { return _authors; }
            set { if (!string.IsNullOrEmpty(value)) _authors = value; }     // không nhận xâu rỗng
        }

        private string _title = "A new book";
        /// <summary>
        /// Tiêu đề sách, không nhận xâu rỗng
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { if (!string.IsNullOrEmpty(value)) _title = value; }   // không nhận xâu rỗng
        }

        private string _publisher = "Unknown publisher";
        /// <summary>
        /// nhà xuất bản, không nhận xâu rỗng
        /// </summary>
        public string Publisher
        {
            get { return _publisher; }
            set { if (!string.IsNullOrEmpty(value)) _publisher = value; }   // không nhận xâu rỗng
        }

        private int _year = 2020;
        /// <summary>
        /// năm xuất bản, không nhỏ hơn 1950
        /// </summary>
        public int Year
        {
            get { return _year; }
            set { if (value >= 1950) _year = value; }   // năm không nhỏ hơn 1950
        }

        private int _edition = 1;
        /// <summary>
        /// lần tái bản, không nhỏ hơn 1
        /// </summary>
        public int Edition
        {
            get { return _edition; }
            set { if (value >= 1) _edition = value; }   // không nhỏ hơn 1
        }

        /// <summary>
        /// mã số quốc tế
        /// </summary>
        public string Isbn { get; set; } = "";

        /// <summary>
        /// Từ khóa mô tả nội dung, thể loại
        /// </summary>
        public string Tags { get; set; } = "";

        /// <summary>
        /// Mô tả nội dung, thể loại
        /// </summary>
        public string Description { get; set; } = "";

        private int _rating = 1;
        /// <summary>
        /// Đánh giá cá nhân, từ 1 đến 5
        /// </summary>
        public int Rating
        {
            get { return _rating; }
            set { if (value <= 1 && value >= 5) _rating = value; }  // giá trị từ 1 đến 5
        }

        /// <summary>
        /// Đánh dấu là đang đọc
        /// </summary>
        public bool Reading { get; set; }

        private string _file;
        /// <summary>
        /// File sách (gồm đường dẫn)
        /// </summary>
        public string File
        {
            get { return _file; }
            set { if (System.IO.File.Exists(value)) _file = value; }    // chỉ nhận đường dẫn đúng
        }

        /// <summary>
        /// File sách (không có đường dẫn)
        /// </summary>
        public string FileName
        {
            get { return System.IO.Path.GetFileName(_file); }
        }
    }
}
