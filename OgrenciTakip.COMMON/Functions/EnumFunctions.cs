using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciTakip.COMMON.Functions
{
   public static class EnumFunctions
    {
        private static T GetAttribute<T>(this Enum value) where T:Attribute
        {
            if (value==null)
            {
                return null;
            }

            var memberInfo = value.GetType().GetMember(value.ToString());
            var attribute = memberInfo[0].GetCustomAttributes(typeof(T), false);

            return (T)attribute[0];
        }

        public static string ToName(this Enum value)
        {
            if (value == null)
            {
                return null;
            }

            var attribute = value.GetAttribute<DescriptionAttribute>();
            return attribute == null ? value.ToString() : attribute.Description;

        }
    }
}
