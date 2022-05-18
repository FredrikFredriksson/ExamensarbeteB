using AngensGard.Models.ViewModels;
using AngensGard.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PagedList.Mvc;
using PagedList;
using AngensGard.Models.Pocos;


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

        public IActionResult OrderDetails(int Id)
        {

            var model = _repo.GetOrderById(Id);

            return View(model);
        }

        
        public IActionResult EditOrder(int id)
        {
            var model = _repo.GetOrderById(id);
            return View(model);
        }


        [HttpPost]
        public IActionResult EditOrder(Order order)
        {
            _repo.UpdateOrder(order);

            return RedirectToAction("OrderDetails", "Admin", order);
        }

        
        public IActionResult DeleteOrder(int id)
        {
            _repo.RemoveOrder(id);
            return RedirectToAction("Index", "Admin");
        }

        //public PartialViewResult OrderListPartial(int? page)
        //{
        //    var pageNumber = page ?? 1;
        //    var pageSize = 3;
        //    var orderList = _repo.GetListOfOrders().ToPagedList(pageNumber, pageSize);
        //    return PartialView(orderList);
        //}
    }
}
