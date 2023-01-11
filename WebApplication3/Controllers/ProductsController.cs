using CPT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CPT.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }
        //Cách của thầy
        public ActionResult ListProductFromCategory(int id){
            var proCategory = ProductModel.list_ProductFormCategory(id);
            return View(proCategory);
        }
    }
}