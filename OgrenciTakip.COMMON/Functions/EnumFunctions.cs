using System;
using System.Collections;
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

        public static ICollection GetEnumDescriptionList<T>()
        {
            return typeof(T).GetMembers()
                .SelectMany(x => x.GetCustomAttributes(typeof(DescriptionAttribute), true)
                .Cast<DescriptionAttribute>())
                .Select(x => x.Description)
                .ToList();
        }
        public static T GetEnum<T>(this string description)
        {
            var enumNames = Enum.GetNames(typeof(T));

            foreach (var e in enumNames.Select(x=>Enum.Parse(typeof(T),x)).Where(y=>description==ToName((Enum)y)))
            {
                return (T)e;
            }
            return default(T);
        }
    }
}
