﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.DTO
{
    public class ProductRequestDTO
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
    }
}
