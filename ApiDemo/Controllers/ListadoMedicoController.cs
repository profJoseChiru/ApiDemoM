using ApiDemo.Contexts;
using ApiDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListadoMedicoController : ControllerBase
    {
        private readonly ApplicationDbContext applicationDbContext;

        public ListadoMedicoController (ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public async Task<ActionResult<List<ListadoMedico>>> GetListadoMedicos()
        {
            return await applicationDbContext.ListadoMedicos.ToListAsync();
        }
        [HttpGet("{nombre}")]
        public async Task<ActionResult<List<ListadoMedico>>> GetMedicoPorNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                return BadRequest("El nombre no puede estar vacío.");
            }

            var resultados = await applicationDbContext.ListadoMedicos
                .Where(m => m.nombre.ToLower().Contains(nombre.ToLower())) // Cambia "Nombre" por la propiedad correcta
                .ToListAsync();

            if (!resultados.Any())
            {
                return NotFound("No se encontraron médicos con ese nombre.");
            }

            return Ok(resultados);
        }
    }
}
