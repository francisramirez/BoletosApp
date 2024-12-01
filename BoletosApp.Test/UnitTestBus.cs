using BoletosApp.Domain.Entities.Configuration;
using BoletosApp.Domain.Result;
using BoletosApp.Persistance.Interfaces.Configuration;
using BoletosApp.Persistance.Repositories.Configuration;
using BoletosApp.Test.BusTest;
using BoletosApp.Test.Context;
using Microsoft.Extensions.Logging;
using Moq;

namespace BoletosApp.Test
{
    public class UnitTestBus
    {
        private readonly IBusRepository _busRepository;

        public UnitTestBus()
        {
            var loggerMock = new Mock<ILogger<BusRepository>>();
            var bolectoMockContext = new Mock<BolectoMockContext>();
            _busRepository = new BusRepository(bolectoMockContext.Object, loggerMock.Object);
        }
        [Fact]
        public async void AddBus_NullBus_ReturnsFailure()
        {
            //Assert
            Bus bus = null;

            // Act
            var result = await _busRepository.Save(bus);
            var message = "El autobus es requerido.";

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }
    }
}