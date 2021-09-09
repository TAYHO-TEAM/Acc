using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Text;
using OfficeOpenXml.Style;
using System.IO;
using System.Data;
using Newtonsoft.Json;
using System.Reflection;
using System.Linq;
using System.Drawing;
using OfficeOpenXml.Drawing;

namespace Services.Common.Utilities
{
    public class EpplusHelper
    {
        /// <summary>
        /// Generate excel
        /// </summary>
        /// <param name="dtSource">Data source</param>
        /// <param name="title">title (Sheet name)</param>
        /// <param name="showTitle">whether to show</param>
        /// <returns></returns>
        public static MemoryStream Export(DataTable dtSource, string title, bool showTitle = true)
        {
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets.Add(title);

                int maxColumnCount = dtSource.Columns.Count;
                int curRowIndex = 0;

                if (showTitle == true)
                {
                    curRowIndex++;
                    //theme
                    workSheet.Cells[curRowIndex, 1, 1, maxColumnCount].Merge = true;
                    workSheet.Cells[curRowIndex, 1].Value = title;
                    var headerStyle = workSheet.Workbook.Styles.CreateNamedStyle("headerStyle");
                    headerStyle.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    headerStyle.Style.Font.Bold = true;
                    headerStyle.Style.Font.Size = 20;
                    workSheet.Cells[curRowIndex, 1].StyleName = "headerStyle";

                    curRowIndex++;
                    //Export time bar
                    workSheet.Cells[curRowIndex, 1, 2, maxColumnCount].Merge = true;
                    workSheet.Cells[curRowIndex, 1].Value = "Export time:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                    workSheet.Cells[curRowIndex, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                }

                curRowIndex++;
                var titleStyle = workSheet.Workbook.Styles.CreateNamedStyle("titleStyle");
                titleStyle.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                titleStyle.Style.Font.Bold = true;
                //title
                for (var i = 0; i < maxColumnCount; i++)
                {
                    DataColumn column = dtSource.Columns[i];
                    workSheet.Cells[curRowIndex, i + 1].Value = column.ColumnName;
                    workSheet.Cells[curRowIndex, i + 1].StyleName = "titleStyle";
                }
                workSheet.View.FreezePanes(curRowIndex, 1);//Freeze the title row

                //content
                for (var i = 0; i < dtSource.Rows.Count; i++)
                {
                    curRowIndex++;
                    for (var j = 0; j < maxColumnCount; j++)
                    {
                        DataColumn column = dtSource.Columns[j];
                        var row = dtSource.Rows[i];
                        object value = row[column];
                        var cell = workSheet.Cells[curRowIndex, j + 1];
                        var pType = column.DataType;
                        pType = pType.Name == "Nullable`1" ? Nullable.GetUnderlyingType(pType) : pType;
                        if (pType == typeof(DateTime))
                        {
                            cell.Style.Numberformat.Format = "yyyy-MM-dd hh:mm";
                            cell.Value = Convert.ToDateTime(value);
                        }
                        else if (pType == typeof(int))
                        {
                            cell.Value = Convert.ToInt32(value);
                        }
                        else if (pType == typeof(double) || pType == typeof(decimal))
                        {
                            cell.Value = Convert.ToDouble(value);
                        }
                        else
                        {
                            cell.Value = value == null ? "" : value.ToString();
                        }
                        workSheet.Cells[curRowIndex, j + 1].Value = row[column].ToString();
                    }
                }
                workSheet.Cells[workSheet.Dimension.Address].Style.Font.Name = "Song Ti";
                workSheet.Cells[workSheet.Dimension.Address].AutoFitColumns();//Auto fill
                for (var i = 1; i <= workSheet.Dimension.End.Column; i++) { workSheet.Column(i).Width = workSheet.Column(i).Width + 2; }//Add 2 to the filling
                MemoryStream ms = new MemoryStream(package.GetAsByteArray());
                return ms;
            }
        }
        /// <summary>
        /// Generate excel
        /// </summary>
        ///  /// <param name="template">template</param>
        /// <param name="dtSource">Data source</param>
        /// <param name="title">title (Sheet name)</param>
        /// <param name="showTitle">whether to show</param>
        /// <param name="curColIndex">Current Colum Index </param>
        /// <param name="curRowIndex">Current Rown Index</param>
        /// <returns></returns>
        public static MemoryStream Export(DataTable dtSource, string title, bool showTitle = false, string template = "", int curColIndex = 1, int curRowIndex = 0, bool isHeader = false)
        {
            FileInfo templateFile = null;
            try
            {
                templateFile = new FileInfo(template);
            }
            catch
            {
                templateFile = null;
            }

            using (ExcelPackage package = (templateFile == null ? new ExcelPackage() : new ExcelPackage(templateFile)))
            {
                ExcelWorksheet workSheet = null;
                try
                {
                    if (templateFile == null)
                        workSheet = package.Workbook.Worksheets.Add(title);
                    else
                        workSheet = package.Workbook.Worksheets[0];
                }
                catch
                {
                    workSheet = package.Workbook.Worksheets.Add("sheet1");
                }

                int maxColumnCount = dtSource.Columns.Count;

                if (showTitle)
                {
                    //theme
                    workSheet.Cells[curRowIndex, curColIndex, curRowIndex, maxColumnCount].Merge = true;
                    workSheet.Cells[curRowIndex, curColIndex].Value = title;
                    var headerStyle = workSheet.Workbook.Styles.CreateNamedStyle("headerStyle");
                    headerStyle.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    headerStyle.Style.Font.Bold = true;
                    headerStyle.Style.Font.Size = 20;
                    workSheet.Cells[curRowIndex, curColIndex].StyleName = "headerStyle";
                    curRowIndex++;
                    //Export time bar
                    workSheet.Cells[curRowIndex, curColIndex, curRowIndex, maxColumnCount].Merge = true;
                    workSheet.Cells[curRowIndex, curColIndex].Value = "Export time:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                    workSheet.Cells[curRowIndex, curColIndex].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    curRowIndex++;
                }
                if (isHeader)
                {

                    var titleStyle = workSheet.Workbook.Styles.CreateNamedStyle("titleStyle");
                    titleStyle.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    titleStyle.Style.Font.Bold = true;
                    //title
                    for (var i = 0; i < maxColumnCount; i++)
                    {
                        DataColumn column = dtSource.Columns[i];
                        workSheet.Cells[curRowIndex, i + curColIndex].Value = column.ColumnName;
                        workSheet.Cells[curRowIndex, i + curColIndex].StyleName = "titleStyle";
                    }
                    workSheet.View.FreezePanes(curRowIndex, curColIndex);//Freeze the title row
                    curRowIndex++;
                }

                //content
                for (var i = 0; i < dtSource.Rows.Count; i++)
                {
                    for (var j = 0; j < maxColumnCount; j++)
                    {
                        DataColumn column = dtSource.Columns[j];
                        var row = dtSource.Rows[i];
                        object value = row[column];
                        var cell = workSheet.Cells[curRowIndex, j + curColIndex];
                        var pType = column.DataType;
                        pType = pType.Name == "Nullable`1" ? Nullable.GetUnderlyingType(pType) : pType;
                        if (pType == typeof(DateTime))
                        {
                            cell.Style.Numberformat.Format = "yyyy-MM-dd hh:mm";
                            if (value != null && value.ToString() != "") cell.Value = Convert.ToDateTime(value);
                        }
                        else if (pType == typeof(int))
                        {
                            cell.Value = Convert.ToInt32(value ?? 0);
                        }
                        else if (pType == typeof(double) || pType == typeof(decimal))
                        {
                            cell.Value = Convert.ToDouble(value ?? 0);
                        }
                        else
                        {
                            cell.Value = value == null ? "" : value.ToString();
                        }
                        //workSheet.Cells[curRowIndex, j + curColIndex].Value = row[column].ToString();
                    }
                    curRowIndex++;
                }
                workSheet.Cells[workSheet.Dimension.Address].Style.Font.Name = "Song Ti";
                workSheet.Cells[workSheet.Dimension.Address].AutoFitColumns();//Auto fill
                for (var i = curColIndex; i <= workSheet.Dimension.End.Column; i++) { workSheet.Column(i).Width = workSheet.Column(i).Width + 2; }//Add 2 to the filling
                MemoryStream ms = new MemoryStream(package.GetAsByteArray());
                return ms;
            }
        }
        /// <summary>
        /// Generate excel
        /// </summary>
        ///  /// <param name="template">template</param>
        /// <param name="dtSource">Data source</param>
        /// <param name="title">title (Sheet name)</param>
        /// <param name="showTitle">whether to show</param>
        /// <param name="curColIndex">Current Colum Index </param>
        /// <param name="curRowIndex">Current Rown Index</param>
        /// <param name="isMergeCell">Merge </param>
        /// <param name="isGenImage"> isGenImage </param>
        /// <param name="colImage">colImage </param>
        /// <returns></returns>
        public static MemoryStream Export(DataTable dtSource, string title, GenImage genImage, bool showTitle = false, string template = "", int curColIndex = 1, int curRowIndex = 0, bool isHeader = false, bool isMergeCell = false)
        {
            FileInfo templateFile = null;
            try
            {
                templateFile = new FileInfo(template);
            }
            catch
            {
                templateFile = null;
            }

            using (ExcelPackage package = (templateFile == null ? new ExcelPackage() : new ExcelPackage(templateFile)))
            {
                ExcelWorksheet workSheet = null;
                try
                {
                    if (templateFile == null)
                        workSheet = package.Workbook.Worksheets.Add(title);
                    else
                        workSheet = package.Workbook.Worksheets[0];
                }
                catch
                {
                    workSheet = package.Workbook.Worksheets.Add("sheet1");
                }
                int maxColumnCount = dtSource.Columns.Count;
                /// show title
                if (showTitle)
                {
                    //theme
                    workSheet.Cells[curRowIndex, curColIndex, curRowIndex, maxColumnCount].Merge = true;
                    workSheet.Cells[curRowIndex, curColIndex].Value = title;
                    var headerStyle = workSheet.Workbook.Styles.CreateNamedStyle("headerStyle");
                    headerStyle.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    headerStyle.Style.Font.Bold = true;
                    headerStyle.Style.Font.Size = 20;
                    workSheet.Cells[curRowIndex, curColIndex].StyleName = "headerStyle";
                    curRowIndex++;
                    //Export time bar
                    workSheet.Cells[curRowIndex, curColIndex, curRowIndex, maxColumnCount].Merge = true;
                    workSheet.Cells[curRowIndex, curColIndex].Value = "Export time:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                    workSheet.Cells[curRowIndex, curColIndex].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    curRowIndex++;
                }
                /// show headert
                if (isHeader)
                {
                    var titleStyle = workSheet.Workbook.Styles.CreateNamedStyle("titleStyle");
                    titleStyle.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    titleStyle.Style.Font.Bold = true;
                    //title
                    for (var i = 0; i < maxColumnCount; i++)
                    {
                        DataColumn column = dtSource.Columns[i];
                        workSheet.Cells[curRowIndex, i + curColIndex].Value = column.ColumnName;
                        workSheet.Cells[curRowIndex, i + curColIndex].StyleName = "titleStyle";
                    }

                    workSheet.View.FreezePanes(curRowIndex, curColIndex);//Freeze the title row
                    curRowIndex++;
                }
                //content
                for (var i = 0; i < dtSource.Rows.Count; i++)
                {
                    for (var j = 0; j < maxColumnCount; j++)
                    {
                        DataColumn column = dtSource.Columns[j];
                        var row = dtSource.Rows[i];
                        object value = row[column];
                        var cell = workSheet.Cells[curRowIndex, j + curColIndex];
                        var pType = column.DataType;
                        pType = pType.Name == "Nullable`1" ? Nullable.GetUnderlyingType(pType) : pType;
                        if (pType == typeof(DateTime))
                        {
                            cell.Style.Numberformat.Format = "yyyy-MM-dd hh:mm";
                            cell.AutoFitColumns();
                            if (value != null && value.ToString() != "") cell.Value = Convert.ToDateTime(value);
                            workSheet.Cells[curRowIndex, j + curColIndex].Value = row[column].ToString();
                        }
                        else if (pType == typeof(int))
                        {
                            cell.Value = Convert.ToInt32(value ?? 0);
                            cell.AutoFitColumns();
                            workSheet.Cells[curRowIndex, j + curColIndex].Value = row[column].ToString();
                        }
                        else if (pType == typeof(double) || pType == typeof(decimal))
                        {
                            cell.Value = Convert.ToDouble(value ?? 0);
                            cell.AutoFitColumns();
                            workSheet.Cells[curRowIndex, j + curColIndex].Value = row[column].ToString();
                        }
                        else
                        {
                            if (!(value == null))
                            {
                                if (genImage.IsGenIamge)
                                {
                                    if (genImage.ColImage.Contains(column.ColumnName))
                                    {
                                        try
                                        {
                                            Image img = Image.FromFile(value.ToString());
                                            if (img != null)
                                            {
                                                float hpw = (float)img.Size.Height / (float)img.Size.Width;
                                                if (genImage.IsAutoCrop)
                                                {
                                                    if (genImage.Width == 0)
                                                        genImage.Width = genImage.GetWidth(genImage.Height, hpw);
                                                    if (genImage.Height == 0)
                                                        genImage.Height = genImage.GetHeight(genImage.Width, hpw);
                                                }


                                                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                                                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                                                ExcelPicture pic = workSheet.Drawings.AddPicture((column.ColumnName + curRowIndex.ToString()), img);

                                                pic.SetPosition(curRowIndex - 1, 0, j + curColIndex - 1, 0);
                                                pic.SetSize((int)Math.Ceiling(genImage.Width), (int)Math.Ceiling(genImage.Height));
                                                workSheet.Column(j + curColIndex).Width = EpplusHelper.Pixel2ExcelW((int)(genImage.Width));
                                                workSheet.Row(curRowIndex).Height = EpplusHelper.Pixel2ExcelH((int)(genImage.Height));
                                            }
                                        }
                                        catch
                                        {

                                        }
                                    }
                                    else
                                    {
                                        cell.Value = value == null ? "" : value.ToString();
                                        workSheet.Cells[curRowIndex, j + curColIndex].Value = row[column].ToString();
                                    }
                                }
                                //else if (isMergeCell)
                                //{
                                //    if (value.ToString() == workSheet.Cells[curRowIndex - 1, (j + curColIndex)].Value.ToString())
                                //    {
                                //        int pointCStart = workSheet.Cells[curRowIndex - 1, (j + curColIndex)].Start.Column;
                                //        int pointCEnd = workSheet.Cells[curRowIndex - 1, (j + curColIndex)].End.Column;
                                //        int pointRStart = workSheet.Cells[curRowIndex - 1, (j + curColIndex)].Start.Row;
                                //        int pointREnd = workSheet.Cells[curRowIndex - 1, (j + curColIndex)].End.Row;
                                //        string contentMerge = value.ToString();
                                //        if (pointRStart < pointREnd)
                                //        {
                                //            contentMerge = workSheet.Cells[pointRStart, pointCStart, pointREnd, pointCEnd].First().Value.ToString();
                                //            workSheet.Cells[pointRStart, pointCStart, pointREnd, pointCEnd].Merge = false;
                                //        }
                                //        workSheet.Cells[pointRStart, pointCStart, curRowIndex, pointCEnd].Merge = true;
                                //        workSheet.Cells[pointRStart, pointCStart, curRowIndex, pointCEnd].Value = contentMerge;
                                //    }
                                //}
                                else
                                {
                                    cell.Value = value.ToString();
                                    workSheet.Cells[curRowIndex, j + curColIndex].Value = row[column].ToString();
                                }
                            }
                            else
                            {
                                cell.Value = value == null ? "" : value.ToString();
                                workSheet.Cells[curRowIndex, j + curColIndex].Value = row[column].ToString();
                            }
                        }
                    }
                    curRowIndex++;
                }
                workSheet.Cells[workSheet.Dimension.Address].Style.Font.Name = "Song Ti";
                //workSheet.Cells[workSheet.Dimension.Address].AutoFitColumns();
                for (var i = curColIndex; i <= workSheet.Dimension.End.Column; i++) { workSheet.Column(i).Width = workSheet.Column(i).Width + 2; }//Add 2 to the filling
                MemoryStream ms = new MemoryStream(package.GetAsByteArray());
                return ms;
            }
        }
        /// <summary>
        /// Generate excel
        /// </summary>
        ///  /// <param name="tableProperties">template</param>
        /// <param name="genImage">Data source</param>
        /// <param name="template">title (Sheet name)</param>
        /// <returns></returns>
        public static MemoryStream Export(IList<TableProperty> tableProperties, string template = "")
        {
            FileInfo templateFile = null;
            try
            {
                templateFile = new FileInfo(template);
            }
            catch
            {
                templateFile = null;
            }

            using (ExcelPackage package = (templateFile == null ? new ExcelPackage() : new ExcelPackage(templateFile)))
            {
                foreach (var tableProperty in tableProperties)
                {
                    Export(tableProperty, package);
                }
                MemoryStream ms = new MemoryStream(package.GetAsByteArray());
                return ms;
            }
        }
        /// <summary>
        /// Generate excel
        /// </summary>
        ///  /// <param name="template">template</param>
        /// <param name="dtSource">Data source</param>
        /// <param name="tableProp">tableProp</param>
        /// <param name="showTitle">whether to show</param>
        /// <param name="curColIndex">Current Colum Index </param>
        /// <param name="curRowIndex">Current Rown Index</param>
        /// <returns></returns>
        public static void Export(TableProperty tableProp, ExcelPackage package)
        {
            DataTable dtSource = new DataTable();
            int startR = 0;
            int endR = 0;
            int startC = 0;
            int endC = 0;
            int curColIndex = 0;
            int curRowIndex = 0;
            bool isShowTitle = true;
            bool isHeader = true;
            bool isFreezeHeader = true;
            string title = "";
            int positionSheet = 0;
            string font = "Song Ti";
            try
            {
                dtSource = tableProp.DataSource;
                curColIndex = tableProp.BeginCol ?? 1;
                curRowIndex = tableProp.BeginRow ?? 0;
                isShowTitle = tableProp.IsShowTitle ?? false;
                isHeader = tableProp.IsHeader ?? false;
                title = tableProp.Title;
                positionSheet = tableProp.SheetIndex ?? 0;
                //font = tableProp.FontStyleId;
            }
            catch
            {
            }
            ExcelWorksheet workSheet = null;
            if (IssetSheetName(package, tableProp.SheetName))
            {
                workSheet = package.Workbook.Worksheets[tableProp.SheetName];
            }
            else if (IssetSheet(package, positionSheet))
            {
                workSheet = package.Workbook.Worksheets[positionSheet - 1];
            }
            else
            {
                workSheet = package.Workbook.Worksheets.Add(string.IsNullOrEmpty(tableProp.SheetName) ? "Sheet" + tableProp.TableIndex : tableProp.SheetName);
            }
            int maxColumnCount = dtSource.Columns.Count;
            if (curColIndex < 0)
            {
                curColIndex = workSheet.Dimension.End.Column - curColIndex;
            }
            if (curRowIndex < 0)
            {
                curRowIndex = workSheet.Dimension.End.Row - curRowIndex;
            }
            /// show title
            if (isShowTitle)
            {
                //theme
                workSheet.Cells[curRowIndex, curColIndex, curRowIndex, maxColumnCount].Merge = true;
                workSheet.Cells[curRowIndex, curColIndex].Value = title;
                var headerStyle = workSheet.Workbook.Styles.CreateNamedStyle("headerStyle");
                headerStyle.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                if (tableProp.FontStyle == "0")
                {
                    headerStyle.Style.Font.Bold = true;
                }
                else if (tableProp.FontStyle == "1")
                {
                    headerStyle.Style.Font.Italic = true;
                }
                else if (tableProp.FontStyle == "2")
                {
                    headerStyle.Style.Font.Strike = true;
                }
                else if (tableProp.FontStyle == "3")
                {
                    headerStyle.Style.Font.UnderLine = true;
                }
                headerStyle.Style.Font.Size = tableProp.HeaderFontSize ?? 20; 
                headerStyle.Style.Font.Color.SetColor(Color.Black);
                workSheet.Cells[curRowIndex, curColIndex].StyleName = "headerStyle";
                curRowIndex++;
                //Export time bar
                workSheet.Cells[curRowIndex, curColIndex, curRowIndex, maxColumnCount].Merge = true;
                workSheet.Cells[curRowIndex, curColIndex].Value = "Export time:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                workSheet.Cells[curRowIndex, curColIndex].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                curRowIndex++;
            }
            /// show header
            if (isHeader)
            {
                var titleStyle = workSheet.Workbook.Styles.CreateNamedStyle("titleStyle");
                titleStyle.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                titleStyle.Style.Font.Bold = true;
                //title
                for (var i = 0; i < maxColumnCount; i++)
                {
                    DataColumn column = dtSource.Columns[i];
                    workSheet.Cells[curRowIndex, i + curColIndex].Value = column.ColumnName;
                    workSheet.Cells[curRowIndex, i + curColIndex].StyleName = "titleStyle";
                }
                if (isFreezeHeader)
                {
                    workSheet.View.FreezePanes(curRowIndex, curColIndex);//Freeze the title row
                }
                curRowIndex++;
            }
            //content
            //set start end 
            startR = curRowIndex;
            startC = curColIndex;
            if (dtSource.Rows.Count > 0)
                endR = startR + dtSource.Rows.Count -1;
            if (maxColumnCount > 0)
                endC = startC + maxColumnCount -1;

            for (var i = 0; i < dtSource.Rows.Count; i++)
            {
                for (var j = 0; j < maxColumnCount; j++)
                {
                    DataColumn column = dtSource.Columns[j];
                    var row = dtSource.Rows[i];
                    object value = row[column];
                    var cell = workSheet.Cells[curRowIndex, j + curColIndex];
                    var pType = column.DataType;
                    pType = pType.Name == "Nullable`1" ? Nullable.GetUnderlyingType(pType) : pType;
                    if (pType == typeof(DateTime))
                    {
                        cell.Style.Numberformat.Format = "yyyy-MM-dd hh:mm";
                        //cell.AutoFitColumns();
                        if (value != null && value.ToString() != "") cell.Value = Convert.ToDateTime(value);
                        workSheet.Cells[curRowIndex, j + curColIndex].Value = row[column].ToString();
                    }
                    else if (pType == typeof(int))
                    {
                        cell.Value = Convert.ToInt32(value ?? 0);
                        //cell.AutoFitColumns();
                        workSheet.Cells[curRowIndex, j + curColIndex].Value = row[column].ToString();
                    }
                    else if (pType == typeof(double) || pType == typeof(decimal))
                    {
                        cell.Value = Convert.ToDouble(value ?? 0);
                        //cell.AutoFitColumns();
                        workSheet.Cells[curRowIndex, j + curColIndex].Value = row[column].ToString();
                    }
                    else
                    {
                        if (!(value == null))
                        {
                            if (tableProp.IsGenIamge ?? false)
                            {
                                if (tableProp.ColsImage.Contains(column.ColumnName))
                                {
                                    try
                                    {
                                        Image img = Image.FromFile(value.ToString());
                                        if (img != null)
                                        {
                                            double hpw = (double)img.Size.Height / (double)img.Size.Width;
                                            if (tableProp.IsAutoCropImage ?? false == true)
                                            {
                                                if ((tableProp.WidthImage == 0 || !tableProp.WidthImage.HasValue) && (tableProp.HeightImage == 0 || !tableProp.HeightImage.HasValue))
                                                {
                                                    tableProp.HeightImage = 200;
                                                }
                                                if (tableProp.WidthImage == 0 || !tableProp.WidthImage.HasValue)
                                                    tableProp.WidthImage = tableProp.GetWidth(tableProp.HeightImage ?? 0, hpw);
                                                if (tableProp.HeightImage == 0 || !tableProp.HeightImage.HasValue)
                                                    tableProp.HeightImage = tableProp.GetHeight(tableProp.WidthImage ?? 0, hpw);
                                            }
                                            ///format alignment
                                            cell.Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                                            cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                                            ///add image
                                            ExcelPicture pic = workSheet.Drawings.AddPicture((column.ColumnName + curRowIndex.ToString()), img);
                                            pic.SetPosition(curRowIndex - 1, 0, j + curColIndex - 1, 0);
                                            pic.SetSize((int)Math.Ceiling(tableProp.WidthImage ?? 0), (int)Math.Ceiling(tableProp.HeightImage ?? 0));
                                            workSheet.Column(j + curColIndex).Width = EpplusHelper.Pixel2ExcelW((int)(tableProp.WidthImage ?? 0));
                                            workSheet.Row(curRowIndex).Height = EpplusHelper.Pixel2ExcelH((int)(tableProp.HeightImage ?? 0));
                                        }
                                    }
                                    catch
                                    {

                                    }
                                }
                                else
                                {
                                    cell.Value = value == null ? "" : value.ToString();
                                    workSheet.Cells[curRowIndex, j + curColIndex].Value = row[column].ToString();
                                    ///format alignment
                                    cell.Style.VerticalAlignment = (ExcelVerticalAlignment)(tableProp.VerticalAlignment ?? 0);
                                    cell.Style.HorizontalAlignment = (ExcelHorizontalAlignment)(tableProp.HorizontalAlignment ?? 0);
                                }
                            }
                            else
                            {
                                cell.Value = value.ToString();
                                workSheet.Cells[curRowIndex, j + curColIndex].Value = row[column].ToString();
                            }
                        }
                        else
                        {
                            cell.Value = value == null ? "" : value.ToString();
                            workSheet.Cells[curRowIndex, j + curColIndex].Value = row[column].ToString();
                        }
                    }
                    ///format boder cell
                    if (tableProp.Border.HasValue)
                    {
                        cell.Style.Border.Top.Style = (ExcelBorderStyle)tableProp.Border;
                        cell.Style.Border.Left.Style = (ExcelBorderStyle)tableProp.Border;
                        cell.Style.Border.Right.Style = (ExcelBorderStyle)tableProp.Border;
                        cell.Style.Border.Bottom.Style = (ExcelBorderStyle)tableProp.Border;
                    }
                    /// font size 
                    if (tableProp.FontSize.HasValue)
                    {
                        cell.Style.Font.Size = tableProp.FontSize ?? 14;
                    }

                }
                curRowIndex++;
            }
            ///format table
            ///---Marge colums
            if (tableProp.IsMergeCol??false)
            {
                try
                {
                    List<int> cols = ConvertHelper.SplitString2Int(tableProp.ColsMerge, ",");
                    foreach (var _item in cols)
                    {
                        int _indexColumn = _item + startC -1;
                        string _value = "";
                        int _mergeStartR = 0;
                        for (int i = startR; i <= endR; i++)
                        {
                            if (_value == "")
                            {
                                _mergeStartR = i;
                                _value = workSheet.Cells[i, _indexColumn].Value.ToString();
                            }
                            else if (_value != workSheet.Cells[i, _indexColumn].Value.ToString())
                            {
                                workSheet.Cells[_mergeStartR,_indexColumn, i - 1,_indexColumn].Merge = true;
                                _mergeStartR = i;
                                _value = workSheet.Cells[i, _indexColumn].Value.ToString();
                            }
                            if(i == endR)
                            {
                                workSheet.Cells[_mergeStartR, _indexColumn, i - 1, _indexColumn].Merge = true;
                            }    

                        }
                    }
                }
                catch
                {

                }
              
            }
            //format colum
            if (tableProp.ColumProperties != null)
            {
                try
                {
                    List<int> cols = ConvertHelper.SplitString2Int(tableProp.ColsMerge, ",");
                    foreach (var _item in tableProp.ColumProperties)
                    {
                        int _indexColumn = _item.NoCol??1 + startC - 1;
                        ///---waptext
                        workSheet.Cells[startR, _indexColumn, endR, _indexColumn].Style.WrapText = true;
                        ///---width 
                        workSheet.Column(_indexColumn).Width = _item.Width??8.5;
                        ///---Autofill
                        if(_item.IsAutoFit?? false)
                        {
                            workSheet.Column(_indexColumn).AutoFit();
                        }  
                    }
                }
                catch
                {

                }

            }
            try
            {

            }
            catch
            {
            }
            //try
            //{
            //    workSheet.Cells[1,1,1,1].Style.WrapText = true;
            //}
            //catch
            //{
            //}

            int endCol = 0;
            try
            {
                endCol = workSheet.Dimension.End.Column;
            }
            catch
            {

            }

            for (var i = curColIndex; i <= endCol; i++)
            {
                workSheet.Column(i).Width = workSheet.Column(i).Width + 2;
            }//Add 2 to the filling


        }
        /// <summary>
        /// Generate excel
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dtSource">Data source</param>
        /// <param name="columns">Export field header collection</param>
        /// <param name="title">title (Sheet name)</param>
        /// <param name="showTitle">whether to show the title</param>
        /// <returns></returns>
        public static byte[] Export<T>(IList<T> dtSource, ExportColumnCollective columns, string title, bool showTitle = true)
        {
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets.Add(title);

                int maxColumnCount = columns.ExportColumnList.Count;
                int curRowIndex = 0;

                //Excel title
                if (showTitle == true)
                {
                    curRowIndex++;
                    workSheet.Cells[curRowIndex, 1, 1, maxColumnCount].Merge = true;
                    workSheet.Cells[curRowIndex, 1].Value = title;
                    var headerStyle = workSheet.Workbook.Styles.CreateNamedStyle("headerStyle");
                    headerStyle.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    headerStyle.Style.Font.Bold = true;
                    headerStyle.Style.Font.Size = 20;
                    workSheet.Cells[curRowIndex, 1].StyleName = "headerStyle";

                    curRowIndex++;
                    //Export time
                    workSheet.Cells[curRowIndex, 1, 2, maxColumnCount].Merge = true;
                    workSheet.Cells[curRowIndex, 1].Value = "Export time:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                    workSheet.Cells[curRowIndex, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                }

                //Data table title (column name)
                for (int i = 0, rowCount = columns.HeaderExportColumnList.Count; i < rowCount; i++)
                {
                    curRowIndex++;
                    workSheet.Cells[curRowIndex, 1, curRowIndex, maxColumnCount].Style.Font.Bold = true;
                    var curColSpan = 1;
                    for (int j = 0, colCount = columns.HeaderExportColumnList[i].Count; j < colCount; j++)
                    {
                        var colColumn = columns.HeaderExportColumnList[i][j];
                        var colSpan = FindSpaceCol(workSheet, curRowIndex, curColSpan);
                        if (j == 0) curColSpan = colSpan;
                        var toColSpan = colSpan + colColumn.ColSpan;
                        var cell = workSheet.Cells[curRowIndex, colSpan, colColumn.RowSpan + curRowIndex, toColSpan];
                        cell.Merge = true;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        workSheet.Cells[curRowIndex, colSpan].Value = colColumn.Title;
                        curColSpan += colColumn.ColSpan;
                    }
                }
                workSheet.View.FreezePanes(curRowIndex + 1, 1);//Freeze the title row

                Type type = typeof(T);
                PropertyInfo[] propertyInfos = type.GetProperties();
                if (propertyInfos.Count() == 0 && dtSource.Count > 0) propertyInfos = dtSource[0].GetType().GetProperties();

                //Data row
                for (int i = 0, sourceCount = dtSource.Count(); i < sourceCount; i++)
                {
                    curRowIndex++;
                    for (var j = 0; j < maxColumnCount; j++)
                    {
                        var column = columns.ExportColumnList[j];
                        var cell = workSheet.Cells[curRowIndex, j + 1];
                        foreach (var propertyInfo in propertyInfos)
                        {
                            if (column.Field == propertyInfo.Name)
                            {
                                object value = propertyInfo.GetValue(dtSource[i]);
                                var pType = propertyInfo.PropertyType;
                                pType = pType.Name == "Nullable`1" ? Nullable.GetUnderlyingType(pType) : pType;
                                if (pType == typeof(DateTime))
                                {
                                    cell.Style.Numberformat.Format = "yyyy-MM-dd hh:mm";
                                    cell.Value = Convert.ToDateTime(value);
                                }
                                else if (pType == typeof(int))
                                {
                                    cell.Style.Numberformat.Format = "#0";
                                    cell.Value = Convert.ToInt32(value);
                                }
                                else if (pType == typeof(double) || pType == typeof(decimal))
                                {
                                    if (column.Precision != null) cell.Style.Numberformat.Format = "#,##0.00";//Keep two decimal places

                                    cell.Value = Convert.ToDouble(value);
                                }
                                else
                                {
                                    cell.Value = value == null ? "" : value.ToString();
                                }
                            }
                        }
                    }
                }
                workSheet.Cells[workSheet.Dimension.Address].Style.Font.Name = "Song Ti";
                workSheet.Cells[workSheet.Dimension.Address].AutoFitColumns();//Auto fill
                for (var i = 1; i <= workSheet.Dimension.End.Column; i++) { workSheet.Column(i).Width = workSheet.Column(i).Width + 2; }//Add 2 to the filling

                return package.GetAsByteArray();
            }
        }

