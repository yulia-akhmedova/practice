using System;
using System.ComponentModel;
using System.Linq;

namespace CharacterCreatorMenu.Extensions
{
    public static class EnumExtensions
    {
        private static void IsEnum<T>()
             where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("Type must represent an enumeration");
            }
        }

        public static string GetDescription<T>(this T enumValue)
            where T : struct
        {
            IsEnum<T>();

            var description = enumValue.ToString();
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            if (fieldInfo != null)
            {
                var attrs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attrs != null && attrs.Length > 0)
                {
                    description = ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return description;
        }

        public static bool GetEnumFromDescription<T>(string description, out T enumValue)
            where T : struct
        {
            IsEnum<T>();

            T[] enumArray = GetEnumArray<T>();
            enumValue = enumArray.FirstOrDefault(a => a.GetDescription().ToLower() == description.ToLower());

            return enumArray.Any(a => a.GetDescription().ToLower() == description.ToLower());
        }

        public static T[] GetEnumArray<T>()
            where T : struct
        {
            IsEnum<T>();

            return (T[])Enum.GetValues(typeof(T));
        }

    }
}