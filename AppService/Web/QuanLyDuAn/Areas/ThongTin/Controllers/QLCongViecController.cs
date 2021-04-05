using Newtonsoft.Json;
using QuanLyDuAn.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace QuanLyDuAn.Areas.ThongTin.Controllers
{
    public class QLCongViecController : Controller
    {
        // GET: ThongTin/QLCongViec
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _CongViecDetail()
        {
            return PartialView();
        }
        public ActionResult _PhanHoi(int id)
        {
            return PartialView(id);
        }
        [HttpPost, ValidateInput(false)]
        public async Task<JsonResult> _PhanHoiCreate(ConversationOBJ requestOBJ)
        {
            string token = requestOBJ.token;
            int id = 0;
            requestOBJ.OwnerTable = "PlanMaster";
            MultipartFormDataContent mFormData = new MultipartFormDataContent();
            HttpFileCollectionBase listFile = HttpContext.Request.Files;
            var data = JsonConvert.SerializeObject(requestOBJ);
            var httpContent = new StringContent(data, Encoding.UTF8, "application/json");
           
          
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationSettings.AppSettings["pmCMD"].ToString()); //http://localhost:50999/,https://api-pm-cmd.tayho.com.vn/
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                using (HttpResponseMessage response = client.PostAsync("api/cmd/v1/Conversation", httpContent).Result)
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
                if(id >0 )
                {
                    if (listFile.Count > 0)
                    {
                        FilesAttachmentOBJ filesAttachment = new FilesAttachmentOBJ();
                        filesAttachment.ownerByTable = "Conversation";
                        filesAttachment.ownerById = id;
                        filesAttachment.url = @"/Conversation/PlanMaster";
                        MultipartFormDataContent mFormDataFile = new MultipartFormDataContent();
                        int i = 1;
                        if (filesAttachment.ownerById.HasValue) mFormDataFile.Add(new StringContent(((int)filesAttachment.ownerById).ToString()), nameof(filesAttachment.ownerById));
                        if (!string.IsNullOrEmpty(filesAttachment.ownerByTable)) mFormDataFile.Add(new StringContent(filesAttachment.ownerByTable), nameof(filesAttachment.ownerByTable));
                        if (!string.IsNullOrEmpty(requestOBJ.Content)) mFormDataFile.Add(new StringContent(requestOBJ.Content), nameof(requestOBJ.Content));
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
                            mFormDataFile.Add(b, nameof(file) + i++.ToString(), fileBase.FileName);
                        }
                        using (HttpResponseMessage response = client.PostAsync("api/cmd/v1/FilesAttachment/UploadFile", mFormDataFile).Result)
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
                }    
            }
            return Json(new { status = "success", result = "Đã lưu thông tin yêu cầu thành công" });
        }
        [HttpPost, ValidateInput(false)]
        public async Task<JsonResult> Create(PlanMaster requestOBJ)
        {

            MultipartFormDataContent mFormData = new MultipartFormDataContent();
            HttpFileCollectionBase listFile = HttpContext.Request.Files;
            string token = requestOBJ.token;

            foreach (PropertyInfo propertyInfo in requestOBJ.GetType().GetProperties())
            {
                string name = propertyInfo.Name.ToString();
                string type = propertyInfo.PropertyType.Name.ToString();
                try
                {
                    var value = propertyInfo.GetValue(requestOBJ);
                    if ((type != "String" || type != "string") && type != "DateTime")
                    {
                        if (value != null)
                        {
                            mFormData.Add(new StringContent(value.ToString()), name.ToString());
                        }
                    }
                    else if (type == "DateTime")
                    {
                        if (value.ToString() != "01/01/0001 12:00:00 AM")
                        {
                            if (value.ToString() != "01/01/0001 12:00:00 AM")
                            {
                                DateTime getdate = DateTime.ParseExact(value.ToString(), "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                                string convertDate = getdate.ToString("yyyy-MM-dd HH:mm:ss");
                                mFormData.Add(new StringContent(convertDate), name.ToString());
                            }
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(value.ToString()))
                        {
                            mFormData.Add(new StringContent(value.ToString()), name);
                        }
                    }
                    mFormData.Add(new StringContent("false"), "IsVisible");
                }
                catch (Exception ex)
                {

                }
            }
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
                client.BaseAddress = new Uri(ConfigurationSettings.AppSettings["pmCMD"].ToString()); //http://localhost:50999/,https://api-pm-cmd.tayho.com.vn/
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                using (HttpResponseMessage response = client.PostAsync("api/cmd/v1/PlanMaster/FormPlanMaster", mFormData).Result)
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