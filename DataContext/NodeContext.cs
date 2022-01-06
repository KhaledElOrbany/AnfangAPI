using AnfangAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AnfangAPI.DataContext
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NodeType>().HasData(
                new NodeType { Id = 1, NodeTypeId = Services.Enums.NodeTypes.Plug, NodeTypeName = "Plug" },
                new NodeType { Id = 2, NodeTypeId = Services.Enums.NodeTypes.Light, NodeTypeName = "Light" }
            );
        }

        public DbSet<Node> Nodes { get; set; }
        public DbSet<Plug> Plugs { get; set; }
        public DbSet<Light> Lights { get; set; }
        public DbSet<NodeType> NodeTypes { get; set; }
    }
}