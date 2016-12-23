using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiOwin.Models;

namespace WebApiOwin.Services
{
    public interface IRefreshTokenService
    {
        Task<RefreshToken> Get(string Id);
        Task<bool> Save(RefreshToken refreshToken);
        Task<bool> Remove(string Id);
    }
}
