using Grocery.Core.Helpers;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IClientService _clientService;
        public AuthService(IClientService clientService)
        {
            _clientService = clientService;
        }
        public Client? Login(string email, string password)
        {
            Client? client = _clientService.Get(email);
            if (client != null)
            {
                bool validPassword = PasswordHelper.VerifyPassword(password, client.Password);
                if (validPassword)
                {
                    return client;
                }
            }
            return null;
        }
    }
}
