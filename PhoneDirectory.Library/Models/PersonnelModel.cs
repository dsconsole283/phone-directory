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
        public int DepartmentId { get; set; }
        [Required]
        public TitleModel Title { get; set; }
        public int TitleId { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        public bool IsExec { get; set; } = false;
#nullable enable
        [MaxLength(11, ErrorMessage = "Must be 11 digits with no spaces or dashes.")]
        [MinLength(11, ErrorMessage = "Must be 11 digits with no spaces or dashes.")]
        public string? PhoneMain { get; set; }
        [MaxLength(11, ErrorMessage = "Must be 11 digits with no spaces or dashes.")]
        [MinLength(11, ErrorMessage = "Must be 11 digits with no spaces or dashes.")]

        public string? PhoneMobile { get; set; }
        [MaxLength(4, ErrorMessage = "Max 4 digits.")]
        [MinLength(3, ErrorMessage = "Minimum 3 digits")]

        public string? Extension { get; set; }
        public string? Notes { get; set; }
#nullable disable
    }
}
