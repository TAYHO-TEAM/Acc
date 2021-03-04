
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common.Utilities
{
    public static class CallApi
    {
        public static async Task<string> ApiJsonPost(string url, string uri, string authen = "", string request = "")
        {
            string result = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var httpContent = new StringContent(request, Encoding.UTF8, "application/json");
                //POST Method  
                HttpResponseMessage response = await client.PostAsync(uri, httpContent);
                if (response.IsSuccessStatusCode)
                {
                    result = "Ok";
                }
                else
                {
                    result = "Error";
                }
            }
            return result;
        }
        public static async Task<string> ApiJsonGet(string url, string uri, string authen = "", string request = "")
        {
            string result = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                HttpResponseMessage response = await client.GetAsync(uri+"?"+request);
                if (response.IsSuccessStatusCode)
                {
                    result = "Ok";
                }
                else
                {
                    result="Error";
                }
            }
            return result;
        }
    }

}
