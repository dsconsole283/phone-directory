using static PhoneDirectory.Library.Enums.Enums;

namespace PhoneDirectory.Library.Models
{
    public class DirectoryRecordModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DepartmentModel Department { get; set; }
        public Titles Title { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneMain { get; set; }
        public string PhoneMobile { get; set; }
        public string Extension { get; set; }
        public string Notes { get; set; }
        public bool IsExec { get; set; } = false;
    }
}
