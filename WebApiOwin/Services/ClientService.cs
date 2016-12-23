using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApiOwin.Models;

namespace WebApiOwin.Services
{
    public class ClientService
    {
        public async Task<Client> Get(string clientId)
        {
            return new Client() { Id = Guid.NewGuid(), Name = "test", DateAdded = DateTime.UtcNow, RefreshTokenLifeTime = 1000 };
        }
    }
}