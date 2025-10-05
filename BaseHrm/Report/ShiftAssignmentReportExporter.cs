using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace BaseHrm.Reports
{
    public class ShiftAssignmentReportExporter
    {
        public void ExportToExcel(List<BaseHrm.Data.DTO.ShiftAssignmentDto> assignments, string filePath, string reportTitle = "Báo Cáo Phân Công Ca Làm Việc", DateTime? startDate = null, DateTime? endDate = null, string? employeeName = null, string? teamName = null)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Phân Công Ca");

                int currentRow = 1;
                worksheet.Cells[currentRow, 1].Value = reportTitle;
                worksheet.Cells[currentRow, 1, currentRow, 17].Merge = true;
                worksheet.Cells[currentRow, 1].Style.Font.Bold = true;
                worksheet.Cells[currentRow, 1].Style.Font.Size = 16;
                worksheet.Cells[currentRow, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                currentRow++;

                if (startDate.HasValue && endDate.HasValue)
                {
                    worksheet.Cells[currentRow, 1].Value = $"Từ ngày: {startDate.Value:dd/MM/yyyy} đến ngày: {endDate.Value:dd/MM/yyyy}";
                    worksheet.Cells[currentRow, 1, currentRow, 17].Merge = true;
                    worksheet.Cells[currentRow, 1].Style.Font.Italic = true;
                    worksheet.Cells[currentRow, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    currentRow++;
                }

                if (!string.IsNullOrWhiteSpace(employeeName))
                {
                    worksheet.Cells[currentRow, 1].Value = $"Nhân viên: {employeeName}";
                    worksheet.Cells[currentRow, 1, currentRow, 17].Merge = true;
                    worksheet.Cells[currentRow, 1].Style.Font.Bold = true;
                    worksheet.Cells[currentRow, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                    currentRow++;
                }
                if (!string.IsNullOrWhiteSpace(teamName))
                {
                    worksheet.Cells[currentRow, 1].Value = $"Team: {teamName}";
                    worksheet.Cells[currentRow, 1, currentRow, 17].Merge = true;
                    worksheet.Cells[currentRow, 1].Style.Font.Bold = true;
                    worksheet.Cells[currentRow, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                    currentRow++;
                }

                // Thêm dòng tổng hợp
                decimal totalHours = assignments.Sum(a => a.ExpectedHours);
                int totalEmployees = assignments.Select(a => a.EmployeeId).Distinct().Count();
                int totalShifts = assignments.Count;
                worksheet.Cells[currentRow, 1].Value = $"Tổng giờ công: {totalHours:F2}";
                worksheet.Cells[currentRow, 2].Value = $"Tổng nhân viên: {totalEmployees}";
                worksheet.Cells[currentRow, 3].Value = $"Tổng ca: {totalShifts}";
                worksheet.Cells[currentRow, 1, currentRow, 3].Style.Font.Bold = true;
                currentRow++;

                int headerRow = currentRow;
                string[] headers = {
                    "ID Phân Công", "Ngày", "ID Ca", "Tên Ca",
                    "Bắt Đầu Ca", "Kết Thúc Ca", "Giờ Dự Kiến",
                    "Tên Loại Ca", "ID Nhân Viên", "Họ Nhân Viên",
                    "Tên Nhân Viên", "Họ Tên Đầy Đủ", "Email Nhân Viên",
                    "SĐT Nhân Viên", "Chức Vụ Nhân Viên",
                    "ID Người Duyệt", "Tên Người Duyệt"
                };

                for (int i = 0; i < headers.Length; i++)
                {
                    worksheet.Cells[headerRow, i + 1].Value = headers[i];
                    worksheet.Cells[headerRow, i + 1].Style.Font.Bold = true;
                    worksheet.Cells[headerRow, i + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    worksheet.Cells[headerRow, i + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                    worksheet.Cells[headerRow, i + 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                }
                int row = headerRow + 1;
                foreach (var assignment in assignments.OrderBy(a => a.Date).ThenBy(a => a.EmployeeFullName))
                {
                    worksheet.Cells[row, 1].Value = assignment.ShiftAssignmentId;
                    worksheet.Cells[row, 2].Value = assignment.Date;
                    worksheet.Cells[row, 2].Style.Numberformat.Format = "dd/MM/yyyy";
                    worksheet.Cells[row, 3].Value = assignment.ShiftId;
                    worksheet.Cells[row, 4].Value = assignment.ShiftName;
                    worksheet.Cells[row, 5].Value = assignment.ShiftStart.ToString(@"hh\:mm\:ss");
                    worksheet.Cells[row, 6].Value = assignment.ShiftEnd.ToString(@"hh\:mm\:ss");
                    worksheet.Cells[row, 7].Value = assignment.ExpectedHours;
                    worksheet.Cells[row, 8].Value = assignment.ShiftTypeName;
                    worksheet.Cells[row, 9].Value = assignment.EmployeeId;
                    worksheet.Cells[row, 10].Value = assignment.EmployeeLastName;
                    worksheet.Cells[row, 11].Value = assignment.EmployeeFirstName;
                    worksheet.Cells[row, 12].Value = assignment.EmployeeFullName;
                    worksheet.Cells[row, 13].Value = assignment.EmployeeEmail;
                    worksheet.Cells[row, 14].Value = assignment.EmployeePhone;
                    worksheet.Cells[row, 15].Value = assignment.EmployeePosition;
                    worksheet.Cells[row, 16].Value = assignment.ApprovedByAccountId;
                    worksheet.Cells[row, 17].Value = assignment.ApproverName;

                    for (int col = 1; col <= 17; col++)
                    {
                        worksheet.Cells[row, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
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
                worksheet.Cells[summaryStartRow, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;

                int summaryRow = summaryStartRow + 1;
                worksheet.Cells[summaryRow, 1].Value = "Tổng số bản ghi";
                worksheet.Cells[summaryRow, 2].Value = assignments.Count;
                summaryRow++;
                worksheet.Cells[summaryRow, 1].Value = "Tổng giờ công";
                worksheet.Cells[summaryRow, 2].Value = totalHours;
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
                worksheet.Cells[summaryRow, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                summaryRow++;
                worksheet.Cells[summaryRow, 1].Value = "Tên loại ca";
                worksheet.Cells[summaryRow, 2].Value = "Số lượng";
                worksheet.Cells[summaryRow, 3].Value = "Tổng giờ công";
                worksheet.Cells[summaryRow, 1, summaryRow, 3].Style.Font.Bold = true;
                summaryRow++;
                var byType = assignments
                    .GroupBy(a => a.ShiftTypeName ?? "Không xác định")
                    .Select(g => new { TypeName = g.Key, Count = g.Count(), TotalHours = g.Sum(x => x.ExpectedHours) })
                    .OrderByDescending(x => x.Count)
                    .ToList();
                foreach (var type in byType)
                {
                    worksheet.Cells[summaryRow, 1].Value = type.TypeName;
                    worksheet.Cells[summaryRow, 2].Value = type.Count;
                    worksheet.Cells[summaryRow, 3].Value = type.TotalHours;
                    summaryRow++;
                }

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                using (var stream = new System.IO.FileStream(filePath, System.IO.FileMode.Create))
                {
                    package.SaveAs(stream);
                }
            }
        }
    }
}