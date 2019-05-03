using System.Collections.Generic;

namespace Domains
{
    public class Country : Location
    {
        public List<City> Cities { get; set; }
    }
}
