using EmployeeManagement.Models.CustomValidators;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; } 
        
        [Required(ErrorMessage = "Fisrt Name must be provided")]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [EmailAddress]
        [EmailDomainValidator(AllowedDomain = "uhg.com",ErrorMessage = "domain name must be uhg.com")]
        public string Email { get; set; }
        public DateTime DateOfBitrh { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentId { get; set; }
        public string PhotoPath { get; set; }
       public Department Department { get; set; }
    }
}
