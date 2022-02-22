using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<NodeType> GetAllNodeTypes()
        {
            return this.dataBaseContext.NodeTypes.ToList();
        }

        public NodeType GetNodeTypeById(int id)
        {
            return this.dataBaseContext.NodeTypes.FirstOrDefault(x => x.Id == id);
        }

        public ReturnStates CreateNodeType(NodeType nodeType)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateNodeType(NodeType nodeType)
        {
            throw new System.NotImplementedException();
        }

        public ReturnStates DeleteNodeType(NodeType nodeType)
        {
            throw new System.NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}