using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BaseHrm.Utils
{
    public static class ValidationHelper
    {
        /// <summary>
        /// Validates email format using comprehensive regex
        /// </summary>
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            
            try
            {
                // More comprehensive email validation
                return Regex.IsMatch(email,
                    @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Validates Vietnamese phone number format
        /// </summary>
        public static bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return false;
            
            try
            {
                // Remove all non-digit characters
                var digitsOnly = Regex.Replace(phone, @"[^\d]", "");
                
                // Vietnamese phone number validation:
                // - Must start with 0
                // - Must have 10-11 digits total
                // - Common prefixes: 03, 05, 07, 08, 09
                return Regex.IsMatch(digitsOnly, @"^0[3-9]\d{8,9}$");
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Normalizes phone number by removing all non-digit characters
        /// </summary>
        public static string NormalizePhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return "";
            
            try
            {
                return Regex.Replace(phone, @"[^\d]", "");
            }
            catch
            {
                return phone;
            }
        }

        /// <summary>
        /// Validates username format
        /// </summary>
        public static bool IsValidUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) return false;
            
            try
            {
                // Username must be 3-50 characters, containing only letters, numbers, underscore, dot, and dash
                return username.Length >= 3 && 
                       username.Length <= 50 && 
                       Regex.IsMatch(username, @"^[a-zA-Z0-9_.\-]+$");
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Validates password strength
        /// </summary>
        public static bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password)) return false;
            
            try
            {
                // Password must be 6-100 characters and contain at least one letter and one digit
                return password.Length >= 6 && 
                       password.Length <= 100 && 
                       Regex.IsMatch(password, @"^(?=.*[a-zA-Z])(?=.*\d).+$");
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Validates Vietnamese name format (simplified to avoid regex encoding issues)
        /// </summary>
        public static bool IsValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;
            
            var trimmedName = name.Trim();
            
            // Basic validation: length and no special characters except space
            if (trimmedName.Length < 1 || trimmedName.Length > 50)
                return false;
            
            // Check for invalid characters (numbers, special symbols)
            foreach (char c in trimmedName)
            {
                if (char.IsDigit(c) || 
                    (char.IsPunctuation(c) && c != ' ') ||
                    (char.IsSymbol(c) && c != ' '))
                {
                    return false;
                }
            }
            
            return true;
        }

        /// <summary>
        /// Validates age range
        /// </summary>
        public static bool IsValidAge(DateTime dateOfBirth, int minAge = 15, int maxAge = 100)
        {
            var today = DateTime.Today;
            if (dateOfBirth > today) return false;
            
            int age = today.Year - dateOfBirth.Year;
            if (dateOfBirth > today.AddYears(-age)) age--;
            
            return age >= minAge && age <= maxAge;
        }

        /// <summary>
        /// Validates working hours
        /// </summary>
        public static bool IsValidWorkingHours(decimal hours, decimal minHours = 0, decimal maxHours = 24)
        {
            return hours >= minHours && hours <= maxHours;
        }

        /// <summary>
        /// Validates date range (hire date should not be before birth date and not in future)
        /// </summary>
        public static bool IsValidHireDate(DateTime hireDate, DateTime dateOfBirth)
        {
            var today = DateTime.Today;
            return hireDate <= today && hireDate >= dateOfBirth;
        }

        /// <summary>
        /// Gets validation error messages for employee data
        /// </summary>
        public static List<string> ValidateEmployeeData(
            string firstName, 
            string lastName, 
            string email, 
            string phone, 
            DateTime dateOfBirth, 
            DateTime hireDate, 
            decimal maxHoursPerDay, 
            decimal maxHoursPerMonth)
        {
            var errors = new List<string>();

            // Validate names
            if (string.IsNullOrWhiteSpace(firstName) || !IsValidName(firstName))
            {
                errors.Add("H? không h?p l? (1-50 ký t?, ch? ch?a ch? cái và kho?ng tr?ng)");
            }

            if (string.IsNullOrWhiteSpace(lastName) || !IsValidName(lastName))
            {
                errors.Add("Tên không h?p l? (1-50 ký t?, ch? ch?a ch? cái và kho?ng tr?ng)");
            }

            // Validate email
            if (!string.IsNullOrWhiteSpace(email) && !IsValidEmail(email))
            {
                errors.Add("Email không ?úng ??nh d?ng");
            }

            // Validate phone
            if (!string.IsNullOrWhiteSpace(phone) && !IsValidPhone(phone))
            {
                errors.Add("S? ?i?n tho?i không h?p l? (ph?i là s? Vi?t Nam 10-11 ch? s?, b?t ??u b?ng 0)");
            }

            // Validate age
            if (!IsValidAge(dateOfBirth))
            {
                errors.Add("Tu?i không h?p l? (t? 15-100 tu?i)");
            }

            // Validate hire date
            if (!IsValidHireDate(hireDate, dateOfBirth))
            {
                errors.Add("Ngày vào làm không h?p l? (không ???c tr??c ngày sinh ho?c trong t??ng lai)");
            }

            // Validate working hours
            if (!IsValidWorkingHours(maxHoursPerDay, 0, 24))
            {
                errors.Add("S? gi? làm vi?c t?i ?a/ngày không h?p l? (0-24 gi?)");
            }

            if (!IsValidWorkingHours(maxHoursPerMonth, 0, 744))
            {
                errors.Add("S? gi? làm vi?c t?i ?a/tháng không h?p l? (0-744 gi?)");
            }

            if (maxHoursPerMonth < maxHoursPerDay)
            {
                errors.Add("S? gi? t?i ?a/tháng không th? nh? h?n s? gi? t?i ?a/ngày");
            }

            return errors;
        }

        /// <summary>
        /// Gets validation error messages for account data
        /// </summary>
        public static List<string> ValidateAccountData(string username, string password, string confirmPassword)
        {
            var errors = new List<string>();

            // Validate username
            if (string.IsNullOrWhiteSpace(username) || !IsValidUsername(username))
            {
                errors.Add("Username không h?p l? (3-50 ký t?, ch? ch?a ch? cái, s?, _, ., -)");
            }

            // Validate password
            if (string.IsNullOrWhiteSpace(password) || !IsValidPassword(password))
            {
                errors.Add("M?t kh?u không h?p l? (6-100 ký t?, ph?i có ít nh?t 1 ch? cái và 1 ch? s?)");
            }

            // Validate confirm password
            if (string.IsNullOrWhiteSpace(confirmPassword) || password != confirmPassword)
            {
                errors.Add("M?t kh?u nh?p l?i không kh?p");
            }

            return errors;
        }
    }
}