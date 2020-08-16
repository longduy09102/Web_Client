using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebQLBHMA_Client.Models
{
    public class PagedInput
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
    public class PagedInputLoaiId
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int? Id { get; set; }
    }
    public class PagedOutPut<T>
    {
        public List<T> Items { get; set; }
        public int TotalItemCount { get; set; }
    }    
    public class HangHoaPagedOutput
    {
        public List<HangHoaOutput> Items { get; set; }
        public int TotalItemCount { get; set; }
    }
}