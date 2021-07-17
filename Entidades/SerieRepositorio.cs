using DIO.Series.IRepositorio;
using System;
using System.Collections.Generic;

namespace DIO.Series.Entidades
{
   
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSeries = new List<Serie>();

        public List<Serie> GetSeries()
        {
            return listaSeries;
        }
        public Serie GetSeriePorID(int id)
        {
            try
            {
                return listaSeries[id];
            }
            catch(Exception e)
            {
                Console.WriteLine("Série não cadastrada!");           
            }

            return null;
        }
        public void Inserir(Serie serie)
        {
            listaSeries.Add(serie);
        }
        public void Excluir(int id)
        {
            listaSeries[id].Excluir();
        }
        public void Atualizar(Serie serie)
        {
            listaSeries[serie.Id] = serie;
        } 
        public int GetProximoId()
        {
            return listaSeries.Count;
        }
    }
}
