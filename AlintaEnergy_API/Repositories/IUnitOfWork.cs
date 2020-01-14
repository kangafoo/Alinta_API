using AlintaEnergy_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlintaEnergy_API.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<Employee> EmployeeRepository { get; }
        /// <summary>
        /// Commits all changes
        /// </summary>
        Task Commit();
        /// <summary>
        /// Discards all changes that has not been commited
        /// </summary>
        void RejectChanges();
        void Dispose();
    }
}
