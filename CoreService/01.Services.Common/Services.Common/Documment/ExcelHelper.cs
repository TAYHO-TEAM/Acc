using OfficeOpenXml;
using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;


namespace Services.Common.Documment
{
    public static class ExcelHelper
    {
        public static async Task<MemoryStream> ExportExcel(DataTable dt, string fileName = "")
        {
            await Task.Yield();
            string excelName = fileName + $"-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";
            var stream = new MemoryStream();
            try
            {
                using (var package = new ExcelPackage(stream))
                {
                    var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                    workSheet.Cells.LoadFromDataTable(dt, true);
                    package.Save();
                }
                stream.Position = 0;
                return stream;
            }
            catch (Exception ex)
            {
                return new MemoryStream();
            }
        }
    }
}
