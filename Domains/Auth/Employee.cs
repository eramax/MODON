using System.ComponentModel.DataAnnotations.Schema;

namespace Domains
{
    public class Employee : BaseEntity
    {
        [ForeignKey("Job")]
        public long? Job_Id { get; set; }
        public Job Job { get; set; }

        [ForeignKey("UserAccount")]
        public long UserAccount_Id { get; set; }
        public UserAccount UserAccount { get; set; }

        public string ADUsername { get; set; }
    }
}
