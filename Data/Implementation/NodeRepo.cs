using System;
using System.Collections.Generic;
using System.Linq;
using AnfangAPI.Data.Interfaces;
using AnfangAPI.DataContext;
using AnfangAPI.Models;

namespace AnfangAPI.Data.Implementation
{
    public class NodeRepo : INodeRepo
    {
        private readonly NodeContext _context;

        public NodeRepo(NodeContext context)
        {
            _context = context;
        }

        public void CreateNode(Node node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }
            _context.Nodes.Add(node);
        }

        public void DeleteNode(Node node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }
            _context.Nodes.Remove(node);
        }

        public IEnumerable<Node> GetAllNodes()
        {
            return _context.Nodes.ToList();
        }

        public Node GetNodeById(int id)
        {
            return _context.Nodes.FirstOrDefault(x => x.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateNode(Node node) { }
    }
}