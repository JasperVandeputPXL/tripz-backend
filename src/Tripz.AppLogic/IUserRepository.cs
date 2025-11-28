using Tripz.Domain.Entities;

namespace Tripz.AppLogic
{
    public interface IUserRepository
    {
        Task<User?> FindByIdentifierAsync(string identifier);
        Task<User?> LoginAsync(string identifier, string password);
        Task<User> RegisterNicknameAsync(string nickname, string password);
        Task<IEnumerable<User>> GetAllAsync();
    }
}
