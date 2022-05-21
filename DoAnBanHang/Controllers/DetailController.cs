using DoAnBanHang.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using DoAnBanHang.Models.DTO;

namespace DoAnBanHang.Controllers
{
    public class DetailController : Controller
    {
        private DB_BanHang1Entities db = new DB_BanHang1Entities();
   
        public ActionResult Index(int id)
        {
            
            ViewBag.query = (from kc in db.KichCo select kc).Where(s => s.ID_SP == id).ToList();
            var sp = db.SanPham.Where(s => s.ID_SP == id).FirstOrDefault();
            
            return View(sp);
        }
        
    }
}