using System;

namespace MinhaEstante
{
    public class Livro: EntidadeBase
    {
         //Atributos
        private Genero Genero{get;set;}
        private string Titulo{get;set;}
        private string Autor{get;set;}
        private string Descricao{get;set;}
        private int Ano{get;set;}
        private bool Emprestado {get;set;}

    public Livro (int id, Genero genero, string titulo, string autor, string descricao, int ano)
    {
        this.Id=id;
        this.Genero=genero;
        this.Titulo=titulo;
        this.Autor=autor;
        this.Descricao=descricao;
        this.Ano=ano;
        this.Emprestado=false;
    }

        public override string ToString()
        {
            string retorno="";
            retorno+="Gênero: "+this.Genero+Environment.NewLine;
            retorno+="Título: "+this.Titulo+Environment.NewLine;
            retorno+="Autor: "+this.Autor+Environment.NewLine;
            retorno+="Descrição: "+this.Descricao+Environment.NewLine;
            retorno+="Ano de estréia: "+this.Ano+Environment.NewLine;
            retorno+="Emprestado: "+this.Emprestado;
            
            return retorno;
        }

        public string retornaTitulo(){
            return this.Titulo;
        }
        public string retornaAutor()
        {
            return this.Autor;
        }
        public int retornaId()
        {
            return this.Id;
        }
        public bool retornaEmprestado()
        {
            return this.Emprestado;
        }
        public void Emprestar()
        {
            this.Emprestado=true;
        }
        public void Devolver()
        {
            this.Emprestado=false;
        }
    }

}