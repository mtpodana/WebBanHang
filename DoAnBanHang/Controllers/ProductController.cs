using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnBanHang.Models;
using System.Dynamic;
using System.Data.Entity;
//using DoAnBanHang.Models.DTO;



namespace DoAnBanHang.Controllers
{
   

    public class ProductController : Controller
    {

        private List<SanPham> GetSanPham()
        {
            List<SanPham> sanpham = new List<SanPham>();
            return sanpham;
        }
        //private List<PhieuNhap> Getphieunhap()
        //{
        //    List<PhieuNhap> sanpham = new List<PhieuNhap>();
        //    return sanpham;
        //}

        //private List<CTPhieuNhap> Getctphieunhap()
        //{
        //    List<CTPhieuNhap> ctphieunhap = new List<CTPhieuNhap>();
        //    return ctphieunhap;
        //}

       

        DB_BanHang1Entities db = new DB_BanHang1Entities();
        public ActionResult ReturnPrice(int id)
        {
            
            var ketqua = from sp in db.SanPham
                         where (100000 >= sp.DonGia || sp.DonGia <= 200000) && sp.ID_Loai == id
                         select sp;
            return View(ketqua.ToList());
        }
        // GET: Product
        public ActionResult Ao()
        {
            return View(db.SanPham.ToList());
            
        }
        public ActionResult Quan()
        {
            return View(db.SanPham.ToList());
        }
        public ActionResult Giay()
        {
            return View(db.SanPham.ToList());
        }

        public ActionResult Nam()
        {
            return View(db.SanPham.ToList());
        }
        public ActionResult Nu()
        {
            return View(db.SanPham.ToList());
        }
        
        //public ActionResult NewProducts()
        //{

            // var sp = db.CTPhieuNhap.Select(x => new DetailSP
            //{
            //    TenSP = x.SanPham.TenSP,
            //    DonGia = x.SanPham.DonGia,
            //    Image = x.SanPham.Image,
            //    NgayNhap = x.PhieuNhap.NgayNhap

            //}).ToList();

            //var query1 = (from sp in db.CTPhieuNhap
            //              select sp).Where(x => x.PhieuNhap.NgayNhap.Month == DateTime.Now.Month).ToList();
            //ViewBag.query = query1;
                         
            //return View();
            
           // ModelNgayNhap viewModel = new ModelNgayNhap(); //initialize it
           // viewModel.sanpham = GetSanPham();
           // viewModel.ctphieunhap = Getctphieunhap();
           // viewModel.phieunhap = Getphieunhap();
        //   // return View(viewModel);
        //}
    }
}