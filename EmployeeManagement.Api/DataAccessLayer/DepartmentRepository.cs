using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.DataAccessLayer
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EmployeeDbContext employeeDbContext;

        public DepartmentRepository(EmployeeDbContext employeeDbContext)
        {
            this.employeeDbContext = employeeDbContext;
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
           return await employeeDbContext.Departments.ToListAsync();
        }

        public async Task<Department> GetDepartment(int departmentId)
        {
            var department = await employeeDbContext.Departments.FirstOrDefaultAsync(d => d.DepartmentId == departmentId);
            return department;
        }

    }
}
