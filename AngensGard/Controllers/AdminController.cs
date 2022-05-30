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
            
            return View();
        }

        public IActionResult Orders(string status)
        {
            var model = new AdminViewModel();
            if (status != null)
            {
                if (status == "Hemleverans")
                {
                    model.Orders = _repo.GetOrdersByDelivery(status);
                    return View(model);
                }
                model.Orders = _repo.GetOrdersByStatus(status);
            }
            else
            {
                model.Orders = _repo.GetListOfOrders();                
            }

            return View(model);
        }

        public IActionResult StockBalance()
        {
            var model = new AdminViewModel()
            {
                Products = _repo.GetListOfProducts()
            };
            return View(model);
        }

        public IActionResult MyAction(string submitButton, AdminViewModel model)
        {
            switch (submitButton)
            {
                case "Add": return (AddStock(model));
                case "Sub": return (SubStock(model));
                default: return View();
            }
        }

        public IActionResult SubStock(AdminViewModel model)
        {
            var product = _repo.GetProductById(model.ProductId);
            product.StockQuantity -= model.Number;
            _repo.UpdateStockBalance(product);

            return RedirectToAction("StockBalance", "Admin");
        }
       
        public IActionResult AddStock(AdminViewModel model)
        {
            var product = _repo.GetProductById(model.ProductId);         
            product.StockQuantity += model.Number;
            _repo.UpdateStockBalance(product);

            return RedirectToAction("StockBalance", "Admin");
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
            if (order.Delivery == "Hemleverans")
            {
                order.TotalPrice += 250;
            }
            order.Product = _repo.GetProductById(order.Product.Id);
            order.TotalPrice += order.Product.Price * order.ProductQuantity;
            _repo.UpdateOrder(order);

            return RedirectToAction("Orders", "Admin", order);
        }

        
        public IActionResult DeleteOrder(int id)
        {
            _repo.RemoveOrder(id);
            return RedirectToAction("Orders", "Admin");
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
