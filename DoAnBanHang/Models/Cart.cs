using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnBanHang.Models
{


    public class Cart
    {
        DB_BanHang1Entities db = new DB_BanHang1Entities();
        public KichCo kc = new KichCo();
        public int ID_SP { get; set; }

        public string TenSP { get; set; }
        public double DonGia { get; set; }
        public string Image { get; set; }
        public int SoLuong { get; set; }
        public int ID_Size { get; set; }
        public string Size { get; set; }
        public Cart GetCart() {
            
            this.ID_Size = kc.ID_Size;
            this.Size = kc.Size;
            return this;
            }

       
        
        public double ThanhTien()
        {
            return SoLuong * DonGia;
        }
        public Cart(int ID_SP, string Size)
        {

            this.ID_SP = ID_SP;
            //Tim san pham
            var sp = db.SanPham.Single(s => s.ID_SP == this.ID_SP);
            this.TenSP = sp.TenSP;
            this.DonGia = double.Parse(sp.DonGia.ToString());
            this.SoLuong = 1;
            this.Image = sp.Image;
            //this.kichco = db.KichCo.FirstOrDefault(s => s.ID_SP == this.ID_SP && s.Size== Size);
        }
      
        //public void Remove(int id)
        //{
        //    items.RemoveAll(s => s._chosen_product.ID_SP == id);
        //}
    }
    //public class CartItem
    //{
    //    public SanPham _chosen_product { get; set; }

    //    public int _chosen_product_quantity { get; set; }
    //}
    //public class Cart
    //{

    ////    //public int ID_SP { get; set; }
    ////    //public int ID_Loai { get; set; }
    ////    //public string TenSP { get; set; }
    ////    //public double DonGia { get; set; }
    ////    //public bool GioiTinh { get; set; }
    ////    //public string Image { get; set; }
    ////    //public int SoLuong { get; set; }

    ////    public List<CartItem> items = new List<CartItem>();

    ////    public IEnumerable<CartItem> Items
    ////    {
    ////        get { return items; }
    ////    }

    //    public string Total_Items()
    //    {
    //        var total = 0;
    //        total = (int)items.Sum(s => s._chosen_product.DonGia * s._chosen_product_quantity);
    //        string[] temp = Convert.ToString(total).Split();
    //        string str = "";
    //        int cham = 1;
    //        for (int i = temp.Length - 1; i >= 0; i--)
    //        {
    //            if (cham % 3 == 0)
    //            {
    //                str = "." + str;
    //                cham = 1;
    //            }
    //            str = temp[i] + str;
    //            cham++;
    //        }
    //        str += " đ";
    //        return str;
    //    }

    //    public int Total_Quantity()
    //    {
    //        return items.Sum(s => s._chosen_product_quantity);
    //    }

    //    internal void Clear()
    //    {
    //        items.Clear();
    //    }
    //    public void UpdateQuantity(int id, int quantity)
    //    {
    //        var item = items.Find(s => s._chosen_product.ID_SP == id);
    //        if (item != null)
    //        {
    //            item._chosen_product_quantity = quantity;
    //        }
    //    }
    //Tính tổng tiền = DonGia*SoLuong
    //public double TongTien()
    //{
    //    return SoLuong * DonGia;
    //}
    //public Cart(int id)
    //{
    //    this.ID_SP = id;

    //    var SP = db.SanPham.Single(s => s.ID_SP == this.ID_SP);
    //    this.TenSP = SP.TenSP;
    //    this.DonGia = double.Parse(SP.DonGia.ToString());
    //    this.Image = SP.Image;

    //    this.SoLuong = 1;


    //}
}
