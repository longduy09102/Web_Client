using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebQLBHMA_Client.Models
{
    public class ThuongHieuOutput
    {
        public int ID { get; set; }

        public string Ten { get; set; }

        public string MoTa { get; set; }

        public List<string> HinhURLs { get; set; }

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
}