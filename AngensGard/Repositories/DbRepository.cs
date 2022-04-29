using AngensGard.Data;
using AngensGard.Models.Pocos;
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
            db = _db;
        }

        //Hämtar en order från databasen
        //Hitta med ordernummer istället för id?
        public Order GetOrderById(int id)
        {
            var order = _db.Orders.Find(id);
            return order;
        }
    }
}
