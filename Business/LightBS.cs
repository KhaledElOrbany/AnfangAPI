using System;
using AnfangAPI.Data.Interfaces;
using AnfangAPI.DTOs.Node;
using AnfangAPI.Models;
using AnfangAPI.Services;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using static AnfangAPI.Services.Enums;

namespace AnfangAPI.Business
{
    public class LightBS
    {
        private readonly IMapper _mapper;
        private readonly ILightRepo _lightRepo;

        public LightBS(IMapper mapper, ILightRepo lightRepo)
        {
            _mapper = mapper;
            _lightRepo = lightRepo;
        }

        public JsonObject CreateLightNode(NodeCreateDto nodeCreateDto)
        {
            var lightModel = _mapper.Map<Light>(nodeCreateDto);
            var res = _lightRepo.CreateLight(lightModel);

            JsonObject jsonObject = new JsonObject();
            if (res == ReturnStates.Created)
            {
                _lightRepo.SaveChanges();

                jsonObject.NodeReadDto = _mapper.Map<NodeReadDto>(lightModel);
                jsonObject.response = JsonResponseMsg.SuccessfullyCreated.GetEnumDescription();
                return jsonObject;
            }
            else
            {
                jsonObject.NodeReadDto = null;
                jsonObject.response = JsonResponseMsg.DuplicateError.GetEnumDescription();
                return jsonObject;
            }
        }

        public JsonObject DeleteLightNode(int id)
        {
            JsonObject jsonObject = new JsonObject();
            var lightModel = _lightRepo.GetLightById(id);
            if (lightModel == null)
            {
                jsonObject.response = JsonResponseMsg.NodeNotFound.GetEnumDescription();
                return jsonObject;
            }

            var res = _lightRepo.DeleteLight(lightModel);
            if (res == ReturnStates.Deleted)
            {
                _lightRepo.SaveChanges();
                jsonObject.response = JsonResponseMsg.SuccessfullyDeleted.GetEnumDescription();
            }
            else
            {
                jsonObject.response = JsonResponseMsg.HasNotBeenDeleted.GetEnumDescription();
            }
            return jsonObject;
        }

        public JsonObject UpdateLightNode(int id, NodeUpdateDto nodeUpdateDto)
        {
            JsonObject jsonObject = new JsonObject();
            var lightModel = _lightRepo.GetLightById(id);
            if (lightModel == null)
            {
                jsonObject.response = JsonResponseMsg.NodeNotFound.GetEnumDescription();
                return jsonObject;
            }

            _mapper.Map(nodeUpdateDto, lightModel);
            _lightRepo.UpdateLight(lightModel);
            _lightRepo.SaveChanges();

            jsonObject.response = JsonResponseMsg.SuccessfullyUpdated.GetEnumDescription();
            return jsonObject;
        }
    }
}