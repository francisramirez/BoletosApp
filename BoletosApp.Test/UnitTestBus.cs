using BoletosApp.Domain.Entities.Configuration;
using BoletosApp.Domain.Result;
using BoletosApp.Persistance.Interfaces.Configuration;
using BoletosApp.Test.BusTest;

namespace BoletosApp.Test
{
    public class UnitTestBus
    {
        private readonly IBusRepository _busRepository;

        public UnitTestBus()
        {
            _busRepository = new BusMockRepository(new Context.BolectoMockContext());
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