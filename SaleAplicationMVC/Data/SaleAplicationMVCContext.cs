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

        public DbSet<SaleAplicationMVC.Models.Department> Department { get; set; }
    }
}
