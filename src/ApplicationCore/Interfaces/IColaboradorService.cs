using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace ApplicationCore.Interfaces
{
    // recuerda el public pero en este caso no es class es interface, aqui se supone que van todos tus metodos que usaras en el crud
    // pero si ves que tengo comentados los demas es porque solo puse los que no requieren modificar datos, solo puse los get,
    // porque a lo que entendi es que ericka dijo que los que necesiten modificar datos se usara un handle con un command.
    // aqui vas a poner Task seguido de los que regresa
    // por ejemplo <List<Colaborador> es una lista de colaboradores y <Colaborador> es uno solo, pondras el nombre del metodo
    // como ejemplo GetAllAsync(); y si requiere algun parametro como GetByIdAsync(int id); que te pide el id y que sea tipo int
    // 
    public interface IColaboradorService
    {
        Task<List<Colaborador>> GetAllAsync();
        Task<Colaborador> GetByIdAsync(int id);
        //Task AddAsync(Colaborador colaborador);
        //Task UpdateAsync(Colaborador colaborador);
        //Task DeleteAsync(int id);
    }
}
