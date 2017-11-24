using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.SS.UserModel;
using System.IO;
using NPOI.HSSF.UserModel;

namespace Test.Excel
{
    public class NOPIHelper
    {
        public void CreateExcel(List<DeviationTable> list, string fileName, string sheetName)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet(sheetName);

            IRow rowHeader = sheet.CreateRow(0);
            ICellStyle style = workbook.CreateCellStyle();
            style.Alignment = HorizontalAlignment.CENTER;
            style.VerticalAlignment = VerticalAlignment.CENTER;

            ICell cellHeader1 = rowHeader.CreateCell(0);
            cellHeader1.SetCellValue("序号");
            cellHeader1.CellStyle = style;

            ICell cellHeader2 = rowHeader.CreateCell(1);
            cellHeader2.SetCellValue("局名");
            cellHeader2.CellStyle = style;

            ICell cellHeader3 = rowHeader.CreateCell(2);
            cellHeader3.SetCellValue("线名");
            cellHeader3.CellStyle = style;

            for (int i = 0; i < list.Count; i++)
            {
                IRow row = sheet.CreateRow(i + 1);




                ICell cell1 = row.CreateCell(0);
                cell1.SetCellValue(list[i].ID);
                cell1.CellStyle = style;

                ICell cell2 = row.CreateCell(1);
                cell2.SetCellValue(list[i].BureauName);
                cell2.CellStyle = style;

                ICell cell3 = row.CreateCell(2);
                cell3.SetCellValue(list[i].LineName);
                cell3.CellStyle = style;

            }

            string folderPath = "E:\\test";
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            string fileNamePath = folderPath + "\\" + fileName + ".xls";
            FileStream fs = new FileStream(fileNamePath, FileMode.Create);
            workbook.Write(fs);
            fs.Close();
            workbook = null;
        }


        public void Test()
        {
            string str = @"E:\111.xls";

            HSSFWorkbook wb = getWorkbook(str);
            //获取Excel 文件Sheet页的个数
            int sheetNum = wb.NumberOfSheets;

            string fileName = str.Substring(str.LastIndexOf('\\') + 1);
            fileName = fileName.Replace("111.xls", "222.xls");

            ISheet sheet = wb.GetSheetAt(0);
            string sheetName = sheet.SheetName;

            BuildSingleSheetExcel(fileName, sheetName, sheet, wb);

        }

        public static HSSFWorkbook getWorkbook(string excelFilePath)
        {
            FileStream file = new FileStream(excelFilePath, FileMode.Open, FileAccess.ReadWrite);//打开模板 只读
            HSSFWorkbook hssfworkbook = new HSSFWorkbook(file);
            return hssfworkbook;
        }

        private void BuildSingleSheetExcel(string fileName, string sheetName, ISheet sheetOrigial, HSSFWorkbook wb)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet(sheetName);

            List<string> list = new List<string>();
            List<string> list2 = new List<string>();

            for (int i = (sheetOrigial.FirstRowNum); i <= sheetOrigial.LastRowNum; i++)
            {
                IRow rowOrigial = sheetOrigial.GetRow(i);
                
                if (rowOrigial != null)
                {
                    for (int j = rowOrigial.FirstCellNum; j < rowOrigial.LastCellNum; j++)
                    {
                        if (i == 0)
                        {
                            sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 0, 0, rowOrigial.LastCellNum));
                        }

                        int columnWidth = sheetOrigial.GetColumnWidth(j);
                        columnWidth = columnWidth + 220;
                        sheet.SetColumnWidth(j, columnWidth);

                        ICell cellOrigial = rowOrigial.GetCell(j);

                        string phone=cellOrigial.ToString().Substring(0,3);
                        

                        if (phone == "130" || phone == "131" || phone == "132" || phone == "155" || phone == "156" || phone == "185" || phone == "186")
                        {
                            list.Add(cellOrigial.ToString());
                        }

                        if (phone == "134" || phone == "135" || phone == "136" || phone == "137" || phone == "138" || phone == "139" || phone == "147"
                            || phone == "150" || phone == "151" || phone == "152" || phone == "157" || phone == "158" || phone == "182" || phone == "187"
                            || phone == "147" || phone == "147" || phone == "147"
                            || phone == "188")
                        {
                            list2.Add(cellOrigial.ToString());
                        }

                        //if (cellOrigial != null)
                        //{
                        //    ICellStyle cellStyleOrigial = cellOrigial.CellStyle;
                        //    IFont fontOrigial = cellStyleOrigial.GetFont(wb);

                        //    ICellStyle style = workbook.CreateCellStyle();
                        //    style.Alignment = cellStyleOrigial.Alignment;
                        //    style.VerticalAlignment = cellStyleOrigial.VerticalAlignment;
                        //    IFont font = workbook.CreateFont();
                        //    font.Boldweight = fontOrigial.Boldweight;
                        //    font.Color = fontOrigial.Color;
                        //    font.FontHeight = fontOrigial.FontHeight;
                        //    font.FontName = fontOrigial.FontName;
                        //    style.SetFont(font);

                        //    ICell cell = row.CreateCell(j);
                        //    cell.SetCellValue(cellOrigial.ToString());
                        //    cell.CellStyle = style;
                        //}
                    }
                }


                
            }

            
            //for (int x = 0; x < list.Count; x++)
            //{
            //    IRow row = sheet.CreateRow(x);
            //    ICell cell = row.CreateCell(0);
            //    cell.SetCellValue(list[x]);
            //}

            for (int x = 0; x < list2.Count; x++)
            {
                IRow row = sheet.CreateRow(x);
                ICell cell = row.CreateCell(1);
                cell.SetCellValue(list2[x]);
            }


            string folderPath = @"E:\" + fileName;
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            string fileNamePath = folderPath + "\\" + fileName + sheetName + ".xls";
            FileStream fs = new FileStream(fileNamePath, FileMode.Create);
            workbook.Write(fs);
            fs.Close();
            workbook = null;

        }
    }
}
