using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages
{
    public class DisplayEmployeeBase : ComponentBase
    {
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

    }


}
