using EmployeeManagement.Models;

namespace EmployeeManagement.Web.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;
        private readonly ILogger<EmployeeService> logger;
        public EmployeeService(HttpClient httpClient, ILogger<EmployeeService> logger)
        {
            this.httpClient = httpClient;
            this.logger = logger;
        }
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            logger.LogTrace("Connecting to http client to retrive employee from api end point");
            return await httpClient.GetFromJsonAsync<Employee[]>("api/Employee");
        }

        public async Task<Employee> GetEmployee(int id)
        {
            logger.LogTrace("Connecting to http client to retrive employee details from api end point");
            return await httpClient.GetFromJsonAsync<Employee>($"api/Employee/{id}");
        }
    }
}
