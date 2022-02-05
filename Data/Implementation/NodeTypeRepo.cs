using System.Collections.Generic;
using AnfangAPI.Data.Interfaces;
using AnfangAPI.Models;
using AnfangAPI.Services;

namespace AnfangAPI.Data.Implementation
{
    public class NodeTypeRepo : INodeTypeRepo
    {
        Enums.ReturnStates INodeTypeRepo.CreateLight(NodeType nodeType)
        {
            throw new System.NotImplementedException();
        }

        Enums.ReturnStates INodeTypeRepo.DeleteLight(NodeType nodeType)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<NodeType> INodeTypeRepo.GetAllLights()
        {
            throw new System.NotImplementedException();
        }

        NodeType INodeTypeRepo.GetLightById(int id)
        {
            throw new System.NotImplementedException();
        }

        bool INodeTypeRepo.SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        void INodeTypeRepo.UpdateLight(NodeType nodeType)
        {
            throw new System.NotImplementedException();
        }
    }
}