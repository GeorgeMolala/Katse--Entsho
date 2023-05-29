using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace Katse_Entsho.Data
{
    public class UserApp:IdentityUser
    {
        public int UserID { get; set; }

    }
}
