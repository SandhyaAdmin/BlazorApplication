using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        [Inject]
        public IEmployeeService employeeService { get; set; }
        public IEnumerable<Employee> employees { get; set; }
        public bool ShowFooter { get; set; } = true;
        protected int SelectedEmployeesCount { get; set; } = 0;

        protected override async Task OnInitializedAsync()
        {
            //await Task.Run(LoadEmployees);
            //return base.OnInitializedAsync();
            employees = (await employeeService.GetEmployees()).ToList();
        }
        public void EmployeeSelectionChange(bool isSelected)
        {
            if (isSelected)
            {
                SelectedEmployeesCount++;
            }
            else
            {
                SelectedEmployeesCount--;
            }
            //private void LoadEmployees()
            //{
            //    System.Threading.Thread.Sleep(3000);
            //    Employee e1 = new Employee
            //    {
            //        EmployeeId = 1,
            //        FirstName = "Sandhya",
            //        LastName = "D",
            //        Email = "sandhya@gmail.com",
            //        DateOfBitrh = new DateTime(1996, 04, 26),
            //        Gender = Gender.Female,
            //        DepartmentId = 3,
            //        PhotoPath = "images/sandhya.jpeg"
            //    };
            //    Employee e2 = new Employee
            //    {
            //        EmployeeId = 2,
            //        FirstName = "Sridhar",
            //        LastName = "M",
            //        Email = "Sridhar@gmail.com",
            //        DateOfBitrh = new DateTime(1991, 03, 12),
            //        Gender = Gender.Male,
            //        DepartmentId = 3,
            //        PhotoPath = "images/sridhar.jpeg"
            //    };
            //    Employee e3 = new Employee
            //    {
            //        EmployeeId = 3,
            //        FirstName = "Deekshith",
            //        LastName = "K",
            //        Email = "Deekshith@gmail.com",
            //        DateOfBitrh = new DateTime(1998, 12, 13),
            //        Gender = Gender.Male,
            //        DepartmentId = 1,
            //        PhotoPath = "images/deekshith.jpeg"
            //    };
            //    Employee e4 = new Employee
            //    {
            //        EmployeeId = 4,
            //        FirstName = "Shirisha",
            //        LastName = "D",
            //        Email = "Shirisha@gmail.com",
            //        DateOfBitrh = new DateTime(1999, 12, 13),
            //        Gender = Gender.Female,
            //        DepartmentId = 2,
            //        PhotoPath = "images/shirisha.jpeg"
            //    };

            //    employees = new List<Employee> { e1, e2, e3, e4 };
            //}
        }

        /* When OnEmployeeDeleted eventhandler calls the EmployeeDeleted method, same as button click even which calls other method for logic
    then gets the list of employees
    EmployeeDeleted() custom event method gets called when the custom delete event triggers
*/
        protected async Task EmployeeDeleted()
        {
            employees = (await employeeService.GetEmployees()).ToList();
        }
    }
}
