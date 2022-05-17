using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnBanHang.Models;

namespace DoAnBanHang.Controllers
{
    public class CartController : Controller
    {
        private DB_BanHang1Entities db = new DB_BanHang1Entities();
        // GET: Cart
        public ActionResult Cart()
        {
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public ActionResult AddtoCart(int id )
        {
            var sp = db.SanPham.SingleOrDefault(s => s.ID_SP == id);
            
            //if (Session["Email"] == null)
            //    return RedirectToAction("Index", "Login");
            Cart cart = GetCart();
            if (sp != null)
            {
                cart.Add(sp);
            }
            cart.Total_Items();
            return RedirectToAction("Cart", "Cart");
        }
        public ActionResult Remove(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove(id);
            return RedirectToAction("Cart", "Cart");
        }
        public ActionResult UpdateQuantity(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id = int.Parse(form["ID_SP"]);
            int quantity = int.Parse(form["quantity"]);
            cart.UpdateQuantity(id, quantity);
            return RedirectToAction("Cart", "Cart");
        }
    }
}