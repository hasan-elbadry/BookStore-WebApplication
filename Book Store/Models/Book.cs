using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book_Store.Models
{
    public class Book
    {
        public int Id { get; set; }

        [StringLength(80, MinimumLength = 1, ErrorMessage = "name field is requrid with min length:1 and max length:80")]
        public string Title { get; set; } = string.Empty;

        [StringLength(80, MinimumLength = 5, ErrorMessage = "bio field is requrid with min length:1 and max length:80")]
        public string Genre { get; set; } = string.Empty;

        public double Price { get; set; }

        [Display(Name = "Cover")]
        public string imgUrl { get; set; } = string.Empty;

        [Display(Name = "Publication Date")]
        public DateOnly publicationDate { get; set; }


        [ForeignKey("AuthorId")]
        public int AuthorId { get; set; }

        public Author? Author { get; set; }
    }
}
