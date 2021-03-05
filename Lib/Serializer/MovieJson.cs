using DIO.Series.Lib.Identificavel;
using DIO.Series.Lib.Movies;
using System;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DIO.Series.Lib.Serializer
{
    public class MovieJson : Identificaveis
    {
      
        [JsonInclude]
        public int Id { get; set; }
        [JsonInclude]
        public Genero Genero { get; set; }
        [JsonInclude]
        public string Titulo { get; set; }
        [JsonInclude]
        public string Descricao { get; set; }
        [JsonInclude]
        public int Ano { get; set; }
        [JsonInclude]
        public bool Excluido { get; set; }
        
        public MovieJson()
        {
            
        }
        
        public MovieJson(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;

        }


        public MovieJson(Genero genero, string titulo, string descricao, int ano, bool excluido)
        {
            this.Id = GerarId();
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = excluido;

        }

        public MovieJson(Genero genero, string titulo, string descricao, int ano)
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