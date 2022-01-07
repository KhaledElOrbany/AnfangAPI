namespace AnfangAPI.DTOs.Light
{
    public class LightReadDto
    {
        public int Id { get; set; }
        public string NodeName { get; set; }
        public string NodeMacAddress { get; set; }
        public bool NodeState { get; set; }
    }
}