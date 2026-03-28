using Microsoft.AspNetCore.Mvc;
using ProductManagement.Data;
using ProductManagement.Models;

namespace ProductManagement.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Product
        public IActionResult Index()
        {
            // ── Uncomment to TEST exception filter ──
            // throw new Exception("Test crash!");

            var products = _context.Products.ToList();
            return View(products);
        }

        // GET: /Product/Details/1
        public IActionResult Details(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();
            return View(product);
        }

        // GET: /Product/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            _context.Products.Add(product);
            _context.SaveChanges();

            TempData["SuccessMessage"] = $"Product '{product.Name}' added!";
            return RedirectToAction("Index");
        }
    }
}