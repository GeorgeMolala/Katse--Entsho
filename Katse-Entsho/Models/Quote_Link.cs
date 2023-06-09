using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Katse_Entsho.Models
{
    public class Quote_Link
    {
        [Key]
        public int Quote_LinkID { get; set; }

        public int ProductID { get; set; }
        public Product Product;

        public int Quantity { get; set; }

        public double Price { get; set; }

    }
}
