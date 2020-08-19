using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebQLBHMA_Client.Models
{
    public class HoaDonChiTietInput
    {
        public int HoaDonID { get; set; }
        public int HangHoaID { get; set; }
        public int SoLuong { get; set; }
        public int DonGia { get; set; }
        public int ThanhTien { get; set; }
    }
}