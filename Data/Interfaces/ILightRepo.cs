using System.Collections.Generic;
using AnfangAPI.Models;
using static AnfangAPI.Services.Enums;

namespace AnfangAPI.Data.Interfaces
{
    public interface ILightRepo
    {
        bool SaveChanges();
        IEnumerable<Light> GetAllLights();
        Light GetLightById(int id);
        ReturnStates CreateLight(Light light);
        void UpdateLight(Light light);
        ReturnStates DeleteLight(Light light);
    }
}