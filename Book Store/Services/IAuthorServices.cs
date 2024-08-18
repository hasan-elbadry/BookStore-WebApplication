using Book_Store.Models;
using Book_Store.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Book_Store.Services
{
    public interface IAuthorServices
    {
        public Author? GetByID(int id);
        public void Add(Author author);
        public void Update(Author author);
        public IEnumerable<Author> GetAllAuthors();
        public void Delete(Author author);

        /* in author service */
        public IEnumerable<SelectListItem> GetSelecListItemAuthor();

    }
}
