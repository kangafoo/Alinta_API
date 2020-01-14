using AlintaEnergy_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlintaEnergy_API.Models
{
    public class AlintaEnergy_API_DBContext : DbContext
    {
        public AlintaEnergy_API_DBContext(DbContextOptions<AlintaEnergy_API_DBContext> options):base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
