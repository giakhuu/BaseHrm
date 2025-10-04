using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BaseHrm.Utils
{
    public static class ValidationExtensions
    {
        /// <summary>
        /// Sets validation error for a control with icon
        /// </summary>
        public static void SetValidationError(this ErrorProvider errorProvider, Control control, string errorMessage)
        {
            errorProvider.SetError(control, errorMessage);
            errorProvider.SetIconAlignment(control, ErrorIconAlignment.MiddleRight);
            errorProvider.SetIconPadding(control, 2);
        }

        /// <summary>
        /// Clears all validation errors
        /// </summary>
        public static void ClearAllErrors(this ErrorProvider errorProvider)
        {
            errorProvider.Clear();
        }

        /// <summary>
        /// Validates required field and sets error if empty
        /// </summary>
        public static bool ValidateRequired(this ErrorProvider errorProvider, Control control, string fieldName)
        {
            var text = control.Text?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(text))
            {
                errorProvider.SetValidationError(control, $"{fieldName} là b?t bu?c.");
                return false;
            }
            
            errorProvider.SetError(control, "");
            return true;
        }

        /// <summary>
        /// Validates text length and sets error if invalid
        /// </summary>
        public static bool ValidateLength(this ErrorProvider errorProvider, Control control, 
            string fieldName, int minLength = 0, int maxLength = int.MaxValue)
        {
            var text = control.Text?.Trim() ?? "";
            
            if (text.Length < minLength)
            {
                errorProvider.SetValidationError(control, $"{fieldName} ph?i có ít nh?t {minLength} ký t?.");
                return false;
            }
            
            if (text.Length > maxLength)
            {
                errorProvider.SetValidationError(control, $"{fieldName} không ???c quá {maxLength} ký t?.");
                return false;
            }
            
            errorProvider.SetError(control, "");
            return true;
        }

        /// <summary>
        /// Validates email format and sets error if invalid
        /// </summary>
        public static bool ValidateEmail(this ErrorProvider errorProvider, Control control, bool required = false)
        {
            var email = control.Text?.Trim() ?? "";
            
            if (string.IsNullOrWhiteSpace(email))
            {
                if (required)
                {
                    errorProvider.SetValidationError(control, "Email là b?t bu?c.");
                    return false;
                }
                errorProvider.SetError(control, "");
                return true;
            }
            
            if (!ValidationHelper.IsValidEmail(email))
            {
                errorProvider.SetValidationError(control, "Email không ?úng ??nh d?ng.");
                return false;
            }
            
            errorProvider.SetError(control, "");
            return true;
        }

        /// <summary>
        /// Validates phone format and sets error if invalid
        /// </summary>
        public static bool ValidatePhone(this ErrorProvider errorProvider, Control control, bool required = false)
        {
            var phone = control.Text?.Trim() ?? "";
            
            if (string.IsNullOrWhiteSpace(phone))
            {
                if (required)
                {
                    errorProvider.SetValidationError(control, "S? ?i?n tho?i là b?t bu?c.");
                    return false;
                }
                errorProvider.SetError(control, "");
                return true;
            }
            
            if (!ValidationHelper.IsValidPhone(phone))
            {
                errorProvider.SetValidationError(control, "S? ?i?n tho?i không h?p l?.");
                return false;
            }
            
            errorProvider.SetError(control, "");
            return true;
        }

        /// <summary>
        /// Validates ComboBox selection and sets error if not selected
        /// </summary>
        public static bool ValidateComboBoxSelection(this ErrorProvider errorProvider, ComboBox comboBox, string fieldName)
        {
            if (comboBox.SelectedValue == null || string.IsNullOrWhiteSpace(comboBox.Text))
            {
                errorProvider.SetValidationError(comboBox, $"Vui lòng ch?n {fieldName}.");
                return false;
            }
            
            errorProvider.SetError(comboBox, "");
            return true;
        }

        /// <summary>
        /// Validates numeric input and sets error if invalid
        /// </summary>
        public static bool ValidateNumeric(this ErrorProvider errorProvider, Control control, 
            string fieldName, decimal minValue = decimal.MinValue, decimal maxValue = decimal.MaxValue)
        {
            var text = control.Text?.Trim() ?? "";
            
            if (!decimal.TryParse(text, out decimal value))
            {
                errorProvider.SetValidationError(control, $"{fieldName} ph?i là s?.");
                return false;
            }
            
            if (value < minValue)
            {
                errorProvider.SetValidationError(control, $"{fieldName} ph?i >= {minValue}.");
                return false;
            }
            
            if (value > maxValue)
            {
                errorProvider.SetValidationError(control, $"{fieldName} ph?i <= {maxValue}.");
                return false;
            }
            
            errorProvider.SetError(control, "");
            return true;
        }

        /// <summary>
        /// Validates date and sets error if invalid
        /// </summary>
        public static bool ValidateDate(this ErrorProvider errorProvider, DateTimePicker dateTimePicker, 
            string fieldName, DateTime? minDate = null, DateTime? maxDate = null)
        {
            var date = dateTimePicker.Value.Date;
            var today = DateTime.Today;
            
            if (minDate.HasValue && date < minDate.Value)
            {
                errorProvider.SetValidationError(dateTimePicker, $"{fieldName} không ???c tr??c {minDate.Value:dd/MM/yyyy}.");
                return false;
            }
            
            if (maxDate.HasValue && date > maxDate.Value)
            {
                errorProvider.SetValidationError(dateTimePicker, $"{fieldName} không ???c sau {maxDate.Value:dd/MM/yyyy}.");
                return false;
            }
            
            errorProvider.SetError(dateTimePicker, "");
            return true;
        }

        /// <summary>
        /// Shows validation summary with all errors in a user-friendly message box
        /// </summary>
        public static void ShowValidationSummary(this Form form, List<string> errors, string title = "L?i Validation")
        {
            if (errors == null || errors.Count == 0) return;

            // Remove duplicates and empty errors
            var uniqueErrors = errors.Where(e => !string.IsNullOrWhiteSpace(e)).Distinct().ToList();
            if (uniqueErrors.Count == 0) return;

            var message = "?? Vui lòng s?a các l?i sau:\n\n";
            
            // Show up to 10 errors to avoid overwhelming the user
            var errorsToShow = Math.Min(uniqueErrors.Count, 10);
            
            for (int i = 0; i < errorsToShow; i++)
            {
                message += $"• {uniqueErrors[i]}\n";
            }

            if (uniqueErrors.Count > 10)
            {
                message += $"\n... và {uniqueErrors.Count - 10} l?i khác";
            }

            // Add helpful tips based on error count
            if (uniqueErrors.Count > 5)
            {
                message += "\n\n?? Tip: Hãy s?a t?ng l?i m?t ?? d? dàng h?n.";
            }
            else if (uniqueErrors.Count > 1)
            {
                message += "\n\n?? Các tr??ng có l?i s? ???c ?ánh d?u b?ng bi?u t??ng c?nh báo.";
            }

            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Shows a detailed validation error message box with custom formatting
        /// </summary>
        public static void ShowDetailedValidationErrors(this Form form, List<string> errors, string title = "L?i Validation")
        {
            if (errors == null || errors.Count == 0) return;

            var uniqueErrors = errors.Where(e => !string.IsNullOrWhiteSpace(e)).Distinct().ToList();
            if (uniqueErrors.Count == 0) return;

            // Categorize errors
            var requiredFieldErrors = uniqueErrors.Where(e => e.Contains("b?t bu?c") || e.Contains("ch?n")).ToList();
            var formatErrors = uniqueErrors.Where(e => e.Contains("không h?p l?") || e.Contains("??nh d?ng") || e.Contains("ký t?")).ToList();
            var duplicateErrors = uniqueErrors.Where(e => e.Contains("?ã ???c s? d?ng") || e.Contains("?ã t?n t?i")).ToList();
            var otherErrors = uniqueErrors.Except(requiredFieldErrors).Except(formatErrors).Except(duplicateErrors).ToList();

            var message = "?? D? li?u nh?p vào ch?a ?úng:\n\n";

            if (requiredFieldErrors.Any())
            {
                message += "?? Thông tin b?t bu?c:\n";
                foreach (var error in requiredFieldErrors)
                {
                    message += $"  • {error}\n";
                }
                message += "\n";
            }

            if (formatErrors.Any())
            {
                message += "?? ??nh d?ng không ?úng:\n";
                foreach (var error in formatErrors)
                {
                    message += $"  • {error}\n";
                }
                message += "\n";
            }

            if (duplicateErrors.Any())
            {
                message += "?? D? li?u trùng l?p:\n";
                foreach (var error in duplicateErrors)
                {
                    message += $"  • {error}\n";
                }
                message += "\n";
            }

            if (otherErrors.Any())
            {
                message += "? L?i khác:\n";
                foreach (var error in otherErrors)
                {
                    message += $"  • {error}\n";
                }
                message += "\n";
            }

            message += "?? Vui lòng ki?m tra và s?a các l?i trên tr??c khi l?u.";

            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Validates all controls in a container and returns error list
        /// </summary>
        public static List<string> ValidateContainer(this ErrorProvider errorProvider, Control container)
        {
            var errors = new List<string>();
            
            foreach (Control control in container.Controls)
            {
                var error = errorProvider.GetError(control);
                if (!string.IsNullOrEmpty(error))
                {
                    errors.Add($"{control.Name}: {error}");
                }
                
                if (control.HasChildren)
                {
                    errors.AddRange(errorProvider.ValidateContainer(control));
                }
            }
            
            return errors;
        }
    }
}