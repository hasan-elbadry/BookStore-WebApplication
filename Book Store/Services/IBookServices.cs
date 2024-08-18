using Book_Store.Models;
using Book_Store.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Book_Store.Services
{
    public interface IBookServices
    {
        public Book? GetByID(int id);
        public Book? GetByName(string name);
        public void Add(AddBookFormViewModel book);
        public void Update(UpdateBookFormViewModel book);
        public IEnumerable<Book> GetAllBooks();
        public IEnumerable<Book> GetAllBooksSortedbyPrice();
        public IEnumerable<Book> GetAllBooksSortedbypublicationDate();
        public IEnumerable<Book> GetAllBooksSortedbyTitle();

        public void Delete(Book book);

    }
}
