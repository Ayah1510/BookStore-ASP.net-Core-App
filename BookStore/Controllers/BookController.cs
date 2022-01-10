using BookStore.Models;
using BookStore.Models.Repositories;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBooksStoreRepository<Book> bookRepository;
        private readonly IBooksStoreRepository<Author> authorRepository;

        public BookController(IBooksStoreRepository<Book> bookRepository, IBooksStoreRepository<Author> authorRepository)
        {
            this.bookRepository = bookRepository;
            this.authorRepository = authorRepository;
        }
        // GET: BookController
        public ActionResult Index()
        {
            var books = bookRepository.List();
            return View(books);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var book = bookRepository.Find(id);
            return View(book);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            var model = new BookAuthorViewModel
            {
                Authors = FillList()
            };
            return View(model);
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookAuthorViewModel model)
        {
            try
            {
                if(model.AuthorID == -1)
                {
                    ViewBag.Message = "Please select an author from the list!";
                    var vmodel = new BookAuthorViewModel
                    {
                        Authors = FillList()
                    };
                    return View(vmodel);
                }
                Book book = new Book
                {
                    ID = model.BookId,
                    Title = model.Title,
                    Description = model.Description,
                    Author = authorRepository.Find(model.AuthorID)

                };
                bookRepository.Add(book);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            Book book = bookRepository.Find(id);
            var authorID = book.Author == null ? book.Author.ID=0 : book.Author.ID;
            var viewModel = new BookAuthorViewModel
            {
                BookId = book.ID,
                Title = book.Title,
                Description= book.Description,
                AuthorID = authorID,
                Authors = authorRepository.List().ToList()
            };

            return View(viewModel);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookAuthorViewModel model)
        {
            try
            {
                Book book = new Book
                {
                    Title = model.Title,
                    Description = model.Description,
                    Author = authorRepository.Find(model.AuthorID)

                };
                bookRepository.Update(model.BookId,book);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            var book = bookRepository.Find(id);
            return View(book);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult confirmDelete(int id)
        {
            try
            {
                bookRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        List<Author> FillList()
        {
            var authors = authorRepository.List().ToList();
            authors.Insert(0, new Author { ID = -1, FullName = "Please select an author" });
            return authors;
        }
    }
}
