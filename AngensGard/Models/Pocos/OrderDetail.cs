﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngensGard.Models.Pocos
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
