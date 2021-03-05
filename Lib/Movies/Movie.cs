using DIO.Series.Lib.Identificavel;
using System;
using System.Diagnostics;

namespace DIO.Series.Lib.Movies
{
    public class Movie : Identificaveis
    {
      
        public int Id { get; set; }
        public Genero Genero { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Ano { get; set; }
        public bool Excluido { get; set; }
        
        public Movie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;

        }


        public Movie(Genero genero, string titulo, string descricao, int ano, bool excluido)
        {
            this.Id = GerarId();
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = excluido;

        }

        public Movie(Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = GerarId();
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;

        }

        public void SetId(int id)
        {
            this.Id = id;
        }

        public int GetId()
        {
            return this.Id;
        }

        public int GerarId()
        { 
            Guid myuuid = Guid.NewGuid();
            string myuuidAsString = myuuid.ToString();
            string numerosUid = "";
            // Pegar só os números
            foreach(char l in myuuidAsString)
            {
                if(l >= '0' && l <= '9')
                    numerosUid += l;
            }

            int iRet = 0;
            try
            {
                iRet = int.Parse(numerosUid);    
            }
            catch (Exception)
            {
                iRet = 1;
            }
            
            return iRet;
        }

         public override string ToString()
		{
			string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
			return retorno;
		}

        public string retornaTitulo()
		{
			return this.Titulo;
		}

		public int retornaId()
		{
			return this.Id;
		}
        public bool retornaExcluido()
		{
			return this.Excluido;
		}
        public void Excluir() {
            this.Excluido = true;
        }
    }
}