using AngensGard.Data;
using AngensGard.Models.Pocos;
using AngensGard.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngensGard.Models.ViewModels
{
    public class OrderViewModel
    {

        public string OrderNumber { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string OrderDate { get; set; }
        public bool IsHomeDelivery { get; set; }
        public Product Product { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }




        public int SetPrice()
        {
            int price = 0;
            price += (Product.Price * Quantity);
            if (IsHomeDelivery)
            {
                price += 250;
            }

            return price;
        }



        private void SetDate()
        {
            OrderDate = DateTime.Now.ToString();
        }

        public OrderViewModel()
        {
            SetDate();
            
        }
        //lägga metod för att tilldela ordernummer här 





    }
}
