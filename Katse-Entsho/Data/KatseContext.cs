using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Katse_Entsho.Data;
using Katse_Entsho.Models;

namespace Katse_Entsho.Data
{
    public class KatseContext: IdentityDbContext<UserApp>
    {
        public KatseContext(DbContextOptions<KatseContext> options) : base(options) { }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<SalesPerson> SalesPeople { get; set; }
        public DbSet<Suburb> Suburbs { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Company> Companies { get; set; }

    }
}
