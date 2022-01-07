using AnfangAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AnfangAPI.DataContext
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Node> Nodes { get; set; }
        public DbSet<Plug> Plugs { get; set; }
        public DbSet<Light> Lights { get; set; }
        public DbSet<NodeType> NodeTypes { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NodeType>().HasData(
                new NodeType
                {
                    Id = (int)Services.Enums.NodeTypes.Plug,
                    NodeTypeId = Services.Enums.NodeTypes.Plug,
                    NodeTypeName = "Plug"
                },
                new NodeType
                {
                    Id = (int)Services.Enums.NodeTypes.Light,
                    NodeTypeId = Services.Enums.NodeTypes.Light,
                    NodeTypeName = "Light"
                },
                new NodeType
                {
                    Id = (int)Services.Enums.NodeTypes.HumiditySensor,
                    NodeTypeId = Services.Enums.NodeTypes.HumiditySensor,
                    NodeTypeName = "Humidity Sensor"
                },
                new NodeType
                {
                    Id = (int)Services.Enums.NodeTypes.TemperatureSensor,
                    NodeTypeId = Services.Enums.NodeTypes.TemperatureSensor,
                    NodeTypeName = "Temperature Sensor"
                },
                new NodeType
                {
                    Id = (int)Services.Enums.NodeTypes.DoorSensor,
                    NodeTypeId = Services.Enums.NodeTypes.DoorSensor,
                    NodeTypeName = "Door Sensor"
                }
            );
        }
    }
}