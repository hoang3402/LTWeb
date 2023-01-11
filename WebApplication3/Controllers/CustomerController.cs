using CPT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CPT.Controllers
{
    public class CustomerController : Controller
    {
        ShopElectricEntities db = new ShopElectricEntities();
        // GET: Customer
        
  
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(FormCollection collection, Customer cs)
        {
            var fullname = collection["Fullname"];
            var email = collection["Email"];
            var password = collection["Password"];
            if (string.IsNullOrEmpty(fullname))
            {
                ViewData["Loi1"] = "Please Type FullName";
            }
            else if (string.IsNullOrEmpty(email))
            {
                ViewData["Loi2"] = "Please Type Email";
            }
            else if (string.IsNullOrEmpty(password))
            {
                ViewData["Loi3"] = "Please Type Password";
            }
            else
            {
                cs.Fullname = fullname;
                cs.Email = email;
                cs.Password = password;
                cs.Id = CustomersModel.GetID();
                db.Customers.Add(cs);
                db.SaveChanges();
                return RedirectToAction("login");
            }
            return this.Register();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Login(FormCollection collection)
        {
            var emaillg = collection["Email"];
            var passwordlg = collection["Password"];
            if (String.IsNullOrEmpty(emaillg))
            {
                ViewData["Loi1"] = "Please Type Email";
            }
            else if (String.IsNullOrEmpty(passwordlg))
            {
                ViewData["Loi1"] = "Please Type Password";
            }
            else
            {
                Customer cs = db.Customers.SingleOrDefault(n => n.Email == emaillg && n.Password == passwordlg);
                if (cs != null)
                {
                    ViewBag.ThongBao = "Login Success";
                    Session["User"] = cs;
                }
                else
                    ViewBag.ThongBao = "Login Faile \n Please Type Email Or Password";
            }
            return View();
        }
    }
}