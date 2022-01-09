using System.Collections.Generic;
using AnfangAPI.Business;
using AnfangAPI.Data.Interfaces;
using AnfangAPI.DTOs;
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

        public NodesController(IMapper mapper, INodeRepo nodeRepo, IPlugRepo plugRepo, ILightRepo lightRepo)
        {
            _mapper = mapper;
            _nodeRepo = nodeRepo;
            _plugRepo = plugRepo;
            _lightRepo = lightRepo;
        }

        //GET api/nodes/
        [HttpGet]
        public ActionResult<IEnumerable<NodeReadDto>> GetAllNodes()
        {
            List<NodeReadDto> nodes = new List<NodeReadDto>();
            nodes.AddRange(_mapper.Map<IEnumerable<NodeReadDto>>(_plugRepo.GetAllPlugs()));
            nodes.AddRange(_mapper.Map<IEnumerable<NodeReadDto>>(_lightRepo.GetAllLights()));

            if (nodes != null)
            {
                return Ok(_mapper.Map<IEnumerable<NodeReadDto>>(nodes));
            }
            else
            {
                return NotFound();
            }
        }

        //GET api/nodes/{type}
        [HttpGet("{type}")]
        public ActionResult<NodeReadDto> GetNodesByType(int type)
        {
            if (type == (int)NodeTypes.Plug)
            {
                var plugs = _plugRepo.GetAllPlugs();
                if (plugs == null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<IEnumerable<NodeReadDto>>(plugs));
            }
            else if (type == (int)NodeTypes.Light)
            {
                var lights = _lightRepo.GetAllLights();
                if (lights == null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<IEnumerable<NodeReadDto>>(lights));
            }
            return NotFound();
        }

        //GET api/nodes/{type}/{id}
        [HttpGet("{type}/{id}", Name = "GetNodeById")]
        public ActionResult<NodeReadDto> GetNodeById(int type, int id)
        {
            if (type == (int)NodeTypes.Plug)
            {
                var node = _plugRepo.GetPlugById(id);
                if (node == null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<NodeReadDto>(node));
            }
            else if (type == (int)NodeTypes.Light)
            {
                var node = _lightRepo.GetLightById(id);
                if (node == null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<NodeReadDto>(node));
            }
            return NotFound();
        }

        //POST api/nodes
        [HttpPost]
        public ActionResult<NodeReadDto> CreateNode(NodeCreateDto nodeCreateDto)
        {
            if (nodeCreateDto.Type == NodeTypes.Plug)
            {
                PlugBS plugBS = new PlugBS(_mapper, _plugRepo);
                JsonObject jsonObject = plugBS.CreatePlugNode(nodeCreateDto);

                return CreatedAtRoute(nameof(GetNodeById),
                new { type = (int)NodeTypes.Plug, Id = jsonObject.NodeReadDto.Id }, jsonObject.NodeReadDto);
            }
            else if (nodeCreateDto.Type == NodeTypes.Light)
            {
                LightBS lightBS = new LightBS(_mapper, _lightRepo);
                JsonObject jsonObject = lightBS.CreateLightNode(nodeCreateDto);

                return CreatedAtRoute(nameof(GetNodeById),
                new { type = (int)NodeTypes.Light, Id = jsonObject.NodeReadDto.Id }, jsonObject.NodeReadDto);
            }
            else
            {
                JsonObject jsonObject = new JsonObject();
                jsonObject.response = JsonResponseMsg.SomethingWentWrong.GetEnumDescription();
                return new JsonResult(jsonObject.ToJSON());
            }
        }

        //POST api/nodes/{id}
        [HttpPut("{type}/{id}")]
        public ActionResult UpdateNode(int type, int id, NodeUpdateDto nodeUpdateDto)
        {
            if (type == (int)NodeTypes.Plug)
            {
                PlugBS plugBS = new PlugBS(_mapper, _plugRepo);
                plugBS.UpdatePlugNode(id, nodeUpdateDto);
            }
            else if (type == (int)NodeTypes.Light)
            {
                LightBS lightBS = new LightBS(_mapper, _lightRepo);
                lightBS.UpdateLightNode(id, nodeUpdateDto);
            }

            return NoContent();
        }

        //Patch api/nodes/{type}/{id}
        [HttpPatch("{type}/{id}")]
        public ActionResult PartialUpdateNode(int type, int id, JsonPatchDocument<NodeUpdateDto> patchDoc)
        {
            NodeUpdateDto nodeToPatch = null;
            if (type == (int)NodeTypes.Plug)
            {
                var plugModel = _plugRepo.GetPlugById(id);
                if (plugModel == null)
                {
                    return NotFound();
                }
                nodeToPatch = _mapper.Map<NodeUpdateDto>(plugModel);

                // Then, we apply the patch to it
                patchDoc.ApplyTo(nodeToPatch, ModelState);
                // Then, check if the patch update is done successfully
                if (!TryValidateModel(nodeToPatch))
                {
                    return ValidationProblem(ModelState);
                }
                _mapper.Map(nodeToPatch, plugModel);
                _plugRepo.UpdatePlug(plugModel);
                _plugRepo.SaveChanges();
            }
            else if (type == (int)NodeTypes.Light)
            {
                var lightModel = _lightRepo.GetLightById(id);
                if (lightModel == null)
                {
                    return NotFound();
                }
                nodeToPatch = _mapper.Map<NodeUpdateDto>(lightModel);

                // Then, we apply the patch to it
                patchDoc.ApplyTo(nodeToPatch, ModelState);
                // Then, check if the patch update is done successfully
                if (!TryValidateModel(nodeToPatch))
                {
                    return ValidationProblem(ModelState);
                }
                _mapper.Map(nodeToPatch, lightModel);
                _lightRepo.UpdateLight(lightModel);
                _lightRepo.SaveChanges();
            }


            return NoContent();
        }

        //Delete api/nodes/{type}/{id}
        [HttpDelete("{type}/{id}")]
        public ActionResult DeleteNode(int type, int id)
        {
            JsonObject jsonObject = new JsonObject();
            if (type == (int)NodeTypes.Plug)
            {
                PlugBS plugBS = new PlugBS(_mapper, _plugRepo);
                jsonObject = plugBS.DeletePlugNode(id);
                return new JsonResult(jsonObject.ToJSON());
            }
            else if (type == (int)NodeTypes.Light)
            {
                LightBS lightBS = new LightBS(_mapper, _lightRepo);
                jsonObject = lightBS.DeleteLightNode(id);
                return new JsonResult(jsonObject.ToJSON());
            }
            else
            {
                jsonObject.response = JsonResponseMsg.SomethingWentWrong.GetEnumDescription();
                return new JsonResult(jsonObject.ToJSON());
            }
        }
    }
}