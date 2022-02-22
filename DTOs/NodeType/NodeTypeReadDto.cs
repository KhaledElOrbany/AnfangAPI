using static AnfangAPI.Services.Enums;

namespace AnfangAPI.DTOs.NodeType
{
    public class NodeTypeReadDto
    {
        public int Id { get; set; }
        public NodeTypes NodeTypeId { get; set; }
        public string NodeTypeName { get; set; }
    }
}