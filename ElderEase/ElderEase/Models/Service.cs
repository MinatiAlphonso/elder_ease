using NuGet.Protocol;
using System.Security.Authentication.ExtendedProtection;

namespace ElderEase.Models
{
    public enum ServiceTypes { Paid, Free }

 
    public class Service
    {
        public string[] ServiceNames = [
            "Home Nurse",
            "Driver",
            "Care taker",
            "House Keeper",
            "Companion"
        ];
        public ServiceTypes serviceType {get; set; }
        public Boolean isAvailable { get; set; }
        public required String serviceName {  get; set; }
    }
}
