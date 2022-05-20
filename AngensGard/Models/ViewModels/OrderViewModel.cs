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
        public int Quantity { get; set; }
        public string Payment { get; set; }
        public int ProductId { get; set; }
        public int TotalPrice { get; set; }

        public Product Product { get; set; }

        public int ProductPrice { get; set; }

        public OrderViewModel()
        {           
            SetDate();
        }

        private void SetDate()
        {
            OrderDate = DateTime.Now.ToString();
        }



        //lägga metod för att tilldela ordernummer här 

        public string GenerateOrderNumber(OrderViewModel order)
        {
            Random random = new Random();
            string orderNumber = order.OrderDate + random.Next(1, 99999).ToString();

            return orderNumber;

        }



    }
}
