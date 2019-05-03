using System;
using System.Collections.Generic;

namespace Domains
{
    public class Order : BaseEntity
    {
        public string OtherFiles { get; set; }
        public string RefusedFields { get; set; }
        public List<Comment> Comments { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public UserAccount ApprovaledBy { get; set; }
        public DateTime? FinalApprovalDate { get; set; }
        public UserAccount FinalApprovaledBy { get; set; }
    }
}
