using AlintaEnergy_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AlintaEnergy_API.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AlintaEnergy_API_DBContext _dbContext;

        #region Repositories
        public IRepository<Employee> EmployeeRepository =>
           new GenericRepository<Employee>(_dbContext);
        #endregion
        public UnitOfWork(AlintaEnergy_API_DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync().ConfigureAwait(true);
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }
        public void RejectChanges()
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries()
                  .Where(e => e.State != EntityState.Unchanged))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }
    }
}
