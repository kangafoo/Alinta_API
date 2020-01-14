using AlintaEnergy_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlintaEnergy_API.ApplicationLayer
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<IEnumerable<Employee>> GetEmployeesByFirstName(string firstName);
        Task<IEnumerable<Employee>> GetEmployeesByLastName(string lastName);
        Task UpdateEmployee(Employee employee);
        Task InsertEmployee(Employee employee);
        Task DeleteEmployee(Employee employee);
        Task<Employee> GetEmployee(string id);        
    }
}