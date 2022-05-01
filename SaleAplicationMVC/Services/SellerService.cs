using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaleAplicationMVC.Data;
using SaleAplicationMVC.Models;

namespace SaleAplicationMVC.Services
{
    public class SellerService
    {

        private readonly SaleAplicationMVCContext _context;

        public SellerService(SaleAplicationMVCContext context)
        {
            this._context = context;
        }

        public List<Seller> ShowAll()
        {
            return this._context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            //obj.Department = ;
            _context.Add(obj);
            _context.SaveChanges();

        }
    }
}
