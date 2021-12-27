using System.Collections.Generic;
using AnfangAPI.Data;
using AnfangAPI.DTOs;
using AnfangAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnfangAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly INodeRepo _nodeRepo;

        public NodesController(IMapper mapper, INodeRepo nodeRepo)
        {
            _mapper = mapper;
            _nodeRepo = nodeRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<NodeReadDto>> GetAllNodes()
        {
            var nodes = _nodeRepo.GetAllNodes();
            if (nodes != null)
            {
                return Ok(_mapper.Map<IEnumerable<NodeReadDto>>(nodes));
            }
            else
            {
                return new EmptyResult();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<NodeReadDto> GetNodeById(int id)
        {
            var node = _nodeRepo.GetNodeById(id);
            return Ok(_mapper.Map<NodeReadDto>(node));
        }
    }
}