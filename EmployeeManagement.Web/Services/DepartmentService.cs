using EmployeeManagement.Models;

namespace EmployeeManagement.Web.Services
{
    public class DepartmentService :IDepartmentService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<DepartmentService> _logger;

        public DepartmentService(HttpClient httpClient, ILogger<DepartmentService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _httpClient.GetFromJsonAsync<Department[]>($"api/Department");
        }
        public async Task<Department> GetDepartmentById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Department>($"api/Department/{id}");
        }
    }
}
