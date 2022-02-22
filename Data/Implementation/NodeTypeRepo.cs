using System.Collections.Generic;
using AnfangAPI.Data.Interfaces;
using AnfangAPI.DataContext;
using AnfangAPI.Models;
using AnfangAPI.Services;
using static AnfangAPI.Services.Enums;

namespace AnfangAPI.Data.Implementation
{
    public class NodeTypeRepo : INodeTypeRepo
    {
        private readonly DataBaseContext dataBaseContext;

        public NodeTypeRepo(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        public ReturnStates CreateNodeType(NodeType nodeType)
        {
            throw new System.NotImplementedException();
        }

        public ReturnStates DeleteNodeType(NodeType nodeType)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<NodeType> GetAllNodeTypes()
        {
            throw new System.NotImplementedException();
        }

        public NodeType GetNodeTypeById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateNodeType(NodeType nodeType)
        {
            throw new System.NotImplementedException();
        }
    }
}