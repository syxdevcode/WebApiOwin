using System;
using System.Threading.Tasks;
using WebApiOwin.Models;

namespace WebApiOwin.Services
{
    public class ClientService : IClientService
    {
        public async Task<Client> Get(string clientId)
        {
            return new Client() { Id = Guid.NewGuid(), Name = "WebApiOwin", Secret = "123", DateAdded = DateTime.UtcNow, RefreshTokenLifeTime = 1000 };
        }
    }
}