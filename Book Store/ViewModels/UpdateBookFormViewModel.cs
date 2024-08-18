using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Book_Store.ViewModels
{
    public class UpdateBookFormViewModel
    {
        public int Id { get; set; }

        [StringLength(80, MinimumLength = 1, ErrorMessage = "name field is requrid with min length:1 and max length:80")]
        public string Title { get; set; } = string.Empty;

        [StringLength(80, MinimumLength = 5, ErrorMessage = "bio field is requrid with min length:1 and max length:80")]
        public string Genre { get; set; } = string.Empty;

        public double Price { get; set; }

        [Display(Name = "Cover")]
        public IFormFile? imgUrl { get; set; }

        [Display(Name = "Publication Date")]
        public DateOnly publicationDate { get; set; }

        public int AuthorId { get; set; }

        public IEnumerable<SelectListItem> Authors { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
