using System.Collections.Generic;
using AnfangAPI.Data.Interfaces;
using AnfangAPI.DTOs;
using AnfangAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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
                return NotFound();
            }
        }

        //GET api/nodes/{id}
        [HttpGet("{id}", Name = "GetNodeById")]
        public ActionResult<NodeReadDto> GetNodeById(int id)
        {
            var node = _nodeRepo.GetNodeById(id);
            if (node == null)
            {
                return NotFound();
            }
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

        //Patch api/nodes/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialUpdateNode(int id, JsonPatchDocument<NodeUpdateDto> patchDoc)
        {
            // Check if we have the resource to update
            var node = _nodeRepo.GetNodeById(id);
            if (node == null)
            {
                return NotFound();
            }

            // Then, we generate the DTO from the model
            var nodeToPatch = _mapper.Map<NodeUpdateDto>(node);

            // Then, we apply the patch to it
            patchDoc.ApplyTo(nodeToPatch, ModelState);
            // Then, check if the patch update is done successfully
            if (!TryValidateModel(nodeToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(nodeToPatch, node);
            _nodeRepo.UpdateNode(node);
            _nodeRepo.SaveChanges();
            return NoContent();
        }

        //Delete api/nodes/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteNode(int id)
        {
            var node = _nodeRepo.GetNodeById(id);
            if (node == null)
            {
                return NotFound();
            }
            _nodeRepo.DeleteNode(node);
            _nodeRepo.SaveChanges();
            return NoContent();
        }
    }
}