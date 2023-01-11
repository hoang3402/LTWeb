using CPT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Mvc;

namespace CPT.Controllers
{
    public class HomeController : Controller
    {
         ShopElectricEntities db = new ShopElectricEntities();
        
        public ActionResult Index()
        {
           

            return View();
        }
        public ActionResult newProducts()
        {
            return PartialView("_newproduct", db.Products);
        }
        public ActionResult getlistSPTheoLoai(int id)
        {
            List<Product> chude = ProductModel.SPTheoChuDE(id);
            return PartialView("_SPTheoLoai", chude);
        }
        //[HttpGet]
        //public ActionResult ThemmoiSP(Product a)
        //{
        //    ShopElectricEntities db = new ShopElectricEntities();
        //    db.Products.Add(a);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        //Xử lý menu Category
        [ChildActionOnly] // Đánh giấu cho biết no là action con, khi chạy thì nó chỉ gọi đúng cái temple này
        public ActionResult menu_Category()
        {
           //khai báo sd entities
            return PartialView("_Category", db.Categories); //trả về view một model
        }
        [ChildActionOnly]
        public ActionResult list_Product()
        {
            return PartialView("_Products", db.Products);
        }
        [ChildActionOnly]
        public ActionResult special_Product()
        {
            return PartialView("_SpecialProduct", db.Products);
        }
    }
}