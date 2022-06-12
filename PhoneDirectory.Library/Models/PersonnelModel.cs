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
        [Required]
        [Phone(ErrorMessage = "Phone numbers must cannot contain spaces or dashes")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Phone numbers must be 11 digits")]
        public string PhoneMain { get; set; }
        [Required]
        [Phone(ErrorMessage = "Phone numbers must cannot contain spaces or dashes")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Phone numbers must be 11 digits")]
        public string PhoneMobile { get; set; }
        [Required]
        [RegularExpression(@"^\d{3,5}$", ErrorMessage = "Extensions must be between 3 and 5 digits")]
        public string Extension { get; set; }
#nullable enable
        public string? Notes { get; set; }
#nullable disable
    }
}
