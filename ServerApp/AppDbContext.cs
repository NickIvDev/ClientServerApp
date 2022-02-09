using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp
{
    // модель, настройка бд
    public class AppDbContext : DbContext
    {
        public DbSet<CarModel> CarModels { get; set; }

        public AppDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=carsModelDb;Trusted_Connection=True;");
        }
    }
}
