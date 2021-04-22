using QuanLyDuAn.Utilities;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
//using Services.Common.Paging;

namespace QuanLyDuAn.Areas.ThongTin.Controllers
{
    public class CauHinhController : Controller
    {
        // GET: ThongTin/CauHinh
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult HangMuc()
        {
            return View();
        }
        public ActionResult PhanQuyenPheDuyet()
        {
            return View();
        }
        public ActionResult QuyTrinh()
        {
            return View();
        }
        //public ActionResult KeHoachDeTrinh()
        //{
        //    return View();
        //}
        //public ActionResult _KeHoachShow()
        //{
        //    return PartialView();
        //}
        [HttpPost, ValidateInput(false)]
        public async Task<JsonResult> postPlanRegist(string requestOBJ, string token)
        {
            string result = "";
            result = await PostPlan(requestOBJ, token, result);
            if (result == "Ok")
                return Json(new { status = "success", result = "Đã lưu thông tin yêu cầu thành công" });
            else
                return Json(new { status = "error", result = result });
        }
        public async Task<string> PostPlan(string requestOBJ, string token, string result)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api-pm-cmd.tayho.com.vn/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var httpContent = new StringContent(requestOBJ, Encoding.UTF8, "application/json");
                //POST Method  
                using (HttpResponseMessage response = client.PostAsync("api/cmd/v1/PlanRegister", httpContent).Result)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        result = "Error";
                    }
                    else
                    {
                        result = "Ok";
                    }
                }

            }
            return result;
        }
        public ActionResult TaiLieu()
        {
            return View();
        }

        public ActionResult CustomTable()
        {
            return View();
        }
        public ActionResult CustomColum()
        {
            return View();
        }
        public ActionResult _CustomTableDetail(int id, string code)
        {

            modelPVCustomTable model = new modelPVCustomTable();
            model.id = id;
            model.code = code;

            return PartialView(model);
        }
        public ActionResult TemplateMail()
        {
            return View();
        }
    }

}