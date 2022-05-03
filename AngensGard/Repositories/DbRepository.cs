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

        public DbRepository(AppDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Saves order to database
        /// </summary>
        /// <param name="RegisteredOrder"></param>
        public async void SaveOrder(OrderViewModel RegisteredOrder)
        {
            var order = new Order
            {
                Name = RegisteredOrder.Name,
                Address = RegisteredOrder.Address,
                City = RegisteredOrder.City,
                PhoneNumber = RegisteredOrder.PhoneNumber,
                ZipCode = RegisteredOrder.City,
                Delivery = RegisteredOrder.Delivery,
                Email = RegisteredOrder.Email,
                Date = RegisteredOrder.Date,
                Sacks = RegisteredOrder.Sacks,
                OrderNumber = RegisteredOrder.OrderNumber,
                Interval = RegisteredOrder.Interval
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
