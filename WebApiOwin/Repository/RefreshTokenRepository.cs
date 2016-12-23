using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using WebApiOwin.Models;

namespace WebApiOwin.Repository
{
    public class RefreshTokenRepository:IRefreshTokenRepository
    {
        private string _jsonFilePath;
        private List<RefreshToken> _refreshTokens;

        public RefreshTokenRepository()
        {
            _jsonFilePath = HostingEnvironment.MapPath("~/App_Data/RefreshToken.json");
            if (File.Exists(_jsonFilePath))
            {
                var json = File.ReadAllText(_jsonFilePath);
                _refreshTokens = JsonConvert.DeserializeObject<List<RefreshToken>>(json);

            }
            if (_refreshTokens == null) _refreshTokens = new List<RefreshToken>();
        }

        public async Task<RefreshToken> FindById(string Id)
        {
            return _refreshTokens.Where(x => x.Id == Id).FirstOrDefault();
        }

        public async Task<bool> Insert(RefreshToken refreshToken)
        {
            _refreshTokens.Add(refreshToken);
            await WriteJsonToFile();
            return true;
        }

        public async Task<bool> Delete(string Id)
        {
            _refreshTokens.RemoveAll(x => x.Id == Id);
            await WriteJsonToFile();
            return true;
        }

        private async Task WriteJsonToFile()
        {
            using (var tw = TextWriter.Synchronized(new StreamWriter(_jsonFilePath, false)))
            {
                await tw.WriteAsync(JsonConvert.SerializeObject(_refreshTokens, Formatting.Indented));
            }
        }
    }
}