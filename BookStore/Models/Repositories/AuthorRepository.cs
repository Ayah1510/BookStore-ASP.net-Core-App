namespace BookStore.Models.Repositories
{
    public class AuthorRepository : IBooksStoreRepository<Author>
    {
         IList<Author> authors;
        public AuthorRepository()
        {
            authors = new List<Author>()
                {
                    new Author
                    {
                        ID = 1,FullName ="Ayah Hamdan"
                    },
                    new Author
                    {
                        ID = 2,FullName ="Lamees Khaled"
                    },
                    new Author
                    {
                        ID = 3,FullName ="Ahmad Karim"
                    },
                };
        }
            public void Add(Author entity)
        {          
            authors.Add(entity); 
        }

        public void Delete(int id)
        {
            var author = Find(id);
            authors.Remove(author);
        }

        public Author Find(int id)
        {
            var author= authors.SingleOrDefault(a => a.ID == id);
            return author;
        }

        public IList<Author> List()
        {
            return authors;
        }

        public void Update(int id, Author entity)
        {
            var author = Find(id);
            author.FullName = entity.FullName;
        }
    }
}
