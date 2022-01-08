using System;
using AnfangAPI.Data.Interfaces;
using AnfangAPI.DTOs.Node;
using AnfangAPI.Models;
using AnfangAPI.Services;
using AutoMapper;
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
    }
}