        private static int FindSpaceCol(ExcelWorksheet workSheet, int row, int col)
        {
            if (workSheet.Cells[row, col].Merge)
            {
                return FindSpaceCol(workSheet, row, col + 1);
            }
            return col;
        }
        public static bool IssetSheet(ExcelPackage excelPackage, int position = -1)
        {
            foreach (ExcelWorksheet sheet in excelPackage.Workbook.Worksheets)
            {
                if (position > -1 && sheet.Index == position)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IssetSheetName(ExcelPackage excelPackage, string sheetName)
        {
            foreach (ExcelWorksheet sheet in excelPackage.Workbook.Worksheets)
            {
                if (sheet.Name == sheetName)
                {
                    return true;
                }
            }
            return false;
        }
        public static double Pixel2ExcelW(int pixels)
        {
            double W = pixels * 0.14214;
            return W;
        }
        public static double Pixel2ExcelH(int pixels)
        {
            double H = pixels * 0.75;
            return H;
        }
        public static int Pixel2MTU(int pixels)
        {
            int mtus = pixels * 9525;
            return mtus;
        }
        public static int MTU2Pixel(int mtu)
        {
            int pixels = mtu / 9525;
            return pixels;
        }
        public static double Pixel2Inch(int pixels)
        {
            double mtus = (pixels - 12 + 5) / 7d + 1;
            return mtus;
        }
        private static bool CheckFontExists(string fontName)
        {
            using (Font fontTester = new Font(fontName,
                                               12,
                                               FontStyle.Regular,
                                               GraphicsUnit.Pixel))
            {
                if (fontTester.Name == fontName)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
        //Export the set of fields and headers that need to be mapped
        public class ExportColumnCollective
        {
            /// <summary>
            /// Field column collection
            /// </summary>
            public List<ExportColumn> ExportColumnList { get; set; }
            /// <summary>
            /// Header or multi-header collection
            /// </summary>
            public List<List<ExportColumn>> HeaderExportColumnList { get; set; }
        }

    }
    //Table properties
    public class TableProperty
    {
        public DataTable DataSource { get; set; }
        public List<ColumProperty> ColumProperties { get; set; }
        //public GenImage GenImage { get; set; }
        //public string Code { get; set; }
        //public string Barcode { get; set; }
        //public int? SysJobId { get; set; }
        //public int? No { get; set; }
        //public string SheetName { get; set; }
        //public int? SheetIndex { get; set; }
        //public int? TableIndex { get; set; }
        //public string Title { get; set; }
        //public int? TitleFontSize { get; set; }
        //public bool? IsShowTitle { get; set; }
        //public bool? IsShowTotal { get; set; }
        //public bool? IsHeader { get; set; }
        //public bool? IsFreezeHeader { get; set; }
        //public string HeaderColor { get; set; }
        //public string HeaderBackGroundColor { get; set; }
        //public int? HeaderBackGroundStyleId { get; set; }
        //public int? HeaderFontSize { get; set; }
        //public bool? IsAutoFit { get; set; }
        //public int? Border { get; set; }
        //public int? BorderStyleId { get; set; }
        //public string BackGroundColor { get; set; }
        //public int? BeginRow { get; set; }
        //public int? BeginCol { get; set; }
        //public string Style { get; set; }
        //public int? FontStyleId { get; set; }
        //public int? FontSize { get; set; }
        //public string Color { get; set; }
        //public int? Priority { get; set; }
        public int Id { get; set; }
        public string Code { get; set; }
        public string Barcode { get; set; }
        public int? SysJobId { get; set; }
        public int? No { get; set; }
        public string SheetName { get; set; }
        public int? SheetIndex { get; set; }
        public int? TableIndex { get; set; }
        public string Title { get; set; }
        public int? Priority { get; set; }
        public int? Border { get; set; }
        public int? BorderStyleId { get; set; }
        public int? FontStyleId { get; set; }
        public string FontStyle { get; set; }
        public int? FontSize { get; set; }
        public string Color { get; set; }
        public bool? IsGenIamge { get; set; }
        public double? HeightImage { get; set; }
        public double? WidthImage { get; set; }
        public string ColsImage { get; set; }
        public bool? IsAutoCropImage { get; set; }
        public bool? IsAutoFit { get; set; }
        public bool? IsFreezeHeader { get; set; }
        public int? HeaderFontSize { get; set; }
        public int? HeaderBackGroundStyleId { get; set; }
        public string HeaderBackGroundStyle { get; set; }
        public int? HeaderBackGroundColorId { get; set; }
        public int? HeaderColorId { get; set; }
        public bool? IsShowTotal { get; set; }
        public string ColsTotal { get; set; }
        public bool? IsShowTitle { get; set; }
        public int? TitleFontSize { get; set; }
        public int? TitleFontId { get; set; }
        public string TitleFont { get; set; }
        public bool? IsMergeCol { get; set; }
        public int? ColFirstMerge { get; set; }
        public int? ColEndMerge { get; set; }
        public bool? IsMergeRow { get; set; }
        public string ColsMerge { get; set; }
        public bool? IsHeader { get; set; }
        public int? BeginRow { get; set; }
        public int? BeginCol { get; set; }
        public int? VerticalAlignment { get; set; }
        public int? HorizontalAlignment { get; set; }
        public int? FontId { get; set; }
        public string Font { get; set; }
        public int? HeaderFontId { get; set; }
        public int? HeaderFontStyleId { get; set; }
        public string HeaderFont { get; set; }
        public string HeaderFontStyle { get; set; }
        public double GetWidth(double height, double hpw)
        {
            return height / hpw;
        }
        public double GetHeight(double width, double hpw)
        {
            return width * hpw;
        }
    }
    public class ColumProperty
    {
        public string Code { get; set; }
        public string Barcode { get; set; }
        public int? SysJobTableId { get; set; }
        public bool? IsAutoFit { get; set; }
        public int? NoCol { get; set; }
        public string Style { get; set; }
        public string Formulas { get; set; }
        public string Functions { get; set; }
        public int? Border { get; set; }
        public string Color { get; set; }
        public int? FontStyleId { get; set; }
        public int? FontId { get; set; }
        public int? FontSize { get; set; }
        public int? BackGroundStyleId { get; set; }
        public int? BackGroundColorId { get; set; }
        public int? VerticalAlignment { get; set; }
        public int? HorizontalAlignment { get; set; }
        public bool? IsWrapText { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public string FontStyle { get; set; }
        public string BackGroundStyle { get; set; }
        public string Font { get; set; }
    }
    //Mapping excel entity
    public class ExportColumn
    {

        /// <summary>
        /// Title
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
        /// <summary>
        /// field
        /// </summary>
        [JsonProperty("field")]
        public string Field { get; set; }
        /// <summary>
        /// Precision (only valid for double, decimal)
        /// </summary>
        [JsonProperty("precision")]
        public int? Precision { get; set; }
        /// <summary>
        /// Cross column
        /// </summary>
        [JsonProperty("colSpan")]
        public int ColSpan { get; set; }
        /// <summary>
        /// Cross line
        /// </summary>
        [JsonProperty("rowSpan")]
        public int RowSpan { get; set; }
    }
    //GenImage excel 
    public class GenImage
    {
        public bool IsGenIamge { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public string ColImage { get; set; }
        public bool IsAutoCrop { get; set; }
        public GenImage()
        {
            IsGenIamge = false;
            IsAutoCrop = false;
            Height = 30;
            Width = 40;
            ColImage = "Image,image,Ảnh,ảnh";
        }
        public GenImage(bool isGenIamge, float height = 0, float width = 0, string colImage = "Image,image,Ảnh,ảnh", bool isAutoCrop = true, float hpw = 1)
        {
            IsGenIamge = isGenIamge;
            IsAutoCrop = isAutoCrop;
            Height = height;
            Width = width;
            if (isAutoCrop)
            {
                if (height == 0)
                    Height = width * hpw;
                if (width == 0)
                    Width = height / hpw;
            }
            ColImage = colImage;
        }
        public float GetWidth(float height, float hpw)
        {
            return height / hpw;
        }
        public float GetHeight(float width, float hpw)
        {
            return width * hpw;
        }
    }

}
