namespace StudentManagementAPI.DTOs;

// Used for POST — accepts Password from client
public class StudentCreateDTO
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}