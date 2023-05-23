using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages
{
    public class EditEmployeeBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        public Employee Employee = new Employee();

        [Parameter]
        public string ID { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Employee = await EmployeeService.GetEmployee(int.Parse(ID));
        }
    }
}
