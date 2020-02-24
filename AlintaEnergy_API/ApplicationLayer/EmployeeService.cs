using AlintaEnergy_API.Models;
using AlintaEnergy_API.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlintaEnergy_API.ApplicationLayer
{
    public class EmployeeService : IEmployeeService
    {
        private IUnitOfWork _unitOfWork;
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }      
       
        public async Task InsertEmployee(Employee employee)
        {
            _unitOfWork.EmployeeRepository.Add(employee);
            await _unitOfWork.Commit().ConfigureAwait(true);
        }

        public async Task UpdateEmployee(Employee employee)
        {
            _unitOfWork.EmployeeRepository.Update(employee);
             await _unitOfWork.Commit().ConfigureAwait(true);
        }

        public async Task DeleteEmployee(Employee employee)
        {
            _unitOfWork.EmployeeRepository.Remove(employee);
            await _unitOfWork.Commit().ConfigureAwait(true);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _unitOfWork.EmployeeRepository.GetEntities.ConfigureAwait(true);
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByFirstName(string firstName)
        {
            return await _unitOfWork.EmployeeRepository.FindByCondition(x => x.FirstName == firstName).ConfigureAwait(true);
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByLastName(string lastName)
        {
            return await _unitOfWork.EmployeeRepository.FindByCondition(x => x.LastName == lastName).ConfigureAwait(true);
        }

        public async Task<Employee> GetEmployee(string id)
        {
            return await _unitOfWork.EmployeeRepository.FindByConditionSingle(x => x.Id == id).ConfigureAwait(true);
        }
    }
}
