using System.Collections.Generic;

namespace Domains
{
    public class UserAccountVM : IEntityKey
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string SSID { get; set; }
        public long? Client_Id { get; set; }
        public Client Client { get; set; }
        public long? Employee_Id { get; set; }
        public Employee Employee { get; set; }
        public int CountryCode { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Password2 { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public int IsEnabled { get; set; }
        public long? CurrentUser_Id { get; set; }
        public List<long> IndustrialCitiesIds { get;set;}
        public List<IndustrialCity> IndustrialCities { get; set; }
    }
}
