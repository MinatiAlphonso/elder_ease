using NuGet.Protocol;
using System.ComponentModel;
using System.Reflection;
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

    public static class EnumHelper
    {
        public static string GetDescription(Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            if (field != null)
            {
                DescriptionAttribute attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));

                if (attribute != null)
                {
                    return attribute.Description;
                }
            }

            return value.ToString();
        }
    }

    public class Service{
        public int Id { get; set; }
        public ServiceTypes serviceType {get; set; }
        public Boolean isAvailable { get; set; }
        public ServiceNames serviceName {  get; set; }
   
    }
}
