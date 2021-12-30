using System.Text.Json;

namespace AnfangAPI.Services
{
    public class JsonObject
    {
        public string response { get; set; }
    }

    public static class Globals
    {
        public static string ToJSON(this object obj)
        {
            if (obj != null)
            {
                return JsonSerializer.Serialize(obj);
            }
            else
            {
                return null;
            }
        }
    }
}