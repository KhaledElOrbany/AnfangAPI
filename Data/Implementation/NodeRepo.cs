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
        private readonly DataBaseContext _context;

        public NodeRepo(DataBaseContext context)
        {
            _context = context;
        }

        public ReturnStates CreateNode(Node node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }
            Node temp = _context.Nodes.FirstOrDefault(m => m.NodeMacAddress.Equals(node.NodeMacAddress));
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

        public ReturnStates DeleteNode(Node node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }
            _context.Nodes.Remove(node);
            return ReturnStates.Deleted;
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