using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Xunit;

namespace WebQLBHMA_Client.Models
{
    public class HangHoaOutput
    {
        public int ID { get; set; }

        public string MaSo { get; set; }

        public string Ten { get; set; }

        public string DonViTinh { get; set; }

        public string MoTa { get; set; }

        public string ThongSoKyThuat { get; set; }

        public int ThuongHieuID { get; set; }

        public List<string> HinhURLs { get; set; }

        public int GiaBan { get; set; }

        public int LoaiID { get; set; }

        public System.DateTime NgayTao { get; set; }

        public System.DateTime NgayCapNhat { get; set; }

        public LoaiOutput Loai { get; set; }

        public ThuongHieuOutput ThuongHieu { get; set; }

        public List<string> Hinhs
        {
            get
            {
                var hinhs = new List<string>();
                foreach (var item in HinhURLs)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        hinhs.Add(item.Substring(39));
                    }
                    else
                        hinhs.Add("noImage.jpg");
                }
                return hinhs;
            }
        }
    }

    public class HangHoaInput
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "{0} không được để trống")]
        [MaxLength(50, ErrorMessage = "{0} tối đa là {1} ký tự.")]
        [Display(Name = "Mã số")]
        public string MaSo { get; set; }

        [Required(ErrorMessage = "{0} không được để trống")]
        [MaxLength(200, ErrorMessage = "{0} tối đa là {1} ký tự.")]
        [Display(Name = "Tên hàng")]
        public string Ten { get; set; }

        [MaxLength(50, ErrorMessage = "{0} tối đa là {1} ký tự.")]
        [Display(Name = "Đơn vị tính")]
        public string DonViTinh { get; set; }

        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }

        [Display(Name = "Thông số kỹ thuật")]
        public string ThongSoKyThuat { get; set; }

        [Display(Name = "Thương hiệu ID")]
        public int? ThuongHieuID { get; set; }

        [Display(Name = "Tên hình hàng hóa")]
        public string TenHinh { get; set; }
        public List<string> Hinhs
        {
            get
            {
                var hinhs = new List<string>();
                if (!string.IsNullOrEmpty(TenHinh))
                {
                    hinhs.AddRange(TenHinh.Split(','));
                }
                else
                {
                    hinhs.Add("noImage.jpg");
                }
                return hinhs;
            }

        }

        [Range(0, int.MaxValue, ErrorMessage = "{0} phải từ {1} đến {2}")]
        [RegularExpression(@"\d*", ErrorMessage = "{0} phải là số nguyên")]
        [Display(Name = "Giá bán")]
        public int GiaBan { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "{0} phải >=1")]
        [RegularExpression(@"\d*", ErrorMessage = "{0} phải là số nguyên")]
        [Display(Name = "Chủng loại")]
        public int? LoaiID { get; set; }
    }
}