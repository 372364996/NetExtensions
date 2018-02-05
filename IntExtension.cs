using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    public static class IntExtension
    {
        public static int ToInt32(this int? i)
        {
            return Convert.ToInt32(i);
        }

        /// <summary>
        /// 转换为Int32
        /// </summary>
        /// <param name="i"></param>
        /// <param name="defaultValue">默认值:如果该值为null，返回默认值</param>
        /// <returns></returns>
        public static int ToInt32(this int? i, int defaultValue)
        {
            if (i == null)
                return defaultValue;

            return ToInt32(i);
        }

        public static long ToInt64(this long? i)
        {
            return i.ToLong();
        }

        public static long ToLong(this long? i)
        {
            return Convert.ToInt64(i);
        }

        /// <summary>
        /// 将整数转换为可为0开头的流水号
        /// </summary>
        /// <param name="i"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string ToStringNumber(this int? i, int length)
        {
            return i.ToInt32().ToStringNumber(length);
        }

        /// <summary>
        /// 将整数转换为可为0开头的流水号
        /// </summary>
        /// <param name="i"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string ToStringNumber(this int i, int length)
        {
            var iLen = i.ToString().Length;

            if (length < iLen)
                throw new Exception("整数本身的长度不能大于指定长度");

            if (iLen == length)
                return i.ToString();

            var number = string.Empty;
            for (var n = 0; n < length - iLen; n++)
            {
                number += "0";
            }

            return number + i;
        }

        public static decimal ToDecimal(this int i)
        {
            return Convert.ToDecimal(i);
        }
    }
}
