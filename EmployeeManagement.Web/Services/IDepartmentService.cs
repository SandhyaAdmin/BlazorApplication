﻿using EmployeeManagement.Models;

namespace EmployeeManagement.Web.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> GetDepartmentById(int id);

    }
}
    