using Katse_Entsho.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Katse_Entsho.Models;
using Microsoft.AspNetCore.Authorization;


namespace Katse_Entsho.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class EmployeesController : Controller
    {

        private readonly ILogger<EmployeesController> _logger;
        private UserManager<UserApp> userManager;
        private SignInManager<UserApp> SignInManager;

        private RoleManager<IdentityRole> roleManager;
        private KatseContext _context;

        public EmployeesController(KatseContext context, UserManager<UserApp> userMagr, SignInManager<UserApp> signInMgr, RoleManager<IdentityRole> roleMgr)
        {
            _context = context;
            userManager = userMagr;
            SignInManager = signInMgr;
            roleManager = roleMgr;

        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            ViewBag.Departments = _context.Departments.OrderBy(g => g.DepartmentName).ToList();

            return View();

        }

        [HttpGet]
        public IActionResult RegisterCredentials()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Departments = _context.Departments.OrderBy(g => g.DepartmentName).ToList();
            var salesPerson = _context.SalesPeople.Find(id);
            return View(salesPerson);
        }


        [HttpPost]
        public async Task<IActionResult> RegisterCredentials(RegisterCredentials user)
        {
            if (ModelState.IsValid)
            {
                Models.SalesPerson salesperson = new Models.SalesPerson();
                int userID = _context.SalesPeople.Max(x => x.UserID);

                salesperson = _context.SalesPeople.Find(userID);
                var usr = new UserApp
                {
                    UserName = user.UserName,
                    UserID = userID,
                    PhoneNumber = salesperson.SalesPersonContact.ToString(),
                    PhoneNumberConfirmed = true,
                    Email = salesperson.SalesPersonEmail,
                    EmailConfirmed = true,

                };


                // var testinga = _context.Patients.Where(x => x.PatiID == userID).Select(x => x.PatientName).FirstOrDefault();


                //return Content(testinga.ToString());

                var result = await userManager.CreateAsync(usr, user.Password);
                var resultss = await roleManager.CreateAsync(new IdentityRole("SalesPerson"));
                var resultROle = await userManager.AddToRoleAsync(usr, "SalesPerson");

                if (result.Succeeded)
                {
                    //   await SignInManager.SignInAsync(usr, isPersistent: false);
                    return RedirectToAction("Index", "Admin");
                }
            }
            return Content("Error Adding");
        }

        [HttpPost]
        public IActionResult Add(Models.SalesPerson salesPerson)
        {
            if (ModelState.IsValid)
            {
                _context.SalesPeople.Add(salesPerson);
                _context.SaveChanges();
                return RedirectToAction("RegisterCredentials");
            }
            else
            {
                ViewBag.Departments = _context.Departments.OrderBy(g => g.DepartmentName).ToList();
                return View();
            }
        }

        [HttpPost]
        public IActionResult Edit(Models.SalesPerson salesPerson)
        {
            if (ModelState.IsValid)
            {
   
                    _context.SalesPeople.Update(salesPerson);
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Admin");     

            }
           

                return Content("Edit");
            
        }


    }
}
