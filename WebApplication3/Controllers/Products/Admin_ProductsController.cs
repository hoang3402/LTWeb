using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers.Products
{
    public class Admin_ProductsController : Controller
    {
        // GET: Admin_Products
        public ActionResult Index()
        {
            List<Product> list_product = ProductModel.GetList_Product();
            ViewBag.Products = list_product;
            return View();
        }

        //Thêm mới Product
        public ActionResult Add_product()
        {
            //Get list Category
            List<Category> list_category = CategoryModel.GetList();
            ViewBag.CategoryList = list_category;
            return View();
        }

        [HttpPost]
        public ActionResult Add_Product(FormCollection form)
        {
            //Lấy thông tin từ form
            string name = form["txtName"];
            double price = Convert.ToDouble(form["txtPrice"]);
            HttpPostedFileBase file_images = Request.Files["fileImage"] as HttpPostedFileBase;
            DateTime pro_date = Convert.ToDateTime(form["txtProductDate"]);
            var avaliable = Convert.ToBoolean(Request.Form.GetValues("ckbAvaliable")[0]);
            int id_category = Convert.ToInt32(form["cmbCategory"]);
            string description = form["txtDescription"];

            //Thêm dữ liệu
            //upload file
            string filename = Server.MapPath("~/Content/images/" + file_images.FileName);
            file_images.SaveAs(filename);

            Product pro = new Product();
            pro.Id = ProductModel.GetNewProductId();
            pro.Name = name;
            pro.UnitPrice = price;
            pro.Image = file_images.FileName;
            pro.ProductDate = pro_date;
            pro.Available = avaliable;
            pro.CategoryId = id_category;
            pro.Description = description;
            ProductModel.AddProduct(pro);
            return RedirectToAction("Index");
        }

        //Cập nhật Product
        public ActionResult EditProduct(int id)
        {
            List<Category> list_category = CategoryModel.GetList();
            ViewBag.CategoryList = list_category;
            Product pro = ProductModel.GetProducDetail(id);
            ViewBag.Product = pro;
            return View();
        }
    }
}