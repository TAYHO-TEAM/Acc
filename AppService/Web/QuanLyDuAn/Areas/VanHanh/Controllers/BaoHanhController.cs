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
    public class BaoHanhController : Controller
    {
        // GET: VanHanh/BaoHanh
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult YeuCau()
        {
            return View();
        }
        public ActionResult _YeuCauCreate()
        {
            return PartialView();
        }
        [HttpPost, ValidateInput(false)]
        public JsonResult YeuCauCreate(DefectFeedBack requestOBJ)
        {
            MultipartFormDataContent mFormData = new MultipartFormDataContent();
            HttpFileCollectionBase listFile = HttpContext.Request.Files;
            string token = requestOBJ.token;
            //if (requestOBJ.RealEstateId.HasValue) mFormData.Add(new StringContent(((int)requestOBJ.RealEstateId).ToString()), nameof(requestOBJ.RealEstateId));
            //if (requestOBJ.DefectiveId.HasValue) mFormData.Add(new StringContent(((int)requestOBJ.DefectiveId).ToString()), nameof(requestOBJ.DefectiveId));
            //if (requestOBJ.CustomerId.HasValue) mFormData.Add(new StringContent(((int)requestOBJ.CustomerId).ToString()), nameof(requestOBJ.CustomerId));
            //if (!string.IsNullOrEmpty(requestOBJ.Note)) mFormData.Add(new StringContent(requestOBJ.Note), nameof(requestOBJ.Note));
            //if (!string.IsNullOrEmpty(requestOBJ.FullName)) mFormData.Add(new StringContent(requestOBJ.FullName), nameof(requestOBJ.FullName));
            //if (!string.IsNullOrEmpty(requestOBJ.Phone)) mFormData.Add(new StringContent(requestOBJ.Phone), nameof(requestOBJ.Phone));
            var values = new JavaScriptSerializer().Serialize(requestOBJ);
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
                    //byte[] binData = b.ReadBytes(fileBase.ContentLength);
                    mFormData.Add(b, nameof(file) + i++.ToString(), fileBase.FileName);
                }

            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationSettings.AppSettings["omCRUD"].ToString());//http://localhost:50999/,https://api-pm-cmd.tayho.com.vn/
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                using (HttpResponseMessage response = client.PostAsync("api/v1/DefectFeedback/", mFormData).Result)
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