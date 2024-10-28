using Entities;
using Microsoft.EntityFrameworkCore;
using Services;

namespace ModesServiceTest
{
    public class UnitTest1
    {
        private DataContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new DataContext(options);

            // Seed the database with some data
            context.Modes.AddRange(
                new Mode { ModeId = 1, ModeName = "Mode1" },
                new Mode { ModeId = 2, ModeName = "Mode2" }
            );

            context.SaveChanges();
            return context;
        }

        [Fact]
        public async Task GetModes_Returns_All_Modes()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var service = new ModeService(context);

            // Act
            var result = await service.GetModes();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Equal("Mode1", result.First().ModeName);
        }

        [Fact]
        public async Task GetMode_Returns_Mode_ById()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var service = new ModeService(context);

            // Act
            var result = await service.GetMode(1);

            // Assert
            Assert.Equal("Mode1", result.ModeName);
        }


        [Fact]
        public async Task CreateMode_Adds_Mode()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var service = new ModeService(context);
            var mode = new Mode { ModeId = 3, ModeName = "Mode3" };

            // Act
            var result = await service.CreateMode(mode);

            // Assert
            Assert.Equal(mode, result);
            Assert.Equal(3, context.Modes.Count());
        }

        [Fact]
        public async Task DeleteMode_Removes_Mode()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var service = new ModeService(context);

            // Act
            var result = await service.DeleteMode(1);

            // Assert
            Assert.True(result);
            Assert.Equal(1, context.Modes.Count());
        }

        [Fact]
        public void ModeExists_Returns_True_If_Mode_Exists()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var service = new ModeService(context);

            // Act
            var result = service.ModeExists(1);

            // Assert
            Assert.True(result);
        }
    }
}