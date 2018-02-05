using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    public static class DoubleExtension
    {
        public static decimal ToDecimal(this double d)
        {
            return Convert.ToDecimal(d);
        }

        public static decimal ToDecimal(this double? d)
        {
            if (d == null)
                return 0;
            return Convert.ToDecimal(d);
        }

        public static decimal ToDecimal(this decimal? d)
        {
            if (d == null)
                return 0;

            return Convert.ToDecimal(d);
        }

		public static string ToString(this decimal? d, string format)
		{
			if (!d.HasValue)
				return string.Empty;

			return d.Value.ToString(format);
		}

	}
}
