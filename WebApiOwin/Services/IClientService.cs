using System.Threading.Tasks;
using WebApiOwin.Models;

namespace WebApiOwin.Services
{
    public interface IClientService
    {
        Task<Client> Get(string clientId);
    }
}