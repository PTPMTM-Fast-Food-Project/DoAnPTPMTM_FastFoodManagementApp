namespace DTO
{
    public static class PasswordHelper
    {
        /// <summary>
        /// Mã hóa mật khẩu bằng BCrypt
        /// </summary>
        /// <param name="password">Mật khẩu gốc</param>
        /// <returns>Mật khẩu đã được mã hóa</returns>
        public static string HashPassword(string password)
        {
            // Sử dụng độ phức tạp mặc định (12 rounds)
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        /// <summary>
        /// Kiểm tra mật khẩu gốc với mật khẩu đã mã hóa
        /// </summary>
        /// <param name="password">Mật khẩu gốc</param>
        /// <param name="hashedPassword">Mật khẩu đã mã hóa</param>
        /// <returns>True nếu mật khẩu đúng, False nếu sai</returns>
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
