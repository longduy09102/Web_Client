using System;
using System.Collections.Generic;
using System.Linq;
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
            return RedirectToAction("Index")
        }
    }
}