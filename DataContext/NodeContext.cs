using AnfangAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AnfangAPI.DataContext
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> opt) : base(opt)
        {
        }

        public DbSet<Node> Nodes { get; set; }
        public DbSet<Plug> Plugs { get; set; }
        public DbSet<Light> Lights { get; set; }
        public DbSet<NodeType> NodeTypes { get; set; }
    }
}