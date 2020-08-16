using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebQLBHMA_Client.Models
{
    public class LoaiOutput
    {
        public int ID { get; set; }

        public string MaSo { get; set; }

        public string Ten { get; set; }

        public int ChungLoaiID { get; set; }

        public ChungLoaiOutput ChungLoai { get; set; }

        public class HangHoa
        {
            public int ID { get; set; }

            public string MaSo { get; set; }

            public string TenHang { get; set; }

            public int GiaBan { get; set; }
        }
    }
}