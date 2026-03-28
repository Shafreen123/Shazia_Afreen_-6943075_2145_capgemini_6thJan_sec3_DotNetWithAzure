using Microsoft.AspNetCore.Mvc;
using LibraryApp.Data;
using LibraryApp.Models;
using LibraryApp.ViewModels;

namespace LibraryApp.Controllers
{
    public class BooksController : Controller
    {
        // DbContext injected via constructor (Dependency Injection)
        private readonly LibraryDbContext _context;

        public BooksController(LibraryDbContext context)
        {
            _context = context;
        }

        // GET: /Books  (default route lands here now)
        public IActionResult Index()
        {
            ViewBag.WelcomeMessage = "Welcome to the Library!";
            ViewData["TotalBooks"] = _context.Books.Count();
            var viewModels = _context.Books.Select(b => new BookViewModel
            {
                Book = b,
                IsAvailable = true,
                BorrowerName = ""
            }).ToList();

            return View(viewModels);
        }

        // GET: /Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(book);      // adds to DbContext
                _context.SaveChanges();         // writes to SQL Server
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }
    }
}
