namespace AnfangAPI.DTOs.Plug
{
    public class PlugReadDto
    {
        public int Id { get; set; }
        public string NodeName { get; set; }
        public string NodeMacAddress { get; set; }
        public bool NodeState { get; set; }
    }
}