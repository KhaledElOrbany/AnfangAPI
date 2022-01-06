using System;
using System.Collections.Generic;
using System.Linq;
using AnfangAPI.Data.Interfaces;
using AnfangAPI.DataContext;
using AnfangAPI.Models;
using AnfangAPI.Services;
using static AnfangAPI.Services.Enums;

namespace AnfangAPI.Data
{
    public class PlugRepo : IPlugRepo
    {
        private readonly DataBaseContext _context;
        public PlugRepo(DataBaseContext context)
        {
            _context = context;
        }

        public ReturnStates CreatePlug(Plug plug)
        {
            if (plug == null)
            {
                throw new ArgumentNullException(nameof(plug));
            }
            Plug temp = _context.Plugs.FirstOrDefault(m => m.NodeMacAddress.Equals(plug.NodeMacAddress));
            if (temp == null)
            {
                _context.Plugs.Add(plug);
                return ReturnStates.Created;
            }
            else
            {
                return ReturnStates.Duplicate;
            }
        }

        public ReturnStates DeletePlug(Plug plug)
        {
            if (plug == null)
            {
                throw new ArgumentNullException(nameof(plug));
            }
            _context.Plugs.Remove(plug);
            return ReturnStates.Deleted;
        }

        public IEnumerable<Plug> GetAllPlugs()
        {
            return _context.Plugs.ToList();
        }

        public Plug GetPlugById(int id)
        {
            return _context.Plugs.FirstOrDefault(x => x.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdatePlug(Plug plug) { }
    }
}