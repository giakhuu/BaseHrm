using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace BaseHrm.Reports
{
    public class AttendanceReportExporter
    {
        public void ExportToExcel(List<BaseHrm.Data.DTO.AttendanceRecordDto> records, string filePath, string reportTitle = "Báo Cáo Chấm Công", DateTime? startDate = null, DateTime? endDate = null, string? employeeName = null, string? teamName = null)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Chấm Công");

                int currentRow = 1;
                worksheet.Cells[currentRow, 1].Value = reportTitle;
                worksheet.Cells[currentRow, 1, currentRow, 20].Merge = true;
                worksheet.Cells[currentRow, 1].Style.Font.Bold = true;
                worksheet.Cells[currentRow, 1].Style.Font.Size = 16;
                worksheet.Cells[currentRow, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                currentRow++;

                if (startDate.HasValue && endDate.HasValue)
                {
                    worksheet.Cells[currentRow, 1].Value = $"Từ ngày: {startDate.Value:dd/MM/yyyy} đến ngày: {endDate.Value:dd/MM/yyyy}";
                    worksheet.Cells[currentRow, 1, currentRow, 20].Merge = true;
                    worksheet.Cells[currentRow, 1].Style.Font.Italic = true;
                    worksheet.Cells[currentRow, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    currentRow++;
                }
                if (!string.IsNullOrWhiteSpace(employeeName))
                {
                    worksheet.Cells[currentRow, 1].Value = $"Nhân viên: {employeeName}";
                    worksheet.Cells[currentRow, 1, currentRow, 20].Merge = true;
                    worksheet.Cells[currentRow, 1].Style.Font.Bold = true;
                    worksheet.Cells[currentRow, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    currentRow++;
                }
                if (!string.IsNullOrWhiteSpace(teamName))
                {
                    worksheet.Cells[currentRow, 1].Value = $"Team: {teamName}";
                    worksheet.Cells[currentRow, 1, currentRow, 20].Merge = true;
                    worksheet.Cells[currentRow, 1].Style.Font.Bold = true;
                    worksheet.Cells[currentRow, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    currentRow++;
                }

                decimal totalHours = records.Sum(r => r.DurationHours ?? 0);
                decimal totalValidHours = records.Sum(r => r.ValidDurationHours);
                int totalRecords = records.Count;
                worksheet.Cells[currentRow, 1].Value = $"Tổng giờ công: {totalHours:F2}";
                worksheet.Cells[currentRow, 2].Value = $"Tổng giờ công hợp lệ: {totalValidHours:F2}";
                worksheet.Cells[currentRow, 3].Value = $"Tổng bản ghi: {totalRecords}";
                worksheet.Cells[currentRow, 1, currentRow, 3].Style.Font.Bold = true;
                currentRow++;

                int headerRow = currentRow;
                string[] headers = {
                    "ID Hồ Sơ", "ID Nhân Viên", "Họ Tên", "Chức Vụ", "Email",
                    "Check In", "Check Out", "Thời Lượng (Giờ)", "Làm Thêm Giờ",
                    "ID Phân Ca", "Ngày Ca", "ID Ca", "Tên Ca", "ID Loại Ca",
                    "Tên Loại Ca", "Hệ Số Lương", "Bắt Đầu Ca", "Kết Thúc Ca",
                    "Thời Lượng Hợp Lệ", "Thời Lượng Hợp Lệ (Giờ)"
                };
                for (int i = 0; i < headers.Length; i++)
                {
                    worksheet.Cells[headerRow, i + 1].Value = headers[i];
                    worksheet.Cells[headerRow, i + 1].Style.Font.Bold = true;
                    worksheet.Cells[headerRow, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[headerRow, i + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                    worksheet.Cells[headerRow, i + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                }
                int row = headerRow + 1;
                foreach (var record in records.OrderBy(r => r.CheckIn))
                {
                    worksheet.Cells[row, 1].Value = record.AttendanceRecordId;
                    worksheet.Cells[row, 2].Value = record.EmployeeId;
                    worksheet.Cells[row, 3].Value = record.FullName;
                    worksheet.Cells[row, 4].Value = record.PositionName;
                    worksheet.Cells[row, 5].Value = record.Email;
                    worksheet.Cells[row, 6].Value = record.CheckIn;
                    worksheet.Cells[row, 6].Style.Numberformat.Format = "dd/MM/yyyy HH:mm:ss";
                    worksheet.Cells[row, 7].Value = record.CheckOut;
                    if (record.CheckOut.HasValue)
                        worksheet.Cells[row, 7].Style.Numberformat.Format = "dd/MM/yyyy HH:mm:ss";
                    worksheet.Cells[row, 8].Value = record.DurationHours;
                    worksheet.Cells[row, 9].Value = record.IsOvertime ? "Có" : "Không";
                    worksheet.Cells[row, 10].Value = record.ShiftAssignmentId;
                    worksheet.Cells[row, 11].Value = record.ShiftDate;
                    if (record.ShiftDate.HasValue)
                        worksheet.Cells[row, 11].Style.Numberformat.Format = "dd/MM/yyyy";
                    worksheet.Cells[row, 12].Value = record.ShiftId;
                    worksheet.Cells[row, 13].Value = record.ShiftName;
                    worksheet.Cells[row, 14].Value = record.ShiftTypeId;
                    worksheet.Cells[row, 15].Value = record.ShiftTypeName;
                    worksheet.Cells[row, 16].Value = record.PayMultiplier;
                    worksheet.Cells[row, 17].Value = record.ShiftStart.ToString(@"hh\:mm\:ss");
                    worksheet.Cells[row, 18].Value = record.ShiftEnd.ToString(@"hh\:mm\:ss");
                    worksheet.Cells[row, 19].Value = record.ValidDuration.ToString(@"hh\:mm\:ss");
                    worksheet.Cells[row, 20].Value = record.ValidDurationHours;
                    for (int col = 1; col <= 20; col++)
                    {
                        worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    }
                    row++;
                }
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                // Bảng tổng kết ở dưới
                int summaryStartRow = row + 2;
                worksheet.Cells[summaryStartRow, 1].Value = "BẢNG TỔNG KẾT";
                worksheet.Cells[summaryStartRow, 1, summaryStartRow, 4].Merge = true;
                worksheet.Cells[summaryStartRow, 1].Style.Font.Bold = true;
                worksheet.Cells[summaryStartRow, 1].Style.Font.Size = 14;
                worksheet.Cells[summaryStartRow, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                int summaryRow = summaryStartRow + 1;
                worksheet.Cells[summaryRow, 1].Value = "Tổng số bản ghi";
                worksheet.Cells[summaryRow, 2].Value = totalRecords;
                summaryRow++;
                worksheet.Cells[summaryRow, 1].Value = "Tổng giờ công";
                worksheet.Cells[summaryRow, 2].Value = totalHours;
                summaryRow++;
                worksheet.Cells[summaryRow, 1].Value = "Tổng giờ công hợp lệ";
                worksheet.Cells[summaryRow, 2].Value = totalValidHours;
                summaryRow++;
                if (!string.IsNullOrWhiteSpace(employeeName))
                {
                    worksheet.Cells[summaryRow, 1].Value = "Nhân viên";
                    worksheet.Cells[summaryRow, 2].Value = employeeName;
                    summaryRow++;
                }
                if (!string.IsNullOrWhiteSpace(teamName))
                {
                    worksheet.Cells[summaryRow, 1].Value = "Team";
                    worksheet.Cells[summaryRow, 2].Value = teamName;
                    summaryRow++;
                }
                // Bảng thống kê loại ca
                summaryRow++;
                worksheet.Cells[summaryRow, 1].Value = "Thống kê loại ca";
                worksheet.Cells[summaryRow, 1, summaryRow, 4].Merge = true;
                worksheet.Cells[summaryRow, 1].Style.Font.Bold = true;
                worksheet.Cells[summaryRow, 1].Style.Font.Size = 12;
                worksheet.Cells[summaryRow, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                summaryRow++;
                worksheet.Cells[summaryRow, 1].Value = "Tên loại ca";
                worksheet.Cells[summaryRow, 2].Value = "Số lượng";
                worksheet.Cells[summaryRow, 3].Value = "Tổng giờ công";
                worksheet.Cells[summaryRow, 4].Value = "Tổng giờ công hợp lệ";
                worksheet.Cells[summaryRow, 1, summaryRow, 4].Style.Font.Bold = true;
                summaryRow++;
                var byType = records
                    .GroupBy(r => r.ShiftTypeName ?? "Không xác định")
                    .Select(g => new {
                        TypeName = g.Key,
                        Count = g.Count(),
                        TotalHours = g.Sum(x => x.DurationHours ?? 0),
                        TotalValidHours = g.Sum(x => x.ValidDurationHours)
                    })
                    .OrderByDescending(x => x.Count)
                    .ToList();
                foreach (var type in byType)
                {
                    worksheet.Cells[summaryRow, 1].Value = type.TypeName;
                    worksheet.Cells[summaryRow, 2].Value = type.Count;
                    worksheet.Cells[summaryRow, 3].Value = type.TotalHours;
                    worksheet.Cells[summaryRow, 4].Value = type.TotalValidHours;
                    summaryRow++;
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