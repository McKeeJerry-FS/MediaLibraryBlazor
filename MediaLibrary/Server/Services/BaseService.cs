using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MediaLibrary.Server.Data;
using MediaLibrary.Shared.Model;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MediaLibrary.Server.Services
{
    public abstract class BaseService<TEntity, TModel>
        where TEntity : BaseEntity
        where TModel : IModel, new()
    {
        private readonly MediaLibraryDbContext _dbContext;
        private readonly IMapper _mapper;

        public BaseService(MediaLibraryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        // Creating a new record
        public async Task<TModel> CreateAsync(TModel model)
        {
            var entity = _mapper.Map<TEntity>(model);
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<TModel>(entity);
        }

        // Reading a single record
        private async Task<TEntity> GetEntityByIdAsync(int id)
        {
            var entity = await _dbContext.FindAsync<TEntity>(id);
            if (entity == null)
            {
                throw new Exception($"Cannot find entity type {typeof(TEntity)} with id {id}");
            }
            return entity;

        }

        public async Task<TModel> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                return new TModel();
            }
            var entity = await GetEntityByIdAsync(id);
            return _mapper.Map<TModel>(entity);
        }
    }
}
