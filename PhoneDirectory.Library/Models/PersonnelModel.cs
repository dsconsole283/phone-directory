using System.ComponentModel.DataAnnotations;

namespace PhoneDirectory.Library.Models
{
    public class PersonnelModel
    {
        public int Id{ get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DepartmentModel Department { get; set; }
        [Required]
        public TitleModel Title { get; set; }
        public int TitleId { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public bool IsExec { get; set; } = false;
#nullable enable
        public int? DepartmentId { get; set; }
        public string? PhoneMain { get; set; }
        public string? PhoneMobile { get; set; }
        public string? Extension { get; set; }
        public string? Notes { get; set; }
#nullable disable
    }
}
