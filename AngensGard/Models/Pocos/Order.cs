using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngensGard.Models.Pocos
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        //DatabaseGenerated som annotation på datumet kanske? Kolla föreläsningen ASP.net Core identity 6 min in med erik 
        public string OrderDate { get; set; }

        //Göra denna till virtual? Alltså så att det blir foreign key i databasen
        public OrderDetail OrderDetail { get; set; }

    }
}
