using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CPT.Models
{
    public class ProductModel
    {
        static ShopElectricEntities db = new ShopElectricEntities();

        public static List<Product> get_listProducts(int count)
        {          
            return db.Products.OrderByDescending(p => p.ProductDate).ToList();
        }
        //
        public static List<Product> SPTheoChuDE(int id)
        {
            var item = from s in db.Products 
                       where s.CategoryId == id 
                       select s;
            return item.ToList();
        }
        //Cách lấy sp theo thể loại của thầy
        public static List<Product> list_ProductFormCategory(int id)
        {
            var query = from pro in db.Products
                        where pro.CategoryId == id
                        select pro;
            return query.ToList();
        }
    }
}