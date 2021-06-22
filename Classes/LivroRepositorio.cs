using System;
using System.Collections.Generic;
using MinhaEstante.Interfaces;

namespace MinhaEstante
{
    public class LivroRepositorio:IFRepositorio<Livro>
    {
         private List <Livro> listaSerie = new List<Livro>();
        public void Atualiza(int id, Livro objeto)
        {
            listaSerie[id]=objeto;
        }

        public void Exclui(int id)
        {
            listaSerie[id].Excluir();
        }

        public void Insere(Livro objeto)
        {
            listaSerie.Add(objeto);
        }

        public List<Livro> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Livro RetornaPorId(int id)
        {
            return listaSerie[id];
        }
    }
    
}