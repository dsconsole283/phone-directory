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
        public int DepartmentId { get; set; }
        [Required]
        public TitleModel Title { get; set; }
        [Required]
        public int TitleId { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        public bool IsExec { get; set; } = false;
        [Phone(ErrorMessage ="Must not contain spaces or dashes. Must be 11 digits.")]
        public string PhoneMain { get; set; }
        [Phone(ErrorMessage = "Must not contain spaces or dashes. Must be 11 digits.")]
        public string PhoneMobile { get; set; }
        [MaxLength(4, ErrorMessage = "Max 4 digits.")]
        public string Extension { get; set; }
#nullable enable
        public string? Notes { get; set; }
#nullable disable
    }
}
