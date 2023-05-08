using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }     
        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBitrh { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentId { get; set; }
        public string PhotoPath { get; set; }
        public Department Department { get; set; }
    }
}
