using System.Collections.Generic;

namespace MinhaEstante.Interfaces
{
    public interface IFRepositorio<T>
    {
        List<T> Lista();
        T RetornaPorId(int id);
        void Insere(T entidade);
        void Empresta(int id);
        void Devolve(int id);
        void Atualiza(int id, T entidade);
        int ProximoId();
    }
}