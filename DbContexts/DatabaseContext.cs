using CarWorkshop.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.DbContexts
{
    public class DatabaseContext : DbContext
    {
        private static string _connectionString => "Data Source=LUNIA-I7-12GEN-;Initial Catalog=CarWorkshopDB;Integrated Security=True;TrustServerCertificate=true";
        public DbSet<Client> Clients {get; set;}
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<Part> Parts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
