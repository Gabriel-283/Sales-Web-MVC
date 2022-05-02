using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaleAplicationMVC.Services;
using SaleAplicationMVC.Models;
using SaleAplicationMVC.Models.ViewModels;

namespace SaleAplicationMVC.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DeparmentService _departmentService;

        public SellersController(SellerService sellerService, DeparmentService deparmentService)
        {
            _sellerService = sellerService;
            _departmentService = deparmentService;
        }

        public IActionResult Index()
        {
            _sellerService.ShowAll();
            var list = _sellerService.ShowAll();
            return View(list);
        }

        public IActionResult Add()
        {
            var departments = _departmentService.FindAll();
            var vieModel = new SellerFormViewModel { Departments = departments };
            return View(vieModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
