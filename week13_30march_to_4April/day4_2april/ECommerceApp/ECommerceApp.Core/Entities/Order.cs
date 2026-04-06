namespace ECommerceApp.Core.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Pending";
        public decimal TotalAmount { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public List<OrderItem> OrderItems { get; set; } = new();
    }
}