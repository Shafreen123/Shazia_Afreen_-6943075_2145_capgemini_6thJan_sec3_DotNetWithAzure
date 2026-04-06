using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using ECommerceApp.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private static readonly JsonSerializerOptions _jsonOpts =
            new() { PropertyNameCaseInsensitive = true };

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private HttpClient GetClient()
        {
            var client = _httpClientFactory.CreateClient("API");
            var token  = HttpContext.Session.GetString("JwtToken");
            if (!string.IsNullOrEmpty(token))
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            return client;
        }

        // GET: /Product
        public async Task<IActionResult> Index(string? search)
        {
            var client = GetClient();
            var url = string.IsNullOrEmpty(search)
                ? "api/product"
                : $"api/product/search?keyword={search}";

            var response = await client.GetAsync(url);
            var products = new List<ProductViewModel>();

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                products = JsonSerializer.Deserialize<List<ProductViewModel>>(json, _jsonOpts) ?? new();
            }

            ViewBag.Search = search;
            return View(products);
        }

        // GET: /Product/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var client   = GetClient();
            var response = await client.GetAsync($"api/product/{id}");
            if (!response.IsSuccessStatusCode) return NotFound();

            var json    = await response.Content.ReadAsStringAsync();
            var product = JsonSerializer.Deserialize<ProductViewModel>(json, _jsonOpts);
            return View(product);
        }

        // GET: /Product/Create (Admin only)
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("UserRole") != "Admin")
                return RedirectToAction("Index");
            return View(new CreateProductViewModel());
        }

        // POST: /Product/Create
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var client = GetClient();
            var json   = JsonSerializer.Serialize(new
            {
                name        = model.Name,
                description = model.Description,
                price       = model.Price,
                stock       = model.Stock,
                imageUrl    = model.ImageUrl,
                categoryIds = model.CategoryIds
            });
            var content  = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/product", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            ModelState.AddModelError("", "Failed to create product.");
            return View(model);
        }

        // POST: /Product/Delete/5 (Admin only)
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var client = GetClient();
            await client.DeleteAsync($"api/product/{id}");
            return RedirectToAction("Index");
        }
    }
}