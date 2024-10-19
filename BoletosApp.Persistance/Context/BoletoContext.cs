using BoletosApp.Domain.Entities.Configuration;
using BoletosApp.Domain.Entities.Reservation;
using BoletosApp.Domain.Entities.Security;
using Microsoft.EntityFrameworkCore;

namespace BoletosApp.Persistance.Context
{
    public partial class BoletoContext : DbContext
    {
        public BoletoContext(DbContextOptions<BoletoContext> options) : base(options)
        {
           
        }

        #region "Configuration Entities"
        public DbSet<Asiento> Asientos { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Ruta> Rutas { get; set; }
        #endregion

        #region "Reserva Entities"
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<ReservaDetalle> ReservaDetalles { get; set; }
        public  DbSet<Viaje> Viajes { get; set; }
        #endregion

        #region "Security Entities"
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        #endregion
    }
}
