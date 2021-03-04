using QuanLyDuAn.Utilities;
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDuAn.Areas.ThongTin.Controllers
{
    public class DangKyController : Controller
    {
        public const int ActionId = 27;
        // GET: ThongTin/DangKy
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PheDuyet()
        {
            return View();
        }
        public ActionResult _DetailRequestRegist(int Id)
        {
            return PartialView(Id);
        }
        public ActionResult _FormRegister()
        {
            return PartialView();
        }

        public ActionResult _FormRev(int id)
        {
            return PartialView(id);
        }
        [HttpPost, ValidateInput(false)]
        public JsonResult Create(RequestOBJ requestOBJ)
        {

            MultipartFormDataContent mFormData = new MultipartFormDataContent();
            HttpFileCollectionBase listFile = HttpContext.Request.Files;
            string token = requestOBJ.token;
            if (requestOBJ.DocumentTypeId.HasValue) mFormData.Add(new StringContent(((int)requestOBJ.DocumentTypeId).ToString()), nameof(requestOBJ.DocumentTypeId));
            if (requestOBJ.PlanRegisterId.HasValue) mFormData.Add(new StringContent(((int)requestOBJ.PlanRegisterId).ToString()), nameof(requestOBJ.PlanRegisterId));
            if (requestOBJ.ProjectId.HasValue) mFormData.Add(new StringContent(((int)requestOBJ.ProjectId).ToString()), nameof(requestOBJ.ProjectId));
            if (!string.IsNullOrEmpty(requestOBJ.Descriptions)) mFormData.Add(new StringContent(requestOBJ.Descriptions), nameof(requestOBJ.Descriptions) );
            if (!string.IsNullOrEmpty(requestOBJ.Note)) mFormData.Add(new StringContent(requestOBJ.Note), nameof(requestOBJ.Note));
            if (requestOBJ.ParentId.HasValue) mFormData.Add(new StringContent(((int)requestOBJ.ParentId).ToString()), nameof(requestOBJ.ParentId));
            if (!string.IsNullOrEmpty(requestOBJ.Title))mFormData.Add(new StringContent(requestOBJ.Title), nameof(requestOBJ.Title));
            if (requestOBJ.WorkItemId.HasValue) mFormData.Add(new StringContent(((int)requestOBJ.WorkItemId).ToString()), nameof(requestOBJ.WorkItemId).ToString());
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
                    mFormData.Add(b, nameof(file)+i++.ToString(), fileBase.FileName);
                }

            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationSettings.AppSettings["pmCMD"].ToString());//http://localhost:50999/,https://api-pm-cmd.tayho.com.vn/
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                using (HttpResponseMessage response = client.PostAsync("api/cmd/v1/RequestRegist", mFormData).Result)
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
        //public async Task PostRegist(MultipartFormDataContent mFormData, string token)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://api-pm-cmd.tayho.com.vn/");//http://localhost:50999/,https://api-pm-cmd.tayho.com.vn/
        //        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
        //        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        //        using (HttpResponseMessage response = client.PostAsync("api/cmd/v1/RequestRegist", mFormData).Result)
        //        {
        //            if (response.StatusCode != HttpStatusCode.OK)
        //            {
        //                var err = response.Content.ReadAsStringAsync().Result;
        //            }
        //        }
        //    }
        //}
    }
}