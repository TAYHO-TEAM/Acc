using Newtonsoft.Json.Linq;
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
        public ActionResult _YeuCauDetail(int id)
        {
            return PartialView(id);
        }
        public ActionResult _DefectFixback(int id)
        {
            return PartialView(id);
        }
        public ActionResult _DefectFix(int id)
        {
            return PartialView(id);
        }
        public ActionResult _DefectFixReport(int id)
        {
            return PartialView(id);
        }
        public ActionResult _DefectAcceptance(int id)
        {
            return PartialView(id);
        }
        [HttpPost, ValidateInput(false)]
        public JsonResult YeuCauCreate(DefectFeedBackOBJ requestOBJ)
        {
            MultipartFormDataContent mFormData = new MultipartFormDataContent();
            HttpFileCollectionBase listFile = HttpContext.Request.Files;
            string token = requestOBJ.token;
            requestOBJ.Status = 10;
            requestOBJ.Key = null;
            var values = new JavaScriptSerializer().Serialize(requestOBJ);

            //var temp = JArray.Parse(values);
            //temp.Descendants()
            //    .OfType<JProperty>()
            //    .Where(attr => attr.Name.StartsWith("Id"))
            //    .ToList() // you should call ToList because you're about to changing the result, which is not possible if it is IEnumerable
            //    .ForEach(attr => attr.Remove()); // removing unwanted attributes
            //values = temp.ToString();
            //if (requestOBJ.RealEstateId.HasValue) mFormData.Add(new StringContent(((int)requestOBJ.RealEstateId).ToString()), nameof(requestOBJ.RealEstateId));
            //if (requestOBJ.DefectiveId.HasValue) mFormData.Add(new StringContent(((int)requestOBJ.DefectiveId).ToString()), nameof(requestOBJ.DefectiveId));
            //if (requestOBJ.CustomerId.HasValue) mFormData.Add(new StringContent(((int)requestOBJ.CustomerId).ToString()), nameof(requestOBJ.CustomerId));
            //if (!string.IsNullOrEmpty(requestOBJ.Note)) mFormData.Add(new StringContent(requestOBJ.Note), nameof(requestOBJ.Note));
            //if (!string.IsNullOrEmpty(requestOBJ.FullName)) mFormData.Add(new StringContent(requestOBJ.FullName), nameof(requestOBJ.FullName));
            //if (!string.IsNullOrEmpty(requestOBJ.Phone)) mFormData.Add(new StringContent(requestOBJ.Phone), nameof(requestOBJ.Phone));

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
                int id = 0;
                using (HttpResponseMessage response = client.PostAsync("api/v1/DefectFeedback/", mFormData).Result)
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
                if(id >0)
                {
                    var numbers = requestOBJ.DefectiveIds.Split(',').Select(Int32.Parse).ToList();
                    foreach (var item in numbers)
                    {
                        MultipartFormDataContent mFormDataSub = new MultipartFormDataContent();
                        DefectFeedBackDetailOBJ defectFeedBackDetailOBJ = new DefectFeedBackDetailOBJ();
                        defectFeedBackDetailOBJ.DefectiveId = item;
                        defectFeedBackDetailOBJ.DefectFeedbackId = id;
                        defectFeedBackDetailOBJ.Status = 1;
                        var valuesSub = new JavaScriptSerializer().Serialize(defectFeedBackDetailOBJ);
                        if (!string.IsNullOrEmpty(valuesSub)) mFormDataSub.Add(new StringContent(valuesSub), "values");
                        using (HttpResponseMessage responseSub = client.PostAsync("api/v1/DefectFeedbackDetail/", mFormDataSub).Result)
                        {
                            if (responseSub.StatusCode != HttpStatusCode.OK)
                            {
                                var err = responseSub.Content.ReadAsStringAsync().Result;
                                return Json(new { status = "error", result = err });
                            }
                        }
                    }
                }    
               
            }
            return Json(new { status = "success", result = "Đã lưu thông tin yêu cầu thành công" });
        }
        [HttpPost, ValidateInput(false)]
        public JsonResult YeuCauUpdate(DefectFeedBackOBJ requestOBJ)
        {
            MultipartFormDataContent mFormData = new MultipartFormDataContent();
            HttpFileCollectionBase listFile = HttpContext.Request.Files;
            string token = requestOBJ.token;
            var values = new JavaScriptSerializer().Serialize(requestOBJ);
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
                    //byte[] binData = b.ReadBytes(fileBase.ContentLength);
                    mFormData.Add(b, nameof(file) + i++.ToString(), fileBase.FileName);
                }

            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationSettings.AppSettings["omCRUD"].ToString());//http://localhost:50999/,https://api-pm-cmd.tayho.com.vn/
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                using (HttpResponseMessage response = client.PutAsync("api/v1/DefectFeedback/", mFormData).Result)
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
        [HttpPost, ValidateInput(false)]
        public JsonResult YeuCauAccept(DefectFeedBackOBJ requestOBJ)
        {
            MultipartFormDataContent mFormData = new MultipartFormDataContent();
            HttpFileCollectionBase listFile = HttpContext.Request.Files;
            requestOBJ.Status = 11;
            string token = requestOBJ.token;
            var values = new JavaScriptSerializer().Serialize(requestOBJ);
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
                    //byte[] binData = b.ReadBytes(fileBase.ContentLength);
                    mFormData.Add(b, nameof(file) + i++.ToString(), fileBase.FileName);
                }

            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationSettings.AppSettings["omCRUD"].ToString());//http://localhost:50999/,https://api-pm-cmd.tayho.com.vn/
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                using (HttpResponseMessage response = client.PutAsync("api/v1/DefectFeedback/", mFormData).Result)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        var err = response.Content.ReadAsStringAsync().Result;
                        return Json(new { status = "error", result = err });
                    }
                }
            }
            DefectFixOBJ defectFix = new DefectFixOBJ();
            defectFix.DefectFeedbackId = requestOBJ.Key;
            mFormData = new MultipartFormDataContent();
            var valuesDefectFix = new JavaScriptSerializer().Serialize(defectFix);
            if (!string.IsNullOrEmpty(values)) mFormData.Add(new StringContent(valuesDefectFix), "values");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationSettings.AppSettings["omCRUD"].ToString());//http://localhost:50999/,https://api-pm-cmd.tayho.com.vn/
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                using (HttpResponseMessage response = client.PostAsync("api/v1/DefectFix/", mFormData).Result)
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
        [HttpPost, ValidateInput(false)]
        public JsonResult DefectFixUpdate(DefectFixOBJ requestOBJ)
        {
            MultipartFormDataContent mFormData = new MultipartFormDataContent();
            HttpFileCollectionBase listFile = HttpContext.Request.Files;
            string token = requestOBJ.token;
            if (requestOBJ.Status == null || requestOBJ.Status < 20)
                requestOBJ.Status = 20;
            else if (requestOBJ.Status == 21)
            {
                requestOBJ.StartDate = DateTime.Now;
                requestOBJ.EndDate = DateTime.Now;
                DefectAcceptanceOBJ defectAcceptance = new DefectAcceptanceOBJ();
                defectAcceptance.DefectFixId = requestOBJ.Key;
                defectAcceptance.DefectFeedbackId = requestOBJ.DefectFeedbackId;
                mFormData = new MultipartFormDataContent();
                var valueAcceptance = new JavaScriptSerializer().Serialize(defectAcceptance);
                if (!string.IsNullOrEmpty(valueAcceptance)) mFormData.Add(new StringContent(valueAcceptance), "values");
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationSettings.AppSettings["omCRUD"].ToString());
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    using (HttpResponseMessage response = client.PostAsync("api/v1/DefectAcceptance/", mFormData).Result)
                    {
                        if (response.StatusCode != HttpStatusCode.OK)
                        {
                            var err = response.Content.ReadAsStringAsync().Result;
                            return Json(new { status = "error", result = err });
                        }
                    }
                }
            }
            else if (requestOBJ.Status == 22)
            {

                requestOBJ.Status = 30;
            }
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
                using (HttpResponseMessage response = client.PutAsync("api/v1/DefectFix/", mFormData).Result)
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
        [HttpPost, ValidateInput(false)]
        public JsonResult DefectAcceptenceUpdate(DefectAcceptanceOBJ requestOBJ)
        {
            MultipartFormDataContent mFormData = new MultipartFormDataContent();
            HttpFileCollectionBase listFile = HttpContext.Request.Files;
            string token = requestOBJ.token;
            if (string.IsNullOrEmpty(requestOBJ.Note) || requestOBJ.Note == "null")
                requestOBJ.Note = "";
            var values = new JavaScriptSerializer().Serialize(requestOBJ);
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
                    //byte[] binData = b.ReadBytes(fileBase.ContentLength);
                    mFormData.Add(b, nameof(file) + i++.ToString(), fileBase.FileName);
                }
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationSettings.AppSettings["omCRUD"].ToString());//http://localhost:50999/,https://api-pm-cmd.tayho.com.vn/
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                using (HttpResponseMessage response = client.PutAsync("api/v1/DefectAcceptance/", mFormData).Result)
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