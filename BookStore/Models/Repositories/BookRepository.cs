namespace BookStore.Models.Repositories
{
    public class BookRepository : IBooksStoreRepository<Book>
    {
         List <Book> books;
        public BookRepository()
        {
            books = new List<Book>()
            {
                new Book
                {
                    ID = 1,Title = "Java Programming", Description = "No description", Author = new Author{ ID = 2 }
                },
                 new Book
                {
                    ID = 2,Title = "Python Programming", Description = "No description", Author = new Author()
                },
                  new Book
                {
                    ID = 3,Title = "c# Programming", Description = "No data", Author = new Author()
                }
            };
        }
        public void Add(Book entity)
        {
            books.Add(entity);
        }

        public void Delete(int id)
        {
            var book = Find(id);
            books.Remove(book);
        }

        public Book Find(int id)
        {
            var book = books.SingleOrDefault(x => x.ID == id);
            return book;
        }

        public IList<Book> List()
        {
            return books;
        }

        public void Update(int id, Book entity)
        {
            var book = Find(id);
            book.Title = entity.Title;
            book.Description = entity.Description;
            book.Author = entity.Author;
        }
    }
}
