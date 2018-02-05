using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace System
{
    #region 枚举

    #region 密码类型
    /// <summary>
    /// 密码类型
    /// </summary>
    public enum PasswordType
    {
        /// <summary>
        /// MD5密码
        /// </summary>
        MD5,
        /// <summary>
        /// BASE64密码
        /// </summary>
        BASE64,
        /// <summary>
        /// SHA1密码
        /// </summary>
        SHA1
    }
    #endregion

    #region 字符串类型
    public enum StringType
    { 
        /// <summary>
        /// 字符串以字母开头，且特殊字符中仅包含下划线的A-Za-z0-9字符串
        /// </summary>
        Pascal,
        /// <summary>
        /// 整数
        /// </summary>
        Integer,
        /// <summary>
        /// 小数
        /// </summary>
        Decimal,
        /// <summary>
        /// 除特殊字符意外，任意包含的字符串
        /// </summary>
        Other
    }
    #endregion

    #region 随机类型
    
    public enum RandomType
    {
        Number,
        Char,
        Hybrid
    }

    #endregion
    #endregion

    /// <summary>
    /// String扩展类
    /// </summary>
    public static class StringExtension
    {
        private static Random random = new Random();

        private static string[] allChars = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

        private static string[] allNumbers = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        #region 字符串数据类型转换

        /// <summary>
        /// 转换到Boolean类型，不包含异常处理
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool ToBoolean(this string s)
        {
            return Convert.ToBoolean(s);
        }

        /// <summary>
        /// 转换到Boolean类型，包含异常处理
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue">出现异常后的返回值</param>
        /// <returns></returns>
        public static bool ToBoolean(this string s, bool defaultValue)
        {
            try
            {
                if (s.IsEmpty())
                    return defaultValue;
                return Convert.ToBoolean(s);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 转换到Byte类型，不包含异常处理
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static byte ToByte(this string s)
        {
            return Convert.ToByte(s);
        }

        /// <summary>
        /// 转换到Byte类型，包含异常处理
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue">出现异常后的返回值</param>
        /// <returns></returns>
        public static byte ToByte(this string s, byte defaultValue)
        {
            try
            {
                return Convert.ToByte(s);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 转换到Int16类型，不包含异常处理
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Int16 ToInt16(this string s)
        {
            return Convert.ToInt16(s);
        }

        /// <summary>
        /// 转换到Int16类型，包含异常处理
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue">出现异常后的返回值</param>
        /// <returns></returns>
        public static Int16 ToInt16(this string s, Int16 defaultValue)
        {
            try
            {
                return s.ToInt16();
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 转换到Int32类型，不包含异常处理
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Int32 ToInt32(this string s)
        {
            if (s.IsMatch(StringType.Decimal) || s.IsMatch(StringType.Integer))
                return Convert.ToInt32(s);

            throw new Exception("String转换到Int32失败，输入字符串格式错误");
        }

        /// <summary>
        /// 转换到Int32类型，含异常处理
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue">出现异常后的返回值</param>
        /// <returns></returns>
        public static Int32 ToInt32(this string s, int defaultValue)
        {
            try
            {
                if(s.IsMatch(StringType.Integer))
                    return s.ToInt32();

                return defaultValue;
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 转换到Int64类型，不包含异常处理
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Int64 ToInt64(this string s)
        {
            return Convert.ToInt64(s);
        }

        /// <summary>
        /// 转换到Int64类型，包含异常处理
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue">出现异常后的返回值</param>
        /// <returns></returns>
        public static Int64 ToInt64(this string s, int defaultValue)
        {
            try
            {
                return s.ToInt64();
            }
            catch
            {
                return defaultValue;
            }
        }

        public static Decimal ToDecimal(this string s)
        {
            return Convert.ToDecimal(s);
        }

        public static Decimal ToDecimal(this string s, float defaultValue)
        {
            return s.ToDecimal(new Decimal(defaultValue));
        }

        public static Decimal ToDecimal(this string s, double defaultValue)
        {
            return s.ToDecimal(new Decimal(defaultValue));
        }

        public static Decimal ToDecimal(this string s, decimal defaultValue)
        {
            try
            {
                if (s.IsEmpty())
                    return defaultValue;

                return s.ToDecimal();
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 转换到时间类型，不包含异常处理
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string s)
        {
            return Convert.ToDateTime(s);
        }

        /// <summary>
        /// 转换到MD5
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToMD5(this string s)
        {
            return Encryption(s, PasswordType.MD5);
        }

        /// <summary>
        /// 转换到Base64
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToBase64(this string s)
        {
            return Encryption(s, PasswordType.BASE64);
        }

        /// <summary>
        /// 转换到SHA1
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToSHA1(this string s)
        {
            return Encryption(s, PasswordType.SHA1);
        }

        /// <summary>
        /// 字符串加密
        /// </summary>
        /// <param name="s"></param>
        /// <param name="passwordType">字符串加密类型</param>
        /// <returns></returns>
        public static string Encryption(this string s, PasswordType passwordType)
        {
            if (passwordType == PasswordType.BASE64)
            {
                return Convert.ToBase64String(System.Text.ASCIIEncoding.Default.GetBytes(s));
            }
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(s, passwordType.ToString());
        }

        #endregion

        #region 字符串格式化

        public static string Format(this string s, params object[] args)
        {
            return string.Format(s, args);
        }

        #endregion

        #region 字符串检查

        /// <summary>
        /// 如果字符串为空，返回true，否则返回false
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsNull(this string s)
        {
            if (s == null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 如果字符串等于空字符串，返回true，否则返回false
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsEmpty(this string s)
        {
            if (s == null || s == string.Empty)
                return true;
            else
                return false;
        }

        public static bool IsEmptySpace(this string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return true;

            return false;
        }

        /// <summary>
        /// 如果字符串不是空的，返回true，否则返回false
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsNotNull(this string s)
        {
            return !s.IsNull();
        }

        /// <summary>
        /// 如果字符串不是空字符串，返回true，否则返回false
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsNotEmpty(this string s)
        {
            return !s.IsEmpty();
        }

        #endregion

        #region 中文转拼音

        /// <summary>
        /// 将中文转换为每个文字的首字母
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ChineseCap(this string s)
        {
            string strTemp = "";
            int iLen = s.Length;
            int i = 0;
            for (i = 0; i <= iLen - 1; i++)
            {
                strTemp += GetCharSpellCode(s.Substring(i, 1));
            }
            return strTemp;
        }


        /// <summary>   
        /// 得到一个汉字的拼音第一个字母，如果是一个英文字母则直接返回大写字母   
        /// </summary>   
        /// <param name="paramChar">单个汉字</param>   
        /// <returns>单个大写字母</returns>   
        private static string GetCharSpellCode(string paramChar)
        {
            long iCnChar;

            byte[] ZW = System.Text.Encoding.Default.GetBytes(paramChar);

            //如果是字母，则直接返回   
            if (ZW.Length == 1)
            {
                return paramChar.ToUpper();
            }
            else
            {
                // get the array of byte from the single char   
                int i1 = (short)(ZW[0]);
                int i2 = (short)(ZW[1]);
                iCnChar = i1 * 256 + i2;
            }

            //expresstion   
            //table of the constant list   
            // 'A'; //45217..45252   
            // 'B'; //45253..45760   
            // 'C'; //45761..46317   
            // 'D'; //46318..46825   
            // 'E'; //46826..47009   
            // 'F'; //47010..47296   
            // 'G'; //47297..47613   

            // 'H'; //47614..48118   
            // 'J'; //48119..49061   
            // 'K'; //49062..49323   
            // 'L'; //49324..49895   
            // 'M'; //49896..50370   
            // 'N'; //50371..50613   
            // 'O'; //50614..50621   
            // 'P'; //50622..50905   
            // 'Q'; //50906..51386   

            // 'R'; //51387..51445   
            // 'S'; //51446..52217   
            // 'T'; //52218..52697   
            //没有U,V   
            // 'W'; //52698..52979   
            // 'X'; //52980..53640   
            // 'Y'; //53689..54480   
            // 'Z'; //54481..55289   

            // iCnChar match the constant   
            if ((iCnChar >= 45217) && (iCnChar <= 45252))
            {
                return "A";
            }
            else if ((iCnChar >= 45253) && (iCnChar <= 45760))
            {
                return "B";
            }
            else if ((iCnChar >= 45761) && (iCnChar <= 46317))
            {
                return "C";
            }
            else if ((iCnChar >= 46318) && (iCnChar <= 46825))
            {
                return "D";
            }
            else if ((iCnChar >= 46826) && (iCnChar <= 47009))
            {
                return "E";
            }
            else if ((iCnChar >= 47010) && (iCnChar <= 47296))
            {
                return "F";
            }
            else if ((iCnChar >= 47297) && (iCnChar <= 47613))
            {
                return "G";
            }
            else if ((iCnChar >= 47614) && (iCnChar <= 48118))
            {
                return "H";
            }
            else if ((iCnChar >= 48119) && (iCnChar <= 49061))
            {
                return "J";
            }
            else if ((iCnChar >= 49062) && (iCnChar <= 49323))
            {
                return "K";
            }
            else if ((iCnChar >= 49324) && (iCnChar <= 49895))
            {
                return "L";
            }
            else if ((iCnChar >= 49896) && (iCnChar <= 50370))
            {
                return "M";
            }
            else if ((iCnChar >= 50371) && (iCnChar <= 50613))
            {
                return "N";
            }
            else if ((iCnChar >= 50614) && (iCnChar <= 50621))
            {
                return "O";
            }
            else if ((iCnChar >= 50622) && (iCnChar <= 50905))
            {
                return "P";
            }
            else if ((iCnChar >= 50906) && (iCnChar <= 51386))
            {
                return "Q";
            }
            else if ((iCnChar >= 51387) && (iCnChar <= 51445))
            {
                return "R";
            }
            else if ((iCnChar >= 51446) && (iCnChar <= 52217))
            {
                return "S";
            }
            else if ((iCnChar >= 52218) && (iCnChar <= 52697))
            {
                return "T";
            }
            else if ((iCnChar >= 52698) && (iCnChar <= 52979))
            {
                return "W";
            }
            else if ((iCnChar >= 52980) && (iCnChar <= 53688))
            {
                return "X";
            }
            else if ((iCnChar >= 53689) && (iCnChar <= 54480))
            {
                return "Y";
            }
            else if ((iCnChar >= 54481) && (iCnChar <= 55289))
            {
                return "Z";
            }
            else return ("?");
        }  
        #endregion

        #region 判断表达式

        public static bool IsMatch(this string s, StringType stringType)
        {
            var m = string.Empty;

            switch (stringType)
            { 
                case StringType.Pascal:
                    m = "^[a-zA-Z_]+[a-zA-Z0-9_]+$";
                    break;
                case StringType.Integer:
                    m = "[0-9]+";
                    break;
                case StringType.Decimal:
                    m = "^[0-9]+[0-9.0-9]+$";
                    break;
                case StringType.Other:
                    m = "[A-Za-z0-9_]+";
                    break;
            }

            System.Text.RegularExpressions.Regex reg = new Text.RegularExpressions.Regex(m);
            return reg.IsMatch(s);
        }

        public static bool IsMatch(this string s, string pattern)
        {
            System.Text.RegularExpressions.Regex reg = new Text.RegularExpressions.Regex(pattern);
            return reg.IsMatch(s);
        }

        #endregion

        #region 常量

        public static string[] A_Z(this string s)
        {
            return new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        }

        #endregion

        #region URL

        /// <summary>
        /// 合并URL
        /// </summary>
        /// <param name="val"></param>
        /// <param name="append"></param>
        /// <returns></returns>
        public static string UriCombine(this string val, string append)
        {
            if (val.IsEmpty())
            {
                return append;
            }

            if (append.IsEmpty())
            {
                return val;
            }

            return val.TrimEnd('/') + "/" + append.TrimStart('/');
        }
        #endregion

        #region 替换


        #endregion

        #region 字符串切割（split扩展）

        /// <summary>
        /// 切割字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="separator">分隔符，支持正则</param>
        /// <returns></returns>
        public static string[] Split(this string str, string separator)
        {
            if (str == null)
                return null;
            if (separator.IsEmpty())
                throw new Exception("不能用空字符串切割");

            return Regex.Split(str, separator, RegexOptions.IgnoreCase);
        }

        #endregion

        #region 不同组合

        /// <summary>
        /// 给出该字符串的各个字母的不同组合
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static IList<string> ToArrange(this string str)
        {
            return str.ToArrange(str.Length, true);
        }

        public static IList<string> ToArrange(this string str, int doubles)
        {
            return str.ToArrange(doubles, true);
        }

        public static IList<string> ToArrange(this string str, bool includeThis)
        {
            return str.ToArrange(str.Length, includeThis);
        }

        /// <summary>
        /// 给出该字符串的各个字母的不同组合
        /// </summary>
        /// <param name="str"></param>
        /// <param name="doubles">定义精度</param>
        /// <returns></returns>
        public static IList<string> ToArrange(this string str, int doubles, bool includeThis)
        {
            var list = new List<string>();
            var result = str.ToCharArray();
            var newString = string.Empty;
            foreach (var s in GetArrangeString(result, doubles, includeThis))
            {
                newString = new String(s);
                if (!list.Contains(newString))
                    list.Add(newString);
            }
            return list;
        }

        private static IEnumerable<char[]> GetArrangeString(char[] list, int X, bool includeThis)
        {
            if (X == 1)
            {
                foreach (var s in list)
                    yield return new char[] { s };
            }
            else if (X > 1)
            {
                for (var i = 0; i < list.Length; i++)
                {
                    char[] newList = null;
                    if (includeThis)
                        newList = list.ToArray();
                    else
                        newList = list.Where((s, p) => p != i).ToArray();
                    foreach (var sub in GetArrangeString(newList, X - 1, includeThis))
                    {
                        for (var j = 0; j < sub.Length; j++)
                        {
                            var ret = sub.ToList();
                            ret.Insert(j, list[i]);
                            yield return ret.ToArray();
                        }
                    }
                }
            }
        }

        #endregion

        #region 随机

        public static string ToRandom(this string s, int length)
        { 
            return s.ToRandom(length, RandomType.Hybrid);
        }

        public static string ToRandom(this string s, int length, RandomType randomType)
        {
            if (length < 1)
                throw new Exception("长度不能小于1");

            var c = string.Empty;

            if (randomType == RandomType.Hybrid)
            {
                var charLen = random.Next(length);
                var numLen = length - charLen;
                for (var i = 0; i < charLen; i++)
                    c += allChars[random.Next(allChars.Length)];
                for (var i = 0; i < numLen; i++)
                    c += allNumbers[random.Next(allNumbers.Length)];
            }
            else if (randomType == RandomType.Char)
            {
                for (var i = 0; i < length; i++)
                    c += allChars[random.Next(allChars.Length)];
            }
            else
            {
                for (var i = 0; i < length; i++)
                    c += allNumbers[random.Next(allNumbers.Length)];
            }
            return c;
        }

        #endregion
    }
}