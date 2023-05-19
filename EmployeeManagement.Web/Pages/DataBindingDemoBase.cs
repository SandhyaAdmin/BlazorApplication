using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages
{
    public class DataBindingDemoBase : ComponentBase
    {
        protected string Name { get; set; } = "Sandhya";
        protected string Gender { get; set; } = "Female";
        protected string Color { get; set; } = "background-color:white";
        protected string Description { get; set; } =string.Empty;
    }
}
