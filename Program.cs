using System;
using DIO.Series.Lib.Movies;
using DIO.Series.View.Crud;
using DIO.Series.View.Menu;
using System.Configuration;
using DIO.Series.Lib.Serializer;

namespace DIO.Series
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configurações
            string diretorioDB = ConfigurationManager.AppSettings["dir"];
            string arquivoDB = ConfigurationManager.AppSettings["file"];
            string pathString = System.IO.Path.Combine(diretorioDB, arquivoDB);
            System.Console.WriteLine($"Arquivo : {pathString}");
            System.Console.WriteLine("");
            // Criar Diretório se não existe
            if(!System.IO.Directory.Exists(diretorioDB))
                System.IO.Directory.CreateDirectory(diretorioDB);


            // Componentes de interface
            MenuBasico menu = new MenuBasico();
            Movies osFilmes = new Movies();
            CrudMovie crud = new CrudMovie(osFilmes);
            JsonMoviesTools tools = null;

            // Criar arquivo se não existe 
            if (!System.IO.File.Exists(pathString))
            {
                System.IO.File.CreateText(pathString);
            } else // Ler o arquivo e guarda na mémória
            {
                tools = new JsonMoviesTools(osFilmes, pathString);
                tools.LerArquivoJson();
                osFilmes = tools.GetMovies();
                
            }
            
            string opcaoUsuario = "";
            bool bAlteracao = false;

			do 
			{
                opcaoUsuario = menu.ObterOpcaoUsuario();
				switch (opcaoUsuario)
				{
					case "1":
						crud.ListarSeries();
						break;
					case "2":
						crud.InserirSerie();
                        bAlteracao = true;
						break;
					case "3":
						crud.AtualizarSerie();
                        bAlteracao = true;
						break;
					case "4":
						crud.ExcluirSerie();
                        bAlteracao = true;
						break;
					case "5":
						crud.VisualizarSerie();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}
                // Salvar Dados da Memória em arquivo Json
                if(bAlteracao)
                {
                    if(tools == null)
                    {
                        tools = new JsonMoviesTools(osFilmes, pathString);
                    }
                    tools.AtualizarMovies(osFilmes);
                    tools.EscreverArquivoJson();
                    bAlteracao = false;
                }

			} while (opcaoUsuario.ToUpper() != "X");

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }
    }
}
