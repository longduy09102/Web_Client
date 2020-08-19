using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebQLBHMA_Client.Helper;
using WebQLBHMA_Client.Models;

namespace WebQLBHMA_Client.Controllers
{
    public class CartAjaxController : Controller
    {
        // GET: CartAjax
        public ActionResult Index()
        {
            var gioHang = Session["GioHang"] as GioHangModel;
            ViewBag.ShoppingCartAct = "active";
            ViewBag.GioHang = gioHang;
            if (Request.IsAjaxRequest())
                return PartialView("_IndexPartial");
            return View();
        }

        [HttpPost]
        public ActionResult AddToCart(int HangHoaID,int SoLuong = 1)
        {
            string url= $"hang-hoa/doc-theo-id?id={HangHoaID}";
            var gioHang = Session["GioHang"] as GioHangModel;
            if(gioHang==null)
            {
                gioHang = new GioHangModel();
                Session["GioHang"] = gioHang;
            }
            HangHoaInput hangHoa = ApiHelper<HangHoaInput>.RunPost(url);
            var item = new GioHangItem(hangHoa, SoLuong);
            gioHang.Them(item);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(int HangHoaID, int SoLuong)
        {
            string url = $"";
            var gioHang = Session["GioHang"] as GioHangModel;
            gioHang.Xoa(HangHoaID);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int HangHoaID)
        {
            var gioHang = Session["GioHang"] as GioHangModel;
            gioHang.Xoa(HangHoaID);
            return RedirectToAction("Index");
        }

        #region Xử lý phát sinh đơn đặt hàng
        [HttpGet]
        public ActionResult DatHang()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DatHang(HoaDonOutput hoaDon)
        {
            var gioHang = Session["GioHang"] as GioHangModel;
            if (gioHang == null || gioHang.TongSanPham == 0)
                return RedirectToAction("Index", "Home");
            try
            {
                string urlHoaDon = "hoa-don/them-moi";
                string urlHoaDonChiTiet = "hoa-don-chi-tiet/them-moi";
                hoaDon.NgayDatHang = DateTime.Now;
                hoaDon.TongTien = gioHang.TongTriGia;
                HoaDonInput resultHoaDon = await ApiHelper<HoaDonInput>.RunPostAsync(urlHoaDon, hoaDon);
                foreach(var item in gioHang.DanhSach)
                {
                    HoaDonChiTietInput ct = new HoaDonChiTietInput();
                    ct.HoaDonID = hoaDon.ID;
                    ct.HangHoaID = item.HangHoa.ID;
                    ct.SoLuong = item.SoLuong;
                    ct.DonGia = item.HangHoa.GiaBan;
                    ct.ThanhTien = item.HangHoa.GiaBan * item.SoLuong;
                    HoaDonChiTietInput resultHoaDonChiTiet = await ApiHelper<HoaDonChiTietInput>.RunPostAsync(urlHoaDonChiTiet, ct);
                }
                gioHang.XoaTatCa();
                return View("DatHangThanhCong", hoaDon);
            }
            catch (Exception ex)
            {

                TempData["LoiDatHang"] = "Đặt hàng không thành công. <br>" + ex.Message;
                return RedirectToAction("Index");
            }
        }
        #endregion
    }
}