using BaseHrm.Data.DTO;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;

namespace BaseHrm.Reports
{
    public static class AttendanceExcelImporter
    {
        public static List<AttendanceRecordDto> ImportFromExcel(string filePath)
        {
            var result = new List<AttendanceRecordDto>();
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];
                int startRow = 0;
                // Tìm dòng header
                for (int r = 1; r <= worksheet.Dimension.End.Row; r++)
                {
                    if ((worksheet.Cells[r, 1].Text ?? "").Contains("ID H? S?"))
                    {
                        startRow = r + 1;
                        break;
                    }
                }
                if (startRow == 0) return result;
                for (int row = startRow; row <= worksheet.Dimension.End.Row; row++)
                {
                    if (string.IsNullOrWhiteSpace(worksheet.Cells[row, 1].Text)) break;
                    var dto = new AttendanceRecordDto
                    {
                        AttendanceRecordId = int.Parse(worksheet.Cells[row, 1].Text),
                        EmployeeId = int.Parse(worksheet.Cells[row, 2].Text),
                        FullName = worksheet.Cells[row, 3].Text,
                        CheckIn = DateTime.Parse(worksheet.Cells[row, 6].Text),
                        CheckOut = string.IsNullOrWhiteSpace(worksheet.Cells[row, 7].Text) ? (DateTime?)null : DateTime.Parse(worksheet.Cells[row, 7].Text),
                        DurationHours = string.IsNullOrWhiteSpace(worksheet.Cells[row, 8].Text) ? (decimal?)null : decimal.Parse(worksheet.Cells[row, 8].Text),
                        IsOvertime = worksheet.Cells[row, 9].Text == "Có",
                        ShiftAssignmentId = string.IsNullOrWhiteSpace(worksheet.Cells[row, 10].Text) ? (int?)null : int.Parse(worksheet.Cells[row, 10].Text),
                        ShiftDate = string.IsNullOrWhiteSpace(worksheet.Cells[row, 11].Text) ? (DateTime?)null : DateTime.Parse(worksheet.Cells[row, 11].Text),
                        ShiftId = string.IsNullOrWhiteSpace(worksheet.Cells[row, 12].Text) ? (int?)null : int.Parse(worksheet.Cells[row, 12].Text),
                        ShiftName = worksheet.Cells[row, 13].Text,
                        ShiftTypeId = string.IsNullOrWhiteSpace(worksheet.Cells[row, 14].Text) ? (int?)null : int.Parse(worksheet.Cells[row, 14].Text),
                        ShiftTypeName = worksheet.Cells[row, 15].Text,
                        PayMultiplier = string.IsNullOrWhiteSpace(worksheet.Cells[row, 16].Text) ? (decimal?)null : decimal.Parse(worksheet.Cells[row, 16].Text),
                        ShiftStart = TimeSpan.TryParse(worksheet.Cells[row, 17].Text, out var st) ? st : TimeSpan.Zero,
                        ShiftEnd = TimeSpan.TryParse(worksheet.Cells[row, 18].Text, out var se) ? se : TimeSpan.Zero,
                        EmployeeEmail = worksheet.Cells[row, 5].Text,
                        EmployeePhone = worksheet.Cells[row, 14].Text,
                        EmployeePosition = worksheet.Cells[row, 4].Text,
                        EmployeeFirstName = worksheet.Cells[row, 10].Text,
                        EmployeeLastName = worksheet.Cells[row, 11].Text
                    };
                    result.Add(dto);
                }
            }
            return result;
        }
    }
}
