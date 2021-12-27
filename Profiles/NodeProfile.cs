using AnfangAPI.DTOs;
using AnfangAPI.Models;
using AutoMapper;

namespace AnfangAPI.Profiles
{
    class NodeProfile : Profile
    {
        public NodeProfile()
        {
            CreateMap<Node, NodeReadDto>();
        }
    }
}