using BoletosApp.Domain.Repositories;
using BoletosApp.Domain.Result;
using BoletosApp.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace BoletosApp.Persistance.Base
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly BoletoContext _boletoContext;
        private DbSet<TEntity> entities;
        public BaseRepository(BoletoContext boletoContext)
        {
            _boletoContext = boletoContext;
            this.entities = _boletoContext.Set<TEntity>();
        }
        public virtual async Task<bool> Exists(Expression<Func<TEntity, bool>> filter)
        {
            return await this.entities.AnyAsync(filter);
        }

        public virtual async Task<OperationResult> GetAll()
        {
            OperationResult result = new OperationResult();

            try
            {
                var datos = await this.entities.ToListAsync();
                result.Data = datos;
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Ocurrió un error {ex.Message} obteniendo los datos.";
            }

            return result;
        }

        public virtual async Task<OperationResult> GetEntityBy(int Id)
        {
            OperationResult result = new OperationResult();
            try
            {
                var entity = await this.entities.FindAsync(Id); 
                result.Data = entity;
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Ocurrió un error {ex.Message} obteniendo la entidad.";
            }
            return result;
        }

        public async virtual Task<OperationResult> Remove(TEntity entity)
        {
            OperationResult result = new OperationResult();

            try
            {
                entities.Remove(entity);
                await _boletoContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió un error {ex.Message} removiendo la entidad.";

            }

            return result;
        }

        public virtual async Task<OperationResult> Save(TEntity entity)
        {
            OperationResult result = new OperationResult();

            try
            {
                entities.Add(entity);
                await _boletoContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió un error {ex.Message} guardando la entidad.";

            }

            return result;
        }

        public virtual async Task<OperationResult> Update(TEntity entity)
        {
            OperationResult result = new OperationResult();

            try
            {
                entities.Update(entity);
                await _boletoContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió un error {ex.Message} actualizando la entidad.";

            }

            return result;
        }
    }
}
