using System.Threading.Tasks;
using WebApiOwin.Models;
using WebApiOwin.Repository;

namespace WebApiOwin.Services
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private IRefreshTokenRepository _refreshTokenRepository;

        public RefreshTokenService(IRefreshTokenRepository refreshTokenRepository)
        {
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<RefreshToken> Get(string Id)
        {
            return await _refreshTokenRepository.FindById(Id);
        }

        public async Task<bool> Save(RefreshToken refreshToken)
        {
            return await _refreshTokenRepository.Insert(refreshToken);
        }

        public async Task<bool> Remove(string Id)
        {
            return await _refreshTokenRepository.Delete(Id);
        }
    }
}