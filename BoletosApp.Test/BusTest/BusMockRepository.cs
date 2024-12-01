

using BoletosApp.Domain.Entities.Configuration;
using BoletosApp.Domain.Result;
using BoletosApp.Persistance.Interfaces.Configuration;
using BoletosApp.Test.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BoletosApp.Test.BusTest
{
    public class BusMockRepository : IBusRepository
    {
        private readonly BolectoMockContext context;

        public BusMockRepository(BolectoMockContext context)
        {
            this.context = context;
        }

        public Task<bool> Exists(Expression<Func<Bus, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> GetAll(Expression<Func<Bus, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> GetBusByid(int busId)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> GetEntityBy(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> Remove(Bus entity)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult> Save(Bus entity)
        {
            OperationResult result = new OperationResult();

            try
            {

                if (entity == null)
                {
                    result.Success = false;
                    result.Message = "El autobus es requerido.";
                    return result;
                }

                if (string.IsNullOrEmpty(entity.NumeroPlaca))
                {
                    result.Success = false;
                    result.Message = "El numero es requerido.";
                    return result;
                }
                if (entity.NumeroPlaca.Length > 50)
                {
                    result.Success = false;
                    result.Message = "El numero de placa no puede ser mayor 50 caracteres.";
                    return result;
                }
                if (await this.context.Buses.AnyAsync(bus => bus.NumeroPlaca == entity.NumeroPlaca))
                {
                    result.Success = false;
                    result.Message = "Existe un autobus con este numero de placa.";
                    return result;
                }

                await this.context.AddAsync(entity);
                await this.context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                result.Message = "Ocurrio un error guardando el autobus";
                result.Success = false;
               
            }

            return result;
        }

        public Task<OperationResult> Update(Bus entity)
        {
            throw new NotImplementedException();
        }
    }
}
