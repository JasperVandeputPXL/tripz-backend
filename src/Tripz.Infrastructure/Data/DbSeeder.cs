using Tripz.Domain.Entities;
using Tripz.Domain.Enums;

namespace Tripz.Infrastructure.Data
{
    public static class DbSeeder
    {
        public static void SeedData(TripzDbContext context)
        {
            if (context.Trips.Any())
            {
                return; // Database already seeded
            }

            var trips = new List<Trip>
            {
                new Trip
                {
                    Id = Guid.NewGuid(),
                    EmployeeId = "EMP001",
                    EmployeeName = "John Doe",
                    TransportType = TransportType.Plane,
                    DepartureDate = new DateTime(2024, 1, 15),
                    ReturnDate = new DateTime(2024, 1, 18),
                    Destination = "New York",
                    EstimatedCost = 1500.00m,
                    Status = TripStatus.Submitted,
                    SubmittedAt = DateTime.Now.AddDays(-2)
                },
                new Trip
                {
                    Id = Guid.NewGuid(),
                    EmployeeId = "EMP002",
                    EmployeeName = "Jane Smith",
                    TransportType = TransportType.Train,
                    DepartureDate = new DateTime(2024, 2, 10),
                    ReturnDate = new DateTime(2024, 2, 12),
                    Destination = "Boston",
                    EstimatedCost = 450.00m,
                    Status = TripStatus.Approved,
                    SubmittedAt = DateTime.Now.AddDays(-5)
                },
                new Trip
                {
                    Id = Guid.NewGuid(),
                    EmployeeId = "EMP001",
                    EmployeeName = "John Doe",
                    TransportType = TransportType.Car,
                    DepartureDate = new DateTime(2024, 2, 20),
                    ReturnDate = new DateTime(2024, 2, 22),
                    Destination = "Philadelphia",
                    EstimatedCost = 320.00m,
                    Status = TripStatus.Submitted,
                    SubmittedAt = DateTime.Now.AddDays(-1)
                },
                new Trip
                {
                    Id = Guid.NewGuid(),
                    EmployeeId = "EMP003",
                    EmployeeName = "Bob Johnson",
                    TransportType = TransportType.Bus,
                    DepartureDate = new DateTime(2024, 3, 5),
                    ReturnDate = new DateTime(2024, 3, 7),
                    Destination = "Washington DC",
                    EstimatedCost = 280.00m,
                    Status = TripStatus.Approved,
                    SubmittedAt = DateTime.Now.AddDays(-7)
                },
                new Trip
                {
                    Id = Guid.NewGuid(),
                    EmployeeId = "EMP002",
                    EmployeeName = "Jane Smith",
                    TransportType = TransportType.Plane,
                    DepartureDate = new DateTime(2024, 3, 15),
                    ReturnDate = new DateTime(2024, 3, 20),
                    Destination = "Los Angeles",
                    EstimatedCost = 2100.00m,
                    Status = TripStatus.Submitted,
                    SubmittedAt = DateTime.Now.AddHours(-3)
                },
                new Trip
                {
                    Id = Guid.NewGuid(),
                    EmployeeId = "EMP004",
                    EmployeeName = "Alice Williams",
                    TransportType = TransportType.Train,
                    DepartureDate = new DateTime(2024, 1, 25),
                    ReturnDate = new DateTime(2024, 1, 27),
                    Destination = "Chicago",
                    EstimatedCost = 680.00m,
                    Status = TripStatus.Completed,
                    SubmittedAt = DateTime.Now.AddDays(-20)
                },
                new Trip
                {
                    Id = Guid.NewGuid(),
                    EmployeeId = "EMP003",
                    EmployeeName = "Bob Johnson",
                    TransportType = TransportType.Car,
                    DepartureDate = new DateTime(2024, 2, 5),
                    ReturnDate = new DateTime(2024, 2, 6),
                    Destination = "Baltimore",
                    EstimatedCost = 150.00m,
                    Status = TripStatus.Rejected,
                    SubmittedAt = DateTime.Now.AddDays(-10)
                }
            };

            context.Trips.AddRange(trips);
            context.SaveChanges();

            var users = new List<User>
            {
                new User { CompanyEmail = "manager@company.com", Password = "1234", Role = "Manager" },
                new User { CompanyEmail = "employee@company.com", Password = "1234", Role = "Employee" },
                new User { Nickname = "JohnDoe", Password = "abcd", Role = "Employee" },
                new User { Nickname = "JaneS", Password = "pass", Role = "Employee" }
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}