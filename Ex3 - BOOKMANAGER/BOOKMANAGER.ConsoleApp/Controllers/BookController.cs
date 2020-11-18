using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOKMANAGER.ConsoleApp.Controllers
{
    using DataServices;
    using Models;
    using Views;

    /// <summary>
    /// Lớp điều khiển, giúp kết nối dữ liệu sách với giao diện
    /// </summary>
    class BookController : ControllerBase
    {
        /// <summary>
        /// Repository được quản lý
        /// </summary>
        protected Repository Repository;

        public BookController(IDataAccess context)
        {
            Repository = new Repository(context);
        }

        /// <summary>
        /// ghép nối thông tin 1 cuốn sách với giao diện hiển thị một cuốn sách,
        /// xuất thông tin 1 cuốn sách ra file theo đường dẫn
        /// </summary>
        /// <param name="id">mã định danh của cuốn sách</param>
        /// <param name="path">đường dẫn file</param>
        public void Single(int id, string path = "")
        {
            // lấy dữ liệu qua repository
            Book model = Repository.Select(id);
            BookSingleView view = new BookSingleView(model);
            Render(view, path);
        }


        /// <summary>
        /// Kích hoạt chức năng nhập dữ liệu cho 1 cuốn sách
        /// </summary>
        public void Create(Book book = null)
        {

            if (book == null)
            {
                BookCreateView view = new BookCreateView();
                view.Render();
                return;
            }
            Repository.Insert(book);
            Success("Book created!!");
        }


        /// <summary>
        /// Kích hoạt chức năng cập nhật thông tin 1 cuốn sách
        /// </summary>
        /// <param name="id">mã định danh của cuốn sách</param>
        public void Update(int id, Book book = null)
        {
            if (book == null)
            {
                // lấy dữ liệu qua repository
                Book model = Repository.Select(id);
                BookUpdateView view = new BookUpdateView(model);
                Render(view);
                return;
            }

            Repository.Update(id, book);
            Success("Book updated");
        }


        /// <summary>
        /// Kích hoạt chức năng hiển thị danh sách,
        /// Xuất thông tin các cuốn sách ra file theo đường dẫn
        /// </summary>
        /// <param name="path">đường dẫn file</param>
        public void List(string path = "")
        {
            // lấy dữ liệu qua repository
            Book[] models = Repository.Select();
            BookListView view = new BookListView(models);
            Render(view, path);
        }

        /// <summary>
        /// Kích hoạt chức năng xóa sách theo id
        /// </summary>
        /// <param name="id">mã định danh của cuốn sách cần xóa</param>
        /// <param name="process"></param>
        public void Delete(int id, bool process = false)
        {
            if (!process)
            {
                Book b = Repository.Select(id);
                Confirmation($"Do you want to delete this book ({b.Title})? [y/n] ", $"do delete ? id = {id}");
            }
            else
            {
                Repository.Delete(id);
                Success("Book deleted!");
            }
        }


        /// <summary>
        /// Lọc sách theo key
        /// </summary>
        /// <param name="key"></param>
        public void Filter(string key)
        {
            Book[] models = Repository.Select(key);
            if (models.Length == 0)
            {
                Information("No matched found!");
            }
            else
            {
                BookListView view = new BookListView(models);
                Render(view);
            }
        }



        /// <summary>
        /// Đánh dấu tình trạng đọc của 1 cuốn sách theo id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isReading"></param>
        public void Mark(int id, bool isReading = true)
        {
            Book book = Repository.Select(id);
            if (book == null)
            {
                Error("Book not found!");
                return;
            }

            book.Reading = isReading;
            Success($"The book '{book.Title}' are marked as {(book.Reading ? "READ" : "UNREAD")}");
        }


        /// <summary>
        /// Hiển thị danh sách các cuốn sách đang đọc
        /// </summary>
        public void ShowMarks()
        {
            Book[] booksReading = Repository.SelectMarked();
            BookListView view = new BookListView(booksReading);
            Render(view);
        }

        public void Clear(bool process = false)
        {
            if (!process)
            {
                Confirmation("Do you really want to clear all books? [y/n] ", "do clear");
                return;
            }
            Repository.Clear();
            Success("All books have been cleared");
        }

        public void StatsByFolder()
        {
            var model = Repository.StatsByFolder();
            BookStatsView view = new BookStatsView(model);
            Render(view);
        }
    }
}
