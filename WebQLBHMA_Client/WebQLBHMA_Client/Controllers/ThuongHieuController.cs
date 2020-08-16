using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//----------------------------------------------
using WebQLBHMA_Client.Helper;
using WebQLBHMA_Client.Models;

namespace WebQLBHMA_Client.Controllers
{
    public class ThuongHieuController : Controller
    {
        // GET: ThuongHieu
        public PartialViewResult ThuongHieuIndex()
        {
            try
            {
                string url = "thuong-hieu/doc-danh-sach";
                var thuonghieus = ApiHelper<List<ThuongHieuOutput>>.RunGet(url);
                return PartialView(model:thuonghieus);
            }
            catch (Exception ex)
            {
                return PartialView("Error", model: ex.Message);
            }
        }
    }
}