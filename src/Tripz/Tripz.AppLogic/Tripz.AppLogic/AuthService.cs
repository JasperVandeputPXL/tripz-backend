using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tripz.Domain;

namespace Tripz.AppLogic
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User? Login(string identifier, string password)
        {
            if (string.IsNullOrWhiteSpace(identifier) || string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Identifier and password are required.");

            return _userRepository.Login(identifier, password);
        }
    }
}
