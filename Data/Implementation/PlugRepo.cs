using System.Collections.Generic;
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
            throw new System.NotImplementedException();
        }

        public ReturnStates DeletePlug(Plug plug)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Plug> GetAllPlugs()
        {
            throw new System.NotImplementedException();
        }

        public Plug GetPlugById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdatePlug(Plug plug)
        {
            throw new System.NotImplementedException();
        }
    }
}