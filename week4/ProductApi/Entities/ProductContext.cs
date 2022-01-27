using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Entities
{
    public class ProductContext : DbContext
    {
        protected readonly IConfiguration Configuration; 
        public ProductContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Data Source = ALEYNA\\SQLEXPRESS01; Database = ProductDB; integrated security = True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Product_Photo>().ToTable("Product_Photos");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Product_Photo> Product_Photos { get; set; }

    }
}
