using BookStore.Models;
using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModels
{
    public class BookAuthorViewModel
    {
        public int BookId { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 1)]
        public string Title { get; set; }

        [Required]
        public String Description { get; set; }

        public int AuthorID { get; set; }

        public List<Author> Authors { get; set; }
        public IFormFile File { get; set; }
    }
}
