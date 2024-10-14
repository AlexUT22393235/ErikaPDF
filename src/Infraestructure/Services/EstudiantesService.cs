using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.Wrappers;
using AutoMapper;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Services
{
    public class EstudiantesService : IEstudiantesService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public EstudiantesService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Response<object>> GetEstudiantes(){
            object list = new object();
            list = await _dbContext.Estudiantes.ToListAsync();
            return new Response<object>(list);
        }
    }

        //Task<Response<object>> IEstudiantesService.GetEstudiantes()
        //{
        //    throw new NotImplementedException();
        //}
    }
