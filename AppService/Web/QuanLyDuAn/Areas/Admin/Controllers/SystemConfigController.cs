using Newtonsoft.Json;
using QuanLyDuAn.Utilities;
using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDuAn.Areas.Admin.Controllers
{
    public class SystemConfigController : Controller
    {
        // GET: Admin/SystemConfig
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Actions()
        {
            return View();
        }
        public ActionResult Accounts()
        {
            return View();
        }
        public ActionResult Functions()
        {
            return View();
        }
        public ActionResult Groups()
        {
            return View();
        }
        public ActionResult GroupAccount()
        {
            return View();
        }
        public ActionResult GroupActionPermistion()
        {
            return View();
        }
        public ActionResult GroupFunction()
        {
            return View();
        }
        public ActionResult LogEvent()
        {
            return View();
        }
        public ActionResult UserInfo()
        {
            return View();
        }
        public ActionResult _ContractorInfoAdd()
        {
            return PartialView();
        }
        [HttpPost, ValidateInput(false)]
        public async Task<JsonResult> _ContractorInfoCreate(ContractorInfoOBJ requestOBJ)
        {
            MultipartFormDataContent mFormData = new MultipartFormDataContent();
            HttpFileCollectionBase listFile = HttpContext.Request.Files;
            string token = requestOBJ.token;
            if (!string.IsNullOrEmpty(requestOBJ.Address)) mFormData.Add(new StringContent(requestOBJ.Address), nameof(requestOBJ.Address));
            if (!string.IsNullOrEmpty(requestOBJ.BusinessAreas)) mFormData.Add(new StringContent(requestOBJ.BusinessAreas), nameof(requestOBJ.BusinessAreas));
            if (!string.IsNullOrEmpty(requestOBJ.City)) mFormData.Add(new StringContent(requestOBJ.City), nameof(requestOBJ.City));
            if (!string.IsNullOrEmpty(requestOBJ.Code)) mFormData.Add(new StringContent(requestOBJ.Code), nameof(requestOBJ.Code));
            if (!string.IsNullOrEmpty(requestOBJ.Country)) mFormData.Add(new StringContent(requestOBJ.Country), nameof(requestOBJ.Country));
            if (!string.IsNullOrEmpty(requestOBJ.Descriptions)) mFormData.Add(new StringContent(requestOBJ.Descriptions), nameof(requestOBJ.Descriptions));
            if (!string.IsNullOrEmpty(requestOBJ.District)) mFormData.Add(new StringContent(requestOBJ.District), nameof(requestOBJ.District));
            if (!string.IsNullOrEmpty(requestOBJ.Email)) mFormData.Add(new StringContent(requestOBJ.Email), nameof(requestOBJ.Email));
            if (!string.IsNullOrEmpty(requestOBJ.Name)) mFormData.Add(new StringContent(requestOBJ.Name), nameof(requestOBJ.Name));
            if (!string.IsNullOrEmpty(requestOBJ.Phone)) mFormData.Add(new StringContent(requestOBJ.Phone), nameof(requestOBJ.Phone));
            var myContent = JsonConvert.SerializeObject(requestOBJ);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //if (listFile.Count > 0)
            //{
            //    int i = 1;
            //    foreach (string file in listFile)
            //    {
            //        HttpPostedFileBase fileBase = Request.Files[file];
            //        byte[] fileData = null;
            //        using (var binaryReader = new BinaryReader(fileBase.InputStream))
            //        {
            //            fileData = binaryReader.ReadBytes(fileBase.ContentLength);
            //        }
            //        ByteArrayContent b = new ByteArrayContent(fileData);
            //        b.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
            //        //byte[] binData = b.ReadBytes(fileBase.ContentLength);
            //        mFormData.Add(b, nameof(file) + i++.ToString(), fileBase.FileName);
            //    }

            //}
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationSettings.AppSettings["pmCMD"].ToString()); //http://localhost:50999/,https://api-pm-cmd.tayho.com.vn/
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                using (HttpResponseMessage response = client.PostAsync("api/cmd/v1/ContractorInfo", byteContent).Result)
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

        public ActionResult SysJob()
        {
            return View();
        }
        public ActionResult _SysJobCreate()
        {
            return View();
        }
        public ActionResult _SysJobAdd()
        {
            return PartialView();
        }
    }
}