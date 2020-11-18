using System;
using System.IO;
using System.Diagnostics;

namespace BOOKMANAGER.ConsoleApp.Controllers
{
    using Models;
    using DataServices;
    using Framework;
    using Views;
    internal class ShellController : ControllerBase
    {
        protected Repository Repository;
        public ShellController(IDataAccess context)
        {
            Repository = new Repository(context);
        }


        /// <summary>
        /// Tìm các file theo format có trong thư mục theo đường dẫn
        /// </summary>
        /// <param name="path"></param>
        /// <param name="format"></param>
        public void Shell(string path, string format = "*.pdf")
        {
            if (!Directory.Exists(path))
            {
                Error("Folder not found!");
                return;
            }

            string[] files = Directory.GetFiles(path, format, SearchOption.AllDirectories);
            foreach (string f in files)
            {
                Repository.Insert(new Book() { Title = Path.GetFileNameWithoutExtension(f) });
            }
            if (files.Length > 0)
            {
                Success($"{files.Length} item(s) found!");
            }
            else
            {
                Information("No item found!", "Sorry!");
            }
        }


        /// <summary>
        /// Đọc sách theo id
        /// </summary>
        /// <param name="id">mã định danh của sách</param>
        public void Read(int id)
        {
            Book b = Repository.Select(id);
            if (b == null)
            {
                Error("Book not found!");
                return;
            }

            if (!File.Exists(b.File))
            {
                Error("File not found!");
                return;
            }

            Process.Start(b.File);
            Success($"You are reading the book '{b.Title}'");
        }

        public void Save()
        {
            Repository.SaveChanges();
            Success("Data saved!");
        }
    }
}
