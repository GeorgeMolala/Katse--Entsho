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

        [Required(ErrorMessage = "Field Can not be empty")]
        public int BarCode { get; set; }


        [Required(ErrorMessage = "Field Can not be empty")]
        [StringLength(30)]
        public string Name { get; set; }


        [NotMapped]
        [FileExtension]
        public IFormFile Picture { get; set; }


        [Required(ErrorMessage = "Field Can not be empty")]
        public string Image { get; set; }



        [Required(ErrorMessage = "Field Can not be empty")]
        public int CatID { get; set; }
        public Category Category;

        [Required(ErrorMessage = "Field Can not be empty")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Field Can not be empty")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Field Can not be empty")]
        public int SuppID { get; set; }
        public Supplier Supplier;

    }
}
