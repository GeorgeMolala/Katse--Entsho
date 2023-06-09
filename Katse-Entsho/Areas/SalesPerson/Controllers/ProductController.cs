using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Katse_Entsho.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Katse_Entsho.Models;
using Katse_Entsho.Models.Valida;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace Katse_Entsho.Areas.SalesPerson.Controllers
{

    [Area ("SalesPerson")]
    [Authorize (Roles="SalesPerson")]
    public class ProductController : Controller
    {
        private readonly KatseContext _context;
        private readonly IWebHostEnvironment _webHost;

        public ProductController(KatseContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            this._webHost = webHost;
        }

        public IActionResult Index()
        {

            var product = _context.Products.ToList();
            return View(product);
        }

        [HttpGet]
        public IActionResult Edit()
        {
            

            var supplier = _context.Suppliers.ToList();
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Suppliers = _context.Suppliers.ToList();

            return View();
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {

            var supplier = _context.Suppliers.ToList();
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Suppliers = _context.Suppliers.ToList();

            var product = _context.Products.Find(id);

            return View(product);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product)
        {

            var supplier = _context.Suppliers.ToList();
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Suppliers = _context.Suppliers.ToList();



            //Configuring Path to upload Image to


            string UploadDir = Path.Combine(_webHost.WebRootPath, "media/Products");
            string ImageName = Guid.NewGuid().ToString() + "_" + product.Picture.FileName; //Modifying File name to avoid file override incase file name exist

            string filePath = Path.Combine(UploadDir, ImageName);


            //Writes image to specified Location
            using (var fs = new FileStream(filePath, FileMode.Create))
            {
                await product.Picture.CopyToAsync(fs);
                fs.Close();
            }
            product.Image = ImageName;

            if (ModelState.IsValid)
            {
                if (product.ProductID == 0)
                {



                    //Saving to DB
                    _context.Products.Add(product);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index");
                }

                else
                {
                    ///Update Methods here
                    _context.Products.Update(product);
                    await _context.SaveChangesAsync();
                }
            }

            return View();
        }
    }
}
