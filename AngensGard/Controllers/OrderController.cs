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
    public class OrderController : Controller
    {
        private readonly IDbRepository _repo;

        public OrderController(IDbRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult ConfirmOrder(OrderViewModel order)
        {
            order.Product = _repo.GetProductById(order.ProductId);
            
            //hårdkodat in produkten björkved
            //order.Product = _repo.GetProductById(1);
            _repo.SaveOrder(order);
            return View(order);
        }

        public IActionResult Overview(OrderViewModel order)
        {
            order.Product = _repo.GetProductById(order.ProductId);

            if (order.IsHomeDelivery)
            {
                order.TotalPrice += 250;
            }

            order.ProductPrice = order.Product.Price * order.Quantity;
            order.TotalPrice += order.ProductPrice;

            //for (int i = 0; i < order.Quantity; i++)
            //{
            //    var product = _repo.GetProductById(order.ProductId);
            //    order.OrderDetails.Products.Add(product);
            //}
            //if (order.IsHomeDelivery)
            //{
            //    var delivery = _repo.GetProductById(3);
            //    order.OrderDetails.Products.Add(delivery);
            //}

            //order.OrderDetails.TotalPrice = order.OrderDetails.CalculateTotalPrice();
            //Ska inte ligga här, price borde sättas i viewmodellen och produkten är hårdkodad
            //order.Product = _repo.GetProductById(1);


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
