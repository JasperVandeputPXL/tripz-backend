using Microsoft.EntityFrameworkCore;
using Tripz.AppLogic;
using Tripz.Domain.Entities;
using Tripz.Infrastructure.Data;

namespace Tripz.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TripzDbContext _context;

        public UserRepository(TripzDbContext context)
        {
            _context = context;
        }

        public async Task<User?> FindByIdentifierAsync(string identifier)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u =>
                    u.CompanyEmail == identifier ||
                    u.Nickname == identifier);
        }

        public async Task<User> RegisterNicknameAsync(string nickname, string password)
        {
            var user = new User
            {
                Nickname = nickname,
                Password = password,
                Role = "Employee"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User?> LoginAsync(string identifier, string password)
        {
            var existing = await FindByIdentifierAsync(identifier);

            if (existing == null)
                return null;

            return existing.Password == password ? existing : null;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
