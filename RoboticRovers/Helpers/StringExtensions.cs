using System;
using System.Collections;
using System.Reflection;

namespace RoboticRovers.Helpers
{
    /// <summary>String Extensions</summary>
    public static class StringExtensions
    {
        public static string ToStringValue(this Enum value)
        {
           return StringEnum.GetStringValue(value);
        }

        public static T ToEnum<T>(this string stringValue, bool ignoreCase)
        {
            return StringEnum.GetEnumValue<T>(stringValue, ignoreCase);
        }
    } 
}
