using System;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using RadPdf.Web.UI;
using System.IO;
using RadPdf.Lite;

namespace QuanLyDuAn.Areas.PDFEditer.Controllers
{
    public class HomeController : Controller
    {
        // GET: PDFEditer/Home
        public ActionResult Index()
        {
     
            byte[] pdfData = System.IO.File.ReadAllBytes(@"C:/Users/CongTrien/Desktop/38mb.pdf");

            // Create RAD PDF control
            PdfWebControlLite pdfWebControlLite1 = new PdfWebControlLite();

            // Create settings
            PdfLiteSettings settings = new PdfLiteSettings();

            // Setup pdfWebControl1 with any properties which must be called before CreateDocument (optional)
            // e.g. settings.RenderDpi = 144;

            // Create document from PDF data
            pdfWebControlLite1.CreateDocument("Document Name", pdfData, settings);

            // Put control in ViewBag
            ViewBag.PdfWebControlLite1 = pdfWebControlLite1;

            return View();
        }
    }
}