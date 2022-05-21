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
        public List<Cart> LayGioHang()
        {
            List<Cart> gioHang = Session["GioHang"] as List<Cart>;
            //Nếu giỏ hàng chưa tồn tại thì tạo mới và đưa vào Session
            if (gioHang == null)
            {
                gioHang = new List<Cart>();
                Session["GioHang"] = gioHang;
            }
            return gioHang;
        }
        public ActionResult ThemSanPhamVaoGio(int MaSP, string Size)
        {
            //Lấy giỏ hàng hiện tại
            List<Cart> gioHang = LayGioHang();
            //Kiểm tra xem có tồn tại mặt hàng trong giỏ hay chưa
            //Nếu có thì tăng số lượng lên 1, ngược lại thêm vào giỏ
            Cart sanPham = gioHang.FirstOrDefault(s => s.ID_SP == MaSP );
            if (sanPham == null) //Sản phẩm chưa có trong giỏ
            {
                sanPham = new Cart(MaSP,Size);
                gioHang.Add(sanPham);
            }
            else
            {
                //if (sanPham.kichco != null)
                //{
                //    sanPham = new Cart(MaSP);
                //    gioHang.Add(sanPham);
                //}
                //else
                sanPham.SoLuong++; //Sản phẩm đã có trong giỏ thì tăng số lượng lên 1
            }
            
            return RedirectToAction("HienThiGioHang", "Cart", new { id = MaSP  });
        }
        public ActionResult XoaMatHang(int MaSP)
        {
            List<Cart> gioHang = LayGioHang();
            //Lấy sản phẩm trong giỏ hàng
            var sanpham = gioHang.FirstOrDefault(s => s.ID_SP == MaSP);
            if (sanpham != null)
            {
                gioHang.RemoveAll(s => s.ID_SP == MaSP);
                return RedirectToAction("HienThiGioHang"); //Quay về trang giỏ hàng
            }
            if (gioHang.Count == 0) //Quay về trang chủ nếu giỏ hàng không có gì
                return RedirectToAction("TrangChu", "TrangChu");
            return RedirectToAction("HienThiGioHang");
        }
        //private KichCo ChonKichCo(int id)
        //{
        //    var kichco = from kc in db.KichCo
        //                 where kc.ID_SP == id
        //                 select kc;
        //    return kichco;
        //}
        //Ham tinh tong so luong mat hang duoc mua
        private int TinhTongSL()
        {
            int tongSL = 0;
            List<Cart> gioHang = LayGioHang();
            if (gioHang != null)
                tongSL = gioHang.Sum(sp => sp.SoLuong);
            return tongSL;
        }        //Ham tinh tong tien cac san pham duoc mua
        private double TinhTongTien()
        {
            double TongTien = 0;
            List<Cart> gioHang = LayGioHang();
            if (gioHang != null)
                TongTien = gioHang.Sum(sp => sp.ThanhTien());
            return TongTien;
        }
        //Xay dung ham hiern thi
        //public ActionResult HienThiGioHang()
        //{
        //    List<Cart> gioHang = LayGioHang();
        //    //Nếu giỏ hàng trống thì trả về trang ban đầu
        //    if (gioHang == null || gioHang.Count == 0)
        //    {
        //        return RedirectToAction("TrangChu", "TrangChu");
        //    }
        //    ViewBag.TongSL = TinhTongSL();
        //    ViewBag.TongTien = TinhTongTien();
        //    return View(gioHang); //Trả về View hiển thị thông tin giỏ hàng
        //}
        //[HttpGet]
        //public ActionResult HienThiGioHang()
        //{
        //    return View();
        //}
        //[HttpPost]
        public ActionResult HienThiGioHang()
        {
            List<Cart> gioHang = LayGioHang();
            //Nếu giỏ hàng trống thì trả về trang ban đầu
            if (gioHang == null || gioHang.Count == 0)
            {
                return RedirectToAction("TrangChu", "TrangChu");
            }
            ViewBag.TongSL = TinhTongSL();
            ViewBag.TongTien = TinhTongTien();
            return View(gioHang); //Trả về View hiển thị thông tin giỏ hàng
        }
        public ActionResult GioHangPartial()
        {
            ViewBag.TongSL = TinhTongSL();
            ViewBag.TongTien = TinhTongTien();
            return PartialView();
        }
        //public ActionResult Remove(int id)
        //{
        //    Cart cart = Session["Cart"] as Cart;
        //    cart.Remove(id);
        //    return RedirectToAction("Cart", "Cart");
        //}



        // GET: Cart
        //public ActionResult Cart()
        //{
        //    Cart cart = Session["Cart"] as Cart;
        //    return View(cart);
        //}
        //public Cart GetCart()
        //{
        //    Cart cart = Session["Cart"] as Cart;
        //    if (cart == null || Session["Cart"] == null)
        //    {
        //        cart = new Cart();
        //        Session["Cart"] = cart;
        //    }
        //    return cart;
        //}
        //public ActionResult AddtoCart(int id )
        //{
        //    var sp = db.SanPham.SingleOrDefault(s => s.ID_SP == id);

        //    //if (Session["Email"] == null)
        //    //    return RedirectToAction("Index", "Login");
        //    Cart cart = GetCart();
        //    if (sp != null)
        //    {
        //        cart.Add(sp);
        //    }
        //    cart.Total_Items();
        //    return RedirectToAction("Cart", "Cart");
        //}

        //public ActionResult UpdateQuantity(FormCollection form)
        //{
        //    Cart cart = Session["Cart"] as Cart;
        //    int id = int.Parse(form["ID_SP"]);
        //    int quantity = int.Parse(form["quantity"]);
        //    cart.UpdateQuantity(id, quantity);
        //    return RedirectToAction("Cart", "Cart");
        //}



    }
}