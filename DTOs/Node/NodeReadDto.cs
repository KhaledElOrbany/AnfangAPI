namespace AnfangAPI.DTOs.Node
{
    public class NodeReadDto
    {
        public int Id { get; set; }
        public string NodeName { get; set; }
        public string NodeMacAddress { get; set; }
        public bool NodeState { get; set; }
    }
}