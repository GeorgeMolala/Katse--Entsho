using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Katse_Entsho.Models
{
    public class Request_Link
    {

        [Key]
        public int Request_LinkID { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }

        
    }
}
