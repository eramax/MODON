using System;

namespace Queries
{
    public class NotificationVM
    {
        public Int64 ID { get; set; }
        public Int64 FromUserID { get; set; }
        public Int64 ToUserID { get; set; }
        public Int64 RecordID { get; set; }
        public bool IsSent { get; set; }
        public bool IsReceived { get; set; }
        public bool IsSeen { get; set; }
        public string NotificationMessage { get; set; }
        public string NotificationData { get; set; }
        public Int64 NotificationTypeID { get; set; }
        public DateTime CreationDate { get; set; }
        public Nullable<Int64> CreatedBy { get; set; }
        public Nullable<Int64> ModifiedBy { get; set; }
        public Nullable<DateTime> LastUpdateDate { get; set; }
        public bool IsDeleted { get; set; }
        //public NotificationType NotificationType { get; set; }
    }
}
