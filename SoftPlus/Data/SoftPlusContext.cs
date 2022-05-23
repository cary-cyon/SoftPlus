using Microsoft.EntityFrameworkCore;
using SoftPlus.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftPlus.Data
{
    internal class SoftPlusContext : DbContext
    {
        
        public DbSet<Client> Clients { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ClientStatus> ClientStatuses { get; set; }
        public DbSet<ClientProduct> ClientProducts { get; set; }
        
        public SoftPlusContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=SoftPlusDataBase;Trusted_Connection=True;");
        }

    }
}
