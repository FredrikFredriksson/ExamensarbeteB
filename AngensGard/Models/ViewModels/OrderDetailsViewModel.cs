using AngensGard.Models.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngensGard.Models.ViewModels
{
    public class OrderDetailsViewModel
    {
        public List<Product> Products { get; set; }
        public int TotalPrice { get; set; }

        public OrderDetailsViewModel()
        {
            Products = new List<Product>();
        }

        public int CalculateTotalPrice()
        {
            int price = 0;
            foreach (var p in Products)
            {
                price += p.Price;
            }
            return price;
        }    
    }
}
