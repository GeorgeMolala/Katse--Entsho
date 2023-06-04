using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Katse_Entsho.Models
{
    public class City
    {


        [Key]
        public int CityID { get; set; }



        [Required(ErrorMessage = "Field can not be empty")]
        [StringLength(30)]
        public string Name { get; set; }


        
        [Required(ErrorMessage = "Field Can not be empty")] //Health Council Used as Doctor ID
        public int ProvinceID { get; set; }
        public Province Province { get; set; }

    }
}
