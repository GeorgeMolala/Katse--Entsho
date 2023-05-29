﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Katse_Entsho.Models
{
    public class Product
    {

        [Key]
        public int ProductID { get; set; }


        public int BarCode { get; set; }

        public string Name { get; set; }


        public string Description { get; set; }


        public double Price { get; set; }

        public int SuppID { get; set; }

    }
}
