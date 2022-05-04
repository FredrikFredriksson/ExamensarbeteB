using AngensGard.Data;
using AngensGard.Models.Pocos;
using AngensGard.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngensGard.Repositories
{
    public class DbRepository : IDbRepository
    {
        private readonly AppDbContext _db;

        private List<Product> _products = new List<Product>
        {
            new Product { Name = "Björkved 1m²", Price = 650},
            new Product { Name = "Blandved 1m²", Price = 600}
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
                ZipCode = RegisteredOrder.City,
                Email = RegisteredOrder.Email,
                OrderDate = RegisteredOrder.OrderDate,
                OrderDetail = new OrderDetail()
                {
                    Price = RegisteredOrder.Price,
                    Product = GetProductById(RegisteredOrder.Product.Id),
                    Quantity = RegisteredOrder.Quantity
                }
                
            };
            await _db.AddAsync(order);
            _db.SaveChanges();
        }

        /// <summary>
        /// Retrieves order by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>order</returns>
        public Order GetOrderById(int id)
        {
            var order = _db.Orders.Find(id);
                
            return order;   
        }


        public Product GetProductById(int id)
        {
            var product = _db.Products.Find(id);
            return product;
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



        //Hämtar en order från databasen
        //Hitta med ordernummer istället för id?
        //public Order GetOrderById(int id)
        //{
        //    var order = _db.Orders.Find(id);
        //    return order;
        //}
    }
}
