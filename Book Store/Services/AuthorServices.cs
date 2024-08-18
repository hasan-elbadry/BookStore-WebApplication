using Book_Store.Data;
using Book_Store.Models;
using Book_Store.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Book_Store.Services
{
    public class AuthorServices : IAuthorServices
    {
        AppDbContext _Context;

        public AuthorServices(AppDbContext context)
        {
            _Context = context;
        }

        public void Add(Author model)
        {

            Author author = new()
            {
               Bio = model.Bio,
               dateOfBirth = model.dateOfBirth,
               Name = model.Name,
            };

            _Context.Add(author);
            _Context.SaveChanges();
        }

        public Author? GetByID(int id)
        {
            return _Context.Authors
                .Include(x => x.books)
                .FirstOrDefault(x => x.Id == id);
        }

        public void Delete(Author author)
        {
            _Context.Authors.Remove(author);
            _Context.SaveChanges();
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _Context.Authors
                .Include(x=>x.books)
                .ToList();
        }

        public IEnumerable<SelectListItem> GetSelecListItemAuthor()
        {
            return _Context.Authors
                .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList();
        }

        public void Update(Author model)
        {
            Author author = new()
            {
                Id = model.Id,
                Bio = model.Bio,
                dateOfBirth = model.dateOfBirth,
                Name = model.Name,
            };

            _Context.Update(author);
            _Context.SaveChanges();
        }
    }
}
