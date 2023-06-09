using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Katse_Entsho.Models
{
    public class Customer
    {

        [Key]      //Patient ID Number
        public int UserID { get; set; }


        [Required(ErrorMessage = "Field Can not be empty")]
        [StringLength(40)]
        public string CustomerName { get; set; }


        [Required(ErrorMessage = "Field Can not be empty")]
        [StringLength(30)]
        public string CustomerSurname { get; set; }

        [Required(ErrorMessage = "Field Can not be empty")]
        public int IDNumber { get; set; }

        [Required(ErrorMessage = "Field Can not be empty")]
        [StringLength(10)]
        public string Gender { get; set; }


        [Required(ErrorMessage = "Field Can not be empty")]
        public int ContactNumber { get; set; }



        [StringLength(100)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Field Can not be empty")]
        [StringLength(100)]
        public string AddressLine1 { get; set; }



        [StringLength(100)]
        public string AddressLine2 { get; set; }



        [Required(ErrorMessage = "Field Can not be empty")]      //Suburb Foreign Key
        public int SuburbID { get; set; }
        public Suburb Suburb { get; set; }



        [Required(ErrorMessage = "Field Can not be empty")]      //City Foreign Key
        public int CityID { get; set; }
        public City City { get; set; }



        [Required(ErrorMessage = "Field Can not be empty")]  //Province Foreign Key
        public int ProvinceID { get; set; }
        public Province Province { get; set; }


        public ICollection<Request_Quote> Request_Quotes { get; set; }
        public ICollection<Quote> Quotes { get; set; }

    }
}
