using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Katse_Entsho.Areas.SalesPerson.Controllers
{
    public class SalesPersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
