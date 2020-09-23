using Forma1App.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forma1App.Repositories
{
    public interface IForma1TeamRepository
    {
        Task<Forma1TeamEntity> AddAsync(Forma1TeamEntity entity);
        Task DeleteAsync(long id);
        Task<IList<Forma1TeamEntity>> GetAllAsync();
        Task<Forma1TeamEntity> GetAsync(long id);
        Task<Forma1TeamEntity> UpdateAsync(Forma1TeamEntity forma1TeamEntity);
    }
}