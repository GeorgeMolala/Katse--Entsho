using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Katse_Entsho.Models
{
    public class Supplier
    {

        [Key]
        public int SuppID { get; set; }



        public string SupplierName { get; set; }


        public int ContactNumber { get; set; }


        public string Email { get; set; }


        public string AddressLine1 { get; set; }


        public string AddressLine2 { get; set; }

        public int ProvinceID { get; set; }

        public int CityID { get; set; }


        public int SuburbID { get; set; }
    }
}
