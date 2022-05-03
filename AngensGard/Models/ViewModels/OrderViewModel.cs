using AngensGard.Data;
using AngensGard.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngensGard.Models.ViewModels
{
    public class OrderViewModel
    {
        private readonly AppDbContext dbRepo; 

        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int Sacks { get; set; }
        public string Email { get; set; }
        public string Delivery { get; set; }
        public string Date { get; set; }
        public string Interval { get; set; }



        //lägga metod för att tilldela ordernummer här 

        private void GenerateOrderNumber()
        {
            try
            {
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        

    }
}
