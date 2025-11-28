using Tripz.Domain.Entities;

namespace Tripz.AppLogic.Services;

public class AuthService
{
    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User?> LoginAsync(string identifier, string password)
    {
        if (string.IsNullOrWhiteSpace(identifier) || string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Identifier and password are required.");

        return await _userRepository.LoginAsync(identifier, password);
    }
}