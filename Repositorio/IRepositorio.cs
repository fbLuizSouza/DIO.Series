using System;
using System.Collections.Generic;

namespace DIO.Series.IRepositorio
{
    public interface IRepositorio<T>
    {
        List<T> GetSeries();
        T GetSeriePorID(int id);
        void Inserir(T entidade);
        void Excluir(int id);
        void Atualizar(T entidade);
        int GetProximoId();
    }
}
