using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Katse_Entsho.Models;
using Katse_Entsho.Data;
using Microsoft.AspNetCore.Authorization;

namespace Katse_Entsho.Areas.SalesPerson.Controllers
{


    [Area ("SalesPerson")]
    [Authorize (Roles = "SalesPerson")]
    public class SupplierController : Controller
    {

        private KatseContext _context;

        public SupplierController(KatseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View("Edit", new Supplier());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var supplier = _context.Suppliers.Find(id);

            return View(supplier);
        }

        [HttpPost]
        public IActionResult Edit(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                if(supplier.SuppID == 0)
                {
                    _context.Suppliers.Add(supplier);
                    _context.SaveChanges();

                    RedirectToAction("Index");
                }

                else
                {
                    _context.Suppliers.Update(supplier);
                    _context.SaveChanges();
                    RedirectToAction("Index");
                }
            }
            return RedirectToAction("Edit");
            
        }



    }
}
