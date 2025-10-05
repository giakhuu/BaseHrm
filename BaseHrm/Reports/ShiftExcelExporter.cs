using BaseHrm.Data.DTO;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;

namespace BaseHrm.Reports
{
    public static class ShiftExcelExporter
    {
        public static void ExportToExcel(List<ShiftDto> shifts, string filePath, string reportTitle = "Backup Shift")
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Shift");
                worksheet.Cells[1, 1].Value = reportTitle;
                worksheet.Cells[1, 1, 1, 8].Merge = true;
                worksheet.Cells[1, 1].Style.Font.Bold = true;
                worksheet.Cells[1, 1].Style.Font.Size = 16;
                worksheet.Cells[1, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                int headerRow = 2;
                string[] headers = { "ID Ca", "Tên Ca", "B?t ??u Ca", "K?t Thúc Ca", "Gi? D? Ki?n", "ID Lo?i Ca", "Tên Lo?i Ca", "H? S? L??ng" };
                for (int i = 0; i < headers.Length; i++)
                {
                    worksheet.Cells[headerRow, i + 1].Value = headers[i];
                    worksheet.Cells[headerRow, i + 1].Style.Font.Bold = true;
                    worksheet.Cells[headerRow, i + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    worksheet.Cells[headerRow, i + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                    worksheet.Cells[headerRow, i + 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                }
                int row = headerRow + 1;
                foreach (var shift in shifts)
                {
                    worksheet.Cells[row, 1].Value = shift.ShiftId;
                    worksheet.Cells[row, 2].Value = shift.Name;
                    worksheet.Cells[row, 3].Value = shift.StartTime.ToString(@"hh\:mm\:ss");
                    worksheet.Cells[row, 4].Value = shift.EndTime.ToString(@"hh\:mm\:ss");
                    worksheet.Cells[row, 5].Value = shift.ExpectedHours;
                    worksheet.Cells[row, 6].Value = shift.ShiftTypeId;
                    worksheet.Cells[row, 7].Value = shift.ShiftTypeName;
                    worksheet.Cells[row, 8].Value = shift.PayMultiplier;
                    row++;
                }
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    package.SaveAs(stream);
                }
            }
        }
    }
}
