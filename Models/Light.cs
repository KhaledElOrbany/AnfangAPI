using System.ComponentModel.DataAnnotations;
using static AnfangAPI.Services.Enums;

namespace AnfangAPI.Models
{
    public class Light
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NodeName { get; set; }
        [Required]
        public string NodeMacAddress { get; set; }
        public bool NodeState { get; set; }
        [Required]
        public NodeTypes Type { get; set; }
        public WifiState WifiState { get; set; }
        public float Brightness { get; set; }

        //TODO: Add online property
    }
}