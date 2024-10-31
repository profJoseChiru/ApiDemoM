using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiDemo.Models;
using ApiDemo.Contexts;

namespace ApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EspecialidadesController : ControllerBase
    {
        //Esto permite interactuar con la base de datos.
        private readonly ApplicationDbContext applicationDbContext;

        public EspecialidadesController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        //Obtener todas las especialidades
       //[HttpGet], indica que responde a solicitudes HTTP GET.
        [HttpGet]
        //ActionResult que contiene la lista de especialidades.
        //ActionResult<List<Especialidades>> permite manejar diferentes tipos de respuestas
        //async se usa para marcar un método como asíncrono.
        public async Task<ActionResult<List<Especialidades>>> GetEspecialidades()
        {
            //await se utiliza dentro de un método marcado como async
            return await applicationDbContext.Especialidades.ToListAsync();
        }

        //Buscauna especialida por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Especialidades>> GetEspecialidad(int id)
        {
            var especialidad = await applicationDbContext.Especialidades.FindAsync(id);
            if (especialidad == null) {
                return NotFound();
            }
            return especialidad;
        }

        //Crea una nueva especialidad
        [HttpPost]
        public async Task<ActionResult<Especialidades>> CrearEspecialiad(Especialidades especialidades)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Devuelve los errores de validación
            }

            try
            {
                applicationDbContext.Especialidades.Add(especialidades);
                await applicationDbContext.SaveChangesAsync();

                return CreatedAtAction(nameof(GetEspecialidad), new { id = especialidades.id }, especialidades);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Ocurrió un error al crear la especialidad."); // Manejo de errores en la base de datos
            }
        }

    }
}
