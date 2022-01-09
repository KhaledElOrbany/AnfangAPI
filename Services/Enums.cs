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
            [Description("Humidity Sensor")]
            HumiditySensor = 3,
            [Description("Temperature Sensor")]
            TemperatureSensor = 4,
            DoorSensor = 5
        }

        public enum ReturnStates
        {
            Created = 1,
            Updated = 2,
            Deleted = 3,
            Duplicate = 4
        }

        public enum WifiState
        {
            [Description("Wifi Is Closed")]
            wifiIsClosed = 0,
            [Description("Wifi Is Opened")]
            wifiIsOpened = 1
        }

        public enum JsonResponseMsg
        {
            [Description("Node not found!")]
            NodeNotFound = 1,
            [Description("Something went wrong")]
            SomethingWentWrong = 2,
            [Description("Node has not been created, due to duplicate.")]
            DuplicateError = 3,
            [Description("Node has been successfully created.")]
            SuccessfullyCreated = 4,
            [Description("Node has been deleted successfully.")]
            SuccessfullyDeleted = 5,
            [Description("Node has not been deleted!")]
            HasNotBeenDeleted = 6,
            [Description("Node has been successfully updated.")]
            SuccessfullyUpdated = 7
        }
    }
}