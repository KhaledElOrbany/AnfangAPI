using static AnfangAPI.Services.Enums;

namespace AnfangAPI.DTOs.Node
{
    public class NodeReadDto
    {
        public int Id { get; set; }
        public NodeTypes Type { get; set; }
        public string NodeName { get; set; }
        public string NodeMacAddress { get; set; }
        public bool NodeState { get; set; }
    }
}