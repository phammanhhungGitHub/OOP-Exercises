using System;
using BOOKMANAGER.ConsoleApp.Framework;


namespace BOOKMANAGER.ConsoleApp.Views
{
    using Models;

    /// <summary>
    /// Class để hiện thị thông tin một cuốn sách, chỉ sử dụng trong dự án (internal)
    /// </summary>
    internal class BookSingleView : ViewBase<Book>
    {
        public BookSingleView(Book model) : base(model) { }

        /// <summary>
        /// thực hiện in thông tin ra màn hình
        /// </summary>
        public override void Render()
        {
            if (Model == null)
            {
                ViewHelp.WriteLine("NO BOOK FOUND. SORRY!", ConsoleColor.Red);
            }

            ViewHelp.WriteLine("BOOK DETAIL INFORMATION", ConsoleColor.Green);
            
            // hiển thị các thông tin của cuốn sách
            Console.WriteLine($"-Authors :    {Model.Authors}");
            Console.WriteLine($"-Title :      {Model.Title}");
            Console.WriteLine($"-Publisher :  {Model.Publisher}");
            Console.WriteLine($"-Year :       {Model.Year}");
            Console.WriteLine($"-Edition :    {Model.Edition}");
            Console.WriteLine($"-ISBN :       {Model.Isbn}");
            Console.WriteLine($"-Tags :       {Model.Tags}");
            Console.WriteLine($"-Desciption : {Model.Description}");
            Console.WriteLine($"-Rating :     {Model.Rating}");
            Console.WriteLine($"-Reading :    {Model.Reading}");
            Console.WriteLine($"-File :       {Model.File}");
            Console.WriteLine($"-File name :  {Model.FileName}");
        }

    }
}
