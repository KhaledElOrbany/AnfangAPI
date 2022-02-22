using AnfangAPI.DTOs.Node;
using AnfangAPI.Models;
using AutoMapper;

namespace AnfangAPI.Profiles
{
    class NodeProfile : Profile
    {
        public NodeProfile()
        {
            // Node: Source -> target
            CreateMap<Node, NodeReadDto>();
            CreateMap<NodeCreateDto, Node>();
            CreateMap<NodeUpdateDto, Node>();
            CreateMap<Node, NodeUpdateDto>();

            // Plug: Source -> target
            CreateMap<Plug, NodeReadDto>();
            CreateMap<NodeCreateDto, Plug>();
            CreateMap<NodeUpdateDto, Plug>();
            CreateMap<Plug, NodeUpdateDto>();

            // Light: Source -> target
            CreateMap<Light, NodeReadDto>();
            CreateMap<NodeCreateDto, Light>();
            CreateMap<NodeUpdateDto, Light>();
            CreateMap<Light, NodeUpdateDto>();
        }
    }
}