using System.Collections.Generic;

namespace Domains
{
    public class NotificationType : NamedBaseEntity
    {
        public NotificationType()
        {
            this.Notifications = new HashSet<Notification>();
        }

        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
