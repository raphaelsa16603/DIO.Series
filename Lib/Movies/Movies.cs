using System.Collections.Generic;

namespace DIO.Series.Lib.Movies
{
    public class Movies : IRepositorio<Movie>
    {
        private List<Movie> listaMovies = new List<Movie>();

        public void Atualiza(int id, Movie entidade)
        {
            this.listaMovies[id] = entidade;
        }

        public void Exclui(int id)
        {
            this.listaMovies[id].Excluir();
        }

        public void Insere(Movie entidade)
        {
            this.listaMovies.Add(entidade);
        }

        public List<Movie> Lista()
        {
            return this.listaMovies;
        }

        public int ProximoId()
        {
            return this.listaMovies.Count;
        }

        public Movie RetornaPorId(int id)
        {
            return this.listaMovies[id];
        }
        
    }
}