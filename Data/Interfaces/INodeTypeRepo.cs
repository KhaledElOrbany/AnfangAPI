using System.Collections.Generic;
using AnfangAPI.Models;
using static AnfangAPI.Services.Enums;

namespace AnfangAPI.Data.Interfaces
{
    public interface INodeTypeRepo
    {
        public bool SaveChanges();
        public IEnumerable<NodeType> GetAllNodeTypes();
        public NodeType GetNodeTypeById(int id);
        public ReturnStates CreateNodeType(NodeType nodeType);
        public void UpdateNodeType(NodeType nodeType);
        public ReturnStates DeleteNodeType(NodeType nodeType);
    }
}