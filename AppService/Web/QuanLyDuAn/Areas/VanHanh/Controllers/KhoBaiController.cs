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
    public class KhoBaiController : Controller
    {
        // GET: VanHanh/Kho
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult XuatNhap()
        {
            return View();
        }
        public ActionResult DanhMucHH()
        {
            return View();
        }
        public ActionResult _XuatNhapCreate(int id,bool isIn )
        {
            var tupleModel = new Tuple<int, bool>(id, isIn);
            return PartialView(tupleModel);
        }
        public ActionResult _NhatKyKho(int id)
        {
            return PartialView(id);
        }
        [HttpPost, ValidateInput(false)]
        public JsonResult XuatNhapCreate(WarehouseGoodsLogOBJ requestOBJ)
        {
            MultipartFormDataContent mFormData = new MultipartFormDataContent();
            HttpFileCollectionBase listFile = HttpContext.Request.Files;
            string token = requestOBJ.token;
            requestOBJ.Key = null;
            if(requestOBJ.IsInOrOut == true)
            {
                requestOBJ.CheckInDate = DateTime.Now;
            }   
            else
            {
                requestOBJ.CheckOutDate = DateTime.Now;
                requestOBJ.Quantity = requestOBJ.Quantity * (-1);
            }    
            

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
                using (HttpResponseMessage response = client.PostAsync("api/v1/WarehouseGoodsLog/", mFormData).Result)
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