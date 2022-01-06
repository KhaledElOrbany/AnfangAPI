using System.Collections.Generic;
using AnfangAPI.Models;
using static AnfangAPI.Services.Enums;

namespace AnfangAPI.Data.Interfaces
{
    public interface IPlugRepo
    {
        bool SaveChanges();
        IEnumerable<Plug> GetAllPlugs();
        Plug GetPlugById(int id);
        ReturnStates CreatePlug(Plug plug);
        void UpdatePlug(Plug plug);
        ReturnStates DeletePlug(Plug plug);
    }
}