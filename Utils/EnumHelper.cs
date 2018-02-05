using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace System.Utils
{
    public class EnumHelper
    {
        public static string GetDescription(object value)
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            if (name != null)
            {
                var field = type.GetField(name);
                if (field != null)
                {
                    var attr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr == null)
                        return name;
                    else
                        return attr.Description;
                }
            }
            return null;
        }

		public static DisplayAttribute GetDisplay(object value)
		{
			var type = value.GetType();
			var name = Enum.GetName(type, value);
			if (name != null)
			{
				var field = type.GetField(name);
				if (field != null)
				{
					var attr = Attribute.GetCustomAttribute(field, typeof(DisplayAttribute)) as DisplayAttribute;
					if (attr == null)
						return new DisplayAttribute { };
					else
						return attr;
				}
			}
			return new DisplayAttribute { };
		}
    }
}
