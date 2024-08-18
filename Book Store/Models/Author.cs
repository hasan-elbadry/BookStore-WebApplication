using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Book_Store.Models
{
    public class Author
    {
        public int Id { get; set; }

        [StringLength(80, MinimumLength = 1, ErrorMessage = "name field is requrid with min length:1 and max length:80")]
        public string Name { get; set; } = string.Empty;

        [StringLength(80, MinimumLength = 5, ErrorMessage = "bio field is requrid with min length:1 and max length:80")]
        public string Bio { get; set; } = string.Empty;

        [Display(Name = "Date of birth")]
        public DateTime dateOfBirth { get; set; }

        public IEnumerable<Book>? books { get; set;} = new List<Book>();
    }
}
