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
        public IActionResult Details(int? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit (Seller seller)
        {
            try
            {
            _sellerService.Update(seller);
            return RedirectToAction(nameof(Index));

            }
            catch (Exception exception)
            {

                throw exception;
            }
            
        }


        public IActionResult Edit(int? id)
        {
            var obj = _sellerService.FindById(id.Value);
            List<Department> departments = _departmentService.FindAll();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departments = departments };
            return View(viewModel);
        }

    }
}
