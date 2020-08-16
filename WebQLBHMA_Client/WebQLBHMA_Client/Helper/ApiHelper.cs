using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//------------------------------------
using System.Configuration;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using WebQLBHMA_Client.Models;

namespace WebQLBHMA_Client.Helper
{
    public class ApiHelper<T>
    {
        static string apiURL = ConfigurationManager.AppSettings["apiURL"];

        #region
        public static async Task<dynamic> RunGetAsync(string url)
        {
            dynamic result = null;
            using(HttpClient client= new HttpClient())
            {
                client.BaseAddress = new Uri(apiURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                    result = await response.Content.ReadAsAsync<T>();
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    var err = await response.Content.ReadAsAsync<BadRequestGet>();
                    throw new Exception(err.Message);
                }
                else
                    throw new Exception("Lỗi kết nối với service");
                return result;
            }
        }
        #endregion

        #region
        public static dynamic RunGet(string url)
        {
            dynamic result = null;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                    result = response.Content.ReadAsAsync<T>().Result;
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    var err = response.Content.ReadAsAsync<BadRequestGet>().Result;
                    throw new Exception(err.Message);
                }
                else
                    throw new Exception("Lỗi kết nối với service");
                return result;
            }    
        }
        #endregion

        #region
        public static async Task<dynamic> RunPostAsync(string url,object input = null)
        {
            dynamic result = null;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PostAsJsonAsync(url, input);
                if (response.IsSuccessStatusCode)
                    result = await response.Content.ReadAsAsync<T>();
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    var err = await response.Content.ReadAsAsync<BadRequestPost>();
                    string errMsg = null;
                    if (err.ModelState == null)
                        errMsg = err.Message;
                    else
                    {
                        foreach (KeyValuePair<string, string[]> item in err.ModelState)
                            errMsg += $"{string.Join(",", item.Value)}";
                    }
                    throw new Exception(errMsg);
                }
                else
                    throw new Exception("Lỗi kết nối với service");
                return result;
            }    
        }
        #endregion

        #region
        public static dynamic RunPost(string url,object input = null)
        {
            dynamic result = null;
            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync(url, input).Result;
                if (response.IsSuccessStatusCode)
                    result = response.Content.ReadAsAsync<T>().Result;
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    var err = response.Content.ReadAsAsync<BadRequestPost>().Result;
                    string errMsg = null;
                    if (err.ModelState == null)
                        errMsg = err.Message;
                    else
                    {
                        foreach (KeyValuePair<string, string[]> item in err.ModelState)
                            errMsg += $"{string.Join(",", item.Value)}";
                    }
                    throw new Exception(errMsg);
                }
                else
                    throw new Exception("Lỗi kết nối với service");
                return result;
            }    
        }
        #endregion
    }
}