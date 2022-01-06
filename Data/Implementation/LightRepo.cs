using System.Collections.Generic;
using AnfangAPI.Data.Interfaces;
using AnfangAPI.DataContext;
using AnfangAPI.Models;
using AnfangAPI.Services;
using static AnfangAPI.Services.Enums;

namespace AnfangAPI.Data
{
    public class LightRepo : ILightRepo
    {
        private readonly DataBaseContext _context;
        public LightRepo(DataBaseContext context)
        {
            _context = context;
        }

        public ReturnStates CreateLight(Light light)
        {
            throw new System.NotImplementedException();
        }

        public ReturnStates DeleteLight(Light light)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Light> GetAllLights()
        {
            throw new System.NotImplementedException();
        }

        public Light GetLightById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateLight(Light light)
        {
            throw new System.NotImplementedException();
        }
    }
}