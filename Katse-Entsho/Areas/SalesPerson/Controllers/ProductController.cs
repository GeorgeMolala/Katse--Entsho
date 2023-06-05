using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Katse_Entsho.Data;

namespace Katse_Entsho.Areas.SalesPerson.Controllers
{

    [Area ("SalesPerson")]
    [Authorize (Roles="SalesPerson")]
    public class ProductController : Controller
    {
        private KatseContext _context;

        public ProductController(KatseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit()
        {

            var supplier = _context.Suppliers.ToList();

            return View(supplier);
        }
    }
}
