using System;
using System.Collections.Generic;
using System.Linq;
using AnfangAPI.Data.Interfaces;
using AnfangAPI.DataContext;
using AnfangAPI.Models;
using AnfangAPI.Services;
using static AnfangAPI.Services.Enums;

namespace AnfangAPI.Data.Implementation
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
            if (light == null)
            {
                throw new ArgumentNullException(nameof(light));
            }
            Light temp = _context.Lights.FirstOrDefault(m => m.NodeMacAddress.Equals(light.NodeMacAddress));
            if (temp == null)
            {
                _context.Lights.Add(light);
                return ReturnStates.Created;
            }
            else
            {
                return ReturnStates.Duplicate;
            }
        }

        public ReturnStates DeleteLight(Light light)
        {
            if (light == null)
            {
                throw new ArgumentNullException(nameof(light));
            }
            _context.Lights.Remove(light);
            return ReturnStates.Deleted;
        }

        public IEnumerable<Light> GetAllLights()
        {
            return _context.Lights.ToList();
        }

        public Light GetLightById(int id)
        {
            return _context.Lights.FirstOrDefault(x => x.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateLight(Light light) { }
    }
}