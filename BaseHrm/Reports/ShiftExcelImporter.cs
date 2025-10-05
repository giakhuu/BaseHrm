using BaseHrm.Data.DTO;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;

namespace BaseHrm.Reports
{
    public static class ShiftExcelImporter
    {
        public static List<ShiftDto> ImportFromExcel(string filePath)
        {
            var result = new List<ShiftDto>();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];
                int startRow = 0;
                for (int r = 1; r <= worksheet.Dimension.End.Row; r++)
                {
                    if ((worksheet.Cells[r, 1].Text ?? "").Contains("ID Ca"))
                    {
                        startRow = r + 1;
                        break;
                    }
                }
                if (startRow == 0) return result;
                for (int row = startRow; row <= worksheet.Dimension.End.Row; row++)
                {
                    if (string.IsNullOrWhiteSpace(worksheet.Cells[row, 1].Text)) break;
                    var dto = new ShiftDto
                    {
                        ShiftId = int.Parse(worksheet.Cells[row, 1].Text),
                        Name = worksheet.Cells[row, 2].Text,
                        StartTime = TimeSpan.TryParse(worksheet.Cells[row, 3].Text, out var st) ? st : TimeSpan.Zero,
                        EndTime = TimeSpan.TryParse(worksheet.Cells[row, 4].Text, out var se) ? se : TimeSpan.Zero,
                        ExpectedHours = string.IsNullOrWhiteSpace(worksheet.Cells[row, 5].Text) ? 0 : decimal.Parse(worksheet.Cells[row, 5].Text),
                        ShiftTypeId = string.IsNullOrWhiteSpace(worksheet.Cells[row, 6].Text) ? 0 : int.Parse(worksheet.Cells[row, 6].Text),
                        ShiftTypeName = worksheet.Cells[row, 7].Text,
                        PayMultiplier = string.IsNullOrWhiteSpace(worksheet.Cells[row, 8].Text) ? (decimal?)null : decimal.Parse(worksheet.Cells[row, 8].Text)
                    };
                    result.Add(dto);
                }
            }
            return result;
        }
    }
}
