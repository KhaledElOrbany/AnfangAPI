﻿// <auto-generated />
using AnfangAPI.Data;
using AnfangAPI.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AnfangAPI.Migrations
{
    [DbContext(typeof(NodeContext))]
    [Migration("20211227081356_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AnfangAPI.Models.Node", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NodeMacAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NodeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("NodeState")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Nodes");
                });
#pragma warning restore 612, 618
        }
    }
}
