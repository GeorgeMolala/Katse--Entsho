using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Katse_Entsho.Models
{
    public class Suburb
    {

        [Key]
        public string SuburbID { get; set; }



        [Required(ErrorMessage = "Field Can not be Empty")]
        [StringLength(50)]
        public string Name { get; set; }


        [Required(ErrorMessage = "Field Can not be empty")] //Health Council Used as Doctor ID
        public int Postal_Code { get; set; }


        [Required(ErrorMessage = "Field Can not be empty")] //Health Council Used as Doctor ID
        public int CityID { get; set; }
    }
}
