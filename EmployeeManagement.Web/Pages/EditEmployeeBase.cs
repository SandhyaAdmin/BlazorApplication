using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using EmployeeManagement.Web.Models;
using AutoMapper;

namespace EmployeeManagement.Web.Pages
{
    public class EditEmployeeBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        
        [Inject]
        public IDepartmentService DepartmentService { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public EditEmployeeModel EditEmployeeModel = new EditEmployeeModel();

        public Employee Employee = new Employee();

        public List<Department> Departments = new List<Department>();

        [Parameter]
        public string ID { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Employee = await EmployeeService.GetEmployee(int.Parse(ID));
            //EditEmployeeModel.FirstName = Employee.FirstName;
            //EditEmployeeModel.LastName = Employee.LastName;
            //EditEmployeeModel.Email = Employee.Email;
            //EditEmployeeModel.DateOfBitrh = Employee.DateOfBitrh;
            //EditEmployeeModel.ConfirmEmail = Employee.Email;
            //EditEmployeeModel.DepartmentId = Employee.DepartmentId;
            //EditEmployeeModel.Department.DepartmentName = Employee.Department.DepartmentName;

            Mapper.Map(Employee, EditEmployeeModel);

            Departments = (await DepartmentService.GetDepartments()).ToList();
        }
        protected void HandleValidSubmit() 
        {
        }
    }
}
