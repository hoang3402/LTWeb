using System;
using System.Linq;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers.Customer
{
    public class CustomersController : Controller
    {
        EShopEntities db = new EShopEntities();

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(FormCollection collection)
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
                WebApplication3.Customer customer = new WebApplication3.Customer();
                customer.Fullname = fullname;
                customer.Email = email;
                customer.Password = password;
                customer.Id = CustomerModel.GetID();
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("login");
            }
            return this.Register();
        }
        [HttpGet]
        public ActionResult Login()
        {
            if (Session["User"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
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
                WebApplication3.Customer customer = db.Customers.SingleOrDefault(n => n.Email == emaillg && n.Password == passwordlg);
                if (customer != null)
                {
                    ViewBag.ThongBao = "Login Success";
                    Session["User"] = customer;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ThongBao = "Login Faile \n Please Type Email Or Password";
                    return View();
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}