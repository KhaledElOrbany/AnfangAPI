using System.Collections.Generic;
using System.Linq;
using AnfangAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AnfangAPI.Data
{
    public class NodeRepo : INodeRepo
    {
        private readonly NodeContext _context;

        public NodeRepo(NodeContext context)
        {
            _context = context;
        }

        public IEnumerable<Node> GetAllNodes()
        {
            return _context.Nodes.ToList();
        }

        public Node GetNodeById(int id)
        {
            return _context.Nodes.FirstOrDefault(x => x.Id == id);
        }
    }
}