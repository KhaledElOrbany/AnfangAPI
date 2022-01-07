using AnfangAPI.DTOs.Light;
using AnfangAPI.DTOs.Node;
using AnfangAPI.DTOs.Plug;
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
            CreateMap<Plug, PlugReadDto>();
            CreateMap<PlugCreateDto, Plug>();
            CreateMap<PlugUpdateDto, Plug>();
            CreateMap<Plug, PlugUpdateDto>();

            // Light: Source -> target
            CreateMap<Light, LightReadDto>();
            CreateMap<LightCreateDto, Light>();
            CreateMap<LightUpdateDto, Light>();
            CreateMap<Light, LightUpdateDto>();
        }
    }
}