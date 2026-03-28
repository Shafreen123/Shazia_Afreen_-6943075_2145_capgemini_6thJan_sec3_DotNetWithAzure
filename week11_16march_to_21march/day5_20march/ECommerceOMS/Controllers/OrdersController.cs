using ECommerceOMS.Data;
using ECommerceOMS.Models;
using ECommerceOMS.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ECommerceOMS.Controllers
{
    public class OrdersController : Controller
    {
        private readonly AppDbContext _db;
        public OrdersController(AppDbContext db) => _db = db;

        public async Task<IActionResult> Index() =>
            View(await _db.Orders.Include(o => o.Customer).ToListAsync());

        public async Task<IActionResult> Details(int id)
        {
            var order = await _db.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems).ThenInclude(oi => oi.Product)
                .Include(o => o.ShippingDetail)
                .FirstOrDefaultAsync(o => o.OrderId == id);

            if (order == null) return NotFound();

            var vm = new OrderDetailsViewModel
            {
                Order = order,
                OrderItems = order.OrderItems.ToList(),
                ShippingDetail = order.ShippingDetail,
                Customer = order.Customer
            };
            return View(vm);
        }

        // ✅ Fixed: ViewBag names now match the view exactly
        public IActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(_db.Customers, "CustomerId", "Email");

            ViewBag.Status = new SelectList(
                Enum.GetValues(typeof(OrderStatus))
                    .Cast<OrderStatus>()
                    .Select(s => new { Value = (int)s, Text = s.ToString() }),
                "Value", "Text");

            ViewBag.Products = _db.Products.Include(p => p.Category).ToList();

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Order order, int[] productIds,
                                                int[] quantities, string shippingAddress)
        {
            if (productIds == null || productIds.Length == 0)
            {
                ModelState.AddModelError("", "Please select at least one product.");

                ViewBag.CustomerId = new SelectList(_db.Customers, "CustomerId", "Email");
                ViewBag.Status = new SelectList(
                    Enum.GetValues(typeof(OrderStatus))
                        .Cast<OrderStatus>()
                        .Select(s => new { Value = (int)s, Text = s.ToString() }),
                    "Value", "Text");
                ViewBag.Products = _db.Products.Include(p => p.Category).ToList();

                return View(order);
            }

            order.OrderDate = DateTime.Now;
            order.Status = OrderStatus.Pending;
            order.TotalAmount = 0;

            for (int i = 0; i < productIds.Length; i++)
            {
                var product = await _db.Products.FindAsync(productIds[i]);
                if (product == null) continue;

                var item = new OrderItem
                {
                    ProductId = productIds[i],
                    Quantity = quantities[i],
                    UnitPrice = product.Price
                };
                order.OrderItems.Add(item);
                order.TotalAmount += item.UnitPrice * item.Quantity;
            }

            _db.Orders.Add(order);
            await _db.SaveChangesAsync();

            var shipping = new ShippingDetail
            {
                OrderId = order.OrderId,
                ShippingAddress = shippingAddress,
                Status = "Pending"
            };
            _db.ShippingDetails.Add(shipping);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // ✅ Fixed: ViewBag.CustomerId and ViewBag.Status consistent with view
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var order = await _db.Orders.FindAsync(id);
            if (order == null) return NotFound();

            ViewBag.CustomerId = new SelectList(
                _db.Customers, "CustomerId", "Email", order.CustomerId);

            ViewBag.Status = new SelectList(
                Enum.GetValues(typeof(OrderStatus))
                    .Cast<OrderStatus>()
                    .Select(s => new { Value = (int)s, Text = s.ToString() }),
                "Value", "Text",
                (int)order.Status);   // ✅ pre-selects the current status

            return View(order);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Order order)
        {
            if (id != order.OrderId) return NotFound();

            if (!ModelState.IsValid)
            {
                ViewBag.CustomerId = new SelectList(
                    _db.Customers, "CustomerId", "Email", order.CustomerId);

                ViewBag.Status = new SelectList(
                    Enum.GetValues(typeof(OrderStatus))
                        .Cast<OrderStatus>()
                        .Select(s => new { Value = (int)s, Text = s.ToString() }),
                    "Value", "Text",
                    (int)order.Status);

                return View(order);
            }

            _db.Orders.Update(order);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}