using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using ECommerceApp.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private static readonly JsonSerializerOptions _jsonOpts =
            new() { PropertyNameCaseInsensitive = true };

        public OrderController(IHttpClientFactory httpClientFactory)
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

        // GET: /Order  — My Orders (logged in user)
        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Session.GetString("JwtToken");
            if (string.IsNullOrEmpty(token))
                return RedirectToAction("Login", "Auth");

            var client   = GetClient();
            // ✅ Fixed URL: api/order/myorders
            var response = await client.GetAsync("api/order/myorders");
            var orders   = new List<OrderViewModel>();

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                orders   = JsonSerializer.Deserialize<List<OrderViewModel>>(json, _jsonOpts) ?? new();
            }

            return View(orders);
        }

        // GET: /Order/AllOrders  — Admin only
        public async Task<IActionResult> AllOrders()
        {
            if (HttpContext.Session.GetString("UserRole") != "Admin")
                return RedirectToAction("Index");

            var client   = GetClient();
            // ✅ Fixed URL: api/order (gets all orders, Admin only)
            var response = await client.GetAsync("api/order");
            var orders   = new List<OrderViewModel>();

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                orders   = JsonSerializer.Deserialize<List<OrderViewModel>>(json, _jsonOpts) ?? new();
            }

            return View(orders);
        }

        // GET: /Order/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var client   = GetClient();
            // ✅ Fixed URL: api/order/{id}
            var response = await client.GetAsync($"api/order/{id}");
            if (!response.IsSuccessStatusCode) return NotFound();

            var json  = await response.Content.ReadAsStringAsync();
            var order = JsonSerializer.Deserialize<OrderViewModel>(json, _jsonOpts);
            return View(order);
        }

        // GET: /Order/Place/5
        public IActionResult Place(int productId)
        {
            var token = HttpContext.Session.GetString("JwtToken");
            if (string.IsNullOrEmpty(token))
                return RedirectToAction("Login", "Auth");

            var model = new PlaceOrderViewModel { ProductId = productId };
            return View(model);
        }
// POST: /Order/UpdateStatus  — Admin only
[HttpPost]
public async Task<IActionResult> UpdateStatus(int id, string status)
{
    var client   = GetClient();
    var response = await client.PatchAsync(
        $"api/order/{id}/status?status={status}", null);

    return RedirectToAction("Details", new { id });
}
        // POST: /Order/Place
        [HttpPost]
        public async Task<IActionResult> Place(PlaceOrderViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var token = HttpContext.Session.GetString("JwtToken");
            if (string.IsNullOrEmpty(token))
                return RedirectToAction("Login", "Auth");

            var client = GetClient();
            var json   = JsonSerializer.Serialize(new
            {
                items = new[]
                {
                    new { productId = model.ProductId, quantity = model.Quantity }
                },
                shippingAddress = model.ShippingAddress
            });

            var content  = new StringContent(json, Encoding.UTF8, "application/json");
            // ✅ Fixed URL: api/order
            var response = await client.PostAsync("api/order", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            // Show actual error from API for debugging
            var error = await response.Content.ReadAsStringAsync();
            ModelState.AddModelError("", $"Failed to place order. API said: {error}");
            return View(model);
        }
    }
}