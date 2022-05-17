using AngensGard.Data;
using AngensGard.Models.Pocos;
using AngensGard.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AngensGard.Repositories
{
    public class DbRepository : IDbRepository
    {
        private readonly AppDbContext _db;

        private List<Product> _products = new List<Product>
        {
            new Product { Name = "Björkved 1m², säck", Price = 650},
            new Product { Name = "Björkved 10m², container", Price = 5500},
            new Product { Name = "Hemkörning", Price = 250},
            new Product { Name = "Björkved 15m², container", Price = 8250}
        };

        public DbRepository(AppDbContext db)
        {
            _db = db;
            SeedProducts();
        }

        public void SeedProducts()
        {
            if (_db.Products.Count() == 0)
            {
                _db.AddRange(_products);
                _db.SaveChanges();
            }
        }

        public List<Order> GetListOfOrders()
        {
            var data = _db.Orders
                .Include(x => x.OrderDetail)
                .ThenInclude(x => x.Products);

            return data.ToList();
        }

        public OrderDetail GetOrderDetailsById(int id)
        {
            var data = _db.OrderDetails.Where(x => x.Id == id)
                .Include(x => x.Products);
                        
            return data.FirstOrDefault();
        }

        /// <summary>
        /// Saves order to database
        /// </summary>
        /// <param name="RegisteredOrder"></param>
        public async void SaveOrder(OrderViewModel RegisteredOrder)
        {
            var order = new Order
            {
                OrderNumber = RegisteredOrder.OrderNumber,
                Name = RegisteredOrder.Name,
                Address = RegisteredOrder.Address,
                City = RegisteredOrder.City,
                PhoneNumber = RegisteredOrder.PhoneNumber,
                ZipCode = RegisteredOrder.ZipCode,
                Email = RegisteredOrder.Email,
                OrderDate = RegisteredOrder.OrderDate,
                OrderDetail = new OrderDetail()
                {
                    //Product = GetProductById(RegisteredOrder.Product.Id),
                    Quantity = RegisteredOrder.Quantity,
                    Price = RegisteredOrder.OrderDetails.TotalPrice,
                    Products = new List<Product>()
                }
            };

            foreach (var p in RegisteredOrder.OrderDetails.Products)
            {
                order.OrderDetail.Products.Add(p);
            }
            await _db.AddAsync(order);
            _db.SaveChanges();
        }

        /// <summary>
        /// Retrieves order by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>order</returns>
        public Order GetOrderById(int Id)
        {
            var data = _db.Orders.Where(x => x.Id == Id)
                .Include(x => x.OrderDetail)
                .ThenInclude(x => x.Products);
                
            return data.FirstOrDefault();    
        }


        public Product GetProductById(int Id)
        {
            var data = _db.Products.Where(x => x.Id == Id);
            return data.FirstOrDefault();
        }
        
        /// <summary>
        /// Deletes order 
        /// </summary>
        /// <param name="id"></param>
        public void RemoveOrder(int id)
        {
            var order = GetOrderById(id);

            _db.Orders.Remove(order);
            _db.SaveChanges();
        }

        /// <summary>
        /// Updates an order
        /// </summary>
        /// <param name="order"></param>
        public void UpdateOrder(Order order)
        {
            _db.Orders.Add(order);
            _db.SaveChanges();
        }


        //Hämtar en order från databasen
        //Hitta med ordernummer istället för id?
        //public Order GetOrderById(int id)
        //{
        //    var order = _db.Orders.Find(id);
        //    return order;
        //}
    }
}
