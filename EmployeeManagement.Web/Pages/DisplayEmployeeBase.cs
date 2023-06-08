using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages
{
    public class DisplayEmployeeBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public Employee Employee { get; set; }
        
        [Parameter]
        public bool ShowFooter { get; set; }

        [Parameter]
        public EventCallback<bool> OnEmployeeSeclection { get; set; }

        protected async Task CheckBoxChange(ChangeEventArgs e)
        {
            await OnEmployeeSeclection.InvokeAsync((bool)e.Value);
        }
        protected async Task Delete_Click()
        {
            await EmployeeService.DeleteEmployee(Employee.EmployeeId);
            /* First approach(Force reload: Full page reload): After Employeerecord gets deleted, navigate to EmployeeList.
                The most imp thing to rememer is pass true in second parameter for force reload
            */
            NavigationManager.NavigateTo("/", true); 
        }

    }


}
