using BCrypt.Net;

var hash = BCrypt.Net.BCrypt.HashPassword("Admin@123");
Console.WriteLine("Hash: " + hash);

// Verify it works
var isValid = BCrypt.Net.BCrypt.Verify("Admin@123", hash);
Console.WriteLine("Verified: " + isValid);