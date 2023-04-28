using CrudPersonajesExamenAGC.Data;
using CrudPersonajesExamenAGC.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudPersonajesExamenAGC.Repositories
{
    public class PersonajesReposritory
    {
        private PersonajesContext context;

        public PersonajesReposritory(PersonajesContext context)
        {
            this.context = context;
        }

        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            return await this.context.Personajes.ToListAsync();
        }

        public async Task<Personaje> FindPersonaje(int id)
        {
            return await this.context.Personajes.Where(x => x.IdPersonaje == id).FirstOrDefaultAsync();
        }

        public async Task CreatePersonaje(Personaje personaje)
        {
            personaje.IdPersonaje = this.context.Personajes.Max(x => x.IdPersonaje) + 1;
            this.context.Personajes.Add(personaje);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdatePersonaje(Personaje personaje)
        {
            Personaje p = await FindPersonaje(personaje.IdPersonaje);
            p.PersonajeNombre = personaje.PersonajeNombre;
            p.Imagen = personaje.Imagen;
            p.IdSerie = personaje.IdSerie;
            await this.context.SaveChangesAsync();
        }

        public async Task DeletePersonaje(int id)
        {
            Personaje p = await FindPersonaje(id);
            this.context.Personajes.Remove(p);
            await this.context.SaveChangesAsync();
        }




    }
}
