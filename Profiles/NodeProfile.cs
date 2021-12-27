using AnfangAPI.DTOs;
using AnfangAPI.Models;
using AutoMapper;

namespace AnfangAPI.Profiles
{
    class NodeProfile : Profile
    {
        public NodeProfile()
        {
            // Source -> target
            CreateMap<Node, NodeReadDto>();
            CreateMap<NodeCreateDto, Node>();
            CreateMap<NodeUpdateDto, Node>();
        }
    }
}