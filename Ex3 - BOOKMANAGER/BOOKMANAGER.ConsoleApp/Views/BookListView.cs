using System;
using BOOKMANAGER.ConsoleApp.Framework;

namespace BOOKMANAGER.ConsoleApp.Views
{
    using Models;

    /// <summary>
    /// Class hiển thị danh sách book
    /// </summary>
    internal class BookListView : ViewBase<Book[]>
    {
        public BookListView(Book[] model) : base(model) { }
        

        /// <summary>
        /// In danh sách
        /// </summary>
        public override void Render()
        {
            if (Model.Length == 0)
            {
                ViewHelp.WriteLine("No book found!", ConsoleColor.Yellow);
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("THE BOOK LIST");
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (Book b in Model)
            {
                ViewHelp.Write($"[{b.Id}] ", ConsoleColor.Yellow);
                ViewHelp.WriteLine(b.Title, b.Reading ? ConsoleColor.Cyan : ConsoleColor.White);
            }
            ViewHelp.WriteLine($"{Model.Length} item(s)", ConsoleColor.Green);
        }

    }
}
