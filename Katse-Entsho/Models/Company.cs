using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Katse_Entsho.Models
{
    public class Company
    {
        [Key]
        public int CompanyID { get; set; }


        [Required(ErrorMessage = "Field Can not be empty")]
        [StringLength(30)]
        public string CompanyName { get; set; }


        [Required(ErrorMessage = "Field Can not be empty")]
        [StringLength(30)]
        public string CompanyEmail { get; set; }


        [Required(ErrorMessage = "Field Can not be empty")]
        [MaxLength(10)]
        public int CompanyContactNumber { get; set; }

        [Required(ErrorMessage = "Field Can not be empty")]
        [StringLength(30)]
        public string AddressLine1 { get; set; }

        [Required(ErrorMessage = "Field Can not be empty")]
        [StringLength(30)]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "Field Can not be empty")]
        public int ProvinceID { get; set; }
        public Province Province { get; set; }

        [Required(ErrorMessage = "Field Can not be empty")]
        public int CityID { get; set; }
        public City City { get; set; }


        [Required(ErrorMessage = "Field Can not be empty")]
        public int SuburbID { get; set; }
        public Suburb Suburb { get; set; }


    }
}
