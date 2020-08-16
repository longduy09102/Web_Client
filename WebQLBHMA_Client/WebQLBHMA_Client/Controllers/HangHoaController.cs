using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//-----------------------------------------
using WebQLBHMA_Client.Helper;
using WebQLBHMA_Client.Models;
using System.Threading.Tasks;
using X.PagedList;

namespace WebQLBHMA_Client.Controllers
{
    public class HangHoaController : Controller
    {
        // GET: HangHoa
        #region Index
        public PartialViewResult _HangHoaIndex(int loaiID)
        {
            try
            {
                string url = "hang-hoa/doc-danh-sach";
                List<HangHoaOutput> hanghaos = ApiHelper<List<HangHoaOutput>>.RunGet(url);
                List<HangHoaOutput> items = hanghaos
                    .Where(p => p.LoaiID == loaiID)
                    .OrderByDescending(p => p.ID)
                    .Take(1)
                    .ToList();
                ViewBag.HangHoa = items;
                return PartialView();
            }
            catch (Exception ex)
            {

                return PartialView("Error",model:ex.Message);
            }
        }
        #endregion

        #region Shop
        public async Task<ActionResult> ShopAjax(int? page)
        {
            try
            {
                string url = "hang-hoa/doc-mot-trang";
                int pageNumber = (page == null || page < 1) ? 1 : page.Value;
                var input = new PagedInput { PageIndex = pageNumber, PageSize = 12 };
                HangHoaPagedOutput result = await ApiHelper<HangHoaPagedOutput>.RunPostAsync(url, input);
                ViewBag.OnePageOfData = new StaticPagedList<HangHoaOutput>(result.Items, input.PageIndex, input.PageSize, result.TotalItemCount);
                if (Request.IsAjaxRequest())
                    return PartialView("_ShopAjaxPartial");
                return View();
            }
            catch (Exception ex)
            {

                return View("Error", model: ex.Message);
            }
        }
        public async Task<ActionResult> TraCuuTheoLoaiAjax(int? id, int? page)
        {
            string urlLoai = $"loai/doc-theo-id?value={id}";
            string urlHangHoaTheoLoaiId = "hang-hoa/doc-mot-trang-theo-loai-id";
            if (id == null || id < 0)
                return RedirectToAction("Index", "Home");
            try
            {
                LoaiOutput loaiItem = await ApiHelper<LoaiOutput>.RunPostAsync(urlLoai);
                if (loaiItem == null)
                {
                    return View(viewName: "BaoLoi", model: $"Loai {id} khong ton tai san pham");
                }
                int pageNumber = (page == null || page < 1) ? 1 : page.Value;
                var input = new PagedInputLoaiId { PageIndex = pageNumber, PageSize = 12, Id = loaiItem.ID };
                HangHoaPagedOutput result = await ApiHelper<HangHoaPagedOutput>.RunPostAsync(urlHangHoaTheoLoaiId,input);
                ViewBag.OnePageOfData = new StaticPagedList<HangHoaOutput>(result.Items, input.PageIndex, input.PageSize, result.TotalItemCount);
                ViewBag.LoaiID = loaiItem.ID;
                if (Request.IsAjaxRequest())
                    return PartialView("_ShopAjaxPartial");
                return View("ShopAjax");
            }
            catch (Exception ex)
            {

                return View(viewName: "BaoLoi", model: $"Lỗi truy cập dữ liệu {ex.Message}");
            }
        }
        #endregion

        #region Shop-single
        public async Task<ActionResult> ChiTiet(int? id)
        {
            if (id == null || id < 1) return RedirectToAction("Index", "Home");
            try
            {
                string url = $"hang-hoa/doc-theo-id?id={id}";
                HangHoaInput hangHoa = await ApiHelper<HangHoaInput>.RunPostAsync(url);
                if (hangHoa == null) throw new Exception($"Mặt hàng ID = {id} không tồn tại");
                return View(model:hangHoa);
            }
            catch (Exception ex)
            {

                string cauBaoLoi = $"Lỗi truy cập dữ liệu.<br/>Lý do: {ex.Message}";
                return View(viewName: "BaoLoi", model: cauBaoLoi);
            }
        }
        #endregion
    }
}