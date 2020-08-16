using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebQLBHMA_Client.Models
{
    public class HoaDonOutput
    {
        public int ID { get; set; }

        public System.DateTime NgayDatHang { get; set; }

        public string HoTenKhach { get; set; }

        public string DiaChi { get; set; }

        public string DienThoai { get; set; }

        public string Email { get; set; }

        public int TongTien { get; set; }

        public class HoaDonChiTiet
        {
            public int HangHoaID { get; set; }

            public int SoLuong { get; set; }

            public int DonGia { get; set; }

            public int ThanhTien { get; set; }
        }
    }
}