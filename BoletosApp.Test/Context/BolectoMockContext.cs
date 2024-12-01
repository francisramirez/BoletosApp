

using BoletosApp.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace BoletosApp.Test.Context
{
    public class BolectoMockContext : BoletoContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("bolectodb");
        }
    }
}
