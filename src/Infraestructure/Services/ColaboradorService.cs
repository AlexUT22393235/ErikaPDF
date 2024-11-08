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
    // Recuerda el public class, "IColaboradorService" es la interface del servicio, como ligandolo a esa interface
    // por lo que los nombres de los metodos deben ser iguales que los que pusiste en tu interface ejemplo GetAllAsync y en IColaboradorService
    // tambien dice eso
    public class ColaboradorService : IColaboradorService
    {
        // esto siempre lo haces en el servicio, tienes que llamar a tu ApplicationDbContext basicamente es tu BD o tu forma de acceder a ella
        // basicamente estas creando una variable que es del tipo ApplicationDbContext
        private readonly ApplicationDbContext _context;

        // Este es el contructor de tu clase, inyectas el ApplicationDbContext usando la palabra context
        public ColaboradorService(ApplicationDbContext context)
        {
            // y le asignas el valor del context a tu variable para poder usarla a lo largo de tu servicio
            _context = context;
        }

        // llamas al metodo getAll de igual manera que lo definiste en tu IColaboradorService
        public async Task<List<Colaborador>> GetAllAsync()
        {
            // await es para esperar osea que va a esperar a que _context que es tu BD.Colaboradores que es tu tabla te traiga la lista de los colaboradores
            // ToListAsync(); es un metodo de .net no tienes que hacer mas eso ya te lo trae
            return await _context.Colaboradores.ToListAsync();
        }

        // llamamos al metodo de buscar un colaborador igual que en IColaboradorService y le pasamos el paramtro de igual manera
        public async Task<Colaborador> GetByIdAsync(int id)
        {
            // lo mismo, esperara a que traiga el colaborador el metodo FindAsync(id); pasandole el id ya lo hace solo
            return await _context.Colaboradores.FindAsync(id);
        }

        // IMPORTANTE SI VES QUE LO DEMAS ESTA COMENTADO ES PORQUE COMO TE DIJE EN LA INTERFACE DEL SERVICIO MOVI LA LOGICA A UN HANDLER
        // Y YA NO LOS EJECUTO AQUI EN EL SERVICIO :)

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
