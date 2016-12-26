using System;
using System.Threading.Tasks;
using WebApiOwin.Models;

namespace WebApiOwin.Repository
{
    public interface IClientRepository
    {
        Task<Client> FindById(Guid id);
    }
}