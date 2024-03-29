﻿using BookingService.Maui.Model;
using System.ComponentModel;
using System.Reflection;

namespace BookingService.Maui.Helpers
{
    public static class Extension
    {
        public static bool IsNullOrEmpty<T>(this List<T> source)
        {
            if (source != null && source.Any())
                return true;
            else
                return false;
        }
        public static string GetDescription(this Enum value)
        {
            Type type = value.GetType();
            string? name = Enum.GetName(type, value);

            if (name != null)
            {
                FieldInfo? field = type.GetField(name);
                if (field != null && Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                    return attribute.Description;
            }

            return name ?? "";
        }
        public static List<IdName> GetListFromEnum<TEnum>() where TEnum : Enum
        {
            var list = new List<IdName>();
            foreach (TEnum enumValue in Enum.GetValues(typeof(TEnum)))
            {
                IdName idName = new()
                {
                    Name = enumValue.GetDescription(),
                    Id = Convert.ToInt32(enumValue)
                };
                list.Add(idName);
            }
            return list;
        }
    }
}
