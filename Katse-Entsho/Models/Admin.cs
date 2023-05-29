using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Katse_Entsho.Models
{
    public class Admin
    {
        [Key]
        public int UserID { get; set; }



        [Required]
        [StringLength(30)]
        public string Name { get; set; }


        [Required]
        [StringLength(30)]
        public string Surname { get; set; }


        [Required]
        public int ContactNumber { get; set; }

        [Required]
        [StringLength(30)]
        public string EmailAddress { get; set; }
    }
}
