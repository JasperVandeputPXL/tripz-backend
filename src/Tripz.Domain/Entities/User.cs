namespace Tripz.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Nickname { get; set; } = string.Empty;
    public string CompanyEmail { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Role { get; set; } = "Employee";
    public ICollection<Trip> Trips { get; set; } = new List<Trip>();
}