using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Katse_Entsho.Models
{
    public class Quote
    {

        [Key]
        public int QuoteID { get; set; }

        public DateTime QuoteDate { get; set; }

        

    }
}
