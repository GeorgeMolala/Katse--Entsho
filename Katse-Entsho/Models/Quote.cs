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

        public int RequestID { get; set; } ///We need to add Request_Quote Table

        public int CompanyID { get; set; } //Company Details
        public Company Company { get; set; }

        public int UserID { get; set; }  //Points to Customer Table
        public Customer Customer { get; set; }

        public DateTime QuoteDate { get; set; } //Date Created

        public DateTime ExpiryDate { get; set; }

        public int Quote_LinkID { get; set; } //Points to Linking Table Called Quote_Link Table
        public Quote_Link Quote_Link { get; set; }

        public double SubTotal { get; set; }


        

    }
}
