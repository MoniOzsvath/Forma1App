using Forma1App.Data;
using Forma1App.Exceptions;
using Forma1App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forma1App.Repositories
{
    public class Forma1TeamRepository : IForma1TeamRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public Forma1TeamRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IList<Forma1TeamEntity>> GetAllAsync()
        {
            return await _applicationDbContext.Forma1Teams.ToListAsync();
        }

        public async Task<Forma1TeamEntity> GetAsync(long id)
        {
            return await _applicationDbContext.Forma1Teams.FindAsync(id);
        }

        public async Task<Forma1TeamEntity> AddAsync(Forma1TeamEntity entity)
        {
            var nameExists = await ExistsByNameAsync(entity.Name);
            if (nameExists)
            {
                throw new EntityAlreadyExistsException();
            }
            _applicationDbContext.Forma1Teams.Add(entity);
            await _applicationDbContext.SaveChangesAsync();
            return entity;
        }


        public async Task<Forma1TeamEntity> UpdateAsync(Forma1TeamEntity forma1TeamEntity)
        {
            var entity = await GetAsync(forma1TeamEntity.Id);
            if (entity == null) throw new EntityNotFoundException();

            entity.Name = forma1TeamEntity.Name;
            entity.PaiedEntryFee = forma1TeamEntity.PaiedEntryFee;
            entity.FoundedDate = forma1TeamEntity.FoundedDate;
            entity.WinnedChampionshipsCount = forma1TeamEntity.WinnedChampionshipsCount;
            entity.UpdatedDate = DateTime.UtcNow;

            await _applicationDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(long id)
        {
            var entity = await GetAsync(id);
            if (entity == null) throw new EntityNotFoundException();
            _applicationDbContext.Forma1Teams.Remove(entity);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            var entity = await _applicationDbContext.Forma1Teams.FirstOrDefaultAsync(x => x.Name == name );      
            return entity != null;
        }
    }
}
