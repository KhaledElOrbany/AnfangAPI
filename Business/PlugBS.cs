using System;
using AnfangAPI.Data.Interfaces;
using AnfangAPI.DTOs;
using AnfangAPI.Models;
using AnfangAPI.Services;
using AutoMapper;
using static AnfangAPI.Services.Enums;

namespace AnfangAPI.Business
{
    public class PlugBS
    {
        private readonly IMapper _mapper;
        private readonly IPlugRepo _plugRepo;

        public PlugBS(IMapper mapper, IPlugRepo plugRepo)
        {
            _mapper = mapper;
            _plugRepo = plugRepo;
        }

        public JsonObject CreatePlugNode(NodeCreateDto nodeCreateDto)
        {
            var plugModel = _mapper.Map<Plug>(nodeCreateDto);
            var res = _plugRepo.CreatePlug(plugModel);

            JsonObject jsonObject = new JsonObject();
            if (res == ReturnStates.Created)
            {
                _plugRepo.SaveChanges();

                jsonObject.NodeReadDto = _mapper.Map<NodeReadDto>(plugModel);
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

        public JsonObject DeletePlugNode(int id)
        {
            JsonObject jsonObject = new JsonObject();
            var plugModel = _plugRepo.GetPlugById(id);
            if (plugModel == null)
            {
                jsonObject.response = JsonResponseMsg.NodeNotFound.GetEnumDescription();
                return jsonObject;
            }

            var res = _plugRepo.DeletePlug(plugModel);
            if (res == ReturnStates.Deleted)
            {
                _plugRepo.SaveChanges();
                jsonObject.response = JsonResponseMsg.SuccessfullyDeleted.GetEnumDescription();
            }
            else
            {
                jsonObject.response = JsonResponseMsg.HasNotBeenDeleted.GetEnumDescription();
            }
            return jsonObject;
        }
    }
}