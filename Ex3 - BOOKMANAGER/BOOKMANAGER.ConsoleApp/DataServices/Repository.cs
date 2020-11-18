using System;
using System.Collections.Generic;
using System.Linq;


namespace BOOKMANAGER.ConsoleApp.DataServices
{
    using Models;
    public class Repository
    {
        protected readonly IDataAccess _context;
        public Repository(IDataAccess context)
        {
            _context = context;
            _context.Load();
        }

        public List<Book> Books => _context.Books;
        public void SaveChanges() => _context.SaveChanges();
        public Book[] Select() => _context.Books.ToArray();
        public Book Select(int id)
        {
            return _context.Books.FirstOrDefault(b => b.Id == id);
        }

        public Book[] Select(string key)
        {
            key = key.ToLower();
            
            return _context.Books.Where(b => b.Title.Contains(key) || b.Authors.Contains(key) ||
                                    b.Publisher.Contains(key) || b.Tags.Contains(key) ||
                                    b.Description.Contains(key)).ToArray();
        }

        public Book[] SelectMarked()
        {
            return _context.Books.Where(b => b.Reading).ToArray();
        }

        public void Insert(Book book)
        {
            book.Id = _context.Books.Count == 0 ? 1 : _context.Books.Max(b => b.Id) + 1;
            _context.Books.Add(book);
        }

        public bool Delete(int id)
        {
            Book book = Select(id);
            if (book == null)
                return false;
            _context.Books.Remove(book);
            return true;
        }

        public bool Update(int id, Book newBook)
        {
            Book book = Select(id);
            if (book == null)
                return false;
            book.Title = newBook.Title;
            book.Authors = newBook.Authors;
            book.Year = newBook.Year;
            book.Edition = newBook.Edition;
            book.Tags = newBook.Tags;
            book.Description = newBook.Description;
            book.File = newBook.File;
            book.Isbn = newBook.Isbn;
            book.Rating = newBook.Rating;
            book.Reading = newBook.Reading;
            return true;
        }

        public void Clear()
        {
            _context.Books.Clear();
        }

        public IEnumerable<IGrouping<string, Book>> StatsByFolder()
        {
            return _context.Books.GroupBy(b => System.IO.Path.GetDirectoryName(b.File));
        }
    }
}
