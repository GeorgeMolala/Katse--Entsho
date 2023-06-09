using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Katse_Entsho.Models
{
    public class Category
    {
        [Key]
        public int CatID { get; set; }

        public string CategoryName { get; set; }


        public ICollection<Product> Products { get; set; }


    }
}
