using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        //Xử lý hiển thị danh sách sản phẩm 
        public ActionResult Index()
        {
            List<Product> list_pro = ProductModel.GetList_Product();
            ViewBag.Products = list_pro;
            return View();
        }

        //Xử lý menu Category
        
        [ChildActionOnly]
        public ActionResult menu_Category()
        {
            EShopEntities db = new EShopEntities();
            return PartialView("_Category", db.Categories);
        }
    }
}