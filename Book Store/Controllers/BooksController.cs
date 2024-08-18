using Book_Store.Data;
using Book_Store.Models;
using Book_Store.Services;
using Book_Store.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Reflection.Metadata.BlobBuilder;

namespace Book_Store.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookServices _bookServices;
        private readonly IAuthorServices _authorServices;


        public BooksController(IBookServices bookServices, IAuthorServices authorServices)
        {
            _bookServices = bookServices;
            _authorServices = authorServices;
        }

        public IActionResult Index()
        {
            var Books = _bookServices.GetAllBooks();
            return View(Books);
        }

        [HttpPost]
        public IActionResult Index(IndexSearchWithSort model)
        {
            IEnumerable<Book> Books = new List<Book>();
            if (model.Radio == null)
            {
                 Books = _bookServices.GetAllBooks();
            }
            else if (model.Radio == "Price")
            {
                Books = _bookServices.GetAllBooksSortedbyPrice();
            }
            else if (model.Radio == "publicationDate")
            {
                Books = _bookServices.GetAllBooksSortedbypublicationDate();
            }
            else if (model.Radio == "Title")
            {
                Books = _bookServices.GetAllBooksSortedbyTitle();
            }

            if (!string.IsNullOrEmpty(model.Search))
            {
                Books = Books.Where(p => p.Title
                    .Contains(model.Search,
                    StringComparison.OrdinalIgnoreCase)).ToList();
            }
            return View(Books);
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddBookFormViewModel book = new()
            {
                Authors = _authorServices.GetSelecListItemAuthor()
            };
            return View(book);
        }

        [HttpPost]
        public IActionResult Add(AddBookFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                    AddBookFormViewModel book = new()
                    {
                        Authors = _authorServices.GetSelecListItemAuthor()
                    };
                    return View(book);
            }

            _bookServices.Add(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var model = _bookServices.GetByID(id);
            UpdateBookFormViewModel book = new()
            {
                Title = model.Title,
                AuthorId = model.AuthorId,
                Genre = model.Genre,
                Price = model.Price,
                publicationDate = model.publicationDate,
                Authors = _authorServices.GetSelecListItemAuthor()
            };
            return View(book);
        }

        [HttpPost]
        public IActionResult Update(UpdateBookFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                UpdateBookFormViewModel book = new()
                {
                    Authors = _authorServices.GetSelecListItemAuthor()
                };
                return View(book);
            }

            _bookServices.Update(model);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete (int id)
        {
            var book = _bookServices.GetByID(id); 
            _bookServices.Delete(book);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Book book = _bookServices.GetByID(id);
            if (book != null)
                return View(book);
            return NotFound();
        }
    }
}