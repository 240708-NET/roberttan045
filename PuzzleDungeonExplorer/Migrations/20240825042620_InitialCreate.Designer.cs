﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PuzzleDungeonExplorer.Data;

#nullable disable

namespace PuzzleDungeonExplorer.Migrations
{
    [DbContext(typeof(PuzzleDungeonContext))]
    [Migration("20240825042620_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PuzzleDungeonExplorer.Models.Dungeon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Dungeons");
                });

            modelBuilder.Entity("PuzzleDungeonExplorer.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Health")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("PuzzleDungeonExplorer.Models.Puzzle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Difficulty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PuzzleType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<string>("Solution")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Puzzles");
                });

            modelBuilder.Entity("PuzzleDungeonExplorer.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DungeonId")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("int");

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DungeonId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("PuzzleDungeonExplorer.Models.Trap", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<string>("DisarmCondition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<string>("TrapType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Traps");
                });

            modelBuilder.Entity("PuzzleDungeonExplorer.Models.Puzzle", b =>
                {
                    b.HasOne("PuzzleDungeonExplorer.Models.Room", "Room")
                        .WithMany("Puzzles")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("PuzzleDungeonExplorer.Models.Room", b =>
                {
                    b.HasOne("PuzzleDungeonExplorer.Models.Dungeon", "Dungeon")
                        .WithMany("Rooms")
                        .HasForeignKey("DungeonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PuzzleDungeonExplorer.Models.Player", null)
                        .WithMany("VisitedRooms")
                        .HasForeignKey("PlayerId");

                    b.Navigation("Dungeon");
                });

            modelBuilder.Entity("PuzzleDungeonExplorer.Models.Trap", b =>
                {
                    b.HasOne("PuzzleDungeonExplorer.Models.Room", "Room")
                        .WithMany("Traps")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("PuzzleDungeonExplorer.Models.Dungeon", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("PuzzleDungeonExplorer.Models.Player", b =>
                {
                    b.Navigation("VisitedRooms");
                });

            modelBuilder.Entity("PuzzleDungeonExplorer.Models.Room", b =>
                {
                    b.Navigation("Puzzles");

                    b.Navigation("Traps");
                });
#pragma warning restore 612, 618
        }
    }
}
