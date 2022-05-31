using AngensGard.Models.Pocos;
using AngensGard.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngensGard.Models.ViewModels
{
    public class AdminViewModel
    {
        public List<Order> Orders { get; set; }
        public List<Product> Products { get; set; }
        public int Number { get; set; }

        public string AddOrNot { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }
        public int ProductId { get; set; }

        public int AllOrders { get; set; }
        public int UnPaidOrders { get; set; }
        public int OnGoingOrders { get; set; }
        public int HomeDeliveries { get; set; }
    }
}
