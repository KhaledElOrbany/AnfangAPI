using System.Collections.Generic;
using AnfangAPI.Data.Interfaces;
using AnfangAPI.DTOs.Node;
using AnfangAPI.Models;
using AnfangAPI.Services;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using static AnfangAPI.Services.Enums;

namespace AnfangAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly INodeRepo _nodeRepo;
        private readonly IPlugRepo _plugRepo;
        private readonly ILightRepo _lightRepo;

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
            var res = _nodeRepo.CreateNode(nodeModel);

            if (res == ReturnStates.Created)
            {
                _nodeRepo.SaveChanges();

                var nodeReadDto = _mapper.Map<NodeReadDto>(nodeModel);
                return CreatedAtRoute(nameof(GetNodeById), new { Id = nodeReadDto.Id }, nodeReadDto);
            }
            else
            {
                JsonObject jsonObject = new JsonObject();
                jsonObject.response = "The node has not been created, due to duplicate.";
                return new JsonResult(jsonObject.ToJSON());
            }
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
            var res = _nodeRepo.DeleteNode(node);
            JsonObject jsonObject = new JsonObject();
            if (res == ReturnStates.Deleted)
            {
                _nodeRepo.SaveChanges();
                jsonObject.response = "Node has been deleted successfully.";
            }
            else
            {
                jsonObject.response = "Node has not been deleted!";
            }
            return new JsonResult(jsonObject.ToJSON());
        }
    }
}