using System.Collections.Generic;
using AnfangAPI.Data.Interfaces;
using AnfangAPI.DTOs.NodeType;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnfangAPI.controller
{
    [Route("api/[controller]")]
    [ApiController]
    class NodeTypesController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly INodeTypeRepo _nodeTypeRepo;

        public NodeTypesController(INodeTypeRepo nodeTypeRepo, IMapper mapper)
        {
            this._mapper = mapper;
            this._nodeTypeRepo = nodeTypeRepo;
        }

        //GET api/NodeTypes
        [HttpGet]
        public ActionResult<IEnumerable<NodeTypeReadDto>> GetNodeTypes()
        {
            return new EmptyResult();
        }
    }
}