﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloDapper.Models
{
    public class FruitDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public string Code { get; set; }
        public string StoreCode { get; set; }
    }
}