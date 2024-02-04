using Microsoft.AspNetCore.Server.HttpSys;

namespace ElderEase.Models
{
    public class Provider
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string city { get; set; }    
        public string state { get; set; }
        public string country { get; set; }
        public string zipCode { get; set; }
        public string password { get; set; }
        public ICollection<Service> services { get; set; } = new List<Service>();
    }
}
