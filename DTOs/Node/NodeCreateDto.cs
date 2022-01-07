using System.ComponentModel.DataAnnotations;
using static AnfangAPI.Services.Enums;

namespace AnfangAPI.DTOs.Node
{
    public class NodeCreateDto
    {
        [Required]
        public string NodeName { get; set; }
        [Required]
        public string NodeMacAddress { get; set; }
        [Required]
        public NodeTypes Type { get; set; }
    }
}
