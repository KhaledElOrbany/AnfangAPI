using AnfangAPI.DTOs.Node;
using AnfangAPI.DTOs.NodeType;
using AnfangAPI.Models;
using AutoMapper;

namespace AnfangAPI.Profiles
{
    public class NodeTypesProfile : Profile
    {
        public NodeTypesProfile()
        {
            // Node: Source -> target
            CreateMap<NodeType, NodeTypeReadDto>();
            // CreateMap<NodeCreateDto, NodeType>();
            // CreateMap<NodeUpdateDto, NodeType>();
            // CreateMap<NodeType, NodeUpdateDto>();
        }
    }
}