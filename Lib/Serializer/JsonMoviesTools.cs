using System.Text.Json;
using System.Text.Json.Serialization;
using DIO.Series.Lib.Movies;
using DIO.Series.Lib.Identificavel;
using System.IO;
using System.Collections.Generic;

namespace DIO.Series.Lib.Serializer
{
    public class JsonMoviesTools
    {
        // O uso de "Movies.Movies" é por causa de problemas com o namespace, foi a única solução
        private Movies.Movies osFilmes = null;
        private Serializer.MoviesJson osFilmesSerializaveis = null;
        private string pathString;


        public JsonMoviesTools(Movies.Movies osFilmes, string FilePath)
        {
            this.osFilmes = osFilmes;
            this.pathString = FilePath;
        }

        public void LerArquivoJson()
        {
            string txtjson = LerArquioTexto();

            var options = new JsonSerializerOptions
            {
                IncludeFields = true,
            };

            this.osFilmesSerializaveis = JsonSerializer.Deserialize<Serializer.MoviesJson>(txtjson, options);
            List<MovieJson> filmes = this.osFilmesSerializaveis.Lista();

            ConverterListaDeObjetos(filmes);
        }

        private void ConverterListaDeObjetos(List<MovieJson> filmes)
        {
            if (this.osFilmes == null)
            {
                this.osFilmes = new Movies.Movies();
            }

            foreach (Serializer.MovieJson filme in filmes)
            {
                Movies.Movie filmeNormal = new Movies.Movie
                    (filme.Id, filme.Genero, filme.Titulo, filme.Descricao, filme.Ano);
                if(filme.Excluido)
                {
                    filmeNormal.Excluir();
                }
                this.osFilmes.Insere(filmeNormal);
            }
        }


        private string LerArquioTexto()
        {
            string text = System.IO.File.ReadAllText(this.pathString);

            return text;
        }

        public void EscreverArquivoJson()
        {
            string txtjson = "";

            var options = new JsonSerializerOptions
            {
                IncludeFields = true,
            };

            txtjson = SerializandoObjetosDeFilmes(options);

            EscreverArquivoTexto(this.pathString, txtjson);
        }

        private string SerializandoObjetosDeFilmes(JsonSerializerOptions options)
        {
            string txtjson;
            //Serializar Lista de Filmes
            // Inicializando do zero filmes serializaveis
            this.osFilmesSerializaveis = new MoviesJson();
            List<Movie> filmes = this.osFilmes.Lista();
            foreach (Movie filme in filmes)
            {
                MovieJson FilmeJson =
                    new MovieJson(filme.Id, filme.Genero, filme.Titulo, filme.Descricao, filme.Ano);
                if (filme.Excluido)
                {
                    FilmeJson.Excluir();
                }
                this.osFilmesSerializaveis.Insere(FilmeJson);
            }
            txtjson = JsonSerializer.Serialize<MoviesJson>
                    (this.osFilmesSerializaveis, options);
            return txtjson;
        }

        private static async void EscreverArquivoTexto(string FilePath, string TextoJson)
        {
            await File.WriteAllTextAsync(FilePath, TextoJson);
        }


        public Movies.Movies GetMovies()
        {
            return this.osFilmes;
        }

        public void AtualizarMovies(Movies.Movies filmes)
        {
            this.osFilmes = filmes;
        }
    }
}