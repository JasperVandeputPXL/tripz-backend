using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tripz.AppLogic;
using Tripz.Domain;

namespace Tripz.Infrastructure
{
    public class InMemoryUserRepository : IUserRepository
    {
        private readonly List<User> _users = new()
        {
            new User { Id = 1, CompanyEmail = "manager@company.com", Password = "1234", Role = "Manager" },
            new User { Id = 2, CompanyEmail = "employee@company.com", Password = "1234", Role = "Employee" }
        };

        public User? FindByIdentifier(string identifier)
        {
            return _users.FirstOrDefault(u =>
                u.CompanyEmail == identifier || u.Nickname == identifier);
        }

        public User RegisterNickname(string nickname, string password)
        {
            var user = new User
            {
                Id = _users.Count + 1,
                Nickname = nickname,
                Password = password,
                Role = "Employee"
            };
            _users.Add(user);
            return user;
        }

        public User? Login(string identifier, string password)
        {
            var existing = FindByIdentifier(identifier);

            if (identifier.Contains("@"))
            {
                if (existing == null)
                    return null;
                return existing.Password == password ? existing : null;
            }

            if (existing == null)
                return RegisterNickname(identifier, password);

            return existing.Password == password ? existing : null;
        }

        public IEnumerable<User> GetAll() => _users;
    }
}
