using AngensGard.Models;
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
            _repo.RemoveOrder(1);
            return View();
        }

        public IActionResult AddOrder(OrderViewModel order)
        {
            _repo.SaveOrder(order);
            return RedirectToAction("index");
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
