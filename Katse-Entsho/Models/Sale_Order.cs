using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Katse_Entsho.Models
{
    public class Sale_Order
    {
        [Key]
        public int OrderID { get; set; }


        public DateTime OrderDate { get; set; }

        public int QuoteID { get; set; }


    }
}
