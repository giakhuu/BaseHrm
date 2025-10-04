using BaseHrm.Data.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace BaseHrm.Auth
{
    public static class PasswordHasher
    {
        // Số rounds (work factor), càng cao càng an toàn nhưng chậm
        private const int WORK_FACTOR = 12;

        /// <summary>
        /// Hash mật khẩu sử dụng BCrypt
        /// </summary>
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, WORK_FACTOR);
        }

        /// <summary>
        /// Kiểm tra mật khẩu với hash đã lưu
        /// </summary>
        public static bool VerifyPassword(string hashedPassword, string password)
        {
            Console.WriteLine(password);
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}

