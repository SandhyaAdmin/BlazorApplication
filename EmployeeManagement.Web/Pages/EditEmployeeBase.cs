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

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public EditEmployeeModel EditEmployeeModel = new EditEmployeeModel();

        public Employee Employee = new Employee();

        public List<Department> Departments = new List<Department>();
        public string PageHeaderText { get; set; }


        [Parameter]
        public string ID { get; set; }

        protected async override Task OnInitializedAsync()
        {
           // Employee = await EmployeeService.GetEmployee(int.Parse(ID));
            //EditEmployeeModel.FirstName = Employee.FirstName;
            //EditEmployeeModel.LastName = Employee.LastName;
            //EditEmployeeModel.Email = Employee.Email;
            //EditEmployeeModel.DateOfBitrh = Employee.DateOfBitrh;
            //EditEmployeeModel.ConfirmEmail = Employee.Email;
            //EditEmployeeModel.DepartmentId = Employee.DepartmentId;
            //EditEmployeeModel.Department.DepartmentName = Employee.Department.DepartmentName;

            int.TryParse(ID, out int employeeId);
            //if employeeId is not null then we know we have valid employeeId, we are going to use this to edit existing employee
            if (employeeId != 0)
            {
                PageHeaderText = "Edit Employee";
                Employee = await EmployeeService.GetEmployee(int.Parse(ID));
            }
            // Here, we do not have employee id in the url, then we are going to use EditEmployee Component, to create the component
            else
            {
                PageHeaderText = "Create Employee";
                // Default values
                Employee = new Employee
                {
                    DepartmentId = 1,
                    DateOfBitrh = DateTime.Now,
                    PhotoPath = "images/nophoto.jpg"
                };
            }

            Departments = (await DepartmentService.GetDepartments()).ToList();
            Mapper.Map(Employee, EditEmployeeModel);
        }
        protected void HandleValidSubmit() 
        {
            Object result = new Object();
            Mapper.Map(EditEmployeeModel, Employee);

            if (Employee.EmployeeId != 0)
            {
                result = EmployeeService.UpdateEmployee(Employee);
            }
            else
            {
                result = EmployeeService.CreateEmployee(Employee);
            }

            if (result != null)
            {
                /* If the update is successfull, navigate to Employee List Component otherwise,
                We stayed on to EditEmployeeBase component, display the validation errors if any.
                */
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
