using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
//---------------------------------------------
using WebQLBHMA_Client.Helper;
using WebQLBHMA_Client.Models;

namespace WebQLBHMA_Client.Controllers
{
    public class LoaiController : Controller
    {
        // GET: Loai
        #region Index
        public PartialViewResult _LoaiIndex()
        {
            try
            {
                string url = "loai/doc-danh-sach";
                var loais = ApiHelper<List<LoaiOutput>>.RunGet(url);
                ViewBag.LoaiIndex = loais;
                return PartialView();
            }
            catch (Exception ex)
            {

                return PartialView("Error",model:ex.Message);
            }
        }
        #endregion

        #region Shop
        [ChildActionOnly]
        public PartialViewResult _LoaiAjaxPartial()
        {
            try
            {
                string url = "loai/doc-danh-sach";
                var loais = ApiHelper<List<LoaiOutput>>.RunGet(url);
                ViewBag.LoaiShop = loais;
                return PartialView();
            }
            catch (Exception ex)
            {

                return PartialView("Error",model:ex.Message);
            }
        }
        #endregion
    }

}