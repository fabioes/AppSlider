using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace AppSlider.Utils.Enum
{
    public static class EnumUtils
    {
        public static string GetDescription<T>(this T e) where T : IConvertible
        {
            if ((e is System.Enum) == false) return string.Empty;

            Type type = e.GetType();
            var enumValue = System.Enum.GetValues(type).OfType<int>()
                .FirstOrDefault(f => f == e.ToInt32(CultureInfo.InvariantCulture));

            var enumName = type.GetEnumName(enumValue);
            var memInfo = type.GetMember(enumName);
            var descriptionAttribute = memInfo[0]
                        .GetCustomAttributes(typeof(DescriptionAttribute), false)
                        .FirstOrDefault() as DescriptionAttribute;


            return descriptionAttribute != null
                    ? descriptionAttribute.Description
                    : (enumName ?? String.Empty);
        }

        public static T GetValueFromDescription<T>(string description)
        {
            var type = typeof(T);

            if (!type.IsEnum) throw new InvalidOperationException();

            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }

            throw new ArgumentException("Not found.", "description");
            // or return default(T);
        }
    }
}
