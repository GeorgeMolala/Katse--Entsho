using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Katse_Entsho.Models
{
    public class Province
    {
        [Key]
        [Required(ErrorMessage = "Field Can not be empty")]
        public int ProvinceID { get; set; }


        [Required(ErrorMessage = "Field can not be empty")]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
