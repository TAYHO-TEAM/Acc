using Newtonsoft.Json;
using QuanLyDuAn.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace QuanLyDuAn.Areas.NganSach.Controllers
{
    public class GiaTriController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> Imports(CongViecsOBJ requestOBJ)
        {
            try
            {
                List<CongViecOBJ> obj = new List<CongViecOBJ>();
                JsonConvert.PopulateObject(requestOBJ.congViecOBJs, obj);

                if (obj.Count() > 0)
                {
                    foreach (var item in obj)
                    {
                        CongViecModel model = new CongViecModel();
                        model.NhomCongViecId = item.nhomCongViecId;
                        model.Nhom = item.nhom;
                        model.TenCongViec = item.tenCongViec;
                        model.DienGiai = item.dienGiai;
                        model.DonViTinh = item.dvt;

                        using (var client = new HttpClient())
                        {
                            client.BaseAddress = new Uri(ConfigurationSettings.AppSettings["pmCMD"].ToString());
                            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + requestOBJ.token);
                            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", requestOBJ.token);

                            using (HttpResponseMessage response = client.PostAsJsonAsync("api/cmd/v1/NS_CongViec", model).Result)
                            {
                                if (response.StatusCode != HttpStatusCode.OK)
                                {
                                    var err = response.Content.ReadAsStringAsync().Result;
                                    return Json(new { status = "error", result = err });
                                }
                                else
                                {
                                    var json = new JavaScriptSerializer().Deserialize<dynamic>(response.Content.ReadAsStringAsync().Result.ToString());
                                    var id = Convert.ToInt32(json["result"]["id"].ToString());

                                    CongViecDetailModel detailModel = new CongViecDetailModel();
                                    detailModel.CongViecId = id;
                                    detailModel.GiaiDoanId = item.giaiDoanId;
                                    detailModel.DonGia = item.donGia;
                                    detailModel.KhoiLuong = item.khoiLuong;

                                    using (HttpResponseMessage response2 = client.PostAsJsonAsync("api/cmd/v1/NS_CongViecDetail", detailModel).Result)
                                    {
                                        if (response.StatusCode != HttpStatusCode.OK)
                                        {
                                            var err = response.Content.ReadAsStringAsync().Result;
                                            return Json(new { status = "error", result = err });
                                        } 
                                    }
                                }
                            }
                        }
                    }
                    return Json(new { status = "success", result = "Import dữ liệu thành công." });
                }
                else return Json(new { status = "error", result = "Import dữ liệu không thành công, Vui lòng kiểm tra lại." });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", result = "Có lỗi xảy ra." + e.Message });
            }
        }
    }
}