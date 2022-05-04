using AngensGard.Models;
using AngensGard.Models.Pocos;
using AngensGard.Models.ViewModels;
using AngensGard.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AngensGard.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDbRepository _repo;

        public HomeController(IDbRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ConfirmOrder(OrderViewModel order)
        {
            //hårdkodat in produkten björkved
            order.Product = _repo.GetProductById(1);
            _repo.SaveOrder(order);
            return View(order);
        }

        public IActionResult OrderOverview(OrderViewModel order)
        {
            //Ska inte ligga här, price borde sättas i viewmodellen och produkten är hårdkodad
            order.Product = _repo.GetProductById(1);
            order.Price = order.SetPrice();

            return View(order);
        }

        public IActionResult Privacy()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
