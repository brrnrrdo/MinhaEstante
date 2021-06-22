using System;

namespace MinhaEstante
{
    class Program
    { static LivroRepositorio repositorio=new LivroRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario=ObterOpcaoUsuario();

            while  (opcaoUsuario.ToUpper()!="X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarLivros();
                        break;
                    case "2":
                        InserirLivro();
                        break;
                    case "3":
                        AtualizarLivro();
                        break;
                    case "4":
                        EmprestarLivro();
                        break;
                    case "5":
                        VisualizarLivro();
                        break;
                    case "6":
                        DevolverLivro();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario=ObterOpcaoUsuario();
            }
            Console.WriteLine("Volte sempre.");
            Console.ReadLine();
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Minha Estante");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();
            Console.WriteLine("1 - Listar livros");
            Console.WriteLine("2 - Inserir novo livro");
            Console.WriteLine("3 - Atualizar livro");
            Console.WriteLine("4 - Emprestar livro");
            Console.WriteLine("5 - Visualizar livro");
            Console.WriteLine("6 - Devolver livro");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario=Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void ListarLivros()
        {
            Console.WriteLine("Listar livros");
            Console.WriteLine();

            var lista=repositorio.Lista();

            if(lista.Count==0)
            {
                Console.WriteLine("Nenhum livro cadastrado.");
                Console.ReadLine();
                
                return;
            }
            foreach(var livro in lista)
            {
                var emprestado=livro.retornaEmprestado();
                Console.WriteLine();
                Console.WriteLine("#ID {0} {1} {2} {3}", livro.retornaId(), livro.retornaTitulo(), "- "+livro.retornaAutor(), (emprestado?"*Emprestado*":"- Na estante"));
            }
            Console.ReadLine();
        }

        private static void InserirLivro()
        {
            Console.WriteLine("Inserir novo livro");
            Console.WriteLine();

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof (Genero), i));
            }
            Console.WriteLine();
            Console.Write("Digite o Gênero entre as opções acima: ");
            int entradaGenero=int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Digite o Título do Livro: ");
            string entradaTitulo=Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Digite o Autor do Livro: ");
            string entradaAutor=Console.ReadLine();

            Console.WriteLine();
            Console.Write("Digite o Ano do Livro: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.Write("Digite a Descrição do Livro: ");
            string entradaDescricao=Console.ReadLine();

            Livro novoLivro= new Livro(id: repositorio.ProximoId(),
                                        genero:(Genero)entradaGenero,
                                        titulo: entradaTitulo, autor: entradaAutor,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Insere(novoLivro);
        }
        private static void AtualizarLivro()
        {
            
            Console.Write("Digite o id do livro: ");
            Console.WriteLine();
            int indiceLivro=int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof (Genero)))
            {
                Console.WriteLine("{0}-{1}",i,Enum.GetName(typeof(Genero),i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero=int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título do livro: ");
            string entradaTitulo=Console.ReadLine();

            Console.WriteLine("Digite o Autor do livro: ");
            string entradaAutor=Console.ReadLine();

            Console.Write("Digite o Ano do livro: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do livro: ");
            string entradaDescricao=Console.ReadLine();

            Livro atualizaLivro= new Livro(id: indiceLivro,
                                        genero:(Genero)entradaGenero,
                                        titulo: entradaTitulo, autor: entradaAutor,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            
            repositorio.Atualiza(indiceLivro,atualizaLivro);
        }

        private static void EmprestarLivro()
        {
            Console.Write("Digite o id do livro: ");
            int indiceLivro=int.Parse(Console.ReadLine());

            repositorio.Empresta(indiceLivro);
        }
        private static void DevolverLivro()
        {
            Console.WriteLine("Digite o id do livro: ");
            int indiceLivro=int.Parse(Console.ReadLine());

            repositorio.Devolve(indiceLivro);
        }

        private static void VisualizarLivro()
        {
            Console.Write("Digite o id do livro: ");
            int indiceLivro=int.Parse(Console.ReadLine());

            var livro=repositorio.RetornaPorId(indiceLivro);

            Console.WriteLine();
            Console.WriteLine(livro);

            Console.ReadLine();

        }
    }

}
