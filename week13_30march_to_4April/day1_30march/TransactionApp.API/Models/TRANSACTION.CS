namespace TransactionApp.API.Models;

public class Transaction
{
    public int      Id     { get; set; }           // internal — never exposed via DTO
    public decimal  Amount { get; set; }
    public DateTime Date   { get; set; }
    public string   Type   { get; set; } = "";   // "Credit" | "Debit"
    public int      UserId { get; set; }           // FK
    public User?    User   { get; set; }           // nav property
}