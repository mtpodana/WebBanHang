using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnBanHang.Models;
using System.Data.Entity;
using System.IO;

namespace DoAnBanHang.Controllers
{
    public class QL_SanPhamController : Controller
    {
        DB_BanHang1Entities db = new DB_BanHang1Entities();
        // GET: QL_SanPham
        public ActionResult Index()
        {
            return View(db.SanPham.ToList());

        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            return View(db.SanPham.Where(s => s.ID_SP == id).FirstOrDefault());
        }
        public ActionResult Edit(int id)
        {
            var sp = db.SanPham.Where(s => s.ID_SP == id).FirstOrDefault();
            return View(sp);
        }
        [HttpPost]
        public ActionResult Edit(int id,SanPham sanpham)
        {
            try { 
                var sp = db.SanPham.Find(sanpham.ID_SP);
                sp.TenSP = sanpham.TenSP;
                sp.DonGia = sanpham.DonGia;
                sp.TonKho = sanpham.TonKho;
                //if (sanpham.ImageUpload != null)
                //{
                //    string fileName = Path.GetFileNameWithoutExtension(sanpham.ImageUpload.FileName);
                //    string extension = Path.GetExtension(sanpham.ImageUpload.FileName);
                //    fileName = fileName + extension;
                //    sanpham.Image = "~/Image/" + fileName;
                //    sanpham.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Image/"), fileName));
                //}
                //db.Entry(sanpham).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect("/QL_SanPham/Details");
            }
            catch
            {
                return View();
            }
        }
        
    }
}