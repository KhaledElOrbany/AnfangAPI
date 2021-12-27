using System.ComponentModel.DataAnnotations;

namespace AnfangAPI.DTOs
{
    public class NodeCreateDto
    {
        [Required]
        public string NodeName { get; set; }
        [Required]
        public string NodeMacAddress { get; set; }
        public bool NodeState { get; set; }
    }
}
