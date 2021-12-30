using System;
using System.Collections.Generic;
using System.Linq;
using AnfangAPI.Data.Interfaces;
using AnfangAPI.DataContext;
using AnfangAPI.Models;
using static AnfangAPI.Services.Enums;

namespace AnfangAPI.Data.Implementation
{
    public class NodeRepo : INodeRepo
    {
        private readonly NodeContext _context;

        public NodeRepo(NodeContext context)
        {
            _context = context;
        }

        public ReturnStates CreateNode(Node node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }
            Node temp = _context.Nodes.Where(m => m.NodeMacAddress.Equals(node.NodeMacAddress)).FirstOrDefault();
            if (temp == null)
            {
                _context.Nodes.Add(node);
                return ReturnStates.Created;
            }
            else
            {
                return ReturnStates.Duplicate;
            }
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