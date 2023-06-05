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


        [Required(ErrorMessage = "Field Can not be empty")]
        [StringLength(30)]
        public string SupplierName { get; set; }



        [Required(ErrorMessage = "Field Can not be empty")]
        public int ContactNumber { get; set; }


        [Required(ErrorMessage = "Field Can not be empty")]
        [StringLength(30)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Field Can not be empty")]
        [StringLength(30)]
        public string AddressLine1 { get; set; }


        [Required(ErrorMessage = "Field Can not be empty")]
        [StringLength(30)]
        public string AddressLine2 { get; set; }


        [Required(ErrorMessage = "Field Can not be empty")]
        public int ProvinceID { get; set; }


        [Required(ErrorMessage = "Field Can not be empty")]
        public int CityID { get; set; }


        [Required(ErrorMessage = "Field Can not be empty")]
        public int SuburbID { get; set; }

    }
}
