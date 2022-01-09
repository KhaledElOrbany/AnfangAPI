using System.ComponentModel.DataAnnotations;
using static AnfangAPI.Services.Enums;

namespace AnfangAPI.DTOs
{
    public class NodeUpdateDto
    {
        // Common Properties
        [Required]
        public string NodeName { get; set; }
        [Required]
        public string NodeMacAddress { get; set; }
        [Required]
        public NodeTypes Type { get; set; }
        public WifiState WifiState { get; set; }
        public bool NodeState { get; set; }

        // Light Properties
        public float Brightness { get; set; }

        // Plug Properties
        public double Limit { get; set; }
        public double SensorReading { get; set; }
    }
}
