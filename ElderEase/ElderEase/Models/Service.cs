using NuGet.Protocol;
using System.ComponentModel;
using System.Security.Authentication.ExtendedProtection;

namespace ElderEase.Models
{
    public enum ServiceTypes { Paid, Free }
    public enum ServiceNames
    {
        [Description("Home Nurse")]
        HomeNurse,

        [Description("Driver")]
        Driver,

        [Description("Care Taker")]
        CareTaker,

        [Description("House Keeper")]
        HouseKeeper,

        [Description("Companion")]
        Companion
    }

    public class Service{
        public int Id { get; set; }
        public ServiceTypes serviceType {get; set; }
        public Boolean isAvailable { get; set; }
        public ServiceNames serviceName {  get; set; }
   
    }
}
