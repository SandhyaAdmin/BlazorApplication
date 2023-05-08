
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.DataAccessLayer
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext employeeDbContext;

        public EmployeeRepository(EmployeeDbContext employeeDbContext)
        {
           this.employeeDbContext = employeeDbContext;
        }

        public async Task<IEnumerable<Employee>> Search(string name, Gender? gender)
        {
            IQueryable<Employee> query = employeeDbContext.Employees;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.FirstName.Contains(name)
                                    || e.LastName.Contains(name));
            }
            if(gender != null)
            {
                query = query.Where(e => e.Gender == gender);
            }
            return await query.ToListAsync();
        }
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await employeeDbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            return await employeeDbContext.Employees
                .Include(e => e.Department)
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);;
        }

        public async Task<Employee> GetEmployeeByEmail(string email)
        {
            var employeeDetails = await employeeDbContext.Employees.FirstOrDefaultAsync(e => e.Email == email);
            return employeeDetails;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await employeeDbContext.Employees.AddAsync(employee);
            await employeeDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> DeleteEmployee(int employeeId)
        {
            var employeeToDelete = await employeeDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
            if(employeeToDelete != null)
            {
                employeeDbContext.Employees.Remove(employeeToDelete);
                await employeeDbContext.SaveChangesAsync();
                return employeeToDelete;
            }
            return null;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var employeeDetails = await employeeDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);
            if(employeeDetails != null)
            {
                employeeDetails.EmployeeId = employee.EmployeeId;
                employeeDetails.FirstName = employee.FirstName;
                employeeDetails.LastName = employee.LastName;
                employeeDetails.Email = employee.Email;
                employeeDetails.DateOfBitrh = employee.DateOfBitrh;
                employeeDetails.DepartmentId = employee.DepartmentId;
                employeeDetails.Gender = employee.Gender;
                employeeDetails.PhotoPath = employee.PhotoPath;

                await employeeDbContext.SaveChangesAsync();
                return employeeDetails;
            }
            return null;
        }


    }
}
