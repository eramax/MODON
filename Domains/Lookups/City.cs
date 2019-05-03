using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domains
{
    public class City : Location
    {
        [ForeignKey("Country")]
        public long CountryID { get; set; }
        public Country Country { get; set; }

        public List<IndustrialCity>  IndustrialCities { get; set; }

    }
}
