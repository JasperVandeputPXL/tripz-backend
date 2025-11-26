namespace Tripz.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string? Nickname { get; set; }
    public string? CompanyEmail { get; set; }
    public string Password { get; set; } = string.Empty;
    public string Role { get; set; } = "Employee";
}