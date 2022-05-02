using SaleAplicationMVC.Data;
using SaleAplicationMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleAplicationMVC.Services
{
    public class DeparmentService
    {
        private readonly SaleAplicationMVCContext _context;

        public DeparmentService(SaleAplicationMVCContext context)
        {
            this._context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();

        }



    }
}
