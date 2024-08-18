using Book_Store.Models;
using Book_Store.Services;
using Book_Store.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IBookServices _bookServices;
        private readonly IAuthorServices _AuthorServices;

        public AuthorsController(IBookServices bookServices,IAuthorServices authorServices)
        {
            _bookServices = bookServices;
            _AuthorServices = authorServices;
        }

        public IActionResult Index()
        {
            return View(_AuthorServices.GetAllAuthors());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Author author)
        {
            if(!ModelState.IsValid)
                return View(author);
            _AuthorServices.Add(author);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var Author = _AuthorServices.GetByID(id);
            if(Author != null) 
                return View(Author);
            return NotFound();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var author = _AuthorServices.GetByID(id);
            if(author!=null)
                return View(author);
            return NotFound();
        }

        [HttpPost]
        public IActionResult Update(Author author)
        {
            if (ModelState.IsValid)
            {
                _AuthorServices.Update(author);
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        public IActionResult Delete(int id)
        {
            var author = _AuthorServices.GetByID(id);
            if (author != null)
            {
                _AuthorServices.Delete(author);
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }
}
