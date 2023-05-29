using Katse_Entsho.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Katse_Entsho.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminController : Controller
    {
        private KatseContext _context;

        public AdminController(KatseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            var salesPeople = _context.SalesPeople.Include(n => n.Department).ToList();
          
            return View(salesPeople);

           
        }
    }
}
