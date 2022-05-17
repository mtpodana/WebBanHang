using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnBanHang.Models;
//using DoAnBanHang.Models.DTO;

namespace DoAnBanHang.Controllers
{
    public class AccountController : Controller
    {
        DB_BanHang1Entities db = new DB_BanHang1Entities();

        public ActionResult Index()
        {
            return View();
        }
        // GET: Account
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(TaiKhoan User)
        {
            var check = db.TaiKhoan.Where((s => s.Username.Equals(User.Username) && s.Password.Equals(User.Password))).FirstOrDefault();
            
            if (check == null)
            {
                ViewBag.error = "Sai ten dang nhap hoac mat khau!Hay thu lai!";
                return View("DangNhap", User);
            }
            else
            {
                var test = db.TaiKhoan.SingleOrDefault(s => s.Username == User.Username);
                //test.Username.ToString();
                //test.ID_KhachHang.ToString();
                //test.Username == "admin@gmail.com" &&
                if (test.Username == "admin" || test.ID_TK == 1)
                {
                    //return RedirectToAction("Index", "QL_Home");
                    return RedirectToAction("Index", "QL_Home");
                }
                else
                {
                    //Session["IDUser"] = User.ID_KhachHang;
                    Session["Username"] = User.Username;
                    return RedirectToAction("TrangChu", "TrangChu");
                   
                }
            }
        }
        public ActionResult DoiMatKhau()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(TaiKhoan _user)
        {
            if (ModelState.IsValid)
            {
                var check = db.TaiKhoan.FirstOrDefault(s => s.Username == _user.Username);
                if (check == null)
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.TaiKhoan.Add(_user);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    ViewBag.error = "Username da ton tai! Su dung username khac!";
                    return View();
                }
            }
            return View();
        }
        public ActionResult ThongTinKhach()
        {
            return View();
        }
    }
}