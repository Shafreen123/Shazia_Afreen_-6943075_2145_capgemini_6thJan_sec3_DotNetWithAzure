using System;

class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
}

class Electronics : Product { }
class Clothing : Product { }
class Books : Product { }

class Customer
{
    public string CustomerName { get; set; }
}

class Cart
{
    public void AddProduct(Product p)
    {
        Console.WriteLine(p.Name + " added to cart");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Electronics e = new Electronics();
        e.Name = "Laptop";
        e.Price = 60000;

        Cart cart = new Cart();
        cart.AddProduct(e);
    }
}