using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Services
{
    public class ColaboradorService : IColaboradorService
    {
        private readonly ApplicationDbContext _context;

        public ColaboradorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Colaborador>> GetAllAsync()
        {
            return await _context.Colaboradores.ToListAsync();
        }

        public async Task<Colaborador> GetByIdAsync(int id)
        {
            return await _context.Colaboradores.FindAsync(id);
        }

        //public async Task AddAsync(Colaborador colaborador)
        //{
        //    await _context.Colaboradores.AddAsync(colaborador);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task UpdateAsync(Colaborador colaborador)
        //{
        //    _context.Entry(colaborador).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();
        //}

        //public async Task DeleteAsync(int id)
        //{
        //    var colaborador = await _context.Colaboradores.FindAsync(id);
        //    if (colaborador != null)
        //    {
        //        _context.Colaboradores.Remove(colaborador);
        //        await _context.SaveChangesAsync();
        //    }
        //}
    }
}
