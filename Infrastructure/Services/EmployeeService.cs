using BCTECHAPI.Core.Interfaces;
using BCTECHAPI.Core.Models;
using BCTECHAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BCTECHAPI.Infrastructure.Repositories
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employee_repo;

        public EmployeeService(IEmployeeRepository _employee_repo)
        {
            this._employee_repo = _employee_repo;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _employee_repo.GetAllAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _employee_repo.GetByIdAsync(id);
        }

        public async Task<Employee> AddAsync(Employee employee)
        {
            return await _employee_repo.AddAsync(employee);
        }

        public async Task<Employee> UpdateAsync(Employee employee)
        {
            return await _employee_repo.UpdateAsync(employee);
        }

        public async Task DeleteAsync(int id)
        {
            await _employee_repo.DeleteAsync(id);
        }
    }
}
