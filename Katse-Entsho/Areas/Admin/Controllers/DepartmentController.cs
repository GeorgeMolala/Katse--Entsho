using Katse_Entsho.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Katse_Entsho.Areas.Admin.Controllers
{

    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class DepartmentController : Controller
    {

        private KatseContext _context;
        

        public DepartmentController(KatseContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var department = _context.Departments.ToList();
            return View(department);
        }
        
        public IActionResult Add()
        {

            return View("Edit", new Models.Department());

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var depart = _context.Departments.Find(id);
            return View(depart);
        }


        [HttpPost]
        public IActionResult Delete(Models.Department department)
        {
            _context.Departments.Remove(department);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
         
            var department = _context.Departments.Find(id);
            return View(department);
        }

        [HttpPost]
        public IActionResult Edit(Models.Department department)
        {

            if (department.DeptID == 0)
            {

                if (ModelState.IsValid)
                {
                    _context.Departments.Add(department);
                    _context.SaveChanges();
                    return RedirectToAction("Index");

                }
                else
                {
                    return Content("No direction");
                }

            }

            else
            {
                _context.Departments.Update(department);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }



        }

    }
}
