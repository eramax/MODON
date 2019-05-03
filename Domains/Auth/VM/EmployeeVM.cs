namespace Domains
{
    public class EmployeeVM : EntityKey
    {
        public long? Job_Id { get; set; }
        public Job Job { get; set; }
        public long UserAccount_Id { get; set; }
        public UserAccount UserAccount { get; set; }
        public UserAccountVM UserAccountVM { get; set; }
        public string ADUsername { get; set; }
        public bool FinalPermission { get; set; }
    }
}
