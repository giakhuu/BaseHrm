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
        public void ExportToExcel(List<BaseHrm.Data.DTO.ShiftAssignmentDto> assignments, string filePath, string reportTitle = "Báo Cáo Phân Công Ca Làm Việc", DateTime? startDate = null, DateTime? endDate = null)
        {

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Phân Công Ca");

                worksheet.Cells[1, 1].Value = reportTitle;
                worksheet.Cells[1, 1, 1, 17].Merge = true;
                worksheet.Cells[1, 1].Style.Font.Bold = true;
                worksheet.Cells[1, 1].Style.Font.Size = 16;
                worksheet.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                if (startDate.HasValue && endDate.HasValue)
                {
                    worksheet.Cells[2, 1].Value = $"Từ ngày: {startDate.Value:dd/MM/yyyy} đến ngày: {endDate.Value:dd/MM/yyyy}";
                    worksheet.Cells[2, 1, 2, 17].Merge = true;
                    worksheet.Cells[2, 1].Style.Font.Italic = true;
                    worksheet.Cells[2, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }
                int headerRow = startDate.HasValue ? 4 : 3;
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
                    worksheet.Cells[headerRow, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[headerRow, i + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                    worksheet.Cells[headerRow, i + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
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
                        worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    }

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