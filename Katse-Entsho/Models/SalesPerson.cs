using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Katse_Entsho.Models
{
    public class SalesPerson
    {
        [Key]
        public int UserID { get; set; }


        [Required(ErrorMessage = "Field Can not be empty")]
        [StringLength(30)]
        public string SalesPersonName { get; set; }


        [Required(ErrorMessage = "Field Can not be empty")]
        [StringLength(30)]
        public string SalesPersonSurname { get; set; }



        [Required(ErrorMessage = "Field Can not be empty")]
        public string Gender { get; set; }


        [Required(ErrorMessage = "Field Can not be empty")]
        public int SalesPersonContact { get; set; }


        [Required(ErrorMessage = "Field Can not be empty")]
        [StringLength(30)]
        public string SalesPersonEmail { get; set; }


        [Required(ErrorMessage = "Field Can not be empty")]
        [StringLength(30)]
        public string? GradeLevel { get; set; }


        [Required(ErrorMessage = "Field Can not be empty")]
        public int DeptID { get; set; }
        public Department Department { get; set; }



    }
}
