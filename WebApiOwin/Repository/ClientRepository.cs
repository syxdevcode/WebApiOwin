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
    public class ClientRepository:IClientRepository
    {
        private static readonly Client[] _clients;

        static ClientRepository()
        {
            var json = File.ReadAllText(HostingEnvironment.MapPath("~/App_Data/clients.json"));
            _clients = JsonConvert.DeserializeObject<Client[]>(json);
        }

        public async Task<Client> FindById(Guid id)
        {
            return _clients.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}