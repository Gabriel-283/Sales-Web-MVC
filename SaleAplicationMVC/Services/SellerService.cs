using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium;
using SaleAplicationMVC.Data;
using SaleAplicationMVC.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

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
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Update (Seller seller)
        {
           bool hasAny =  _context.Seller.Any(x => x.Id == seller.Id);

            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(seller);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DBConcurrencyException(e.Message);
            }
        }
    }
}
