using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace System.Utils
{
    public enum EncodeType
    {
        Base64
    }

    public class PasswordHelper
    {
        /// <summary>
        /// 如果被去掉=号之后的密码长度为单数，选择小写，反之选择大写
        /// </summary>
        private static string[] groups = new string[] { "c", "h", "e", "n" };

        public static string Encoding(string text, int level)
        {
            return Encoding(text, level, EncodeType.Base64);
        }

        public static string Encoding(string text, int level, EncodeType encodeType)
        {
            if (text.IsEmpty())
                return string.Empty;

            var password = string.Empty;

            switch (encodeType)
            {
                default: password = ToBase64(text, level); break;
                case EncodeType.Base64: password = ToBase64(text, level); break;
            }
            return password;
        }

        public static string Decoding(string password, int level)
        {
            return Decoding(password, level, EncodeType.Base64);
        }

        public static string Decoding(string password, int level, EncodeType encodeType)
        {
            if (password.IsEmpty())
                return string.Empty;

            var text = string.Empty;

            switch (encodeType)
            {
                default: text = DecodeBase64(password, level); break;
                case EncodeType.Base64: text = DecodeBase64(password, level); break;
            }

            return text;
        }

        private static string DecodeBase64(string password, int level)
        {
            if (password.IsEmpty() || level < 0)
                return string.Empty;

            var len = password.Length;
            var c = string.Empty;
            if (len % 2 == 0)
            {
                c = password[(len - 1) / 2].ToString();
                password = password.Remove((len - 1) / 2, 1);
            }
            else
            {
                c = password[len / 2].ToString();
                password = password.Remove(len / 2, 1);
            }
            var d = string.Empty;
            for(var i = 0;i < Array.IndexOf(groups, c.ToLower()); i++)
                d += "=";

            password += d;

            var text = System.Text.Encoding.Default.GetString(System.Convert.FromBase64String(password));

            if (level-- == 0)
                return text;
            else
                return DecodeBase64(text, level);
        }

        private static string ToBase64(string text, int level)
        {
            if (text.IsEmpty() || level < 0)
                return string.Empty;

            var reg = new Regex("=");
            var oldPassword = text.ToBase64();
            var newPassword = oldPassword.Replace("=", "");
            var ma = reg.Matches(oldPassword);
            var len = newPassword.Length;
            if (len % 2 == 0)
                newPassword = newPassword.Insert(len / 2, groups[ma.Count].ToUpper());
            else
                newPassword = newPassword.Insert(len / 2, groups[ma.Count].ToLower());

            if (level-- == 0)
                return newPassword;
            else
                return ToBase64(newPassword, level);
        }
    }
}