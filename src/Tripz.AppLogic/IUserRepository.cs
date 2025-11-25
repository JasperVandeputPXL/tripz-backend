using Tripz.Domain.Entities;

namespace Tripz.AppLogic;

public interface IUserRepository
{
    User? FindByIdentifier(string identifier);
    User? Login(string identifier, string password);
    User RegisterNickname(string nickname, string password);
    IEnumerable<User> GetAll();
}