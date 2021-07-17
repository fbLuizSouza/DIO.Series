using System;
using System.Collections.Generic;
using System.Text;

namespace DIO.Series.Entidades
{
    public class Serie : EntidadeBase
    {
        public Genero Genero { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public int Ano { get; private set; }
        public bool Excluido { get; set; }

        public Serie()
        {
        }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            Id = id;
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
            Excluido = false;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }
        public override string ToString()
        { 
            string dadosSerie = "";
            dadosSerie += "Gênero: " + this.Genero + Environment.NewLine;
            dadosSerie += "Título: " + this.Titulo + Environment.NewLine;
            dadosSerie += "Descrição: " + this.Descricao + Environment.NewLine;
            dadosSerie += "Ano de lançamento: " + this.Ano + Environment.NewLine;
            dadosSerie += "Excluído: " + (this.Excluido ? "Sim" : "Não") ;

            return dadosSerie;
        }
    }

}
