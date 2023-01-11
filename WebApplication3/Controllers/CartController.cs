using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            List<Cart> carts = GetCarts();
            if (carts is null || carts.Count == 0)
            {
                ViewBag.Amount = 0;
                ViewBag.Total = 0;
                return PartialView("_Cart");
            }
            ViewBag.Amount = TotalAmount();
            ViewBag.Total = TotalMoney();
            return PartialView("_Cart");
        }
        public List<Cart> GetCarts()
        {
            List<Cart> carts = Session["Cart"] as List<Cart>;
            if (carts is null)
            {
                Session["Cart"] = new List<Cart>();
            }
            return carts;
        }

        public ActionResult Add(int id, string strUrl)
        {
            List<Cart> carts = GetCarts();
            Cart cart = carts.Find(item => item.Find(id));
            if (cart is null)
            {
                cart = new Cart(id);
                carts.Add(cart);
                return Redirect(strUrl);
            }
            else
            {
                cart.Amount++;
                return Redirect(strUrl);
            }
        }
        public ActionResult Remove(int id)
        {
            List<Cart> carts = GetCarts();
            Cart cart = carts.Find(item => item.Find(id));
            carts.Remove(cart);
            return RedirectToAction("ShowDetail");
        }

        private int TotalAmount()
        {
            int result = 0;
            List<Cart> carts = Session["Cart"] as List<Cart>;
            if (carts != null)
            {
                result = carts.Sum(item => item.Amount);
            }
            return result;
        }
        private double TotalMoney()
        {
            double result = 0;
            List<Cart> carts = Session["Cart"] as List<Cart>;
            if (carts != null)
            {
                result = carts.Sum(item => item.Total);
            }
            return result;
        }

        public ActionResult ShowDetail()
        {
            if (GetCarts() is null) { return RedirectToAction("Index", "Home"); }
            ViewBag.data = GetCarts();
            ViewBag.Amount = TotalAmount();
            ViewBag.Total = TotalMoney();
            return View();
        }
    }
}