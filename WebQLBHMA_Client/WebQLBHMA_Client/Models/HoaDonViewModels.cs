using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class HoaDonInput
    {
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Required(ErrorMessage = "{0} không được để trống")]
        [MaxLength(50, ErrorMessage = "{0} tối đa là {1} ký tự.")]
        [Display(Name = "Họ tên khách hàng")]
        public string HoTenKhach { get; set; }

        [Required(ErrorMessage = "{0} không được để trống")]
        [MaxLength(150, ErrorMessage = "{0} tối đa là {1} ký tự.")]
        [Display(Name = "Địa chỉ khách hàng")]
        public string DiaChi { get; set; }

        [Required(ErrorMessage = "{0} không được để trống")]
        [MaxLength(30, ErrorMessage = "{0} tối đa là {1} ký tự.")]
        [Display(Name = "Số điện thoại")]
        public string DienThoai { get; set; }

        [Required(ErrorMessage = "{0} không được để trống")]
        [MaxLength(50, ErrorMessage = "{0} tối đa là {1} ký tự.")]
        [Display(Name = "Địa chỉ Email")]
        public string Email { get; set; }

        [Display(Name = "Tổng tiền")]
        public int TongTien { get; set; }
    }
}