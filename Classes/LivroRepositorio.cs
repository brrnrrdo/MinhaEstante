using System;
using System.Collections.Generic;
using MinhaEstante.Interfaces;

namespace MinhaEstante
{
    public class LivroRepositorio:IFRepositorio<Livro>
    {
         private List <Livro> listaLivro = new List<Livro>();
        public void Atualiza(int id, Livro objeto)
        {
            listaLivro[id]=objeto;
        }

        public void Empresta(int id)
        {
            listaLivro[id].Emprestar();
        }
        public void Devolve(int id)
        {
            listaLivro[id].Devolver();
        }

        public void Insere(Livro objeto)
        {
            listaLivro.Add(objeto);
        }

        public List<Livro> Lista()
        {
            return listaLivro;
        }

        public int ProximoId()
        {
            return listaLivro.Count;
        }

        public Livro RetornaPorId(int id)
        {
            return listaLivro[id];
        }
    }
    
}