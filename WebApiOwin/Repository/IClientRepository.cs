using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiOwin.Models;

namespace WebApiOwin.Repository
{
    public interface IClientRepository
    {
        Task<Client> FindById(Guid id);
    }
}
