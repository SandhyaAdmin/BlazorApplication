using EmployeeManagement.Models;
using EmployeeManagement.Models.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Web.Models
{
    public class EditEmployeeModel
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Fisrt Name must be provided")]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [EmailAddress]
        [EmailDomainValidator(AllowedDomain = "uhg.com", ErrorMessage = "domain name must be uhg.com")]
        public string Email { get; set; }

        [CompareProperty("Email", ErrorMessage = "Email and confirmEmail must match")]
        public string ConfirmEmail { get; set; }
        public DateTime DateOfBitrh { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentId { get; set; }
        public string PhotoPath { get; set; }

        [ValidateComplexType]
        public Department Department { get; set; } = new Department();
    }
}
