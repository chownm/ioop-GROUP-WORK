using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net;

namespace ioop_GROUP_WORK.Admin
{
    /// <summary>
    /// ValidationHelper - Static utility class for comprehensive input validation
    /// Provides methods to validate all types of user inputs
    /// Implements prevention of SQL injection and XSS attacks
    /// </summary>
    internal static class ValidationHelper
    {
        //=============================
        // Email Validation
        //=============================

        /// <summary>
        /// Validate email format using regex pattern
        /// Prevents invalid email addresses from entering the system
        /// </summary>
        public static bool ValidateEmail(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                    return false;

                // RFC 5322 simplified email validation pattern
                string emailPattern = @"^[^\s@]+@[^\s@]+\.[^\s@]+$";
                return Regex.IsMatch(email, emailPattern);
            }
            catch
            {
                return false;
            }
        }

        //=============================
        // Password Validation
        //=============================

        /// <summary>
        /// Validate password strength
        /// Requirements: Minimum 8 characters, uppercase, lowercase, and numeric characters
        /// Ensures secure passwords for system access
        /// </summary>
        public static bool ValidatePassword(string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(password))
                    return false;

                if (password.Length < 8)
                    return false;

                // Check for uppercase letter
                if (!Regex.IsMatch(password, "[A-Z]"))
                    return false;

                // Check for lowercase letter
                if (!Regex.IsMatch(password, "[a-z]"))
                    return false;

                // Check for numeric digit
                if (!Regex.IsMatch(password, "[0-9]"))
                    return false;

