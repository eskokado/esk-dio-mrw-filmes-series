using System;

namespace DIO.Series
{
    public class Serie : EntidadeBase
    {
        private Genero genero { get; set; }
        private string titulo { get; set; }

        private string descricao { get; set; }

        private int ano { get; set; }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano) 
        {
            this.id = id;
            this.genero = genero;
            this.titulo = titulo;
            this.descricao = descricao;
            this.ano = ano;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.genero + Environment.NewLine;
            retorno += "Título: " + this.titulo + Environment.NewLine;
            retorno += "Descrição: " + this.descricao + Environment.NewLine;
            retorno += "Ano: " + this.ano;

            return retorno;
        }

        public string retornaTitulo() 
        {
            return this.titulo;
        }

        public int retornaId() 
        {
            return this.id;
        }
    }
}