using AWSApiPersonajes.Data;
using AWSApiPersonajes.Models;
using Microsoft.EntityFrameworkCore;

namespace AWSApiPersonajes.Repositories
{
    public class RepositoryPersonajes
    {
        private PersonajesContext context;
        public RepositoryPersonajes(PersonajesContext context)
        {
            this.context = context;
        }
        public async Task<int> GetMaxIdAsync()
        {
          return await this.context.Personajes.MaxAsync(x => x.IdPersonaje) +1;
            
        }

        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            return await this.context.Personajes.ToListAsync();
        }
        public async Task<Personaje> FindPersonajeAsync(int id)
        {
            return await this.context.Personajes.FirstOrDefaultAsync(x => x.IdPersonaje == id);
        }
        public async Task CreatePersonajeAsync( string nombre, string imagen)
        {
            Personaje personaje = new Personaje();
            personaje.IdPersonaje = await this.GetMaxIdAsync();
            personaje.Nombre = nombre;
            personaje.Imagen = imagen;
            await this.context.Personajes.AddAsync(personaje);
            await this.context.SaveChangesAsync();
        }
    }
}
