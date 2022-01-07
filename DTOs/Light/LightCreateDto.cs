using System.ComponentModel.DataAnnotations;
using static AnfangAPI.Services.Enums;

namespace AnfangAPI.DTOs.Light
{
    public class LightCreateDto
    {
        [Required]
        public string NodeName { get; set; }
        [Required]
        public string NodeMacAddress { get; set; }
        public bool NodeState { get; set; }
        public NodeTypes Type { get; set; }
    }
}
