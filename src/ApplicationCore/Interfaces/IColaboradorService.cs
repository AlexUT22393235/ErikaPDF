using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace ApplicationCore.Interfaces
{
    public interface IColaboradorService
    {
        Task<List<Colaborador>> GetAllAsync();
        Task<Colaborador> GetByIdAsync(int id);
        //Task AddAsync(Colaborador colaborador);
        //Task UpdateAsync(Colaborador colaborador);
        //Task DeleteAsync(int id);
    }
}
