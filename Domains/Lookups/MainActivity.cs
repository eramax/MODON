using System.Collections.Generic;

namespace Domains
{
    public class MainActivity : NamedBaseEntity
    {
        public ICollection<SubActivity> SubActivities { get; } = new List<SubActivity>();
    }
}
