namespace StudentManagementAPI.DTOs;

// Used for PUT — only Name and Email, no Password
public class StudentUpdateDTO
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}