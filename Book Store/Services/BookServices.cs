using Book_Store.Data;
using Book_Store.Models;
using Book_Store.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using System.IO;

namespace Book_Store.Services
{
    public class BookServices : IBookServices
    {
        AppDbContext _Context;
        
        public BookServices(AppDbContext context)
        {
            _Context = context;
        }


        public void Add(AddBookFormViewModel model)
        {
            Book newBook = new()
            {
                Title = model.Title,
                Genre = model.Genre,
                Price = model.Price,
                publicationDate = model.publicationDate,
                imgUrl = model.imgUrl,
                AuthorId = model.AuthorId,
            };

            _Context.Add(newBook);
            _Context.SaveChanges();
        }

        public Book? GetByID(int id)
        {
            return _Context.Books
                .Include(x=>x.Author)
                .FirstOrDefault(x => x.Id == id);
        }

        public void Update(UpdateBookFormViewModel model)
        {
            var book = new Book();
            book.Id = model.Id;
            book.Title = model.Title;
            book.Genre = model.Genre;
            book.Price = model.Price;
            book.publicationDate = model.publicationDate;
            book.AuthorId = model.AuthorId;
            if (model.imgUrl != null)
            {
                book.imgUrl = model.imgUrl.FileName;
            }

            _Context.Update(book);
            _Context.SaveChanges();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _Context.Books
                .Include(x => x.Author)
                .ToList();
        }

        public void Delete(Book book)
        {
            _Context.Books.Remove(book);
            _Context.SaveChanges();
        }

        public Book? GetByName(string name)
        {
            return _Context.Books
                .FirstOrDefault(x => x.Title == name);
        }

        public IEnumerable<Book> GetAllBooksSortedbyPrice()
        {
            return _Context.Books
               .Include(x => x.Author).OrderBy(x => x.Price)
               .ToList();
        }

        public IEnumerable<Book> GetAllBooksSortedbypublicationDate()
        {
            return _Context.Books
               .Include(x => x.Author).OrderBy(x => x.publicationDate)
               .ToList();
        }

        public IEnumerable<Book> GetAllBooksSortedbyTitle()
        {
            return _Context.Books
               .Include(x => x.Author).OrderBy(x => x.Title)
               .ToList();
        }
    }
}
