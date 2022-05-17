using AngensGard.Models.ViewModels;
using AngensGard.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngensGard.Controllers
{
    [Authorize(Roles = "Admin")]
    
    public class AdminController : Controller
    {
        private readonly IDbRepository _repo;

        public AdminController(IDbRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            var model = new AdminViewModel()
            {
                Orders = _repo.GetListOfOrders()
            };
            return View(model);
        }

        public IActionResult OrderOverview(int Id)
        {

            var model = _repo.GetOrderById(Id);



            return View(model);
        }
    }
}
