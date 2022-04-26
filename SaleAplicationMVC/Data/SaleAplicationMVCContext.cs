using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SaleAplicationMVC.Models;

namespace SaleAplicationMVC.Data
{
    public class SaleAplicationMVCContext : DbContext
    {
        public SaleAplicationMVCContext (DbContextOptions<SaleAplicationMVCContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
        public DbSet<Seller> Seller { get; set; }
    }
}
