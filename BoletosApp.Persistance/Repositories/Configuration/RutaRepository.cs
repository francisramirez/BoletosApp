
using BoletosApp.Domain.Entities.Configuration;
using BoletosApp.Domain.Result;
using BoletosApp.Persistance.Base;
using BoletosApp.Persistance.Context;
using BoletosApp.Persistance.Interfaces.Configuration;
using Microsoft.Extensions.Logging;

namespace BoletosApp.Persistance.Repositories.Configuration
{
    public sealed class RutaRepository(BoletoContext context,
                         ILogger<RutaRepository> logger) : BaseRepository<Ruta>(context), IRutaRepository
    {
        private readonly BoletoContext context = context;
        private readonly ILogger<RutaRepository> logger = logger;



        public override Task<OperationResult> Save(Ruta entity)
        {
            return base.Save(entity);
        }
    }

    
}
