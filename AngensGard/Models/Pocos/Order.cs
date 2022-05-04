using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngensGard.Models.Pocos
{
    public class Order
    {
        [Required]
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string OrderDate { get; set; }
        public OrderDetail OrderDetail { get; set; }

    }
}
