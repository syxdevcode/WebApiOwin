using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiOwin.Models;

namespace WebApiOwin.Repository
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken> FindById(string Id);

        Task<bool> Insert(RefreshToken refreshToken);

        Task<bool> Delete(string Id);
    }
}
