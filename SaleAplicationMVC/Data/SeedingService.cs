using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleAplicationMVC.Data
{
    public class SeedingService
    {
        private SaleAplicationMVCContext _context;

        public SeedingService(SaleAplicationMVCContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any()||
                _context.Seller.Any()||
                _context.SalesRecord.Any())
            {
                return;
            }

            
        }
    }
}
