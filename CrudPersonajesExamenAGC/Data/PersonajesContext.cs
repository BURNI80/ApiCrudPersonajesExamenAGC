using CrudPersonajesExamenAGC.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudPersonajesExamenAGC.Data
{
    public class PersonajesContext : DbContext
    {

        public PersonajesContext(DbContextOptions<PersonajesContext> options) : base(options) { }


        public DbSet<Personaje> Personajes { get; set; }

    }
}
