//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoAnBanHang.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CT_HoaDon
    {
        public int ID_SP { get; set; }
        public int ID_HoaDon { get; set; }
        public int SoLuong { get; set; }
    
        public virtual HoaDon HoaDon { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}
