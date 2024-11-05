using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Wrappers;
using AutoMapper;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using DevExpress.DataAccess.ObjectBinding;

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

        public async Task<Response<int>> DeleteEstudiante(int id)
        {
            // Buscar el estudiante por ID
            var estudiante = await _dbContext.Estudiantes.FindAsync(id);
            if (estudiante == null)
            {
                return new Response<int>(0, "Estudiante no encontrado.");
            }
            // Eliminar el estudiante
            _dbContext.Estudiantes.Remove(estudiante);
            await _dbContext.SaveChangesAsync();
            // Retornar la respuesta con el ID del estudiante eliminado
            return new Response<int>(estudiante.Id, "Eliminación exitosa.");
        }

        public async Task<byte[]> GetPDF()
        {
            ObjectDataSource source = new ObjectDataSource();

            var report = new ApplicationCore.PDF.EstudiantesPDF();

            var estudiantes = await (from e in _dbContext.Estudiantes
                select new EstudianteDTO
                {
                    Id = e.Id,
                    nombre = e.nombre,
                    edad = e.edad,
                    correo = e.correo
                }).ToListAsync();
            // var estudiantes = await _dbContext.Estudiantes.ToListAsync();

            EstudiantesPDFDTO reportPdf = new EstudiantesPDFDTO();
            reportPdf.Fecha = DateTime.Now.ToString("dd/mm/yyyy");
            reportPdf.Hora = DateTime.Now.ToString("hh:mm");
            reportPdf.Estudiantes = estudiantes;

            // CONSTRUYE EL PDF
            source.DataSource = reportPdf;
            report.DataSource = source;
            using (var memory = new MemoryStream())
            {
                await report.ExportToPdfAsync(memory);
                memory.Position = 0;
                return memory.ToArray();
            }

        }
    }

        //Task<Response<object>> IEstudiantesService.GetEstudiantes()
        //{
        //    throw new NotImplementedException();
        //}
    }
