using EmployeeManagement.Models;

namespace EmployeeManagement.Api.DataAccessLayer
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> GetDepartment(int departmentId);
    }
}
