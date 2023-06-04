using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Katse_Entsho.Areas.SalesPerson.Controllers
{

    [Area ("SalesPerson")]
    [Authorize (Roles="SalesPerson")]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
