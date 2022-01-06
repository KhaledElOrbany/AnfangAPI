using AnfangAPI.Services;
using static AnfangAPI.Services.Enums;

namespace AnfangAPI.Models
{
    public class NodeType
    {
        public int Id { get; set; }
        public NodeTypes NodeTypeId { get; set; }
        public string NodeTypeName { get; set; }
    }
}