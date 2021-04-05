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
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult _PhanHoiCreate()
        {
            return PartialView();
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
                catch(Exception ex)
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