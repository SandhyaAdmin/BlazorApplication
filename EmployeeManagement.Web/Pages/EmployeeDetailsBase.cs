﻿using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeDetailsBase : ComponentBase
    {
        public Models.Employee Employee { get; set; } = new Employee();

        [Parameter]
        public string Id { get; set; }

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Id = Id ?? "1";
            Employee = await EmployeeService.GetEmployee(int.Parse(Id));
        }
    }
}
