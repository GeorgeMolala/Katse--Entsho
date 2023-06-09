using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Katse_Entsho.Models
{
    public class Request_Quote
    {
        [Key]
        public int RequestID { get; set; }



        public int UserID { get; set; }
        public Customer Customer;


        public DateTime DateCreated { get; set; }


        public int Request_LinkID { get; set; }     //Points to Request_Link Table

        public string Status { get; set; }


    }
}
