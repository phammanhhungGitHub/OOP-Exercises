using System;
using BOOKMANAGER.ConsoleApp.Framework;


namespace BOOKMANAGER.ConsoleApp.Views
{
    /// <summary>
    /// Class để thêm 1 cuốn sách mới
    /// </summary>
    internal class BookCreateView : ViewBase
    {
        public override void Render()
        {
            ViewHelp.WriteLine("CREATE A NEW BOOK", ConsoleColor.Green);

            string title = ViewHelp.InputString("Title");
            string authors = ViewHelp.InputString("Authors");
            string publisher = ViewHelp.InputString("Publisher");
            int year = ViewHelp.InputInt("Year");
            int edition = ViewHelp.InputInt("Edition");
            string tags = ViewHelp.InputString("Tags");
            string description = ViewHelp.InputString("Description");
            int rate = ViewHelp.InputInt("Rate");
            bool reading = ViewHelp.InputBool("Reading");
            string file = ViewHelp.InputString("File");

            var request = "do create ? " +
                          $"title = {title} & " +
                          $"authors = {authors} & " +
                          $"publisher = {publisher} & " +
                          $"year = {year} & " +
                          $"edition = {edition} & " +
                          $"tags = {tags} & " +
                          $"description = {description} & " +
                          $"rate = {rate} & " +
                          $"reading = {reading} & " +
                          $"file = {file}";
            Router.Instance.Forward(request);
        }

    }
}
