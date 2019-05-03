using System;
using System.Collections.Generic;

namespace Domains
{
    public class WorkerVM : IEntityKey
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string JobName { get; set; }
        public long RelegionId { get; set; }
        public SelectItem Relegion { get; set; }

        public DateTime BirthDate { get; set; }
        public long NationalityId { get; set; }
        public SelectItem Nationality { get; set; }

        public string IDCardNumber { get; set; }
        public DateTime IDCardStartDate { get; set; }
        public DateTime IDCardExpireDate { get; set; }

        public string PhoneNumber { get; set; }

        public string EmployeerName { get; set; }

        public List<long> IndustrialCities { get; set; }

        public long IndustrialCityId { get; set; }
        public IndustrialCity IndustrialCity { get; set; }

        public string IDPictureFile { get; set; }
        public string WorkerPictureFile { get; set; }

        public string IDPicture { get; set; }
        public string WorkerPicture { get; set; }
    }
}
