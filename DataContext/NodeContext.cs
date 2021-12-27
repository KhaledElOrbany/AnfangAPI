using AnfangAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AnfangAPI.DataContext
{
    public class NodeContext : DbContext
    {
        public NodeContext(DbContextOptions<NodeContext> opt) : base(opt)
        {
        }

        public DbSet<Node> Nodes { get; set; }
    }
}