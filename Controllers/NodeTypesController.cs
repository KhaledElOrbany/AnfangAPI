using System.Collections.Generic;
using AnfangAPI.Data.Interfaces;
using AnfangAPI.DTOs.NodeType;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnfangAPI.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodeTypesController : ControllerBase
    {
        private readonly IMapper mapper;

        private readonly INodeTypeRepo nodeTypeRepo;

        public NodeTypesController(INodeTypeRepo nodeTypeRepo, IMapper mapper)
        {
            this.mapper = mapper;
            this.nodeTypeRepo = nodeTypeRepo;
        }

        //GET api/nodetypes
        [HttpGet]
        public ActionResult<IEnumerable<NodeTypeReadDto>> GetNodeTypes()
        {
            List<NodeTypeReadDto> nodeTypes = new List<NodeTypeReadDto>();
            nodeTypes.AddRange(this.mapper.Map<IEnumerable<NodeTypeReadDto>>(this.nodeTypeRepo.GetAllNodeTypes()));

            if (nodeTypes != null)
            {
                return Ok(nodeTypes);
            }
            else
            {
                return NotFound();
            }
        }

        //GET api/nodetypes/{id}
        [HttpGet("{typeId}")]
        public ActionResult<NodeTypeReadDto> GetNodeTypeById(int typeId)
        {
            var nodeType = this.nodeTypeRepo.GetNodeTypeById(typeId);

            if (nodeType != null)
            {
                return Ok(this.mapper.Map<NodeTypeReadDto>(nodeType));
            }
            else
            {
                return NotFound();
            }
        }
    }
}