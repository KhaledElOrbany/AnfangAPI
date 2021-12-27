using System.Collections.Generic;
using AnfangAPI.Models;

namespace AnfangAPI.Data.Interfaces
{
    public interface INodeRepo
    {
        bool SaveChanges();
        IEnumerable<Node> GetAllNodes();
        Node GetNodeById(int id);
        void CreateNode(Node node);
        void UpdateNode(Node node);
        void PartialUpdateNode(Node node);
    }
}