namespace PhoneDirectory.Library.Models
{
    public class PersonnelModel
    {
        public int Id{ get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DepartmentModel Department { get; set; }
        public int DepartmentId { get; set; }
        public TitleModel Title { get; set; }
        public int TitleId { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneMain { get; set; }
        public string PhoneMobile { get; set; }
        public string Extension { get; set; }
        public string Notes { get; set; }
        public bool IsExec { get; set; } = false;
    }
}
