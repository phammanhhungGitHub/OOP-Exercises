using System;
using BOOKMANAGER.ConsoleApp.Framework;

namespace BOOKMANAGER.ConsoleApp.Views
{
    using Models;

    /// <summary>
    /// Class để cập nhật 1 cuốn sách
    /// </summary>
    internal class BookUpdateView : ViewBase<Book>
    {
        public BookUpdateView(Book model) : base(model) { }

        public override void Render()
        {
            ViewHelp.WriteLine("UPDATE BOOK INFORMATION", ConsoleColor.Green);

            string title = ViewHelp.InputString("Title", Model.Authors);
            string authors = ViewHelp.InputString("Authors", Model.Authors);
            string publisher = ViewHelp.InputString("Publisher", Model.Publisher);
            int year = ViewHelp.InputInt("Year", Model.Year);
            int edition = ViewHelp.InputInt("Edition", Model.Edition);
            string tags = ViewHelp.InputString("Tags", Model.Tags);
            string description = ViewHelp.InputString("Description", Model.Description);
            int rate = ViewHelp.InputInt("Rate", Model.Rating);
            bool reading = ViewHelp.InputBool("Reading", Model.Reading);
            string file = ViewHelp.InputString("File", Model.File);

            var request = "do update ? " +
                          $"id = {Model.Id} & " +
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
