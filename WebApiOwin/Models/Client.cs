using System;

namespace WebApiOwin.Models
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Secret { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int RefreshTokenLifeTime { get; set; }
        public DateTime DateAdded { get; set; }
    }
}