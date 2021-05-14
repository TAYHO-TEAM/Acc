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
using System.Web.Script.Serialization;

namespace QuanLyDuAn.Areas.ThongTin.Controllers
{
    public class PhatHanhController : Controller
    {
        // GET: ThongTin/PhatHanh
        public ActionResult Index(int id = 0)
        {
            if (id == 0)
            {

            }
            else
            {

            }
            return View();
        }

        // GET: ThongTin/ListPhatHanh
        public ActionResult ListPhatHanh(int id = 0)
        {
            if (id == 0)
            {

            }
            else
            {

            }
            return View();
        }
        // GET: ThongTin/_PhatHanhDetail
        public ActionResult _PhatHanhCreate(int id = 0)
        {
            if (id == 0)
            {

            }
            else
            {

            }
            return PartialView();
        }
        [HttpPost, ValidateInput(false)]
        public async Task<JsonResult> Create(DocumentReleasedOBJ requestOBJ)
        {
            MultipartFormDataContent mFormData = new MultipartFormDataContent();
            HttpFileCollectionBase listFile = HttpContext.Request.Files;
            string token = requestOBJ.token;
            if (requestOBJ.DocumentTypeId.HasValue) mFormData.Add(new StringContent(((int)requestOBJ.DocumentTypeId).ToString()), nameof(requestOBJ.DocumentTypeId));
            if (requestOBJ.ProjectId.HasValue) mFormData.Add(new StringContent(((int)requestOBJ.ProjectId).ToString()), nameof(requestOBJ.ProjectId));
            if (!string.IsNullOrEmpty(requestOBJ.Description)) mFormData.Add(new StringContent(requestOBJ.Description), nameof(requestOBJ.Description));
            if (!string.IsNullOrEmpty(requestOBJ.TagWorkItem)) mFormData.Add(new StringContent(requestOBJ.TagWorkItem), nameof(requestOBJ.TagWorkItem));
            if (!string.IsNullOrEmpty(requestOBJ.Title)) mFormData.Add(new StringContent(requestOBJ.Title), nameof(requestOBJ.Title));
            if (!string.IsNullOrEmpty(requestOBJ.Location )) mFormData.Add(new StringContent(requestOBJ.Location), nameof(requestOBJ.Location));
            if (requestOBJ.Calendar.HasValue) mFormData.Add(new StringContent(requestOBJ.Calendar.Value.ToString("yyyy-MM-dd HH:mm:ss")), nameof(requestOBJ.Calendar));
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
                    mFormData.Add(b, nameof(file) + i++.ToString(), fileBase.FileName);
                }

            }
            int id = 0;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationSettings.AppSettings["pmCMD"].ToString()); //http://localhost:50999/,https://api-pm-cmd.tayho.com.vn/
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                
                using (HttpResponseMessage response =  client.PostAsync("api/cmd/v1/DocumentReleased", mFormData).Result)
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
            return Json(new { status = "success", result = "Tập tin đã được tải lên thành công. Vui lòng đóng cửa sổ này để quay lại giao diện đệ trình" , id= id});
        }
      

    }
}