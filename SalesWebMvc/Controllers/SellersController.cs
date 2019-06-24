using System;
using System.Collections.Generic;
using System.Linq;
using SalesWebMvc.Services;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        // dexclarando a dependencia para o sellerService
        private readonly SellerService _sellerService;
        // construtor para injetar a dependencia
        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }
        
        public IActionResult Index()
        {// implementar a chamada do sellerService.findAll
            var list = _sellerService.findAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            //return RedirectToAction("Index"); o Framework aceita
            return RedirectToAction(nameof(Index));
        }
    }
}