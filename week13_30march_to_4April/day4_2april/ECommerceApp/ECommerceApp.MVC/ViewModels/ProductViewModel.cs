namespace ECommerceApp.MVC.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public List<string> Categories { get; set; } = new();
    }

    public class CreateProductViewModel
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [System.ComponentModel.DataAnnotations.Range(0.01, 999999)]
        public decimal Price { get; set; }

        [System.ComponentModel.DataAnnotations.Range(0, 999999)]
        public int Stock { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public List<int> CategoryIds { get; set; } = new();
    }
}