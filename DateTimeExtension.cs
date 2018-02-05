using System;
namespace System
{
    public enum DateFormat
    {
        /// <summary>
        /// 通用格式 简写
        /// </summary>
        CommonSmall,
        /// <summary>
        /// 通用格式
        /// </summary>
        Common,
        /// <summary>
        /// 中国时间 简写
        /// </summary>
        ChinaDateSmall,
        /// <summary>
        /// 中国时间 全写
        /// </summary>
        ChinaDate
    }

    public static class DateTimeExtension
    {
        public static string Format(this DateTime? d)
        {
            return Format(d, DateFormat.Common);
        }

        public static DateTime ToDateTime(this DateTime? d)
        {
            if (d == null)
                throw new Exception("不能将null转换为DateTime");
            return Convert.ToDateTime(d);
        }

        public static string Format(this DateTime? d, DateFormat format)
        {
            if (d == null)
                return string.Empty;
            return Format((DateTime)d, format);
        }

        public static string Format(this DateTime d)
        {
            return Format(d, DateFormat.Common);
        }

        public static string Format(this DateTime d, DateFormat format)
        {
            switch (format)
            {
                case DateFormat.Common:
                    return Format(d, "yyyy-MM-dd hh:mm:dd");
                case DateFormat.CommonSmall:
                    return Format(d, "yyyy-MM-dd");
                case DateFormat.ChinaDate:
                    return Format(d, "yyyy年MM月dd日 hh点mm分dd秒");
                case DateFormat.ChinaDateSmall:
                    return Format(d, "yyyy年MM月dd日");
            }

            return string.Empty;
        }

        public static string Format(this DateTime? d, string format)
        {
            if (d == null)
                return string.Empty;

            return ((DateTime)d).Format(format);
        }

        public static string Format(this DateTime d, string format)
        {
            return d.ToString(format);
        }

        public static TimeSpan ToTimeSpan(this DateTime? d)
        {
            return ToTimeSpan(Convert.ToDateTime(d));
        }

        public static TimeSpan ToTimeSpan(this DateTime d)
        {
            return new TimeSpan(d.Hour, d.Minute, d.Second);
        }

        public static string DateStringFromNow(this DateTime? d)
        {
            if (d == null)
                return string.Empty;

            return DateStringFromNow(d.ToDateTime());
        }

        /// <summary>
        /// 获得当前月的第一天
        /// </summary>
        /// <returns></returns>
        public static DateTime FirstDay(this DateTime d)
        {
            return new DateTime(d.Year, d.Month, 1);
        }

        /// <summary>
        /// 获得当前月的最后一天
        /// </summary>
        /// <returns></returns>
        public static DateTime LastDay(this DateTime d)
        {
            var datetime = d.FirstDay().AddMonths(1).AddDays(-1);

            return new DateTime(d.Year, d.Month, datetime.Day, 23, 59, 59);
        }

        /// <summary>
        /// 一天的开始
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateTime DayStart(this DateTime d)
        {
            return new DateTime(d.Year, d.Month, d.Day);
        }

        /// <summary>
        /// 一天的结束
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateTime DayEnd(this DateTime d)
        {
            return new DateTime(d.Year, d.Month, d.Day, 23, 59, 59, 999);
        }

        public static DateTime WeekDayForDateTime(this DateTime d, DayOfWeek weekday, int number)
        {
            int wd1 = (int)weekday;
            int wd2 = (int)d.DayOfWeek;
            return wd2 == wd1 ? d.AddDays(7 * number) : d.AddDays(7 * number - wd2 + wd1);
        }

		/// <summary>
		/// DateTime时间格式转换为Unix时间戳格式
		/// </summary>
		/// <param name="time"> DateTime时间格式</param>
		/// <returns>Unix时间戳格式</returns>
		public static int GetTimespan(this DateTime time)
		{
			System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
			return (int)(time - startTime).TotalSeconds;
		}

		public static string DateStringFromNow(this DateTime d)
        {
            TimeSpan span = DateTime.Now - d;
            if (span.TotalDays > 60)
            {
                return d.ToShortDateString();
            }
            else
                if (span.TotalDays > 30)
                {
                    return "1个月前";
                }
                else
                    if (span.TotalDays > 14)
                    {
                        return "2周前";
                    }
                    else
                        if (span.TotalDays > 7)
                        {
                            return "1周前";
                        }
                        else
                            if (span.TotalDays > 1)
                            {
                                return string.Format("{0}天前", (int)Math.Floor(span.TotalDays));
                            }
                            else
                                if (span.TotalHours > 1)
                                {
                                    return string.Format("{0}小时前", (int)Math.Floor(span.TotalHours));
                                }
                                else
                                    if (span.TotalMinutes > 1)
                                    {
                                        return string.Format("{0}分钟前", (int)Math.Floor(span.TotalMinutes));
                                    }
                                    else
                                        if (span.TotalSeconds >= 1)
                                        {
                                            return string.Format("{0}秒前", (int)Math.Floor(span.TotalSeconds));
                                        }
                                        else
                                        {
                                            return "1秒前";
                                        }
        }
    }
}