using static AnfangAPI.Services.Enums;

namespace AnfangAPI.Models
{
    public class Plug : Node
    {
        public NodeTypes Type { get; set; }
        public double Limit { get; set; }
        public double SensorReading { get; set; }
    }
}