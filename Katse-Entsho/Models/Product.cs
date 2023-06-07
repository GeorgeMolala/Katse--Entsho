using Katse_Entsho.Models.Valida;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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


        [NotMapped]
        [FileExtension]
        public IFormFile Picture { get; set; }


        public string? Image { get; set; }


        public int CatID { get; set; }
        public Category Category { get; set; }


        public string Description { get; set; }

        
        public double Price { get; set; }

        public int SuppID { get; set; }
        public  Supplier Supplier { get; set; }

    }
}
