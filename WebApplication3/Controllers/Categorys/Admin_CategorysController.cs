using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers.Categorys
{
    public class Admin_CategorysController : Controller
    {
        // GET: Admin_Categorys
        public ActionResult Index()
        {
            List<Category> list = CategoryModel.GetList();
            ViewBag.Category = list;
            return View();
        }

        // Các phương thức thêm mới Category
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(FormCollection form)
        {
            //Lấy thông tin từ form
            string name = form["txtName"];
            string namevn = form["txtNameVN"];

            //Lưu thông tin vào Database
            Category ct = new Category();
            ct.Id = CategoryModel.GetNewCategoryId();
            ct.Name = name;
            ct.NameVN = namevn;
            CategoryModel.AddCategory(ct);

            return RedirectToAction("Index");
        }

        // Các phương thức cập nhật Category
        public ActionResult Edit(int id)
        {
            EShopEntities db = new EShopEntities();
            var model = db.Categories.Find(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            Category model = new Category();
            model.Id = Convert.ToInt32(form["hiddenId_Category"]);
            model.Name = form["txtName"];
            model.NameVN = form["txtNameVN"];

            CategoryModel.UpdateCategory(model);
            return RedirectToAction("Index");
        }

        //Các phương thức xóa
        public ActionResult Delete(int id)
        {
            EShopEntities db = new EShopEntities();
            //Tìm Category theo id
            var cate = db.Categories.Find(id);
            //Xóa
            db.Categories.Remove(cate);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ViewByIdCategory(int id)
        {
            ViewBag.data = ProductModel.GetList_Product(id);
            return View();
        }
    }
}