using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.SS.UserModel;
using System.IO;
using NPOI.HSSF.UserModel;
using VehicleAcceleration.Model;

namespace VehicleAcceleration.Common
{
    public class NOPIHelper
    {
        public void CreateExcel(List<DeviationTable> list, string fileNamePath, string sheetName)
        {
            
            HSSFWorkbook workbook = new HSSFWorkbook();
            
            ISheet sheet = workbook.CreateSheet(sheetName);

            IRow rowHeader = sheet.CreateRow(0);
            ICellStyle style = workbook.CreateCellStyle();
            style.Alignment = HorizontalAlignment.CENTER;
            style.VerticalAlignment = VerticalAlignment.CENTER;

            ICell cellHeader = rowHeader.CreateCell(0);
            cellHeader.SetCellValue("序号");
            cellHeader.CellStyle = style;

            cellHeader = rowHeader.CreateCell(1);
            cellHeader.SetCellValue("局名");
            cellHeader.CellStyle = style;

            cellHeader = rowHeader.CreateCell(2);
            cellHeader.SetCellValue("线名");
            cellHeader.CellStyle = style;

            cellHeader = rowHeader.CreateCell(3);
            cellHeader.SetCellValue("里程");
            cellHeader.CellStyle = style;

            cellHeader = rowHeader.CreateCell(4);
            cellHeader.SetCellValue("轴箱加速度测试内容");
            cellHeader.CellStyle = style;

            cellHeader = rowHeader.CreateCell(5);
            cellHeader.SetCellValue("有效值/峰值(m/s^2)");
            cellHeader.CellStyle = style;

            cellHeader = rowHeader.CreateCell(6);
            cellHeader.SetCellValue("轨道冲击指数");
            cellHeader.CellStyle = style;

            cellHeader = rowHeader.CreateCell(7);
            cellHeader.SetCellValue("偏差等级");
            cellHeader.CellStyle = style;

            cellHeader = rowHeader.CreateCell(8);
            cellHeader.SetCellValue("速度(km/h)");
            cellHeader.CellStyle = style;

            cellHeader = rowHeader.CreateCell(9);
            cellHeader.SetCellValue("线型");
            cellHeader.CellStyle = style;

            cellHeader = rowHeader.CreateCell(10);
            cellHeader.SetCellValue("备注");
            cellHeader.CellStyle = style;

            for (int i = 0; i < list.Count; i++)
            {
                IRow row = sheet.CreateRow(i + 1);

                ICell cell = row.CreateCell(0);
                cell.SetCellValue(list[i].ID);
                cell.CellStyle = style;

                cell = row.CreateCell(1);
                cell.SetCellValue(list[i].BureauName);
                cell.CellStyle = style;

                cell = row.CreateCell(2);
                cell.SetCellValue(list[i].LineName);
                cell.CellStyle = style;

                cell = row.CreateCell(3);
                cell.SetCellValue(list[i].Miles);
                cell.CellStyle = style;

                cell = row.CreateCell(4);
                cell.SetCellValue(list[i].ChannelName);
                cell.CellStyle = style;

                cell = row.CreateCell(5);
                cell.SetCellValue(list[i].RmsOrPeakValue);
                cell.CellStyle = style;

                cell = row.CreateCell(6);
                cell.SetCellValue(list[i].TrackImpactIndex);
                cell.CellStyle = style;

                cell = row.CreateCell(7);
                cell.SetCellValue(list[i].DeviationGrade);
                cell.CellStyle = style;

                cell = row.CreateCell(8);
                cell.SetCellValue(list[i].Speed);
                cell.CellStyle = style;

                cell = row.CreateCell(9);
                cell.SetCellValue(list[i].LineType);
                cell.CellStyle = style;

                cell = row.CreateCell(10);
                cell.SetCellValue(list[i].Remark);
                cell.CellStyle = style;
            }
            FileStream fs = new FileStream(fileNamePath, FileMode.Create);
            workbook.Write(fs);
            fs.Close();
            workbook = null;
        }


        public void CreateExcelForData(double[] data,string title, string fileNamePath, string sheetName)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();

            ISheet sheet = workbook.CreateSheet(sheetName);

            IRow rowHeader = sheet.CreateRow(0);
            ICellStyle style = workbook.CreateCellStyle();
            style.Alignment = HorizontalAlignment.CENTER;
            style.VerticalAlignment = VerticalAlignment.CENTER;

            ICell cellHeader = rowHeader.CreateCell(0);
            cellHeader.SetCellValue(title);
            cellHeader.CellStyle = style;

            for (int i = 0; i < data.Length; i++)
            {
                IRow row = sheet.CreateRow(i + 1);

                ICell cell = row.CreateCell(0);
                cell.SetCellValue(data[i]);
                cell.CellStyle = style;
            }
            FileStream fs = new FileStream(fileNamePath, FileMode.Create);
            workbook.Write(fs);
            fs.Close();
            workbook = null;
        }

        public void CreateExcelForData(Int64[] data, string title, string fileNamePath, string sheetName)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();

            ISheet sheet = workbook.CreateSheet(sheetName);

            IRow rowHeader = sheet.CreateRow(0);
            ICellStyle style = workbook.CreateCellStyle();
            style.Alignment = HorizontalAlignment.CENTER;
            style.VerticalAlignment = VerticalAlignment.CENTER;

            ICell cellHeader = rowHeader.CreateCell(0);
            cellHeader.SetCellValue(title);
            cellHeader.CellStyle = style;

            for (int i = 0; i < data.Length; i++)
            {
                IRow row = sheet.CreateRow(i + 1);

                ICell cell = row.CreateCell(0);
                cell.SetCellValue(data[i]);
                cell.CellStyle = style;
            }
            FileStream fs = new FileStream(fileNamePath, FileMode.Create);
            workbook.Write(fs);
            fs.Close();
            workbook = null;
        }
    }
}
