namespace StudentManagementAPI.DTOs;

public class StudentReadDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}