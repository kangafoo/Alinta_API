using AlintaEnergy_API.ApplicationLayer;
using AlintaEnergy_API.Models;
using AlintaEnergy_API.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace AlintaEnergy_API.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task EmployeeService_GetEmployees()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            var employeeRepository = new Mock<IRepository<Employee>>();
            employeeRepository.Setup(x => x.GetEntities).ReturnsAsync(new List<Employee>());
            unitOfWork.Setup(x => x.EmployeeRepository).Returns(employeeRepository.Object);
            unitOfWork.Setup(x => x.Commit());

            var employeeService = new EmployeeService(unitOfWork.Object);
            await employeeService.GetEmployees().ConfigureAwait(true);

            unitOfWork.Verify(m => m.EmployeeRepository.GetEntities, Times.Once());
        }
        [Test]
        public async Task EmployeeService_DeleteEmployee()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            var employeeRepository = new Mock<IRepository<Employee>>();
            employeeRepository.Setup(x => x.Remove(It.IsAny<Employee>()));
            unitOfWork.Setup(x => x.EmployeeRepository).Returns(employeeRepository.Object);
            unitOfWork.Setup(x => x.Commit());

            var employeeService = new EmployeeService(unitOfWork.Object);
            await employeeService.DeleteEmployee(It.IsAny<Employee>()).ConfigureAwait(true);

            unitOfWork.Verify(m => m.EmployeeRepository.Remove(It.IsAny<Employee>()), Times.Once());
        }
        [Test]
        public async Task EmployeeService_GetEmployee()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            var employeeRepository = new Mock<IRepository<Employee>>();
            employeeRepository.Setup(x => x.FindByConditionSingle(It.IsAny<Expression<Func<Employee, bool>>>())).ReturnsAsync(() => null);
            unitOfWork.Setup(x => x.EmployeeRepository).Returns(employeeRepository.Object);

            var employeeService = new EmployeeService(unitOfWork.Object);
            await employeeService.GetEmployee(It.IsAny<string>()).ConfigureAwait(true);

            unitOfWork.Verify(m => m.EmployeeRepository.FindByConditionSingle(It.IsAny<Expression<Func<Employee, bool>>>()), Times.Once());
        }
        [Test]
        public async Task EmployeeService_GetEmployeesByFirstName()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            var employeeRepository = new Mock<IRepository<Employee>>();
            employeeRepository.Setup(x => x.FindByCondition(It.IsAny<Expression<Func<Employee, bool>>>())).ReturnsAsync(() => null);
            unitOfWork.Setup(x => x.EmployeeRepository).Returns(employeeRepository.Object);
            unitOfWork.Setup(x => x.Commit());

            var employeeService = new EmployeeService(unitOfWork.Object);
            await employeeService.GetEmployeesByFirstName(It.IsAny<string>()).ConfigureAwait(true);

            unitOfWork.Verify(m => m.EmployeeRepository.FindByCondition(It.IsAny<Expression<Func<Employee, bool>>>()), Times.Once());
        }
        [Test]
        public async Task EmployeeService_GetEmployeesByLastName()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            var employeeRepository = new Mock<IRepository<Employee>>();
            employeeRepository.Setup(x => x.FindByCondition(It.IsAny<Expression<Func<Employee, bool>>>())).ReturnsAsync(() => null);
            unitOfWork.Setup(x => x.EmployeeRepository).Returns(employeeRepository.Object);
            unitOfWork.Setup(x => x.Commit());

            var employeeService = new EmployeeService(unitOfWork.Object);
            await employeeService.GetEmployeesByLastName(It.IsAny<string>()).ConfigureAwait(true);

            unitOfWork.Verify(m => m.EmployeeRepository.FindByCondition(It.IsAny<Expression<Func<Employee, bool>>>()), Times.Once());
        }
        [Test]
        public async Task EmployeeService_UpdateEmployee()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            var employeeRepository = new Mock<IRepository<Employee>>();
            employeeRepository.Setup(x => x.Update(It.IsAny<Employee>()));
            unitOfWork.Setup(x => x.EmployeeRepository).Returns(employeeRepository.Object);
            unitOfWork.Setup(x => x.Commit());

            var employeeService = new EmployeeService(unitOfWork.Object);
            await employeeService.UpdateEmployee(It.IsAny<Employee>()).ConfigureAwait(true);

            unitOfWork.Verify(m => m.EmployeeRepository.Update(It.IsAny<Employee>()), Times.Once());
            unitOfWork.Verify(m => m.Commit(), Times.Once());

        }

        [Test]
        public async Task EmployeeService_InsertEmployee()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            var employeeRepository = new Mock<IRepository<Employee>>();
            employeeRepository.Setup(x => x.Add(It.IsAny<Employee>()));
            unitOfWork.Setup(x => x.EmployeeRepository).Returns(employeeRepository.Object);
            unitOfWork.Setup(x => x.Commit());

            var employeeService = new EmployeeService(unitOfWork.Object);
            await employeeService.InsertEmployee(It.IsAny<Employee>()).ConfigureAwait(true);

            unitOfWork.Verify(m => m.EmployeeRepository.Add(It.IsAny<Employee>()), Times.Once());
        }
    }
}