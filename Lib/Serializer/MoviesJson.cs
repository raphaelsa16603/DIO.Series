using System.Collections.Generic;
using DIO.Series.Lib.Movies;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DIO.Series.Lib.Serializer
{
    public class MoviesJson : Movies.IRepositorio<MovieJson>
    {
        [JsonInclude]
        public List<MovieJson> listaMovies = new List<MovieJson>();

        public void Atualiza(int id, MovieJson entidade)
        {
            this.listaMovies[id] = entidade;
        }

        public void Exclui(int id)
        {
            this.listaMovies[id].Excluir();
        }

        public void Insere(MovieJson entidade)
        {
            this.listaMovies.Add(entidade);
        }

        public List<MovieJson> Lista()
        {
            return this.listaMovies;
        }

        public int ProximoId()
        {
            return this.listaMovies.Count;
        }

        public MovieJson RetornaPorId(int id)
        {
            return this.listaMovies[id];
        }
        
    }
}