using BookStore.Models;

namespace BookStore.ViewModels
{
    public class BookAuthorViewModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public String Description { get; set; }
        public int AuthorID { get; set; }
        public List<Author> Authors { get; set; }
    }
}
