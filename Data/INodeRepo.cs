using System.Collections.Generic;
using AnfangAPI.Models;

namespace AnfangAPI.Data
{
    public interface INodeRepo
    {
        IEnumerable<Node> GetAllNodes();
        Node GetNodeById(int id);
    }
}