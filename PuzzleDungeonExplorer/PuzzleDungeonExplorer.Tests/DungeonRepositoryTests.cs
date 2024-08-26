using System;
using Microsoft.EntityFrameworkCore;
using Xunit;
using PuzzleDungeonExplorer.Data;
using PuzzleDungeonExplorer.Repositories;
using PuzzleDungeonExplorer.Models;

namespace PuzzleDungeonExplorer.Tests
{
    public class DungeonRepositoryTests
    {
        [Fact]
        public void GetDungeonById_ReturnsCorrectDungeon()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<PuzzleDungeonContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new PuzzleDungeonContext(options))
            {
                var dungeon = new Dungeon
                {
                    Id = 1,
                    Name = "Test Dungeon"
                };
                context.Dungeons.Add(dungeon);
                context.SaveChanges();

                var repository = new DungeonRepository(context);

                // Act
                var result = repository.GetDungeonById(1);

                // Assert
                Assert.NotNull(result);
                Assert.Equal("Test Dungeon", result.Name);
            }
        }
    }
}