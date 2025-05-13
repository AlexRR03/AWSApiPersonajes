using AWSApiPersonajes.Models;
using AWSApiPersonajes.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AWSApiPersonajes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private RepositoryPersonajes repo;
        public PersonajesController(RepositoryPersonajes repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public async Task<ActionResult<List<Personaje>>> GetPersonajes()
        {
            return await this.repo.GetPersonajesAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Personaje>> GetPersonaje(int id)
        {
            Personaje personaje = await this.repo.FindPersonajeAsync(id);
            if (personaje == null)
            {
                return NotFound();
            }
            return personaje;
        }
        [HttpPost]
        public async Task<ActionResult> Create(Personaje personaje)
        {
            if (personaje == null)
            {
                return BadRequest();
            }
            await this.repo.CreatePersonajeAsync(personaje.Nombre, personaje.Imagen);
            return Ok();
        }
    }
}
