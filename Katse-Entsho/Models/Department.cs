using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Katse_Entsho.Models
{
    public class Department
    {

        [Key]
        public int DeptID { get; set; }


        public string DepartmentName { get; set; }

        public string Description { get; set; }
    }
}
