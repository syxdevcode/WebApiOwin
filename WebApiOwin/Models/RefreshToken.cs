using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiOwin.Models
{
    public class RefreshToken
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public Guid ClientId { get; set; }

        public DateTime IssuedUtc { get; set; }

        public DateTime ExpiresUtc { get; set; }

        public string ProtectedTicket { get; set; }
    }
}