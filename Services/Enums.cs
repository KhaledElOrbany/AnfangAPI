using System;
using System.ComponentModel;

namespace AnfangAPI.Services
{
    public static class EnumExtensionMethods
    {
        public static string GetEnumDescription(this Enum enumValue)
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : enumValue.ToString();
        }
    }

    public class Enums
    {
        public enum NodeTypes
        {
            Plug = 1,
            Light = 2,
            Fridge = 3
        }

        public enum ReturnStates
        {
            Created = 1,
            Updated = 2,
            Deleted = 3,
            Duplicate = 4
        }
    }
}