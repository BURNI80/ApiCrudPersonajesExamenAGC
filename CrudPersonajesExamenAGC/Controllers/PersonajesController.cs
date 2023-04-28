using CrudPersonajesExamenAGC.Models;
using CrudPersonajesExamenAGC.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudPersonajesExamenAGC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private PersonajesReposritory repo;

        public PersonajesController(PersonajesReposritory repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Personaje>>> GetPersonajes()
        {
            return await this.repo.GetPersonajesAsync();
        }

        [HttpGet]
        [Route("/api/[action]/{id}")]
        public async Task<ActionResult<Personaje>> FindPersonaje(int id)
        {
            return await this.repo.FindPersonaje(id);
        }

        [HttpPost]
        [Route("/api/[action]/{personaje}")]
        public async Task CreatePersonaje(Personaje personaje)
        {
            await this.repo.CreatePersonaje(personaje);
        }

        [HttpPut]
        [Route("/api/[action]/{personaje}")]
        public async Task UpdatePersonaje(Personaje personaje)
        {
            await this.repo.UpdatePersonaje(personaje);
        }

        [HttpDelete]
        [Route("/api/[action]/{id}")]
        public async Task DeletePersonaje(int id)
        {
            await this.repo.DeletePersonaje(id);
        }
    }
}
