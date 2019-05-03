using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domains
{
    public class Notification : NamedBaseEntity
    {
        public string ActionUrl { get; set; }
        public DateTime SeenDate { get; set; }
        public Int64 FromUserID { get; set; }
        public Int64 ToUserID { get; set; }
        public bool IsSent { get; set; }
        public bool IsReceived { get; set; }
        public bool IsSeen { get; set; }
        public string NotificationMessage { get; set; }
        public string NotificationData { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("NotificationType")]
        public Int64 NotificationTypeID { get; set; }
        public NotificationType NotificationType { get; set; }
    }
}
