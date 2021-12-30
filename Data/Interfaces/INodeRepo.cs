using System.Collections.Generic;
using AnfangAPI.Models;
using static AnfangAPI.Services.Enums;

namespace AnfangAPI.Data.Interfaces
{
    public interface INodeRepo
    {
        bool SaveChanges();
        IEnumerable<Node> GetAllNodes();
        Node GetNodeById(int id);
        ReturnStates CreateNode(Node node);
        void UpdateNode(Node node);
        void DeleteNode(Node node);
    }
}