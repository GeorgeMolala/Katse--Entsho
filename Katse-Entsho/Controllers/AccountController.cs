using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Katse_Entsho.Data;
using Katse_Entsho.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Katse_Entsho.Controllers
{
    public class AccountController : Controller
    {

        private readonly ILogger<AccountController> _logger;
        private UserManager<UserApp> userManager;
        private SignInManager<UserApp> SignInManager;

        private RoleManager<IdentityRole> roleManager;

        private KatseContext _context;

        private int Province_ID;
        private int City_ID;
        private int User_NUm;

        public AccountController(UserManager<UserApp> userMngr, SignInManager<UserApp> signInManager, RoleManager<IdentityRole> roleManagerr, KatseContext context)
        {
            userManager = userMngr;
            SignInManager = signInManager;
            _context = context;
            roleManager = roleManagerr;
        }



        [HttpGet]
        public IActionResult RegisterCredentials()
        {

            return View();

        }

        ///Registering Customer
        [HttpPost]
        public IActionResult Register(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();

                return RedirectToAction("RegisterCredentials", "Account");

            }

            else
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                User_NUm = _context.Customers.Max(x => x.UserID);

                return RedirectToAction("Login", "Account");
            }
        }


        public JsonResult LoadProvince()
        {
            var cnt = _context.Provinces.ToList();

            return new JsonResult(cnt);
        }

        public JsonResult LoadCity(int Id)
        {
            Province_ID = Id;
            //ViewBag.City = new SelectList(_context.Cities.Where(c => c.ProvinceID == Id), "CityID", "Name");
            var st = _context.Cities.Where(c => c.ProvinceID == Id).ToList();

            return new JsonResult(st);
        }


        public JsonResult LoadSuburb(int Id)
        {
            City_ID = Id;
            var sb = _context.Suburbs.ToList();
            return new JsonResult(sb);
        }

        [HttpGet]
        public IActionResult Register()
        {
            //    var provinces = new SelectList(_context.Provinces.ToList());
            var Cities = _context.Cities.ToList();
            var Suburs = _context.Suburbs.ToList();
            // Patient patient = new Patient();
            ViewBag.province = _context.Provinces.ToList();
            ViewBag.Suburb = new SelectList(_context.Suburbs, "CityID", "Name");

            ViewBag.cities = _context.Cities.ToList();
            ViewBag.suburbs = _context.Suburbs.ToList();

            ViewBag.Suburb_s = JsonConvert.SerializeObject(_context.Suburbs.ToList());
            ViewBag.City_s = JsonConvert.SerializeObject(_context.Cities.ToList());
            ViewBag.Prov_s = JsonConvert.SerializeObject(_context.Provinces.ToList());

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> RegisterCredentials(RegisterCredentials user)
        {
            if (ModelState.IsValid)
            {
                Customer customer = new Customer();
                int userID = _context.Customers.Max(x => x.UserID);
                customer = _context.Customers.Find(userID);
                var usr = new UserApp
                {
                    UserName = user.UserName,
                    UserID = userID,
                    PhoneNumber = customer.ContactNumber.ToString(),
                    PhoneNumberConfirmed = true,
                    Email = customer.Email,
                    EmailConfirmed = true,

                };


                // var testinga = _context.Patients.Where(x => x.PatiID == userID).Select(x => x.PatientName).FirstOrDefault();


                //return Content(testinga.ToString());

                var result = await userManager.CreateAsync(usr, user.Password);
                var resultss = await roleManager.CreateAsync(new IdentityRole("Customer"));
                var resultROle = await userManager.AddToRoleAsync(usr, "Customer");

                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(usr, isPersistent: false);
                    return RedirectToAction("Index", "Customer"); ///Fix Customer Controller
                }
            }
            return Content("Error Adding");
        }

      

        [HttpGet]
        public IActionResult Login(string returnURL = "")
        {
            var model = new LogIns { ReturnUrl = returnURL };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LogIns model)
        {
            if (ModelState.IsValid)
            {

                var result = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        var use = await userManager.FindByNameAsync(model.UserName);

                        var role = await userManager.GetRolesAsync(use);

                        switch (role.FirstOrDefault())
                        {
                            case "Admin":
                                return RedirectToAction("Index", "Admin", new { area = "Admin" });


                            case "Customer":
                                return RedirectToAction("Index", "Customer", new { area = "Customer" });

                            case "SalesPerson":
                                return RedirectToAction("Index", "SalesPerson", new { area = "SalesPerson" });

                        }
                        return Redirect(model.ReturnUrl);
                    }
                }
            }
            ModelState.AddModelError(" ", "Invalid username/password.");


            return View(model);
        }

        public IActionResult LogIn()
        {
            return View();
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

