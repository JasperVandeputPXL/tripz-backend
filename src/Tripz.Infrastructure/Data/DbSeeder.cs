using Tripz.Domain.Entities;
using Tripz.Domain.Enums;

namespace Tripz.Infrastructure.Data
{
    public static class DbSeeder
    {
        public static void SeedData(TripzDbContext context)
        {
            if (context.Users.Any())
            {
                return; // Database already seeded
            }

            // Seed users first
            var users = new List<User>
            {
                new User { Id = 1, Nickname = "Manager1", CompanyEmail = "manager@company.com", Password = "1234", Role = "Manager" },
                new User { Id = 2, Nickname = "Employee1", CompanyEmail = "employee@company.com", Password = "1234", Role = "Employee" },
                new User { Id = 3, Nickname = "JohnDoe", CompanyEmail = "johndoe@company.com", Password = "abcd", Role = "Employee" },
                new User { Id = 4, Nickname = "JaneS", CompanyEmail = "janes@company.com", Password = "pass", Role = "Employee" },
                new User { Id = 5, Nickname = "BobJ", CompanyEmail = "bobj@company.com", Password = "pass", Role = "Employee" },
                new User { Id = 6, Nickname = "AliceW", CompanyEmail = "alicew@company.com", Password = "pass", Role = "Employee" }
            };

            context.Users.AddRange(users);
            context.SaveChanges();

            // Now seed trips with UserId references
            var trips = new List<Trip>
            {
                new Trip
                {
                    Id = Guid.NewGuid(),
                    UserId = 3, // JohnDoe
                    TransportType = TransportType.Plane,
                    DepartureDate = new DateTime(2024, 1, 15),
                    ReturnDate = new DateTime(2024, 1, 18),
                    Destination = "New York",
                    Distance = 2500,
                    Purpose = "Client meeting and conference",
                    EstimatedCost = 1500.00m,
                    Status = TripStatus.Submitted,
                    SubmittedAt = DateTime.Now.AddDays(-2)
                },
                new Trip
                {
                    Id = Guid.NewGuid(),
                    UserId = 4, // JaneS
                    TransportType = TransportType.Train,
                    DepartureDate = new DateTime(2024, 2, 10),
                    ReturnDate = new DateTime(2024, 2, 12),
                    Destination = "Boston",
                    Distance = 215,
                    Purpose = "Training session",
                    EstimatedCost = 450.00m,
                    Status = TripStatus.Approved,
                    SubmittedAt = DateTime.Now.AddDays(-5)
                },
                new Trip
                {
                    Id = Guid.NewGuid(),
                    UserId = 3, // JohnDoe
                    TransportType = TransportType.Car,
                    DepartureDate = new DateTime(2024, 2, 20),
                    ReturnDate = new DateTime(2024, 2, 22),
                    Destination = "Philadelphia",
                    Distance = 95,
                    Purpose = "Site inspection",
                    EstimatedCost = 320.00m,
                    Status = TripStatus.Submitted,
                    SubmittedAt = DateTime.Now.AddDays(-1)
                },
                new Trip
                {
                    Id = Guid.NewGuid(),
                    UserId = 5, // BobJ
                    TransportType = TransportType.Bus,
                    DepartureDate = new DateTime(2024, 3, 5),
                    ReturnDate = new DateTime(2024, 3, 7),
                    Destination = "Washington DC",
                    Distance = 225,
                    Purpose = "Team building event",
                    EstimatedCost = 280.00m,
                    Status = TripStatus.Approved,
                    SubmittedAt = DateTime.Now.AddDays(-7)
                },
                new Trip
                {
                    Id = Guid.NewGuid(),
                    UserId = 4, // JaneS
                    TransportType = TransportType.Plane,
                    DepartureDate = new DateTime(2024, 3, 15),
                    ReturnDate = new DateTime(2024, 3, 20),
                    Destination = "Los Angeles",
                    Distance = 2800,
                    Purpose = "Annual conference and networking",
                    EstimatedCost = 2100.00m,
                    Status = TripStatus.Submitted,
                    SubmittedAt = DateTime.Now.AddHours(-3)
                },
                new Trip
                {
                    Id = Guid.NewGuid(),
                    UserId = 6, // AliceW
                    TransportType = TransportType.Train,
                    DepartureDate = new DateTime(2024, 1, 25),
                    ReturnDate = new DateTime(2024, 1, 27),
                    Destination = "Chicago",
                    Distance = 780,
                    Purpose = "Client presentation",
                    EstimatedCost = 680.00m,
                    Status = TripStatus.Completed,
                    SubmittedAt = DateTime.Now.AddDays(-20)
                },
                new Trip
                {
                    Id = Guid.NewGuid(),
                    UserId = 5, // BobJ
                    TransportType = TransportType.Car,
                    DepartureDate = new DateTime(2024, 2, 5),
                    ReturnDate = new DateTime(2024, 2, 6),
                    Destination = "Baltimore",
                    Distance = 40,
                    Purpose = "Commute for project work",
                    EstimatedCost = 150.00m,
                    Status = TripStatus.Rejected,
                    SubmittedAt = DateTime.Now.AddDays(-10)
                }
            };

            context.Trips.AddRange(trips);
            context.SaveChanges();
        }
    }
}