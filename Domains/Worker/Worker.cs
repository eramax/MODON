using System;

namespace Domains
{
    public class Worker : NamedBaseEntity
    {
        public string JobName { get; set; }
        public Int64 RelegionId { get; set; }

        public DateTime BirthDate { get; set; }
        public Int64 NationalityId { get; set; }

        public string IDCardNumber { get; set; }
        public DateTime IDCardStartDate { get; set; }
        public DateTime IDCardExpireDate { get; set; }

        public string PhoneNumber { get; set; }

        public string EmployeerName { get; set; }

        //[ForeignKey("IndustrialCity")]
        //public Int64 IndustrialCityId { get; set; }
        //public IndustrialCity IndustrialCity { get; set; }

        public string IDPicture { get; set; }
        public string WorkerPicture { get; set; }
    }
}