                return true;
            }
            catch
            {
                return false;
            }
        }

        //=============================
        // Phone Number Validation
        //=============================

        /// <summary>
        /// Validate phone number format
        /// Accepts various international formats
        /// </summary>
        public static bool ValidatePhoneNumber(string phoneNumber)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(phoneNumber))
                    return false;

                // Allow various formats: +1234567890, (123) 456-7890, 123-456-7890, etc.
                string phonePattern = @"^[\+]?[(]?[0-9]{1,4}[)]?[-\s\.]?[(]?[0-9]{1,4}[)]?[-\s\.]?[0-9]{1,9}$";
                return Regex.IsMatch(phoneNumber, phonePattern);
            }
            catch
            {
                return false;
            }
        }

        //=============================
        // Date Validation
        //=============================

        /// <summary>
        /// Validate date is in future
        /// Used for deadline validation in internship offers
        /// </summary>
        public static bool ValidateFutureDate(DateTime date)
        {
            return date > DateTime.Now;
        }

        /// <summary>
        /// Validate date range
        /// Ensures end date is after start date
        /// </summary>
        public static bool ValidateDateRange(DateTime startDate, DateTime endDate)
        {
            return endDate > startDate;
        }

        //=============================
        // Numeric Validation
        //=============================

        /// <summary>
        /// Validate score range (1-10)
        /// Used for performance, punctuality, and communication scores
        /// </summary>
        public static bool ValidateScoreRange(int score)
        {
            return score >= 1 && score <= 10;
        }

        /// <summary>
        /// Validate decimal range (for stipend, CGPA, etc.)
        /// </summary>
        public static bool ValidateDecimalRange(decimal value, decimal min, decimal max)
        {
            return value >= min && value <= max;
        }

        //=============================
        // File Validation
        //=============================

        /// <summary>
        /// Validate file type for uploads
        /// Only allows PDF and DOCX formats for reports
        /// </summary>
        public static bool ValidateFileType(string fileName, string[] allowedExtensions)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(fileName))
                    return false;

                string extension = System.IO.Path.GetExtension(fileName).ToLower();
                
                if (string.IsNullOrWhiteSpace(extension))
                    return false;

                return allowedExtensions.Any(ext => ext.Equals(extension));
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Validate file size (in MB)
        /// </summary>
        public static bool ValidateFileSize(long fileSize, int maxSizeMB)
        {
            long maxSizeBytes = maxSizeMB * 1024 * 1024;
            return fileSize <= maxSizeBytes;
        }

        //=============================
        // Required Field Validation
        //=============================

        /// <summary>
        /// Check if string field is not empty
        /// </summary>
        public static bool ValidateRequiredField(string field)
        {
            return !string.IsNullOrWhiteSpace(field);
        }

        //=============================
        // SQL Injection Prevention
        //=============================

        /// <summary>
        /// Detect potential SQL injection patterns
        /// Note: Primary defense is using parameterized queries
        /// This provides secondary validation layer
        /// </summary>
        public static bool ContainsSQLInjectionPatterns(string input)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(input))
                    return false;

                string[] sqlKeywords = new string[]
                {
                    "SELECT", "INSERT", "UPDATE", "DELETE", "DROP", "CREATE",
                    "ALTER", "EXEC", "EXECUTE", "UNION", "DECLARE", "--", "/*", "*/"
                };

                string upperInput = input.ToUpper();
                
                foreach (string keyword in sqlKeywords)
                {
                    if (upperInput.Contains(keyword))
                        return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        //=============================
        // XSS Prevention
        //=============================

        /// <summary>
        /// Sanitize string input to prevent XSS attacks
        /// Encodes HTML special characters
        /// </summary>
        public static string SanitizeInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            return WebUtility.HtmlEncode(input);
        }

        //=============================
        // Username Validation
        //=============================

        /// <summary>
        /// Validate username format
        /// Alphanumeric with underscores and hyphens allowed
        /// Length between 3 and 20 characters
        /// </summary>
        public static bool ValidateUsername(string username)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username))
                    return false;

                if (username.Length < 3 || username.Length > 20)
                    return false;

                // Allow alphanumeric, underscores, hyphens
                string usernamePattern = @"^[a-zA-Z0-9_-]+$";
                return Regex.IsMatch(username, usernamePattern);
            }
            catch
            {
                return false;
            }
        }

        //=============================
        // Text Length Validation
        //=============================

        /// <summary>
        /// Validate text length within limits
        /// </summary>
        public static bool ValidateTextLength(string text, int minLength, int maxLength)
        {
            if (string.IsNullOrWhiteSpace(text))
                return minLength == 0;

            int length = text.Trim().Length;
            return length >= minLength && length <= maxLength;
        }

        //=============================
        // Integer Validation
        //=============================

        /// <summary>
        /// Validate integer value within range
        /// </summary>
        public static bool ValidateIntegerRange(int value, int min, int max)
        {
            return value >= min && value <= max;
        }

        //=============================
        // URL Validation
        //=============================

        /// <summary>
        /// Validate URL format
        /// Used if system includes URL fields
        /// </summary>
        public static bool ValidateUrl(string url)
        {
            try
            {
                Uri uriResult;
                return Uri.TryCreate(url, UriKind.Absolute, out uriResult) &&
                       (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            }
            catch
            {
                return false;
            }
        }

        //=============================
        // CGPA Validation
        //=============================

        /// <summary>
        /// Validate CGPA (Cumulative Grade Point Average)
        /// Typical range: 0.0 to 4.0
        /// </summary>
        public static bool ValidateCGPA(decimal cgpa)
        {
            return cgpa >= 0.0m && cgpa <= 4.0m;
        }

        //=============================
        // Composite Validation for Common Objects
        //=============================

        /// <summary>
        /// Validate complete user registration data
        /// Comprehensive check for all required fields and formats
        /// </summary>
        public static bool ValidateUserRegistration(string username, string email, string password, string role)
        {
            return ValidateUsername(username) &&
                   ValidateEmail(email) &&
                   ValidatePassword(password) &&
                   ValidateRequiredField(role);
        }

        /// <summary>
        /// Validate internship offer data
        /// </summary>
        public static bool ValidateInternshipOffer(string title, string description, 
            DateTime deadline, int duration, decimal stipend)
        {
            return ValidateRequiredField(title) &&
                   ValidateRequiredField(description) &&
                   ValidateFutureDate(deadline) &&
                   ValidateIntegerRange(duration, 1, 24) && // 1-24 months
                   ValidateDecimalRange(stipend, 0, 100000); // 0 to 100,000 in currency
        }

        /// <summary>
        /// Validate evaluation scores
        /// All three scores must be in 1-10 range
        /// </summary>
        public static bool ValidateEvaluationScores(int performanceScore, 
            int punctualityScore, int communicationScore)
        {
            return ValidateScoreRange(performanceScore) &&
                   ValidateScoreRange(punctualityScore) &&
                   ValidateScoreRange(communicationScore);
        }
    }
}
