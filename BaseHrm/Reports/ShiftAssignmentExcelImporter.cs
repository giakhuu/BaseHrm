using BaseHrm.Data.DTO;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;

namespace BaseHrm.Reports
{
    public static class ShiftAssignmentExcelImporter
    {
        public static List<ShiftAssignmentDto> ImportFromExcel(string filePath)
        {
            var result = new List<ShiftAssignmentDto>();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];
                int startRow = 0;
                for (int r = 1; r <= worksheet.Dimension.End.Row; r++)
                {
                    if ((worksheet.Cells[r, 1].Text ?? "").Contains("ID Phân Công"))
                    {
                        startRow = r + 1;
                        break;
                    }
                }
                if (startRow == 0) return result;
                for (int row = startRow; row <= worksheet.Dimension.End.Row; row++)
                {
                    if (string.IsNullOrWhiteSpace(worksheet.Cells[row, 1].Text)) break;
                    var dto = new ShiftAssignmentDto
                    {
                        ShiftAssignmentId = int.Parse(worksheet.Cells[row, 1].Text),
                        EmployeeId = int.Parse(worksheet.Cells[row, 9].Text),
                        EmployeeFirstName = worksheet.Cells[row, 11].Text,
                        EmployeeLastName = worksheet.Cells[row, 10].Text,
                        EmployeeEmail = worksheet.Cells[row, 13].Text,
                        EmployeePhone = worksheet.Cells[row, 14].Text,
                        EmployeePosition = worksheet.Cells[row, 15].Text,
                        ShiftId = int.Parse(worksheet.Cells[row, 3].Text),
                        ShiftName = worksheet.Cells[row, 4].Text,
                        ShiftStart = TimeSpan.TryParse(worksheet.Cells[row, 5].Text, out var st) ? st : TimeSpan.Zero,
                        ShiftEnd = TimeSpan.TryParse(worksheet.Cells[row, 6].Text, out var se) ? se : TimeSpan.Zero,
                        ExpectedHours = string.IsNullOrWhiteSpace(worksheet.Cells[row, 7].Text) ? 0 : decimal.Parse(worksheet.Cells[row, 7].Text),
                        ShiftTypeId = string.IsNullOrWhiteSpace(worksheet.Cells[row, 8].Text) ? 0 : int.Parse(worksheet.Cells[row, 8].Text),
                        ShiftTypeName = worksheet.Cells[row, 8].Text,
                        PayMultiplier = null,
                        Date = DateTime.TryParse(worksheet.Cells[row, 2].Text, out var dt) ? dt : DateTime.MinValue,
                        ApprovedByAccountId = string.IsNullOrWhiteSpace(worksheet.Cells[row, 16].Text) ? (int?)null : int.Parse(worksheet.Cells[row, 16].Text),
                        ApproverName = worksheet.Cells[row, 17].Text
                    };
                    result.Add(dto);
                }
            }
            return result;
        }
    }
}
