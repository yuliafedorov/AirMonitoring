using Xunit;
using Moq;
using DAL.Entities;
using DAL.Repositories.Impl;
using DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace DAL.Tests
{
    public class TestStationRepository : BaseRepository<Station>
    {
        public TestStationRepository(DbContext context)
               : base(context)
        {
        }


        public class BaseRepositoryUnitTests
        {

            [Fact]
            public void Create_InputStationInstance_CalledAddMethodOfDBSetWithStationInstance()
            {
                // Arrange
                DbContextOptions opt = new DbContextOptionsBuilder<StationContext>()
                    .Options;
                var mockContext = new Mock<StationContext>(opt);
                var mockDbSet = new Mock<DbSet<Station>>();
                mockContext
                   .Setup(context =>
                        context.Set<Station>(
                            ))
                    .Returns(mockDbSet.Object);
                var repository = new TestStationRepository(mockContext.Object);
                Station expectedStation = new Mock<Station>().Object;
                // Act
                repository.Create(expectedStation);

                // Assert
                mockDbSet.Verify(
                    dbSet => dbSet.Add(
                        expectedStation
                        ), Times.Once());
            }


            [Fact]
            public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
            {
                // Arrange
                DbContextOptions opt = new DbContextOptionsBuilder<StationContext>()
                    .Options;
                var mockContext = new Mock<StationContext>(opt);
                var mockDbSet = new Mock<DbSet<Station>>();
                mockContext
                    .Setup(context =>
                        context.Set<Station>(
                            ))
                    .Returns(mockDbSet.Object);
                //EFUnitOfWork uow = new EFUnitOfWork(mockContext.Object);
                //IStreetRepository repository = uow.Streets;
                var repository = new TestStationRepository(mockContext.Object);

                Station expectedStation = new Station() { StationID = 1 };
                mockDbSet.Setup(mock => mock.Find(expectedStation.StationID)).Returns(expectedStation);

                //Act
                repository.Delete(expectedStation.StationID);

                // Assert
                mockDbSet.Verify(
                    dbSet => dbSet.Find(
                        expectedStation.StationID
                        ), Times.Once());
                mockDbSet.Verify(
                    dbSet => dbSet.Remove(
                        expectedStation
                        ), Times.Once());
            }

            [Fact]
            public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
            {
                // Arrange
                DbContextOptions opt = new DbContextOptionsBuilder<StationContext>()
                    .Options;
                var mockContext = new Mock<StationContext>(opt);
                var mockDbSet = new Mock<DbSet<Station>>();
                mockContext
                    .Setup(context =>
                        context.Set<Station>(
                            ))
                    .Returns(mockDbSet.Object);

                Station expectedStreet = new Station() { StationID = 1 };
                mockDbSet.Setup(mock => mock.Find(expectedStreet.StationID))
                        .Returns(expectedStreet);
                var repository = new TestStationRepository(mockContext.Object);

                //Act
                var actualStreet = repository.Get(expectedStreet.StationID);

                // Assert
                mockDbSet.Verify(
                    dbSet => dbSet.Find(
                        expectedStreet.StationID
                        ), Times.Once());
                Assert.Equal(expectedStreet, actualStreet);
            }
        }

    }
}
