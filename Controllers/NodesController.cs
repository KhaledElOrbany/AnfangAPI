using System.Collections.Generic;
using AnfangAPI.Data.Interfaces;
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

        //GET api/nodes/
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

        //GET api/nodes/{id}
        [HttpGet("{id}", Name = "GetNodeById")]
        public ActionResult<NodeReadDto> GetNodeById(int id)
        {
            var node = _nodeRepo.GetNodeById(id);
            return Ok(_mapper.Map<NodeReadDto>(node));
        }

        //POST api/nodes
        [HttpPost]
        public ActionResult<NodeReadDto> CreateNode(NodeCreateDto nodeCreateDto)
        {
            var nodeModel = _mapper.Map<Node>(nodeCreateDto);
            _nodeRepo.CreateNode(nodeModel);
            _nodeRepo.SaveChanges();

            var nodeReadDto = _mapper.Map<NodeReadDto>(nodeModel);
            return CreatedAtRoute(nameof(GetNodeById), new { Id = nodeReadDto.Id }, nodeReadDto);
        }

        //POST api/nodes/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateNode(int id, NodeUpdateDto nodeUpdateDto)
        {
            var node = _nodeRepo.GetNodeById(id);
            if (node == null)
            {
                return NotFound();
            }
            _mapper.Map(nodeUpdateDto, node);
            _nodeRepo.UpdateNode(node);
            _nodeRepo.SaveChanges();
            return NoContent();
        }
    }
}