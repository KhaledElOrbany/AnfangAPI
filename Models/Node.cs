namespace AnfangAPI.Models
{
    public class Node
    {
        public int Id { get; set; }
        public string NodeName { get; set; }
        public string NodeMacAddress { get; set; }
        public bool NodeState { get; set; }
        public string Data { get; set; }
    }
}