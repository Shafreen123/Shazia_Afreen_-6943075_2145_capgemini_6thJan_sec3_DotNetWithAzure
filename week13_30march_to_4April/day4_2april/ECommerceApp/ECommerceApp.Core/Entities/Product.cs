namespace ECommerceApp.Core.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; } = true;
        public string ImageUrl { get; set; } = string.Empty;   // ← Added

        public List<ProductCategory> ProductCategories { get; set; } = new();
        public List<OrderItem> OrderItems { get; set; } = new();
    }
}