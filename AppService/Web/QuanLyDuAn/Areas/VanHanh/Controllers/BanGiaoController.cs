using QuanLyDuAn.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace QuanLyDuAn.Areas.VanHanh.Controllers
{
    public class BanGiaoController : Controller
    {
        // GET: VanHanh/BanGiao
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _HRDCreate(int id)
        {
            return PartialView(id);
        }
        public ActionResult _HRItemCreate()
        {
            return PartialView();
        }
        [HttpPost, ValidateInput(false)]
        public JsonResult UploadImages(HandOverReceiptOBJ requestOBJ)
        {
            MultipartFormDataContent mFormData = new MultipartFormDataContent();
            HttpFileCollectionBase listFile = HttpContext.Request.Files;
            string token = requestOBJ.token;
            var values = new JavaScriptSerializer().Serialize(requestOBJ);
            if (!string.IsNullOrEmpty(values)) mFormData.Add(new StringContent(values), nameof(values));
            if (!string.IsNullOrEmpty(requestOBJ.Key.ToString())) mFormData.Add(new StringContent(requestOBJ.Key.ToString()), "key");
            if (listFile.Count > 0)
            {
                int i = 1;
                foreach (string file in listFile)
                {
                    HttpPostedFileBase fileBase = Request.Files[file];
                    byte[] fileData = null;
                    using (var binaryReader = new BinaryReader(fileBase.InputStream))
                    {
                        fileData = binaryReader.ReadBytes(fileBase.ContentLength);
                    }
                    ByteArrayContent b = new ByteArrayContent(fileData);
                    b.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                    //byte[] binData = b.ReadBytes(fileBase.ContentLength);
                    mFormData.Add(b, nameof(file) + i++.ToString(), fileBase.FileName);
                }

            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationSettings.AppSettings["omCRUD"].ToString());//http://localhost:50999/,https://api-pm-cmd.tayho.com.vn/
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                int id = 0;
                using (HttpResponseMessage response = client.PutAsync("api/v1/HandOverReceipt/", mFormData).Result)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        var err = response.Content.ReadAsStringAsync().Result;
                        return Json(new { status = "error", result = err });
                    }
                    else
                    {
                        var json = new JavaScriptSerializer().Deserialize<dynamic>(response.Content.ReadAsStringAsync().Result.ToString());
                        id = Convert.ToInt32(json["result"]["id"].ToString());

                    }
                }
            }
            return Json(new { status = "success", result = "Đã lưu ảnh thành công" });
        }
    }
}