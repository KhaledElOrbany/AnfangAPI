using System.ComponentModel.DataAnnotations;

namespace AnfangAPI.DTOs.Plug
{
    public class PlugUpdateDto
    {
        [Required]
        public string NodeName { get; set; }
        [Required]
        public string NodeMacAddress { get; set; }
        public bool NodeState { get; set; }
    }
}
