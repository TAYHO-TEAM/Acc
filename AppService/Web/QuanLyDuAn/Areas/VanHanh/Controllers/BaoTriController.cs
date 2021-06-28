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
    public class BaoTriController : Controller
    {
        // GET: VanHanh/BaoTri
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NhatKyBaoTri()
        {
            return View();
        }
        public ActionResult BaoTriDinhKy()
        {
            return View();
        }
        public ActionResult _PhieuHenBaoTriCreate(int id)
        {
            return PartialView(id);
        }
        public ActionResult _BaoTriHistory(int id)
        {
            return PartialView(id);
        }
     
        [HttpPost, ValidateInput(false)]
        public JsonResult MaintenanceLogUpdate(MaintenanceLogOBJ requestOBJ)
        {
            MultipartFormDataContent mFormData = new MultipartFormDataContent();
            HttpFileCollectionBase listFile = HttpContext.Request.Files;
            if (string.IsNullOrEmpty(requestOBJ.Result))
                requestOBJ.Result = "";
            if (requestOBJ.Status < 11)
                requestOBJ.Status = 11;
            if (requestOBJ.Status > 225)
                requestOBJ.Status = 200;
            string token = requestOBJ.token;
            var values = new JavaScriptSerializer().Serialize(requestOBJ);
            mFormData = new MultipartFormDataContent();

            if (!string.IsNullOrEmpty(requestOBJ.Key.ToString())) mFormData.Add(new StringContent(requestOBJ.Key.ToString()), "key");
            if (!string.IsNullOrEmpty(values)) mFormData.Add(new StringContent(values), nameof(values));
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
                    mFormData.Add(b, nameof(file) + i++.ToString(), fileBase.FileName);
                }
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationSettings.AppSettings["omCRUD"].ToString());//http://localhost:50999/,https://api-pm-cmd.tayho.com.vn/
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                using (HttpResponseMessage response = client.PutAsync("api/v1/MaintenanceLog/", mFormData).Result)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        var err = response.Content.ReadAsStringAsync().Result;
                        return Json(new { status = "error", result = err });
                    }
                }
            }
            return Json(new { status = "success", result = "Đã lưu thông tin yêu cầu thành công" });
        }
    }
}