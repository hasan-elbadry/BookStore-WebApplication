using Book_Store.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Book_Store.ViewModels
{
    public class AddBookFormViewModel
    {

        [StringLength(80, MinimumLength = 1, ErrorMessage = "name field is requrid with min length:1 and max length:80")]
        public string Title { get; set; } = string.Empty;

        [StringLength(80, MinimumLength = 5, ErrorMessage = "bio field is requrid with min length:1 and max length:80")]
        public string Genre { get; set; } = string.Empty;

        public double Price { get; set; }

        [Display(Name = "Cover")]
        public string imgUrl { get; set; }

        [Display(Name = "Publication Date")]
        public DateOnly publicationDate { get; set; }

        public int AuthorId { get; set; }

        public IEnumerable<SelectListItem> Authors { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
