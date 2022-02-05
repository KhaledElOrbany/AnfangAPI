using System.Collections.Generic;
using AnfangAPI.Models;
using static AnfangAPI.Services.Enums;

namespace AnfangAPI.Data.Interfaces
{
    public interface INodeTypeRepo
    {
        bool SaveChanges();
        IEnumerable<NodeType> GetAllLights();
        NodeType GetLightById(int id);
        ReturnStates CreateLight(NodeType nodeType);
        void UpdateLight(NodeType nodeType);
        ReturnStates DeleteLight(NodeType nodeType);
    }
}