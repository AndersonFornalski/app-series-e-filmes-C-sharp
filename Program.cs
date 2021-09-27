using System;
using Series.Classes;

namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static FilmeRepositorio repositorioFilme = new FilmeRepositorio();
        static UsuarioRepositorio repositorioUsuario = new UsuarioRepositorio();
        static void Main(string[] args)
        {
            
            string filmeOuSerie = menu();
            while (filmeOuSerie.ToUpper() != "X")
            {
                switch (filmeOuSerie)
                {
                        case "1":
                            TodosFilmes();
                            break;
                        case "2":
                            TodasSeries();
                            break;
                        case "3":
                            RegistroUsuario();
                            break;    
                        default:
                        throw new ArgumentOutOfRangeException();
                };
                filmeOuSerie = menu();
            };
        }
       
        private static string menu()
        {
            Console.WriteLine();
            Console.WriteLine(" ||====   ||           |||     ()   |==| |==|   ||====  ====||===== ");
            Console.WriteLine(" ||       ||          || ||    ||   |  ||   |   ||          ||      ");
            Console.WriteLine(" ||       ||         ||   ||   ||   |       |   ||====      ||      ");
            Console.WriteLine(" ||       ||        ||=====||  ||   |  ||   |   ||          ||      ");
            Console.WriteLine(" ||====   ||=====   ||     ||  ||   |==| |==|   ||====      ||      ");
            Console.WriteLine(" =================================================================== ");
            Console.WriteLine();
            Console.WriteLine(" Bem Vindo a Clainet. Aqui você vai poder \n assistir a filmes e séries todos os dias!! ");
            Console.WriteLine(" Escolha o que você deseja fazer:");
            Console.WriteLine();
            Console.WriteLine(" 1 - Assistir Filmes ");
            Console.WriteLine(" 2 - Assistir Séries ");
            Console.WriteLine(" 3 - Cadastrar-se ");
            Console.WriteLine(" X - Sair ");
            Console.WriteLine();
            string filmeOuSerie = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return filmeOuSerie;
        }

         private static void RegistroUsuario()
        {
             string usuario = cadastroUsuario();                        
             while (usuario.ToUpper() != "X")
            {
                switch (usuario)
                {
                    case "1":
                        ListarUsuario();
                        break;
                    case "2":
                        CadastrarUsuario();
                        break;
                    case "3":
                        AtualizarUsuario();
                        break;
                    case "4":
                        ExcluirUsuario();
                        break;
                    case "5":
                        VisualizarUsuario();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                usuario = cadastroUsuario();
            }   
            Console.WriteLine("Aperte enter, você irá voltar para o menu.");
            Console.ReadLine();            
        }
        private static void TodosFilmes()
        {
             string opcaoFilme = opcoesFilmes();                        
             while (opcaoFilme.ToUpper() != "X")
            {
                switch (opcaoFilme)
                {
                    case "1":
                        ListarFilme();
                        break;
                    case "2":
                        InserirFilme();
                        break;
                    case "3":
                        AtualizarFilme();
                        break;
                    case "4":
                        ExcluirFilme();
                        break;
                    case "5":
                        VisualizarFilme();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoFilme = opcoesFilmes();
            }    
            Console.WriteLine("Aperte enter, você irá voltar para o menu.");
            Console.ReadLine();
        }

        private static void TodasSeries()
        {
            string opcaoSerie = opcoesSeries();
            while (opcaoSerie.ToUpper() != "X")
            {
                switch (opcaoSerie)
                {
                    case "1":
                        ListarSerie();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoSerie = opcoesSeries();
            }
            Console.WriteLine("Aperte enter, você irá voltar para o menu.");
            Console.ReadLine();
        }

        //METODOS USUARIOS
         private static void ListarUsuario()
        {
            Console.WriteLine("Listar Usuarios");
            Console.WriteLine();

            var lista = repositorioUsuario.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum usuario cadastrado.");
                Console.WriteLine();
                return;
            }

            foreach (var user in lista)
            {
                var excluido = user.retornaExcluido();
             
                Console.WriteLine("#ID {0}: - {1} - {2} ",
                user.retornaId(), user.retornaNome(),
                ( excluido ? "Excluido" : " "));
                Console.WriteLine();
            }
        }
        private static void CadastrarUsuario()
        {
            Console.WriteLine("Inserir novo Usuario");
            Console.WriteLine();
            Console.WriteLine("Digite seu nome: ");
            string entradaNome = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Digite seu e-mail: ");
            string entradaEmail = Console.ReadLine();
            Console.WriteLine();
            Usuario novoUsuario = new Usuario(
                                        id: repositorioUsuario.ProximoId(),
                                        nome: entradaNome, 
                                        email: entradaEmail
                                        );
            repositorioUsuario.Insere(novoUsuario);
            Console.WriteLine();
        }
        private static void AtualizarUsuario()
         {
            Console.WriteLine("Digite o ID do usuario");
            int indiceUsuario = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Atualize seu nome: ");
            string entradaNome = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Atualize seu e-mail: ");
            string entradaEmail = Console.ReadLine();
            Console.WriteLine();
            Usuario atualizeUsuario = new Usuario(
                                        id: indiceUsuario,
                                        nome: entradaNome,
                                        email: entradaEmail);
            repositorioUsuario.Atualiza(indiceUsuario, atualizeUsuario);
         }
           private static void ExcluirUsuario()
        {
            Console.WriteLine("Digite o ID do usuário: ");
            int indiceUsuario = int.Parse(Console.ReadLine());
            Console.WriteLine();
            repositorioUsuario.Exclui(indiceUsuario);    
        }

        private static void VisualizarUsuario()
        {
            Console.WriteLine("Digite o ID do usuário: ");
            int indiceUsuario = int.Parse(Console.ReadLine());
            Console.WriteLine();

            var usuario = repositorioUsuario.RetornaPorId(indiceUsuario);            
            Console.WriteLine(usuario);
            Console.WriteLine();
        }



        //METODOS FILMES
         private static void ListarFilme()
        {
            Console.WriteLine("Listar Filmes ");
            var lista = repositorioFilme.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum filme cadastrado. ");
                Console.WriteLine();
                return;
            }

            foreach (var filme in lista)
            {
                var excluido = filme.retornaExcluido();             
                Console.WriteLine("#ID {0}: - {1} - {2} ",
                filme.retornaId(), filme.retornaTitulo(),
                ( excluido ? "Excluido" : " "));
                Console.WriteLine();
            }
        }

        private static void InserirFilme()
        {
            Console.WriteLine("Inserir Novo Filme");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Digite o título do filme: ");
            string entradaTitulo = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Digite o Ano de inicio do filme: ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Digite a descrição do filme: ");
            string entradaDescricao = Console.ReadLine();
            Console.WriteLine();

            Filme novoFilme = new Filme(id: repositorioFilme.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorioFilme.Insere(novoFilme);
            Console.WriteLine();
        }

        private static void AtualizarFilme()
         {
            Console.WriteLine("Digite o ID do Filme");
            int indiceFilme = int.Parse(Console.ReadLine());
            Console.WriteLine();
             
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Digite o título do filme: ");
            string entradaTitulo = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Digite o Ano de inicio do filme: ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Digite a descrição do filme: ");
            string entradaDescricao = Console.ReadLine();
            Console.WriteLine();

            Filme atualizeFilme = new Filme(id: indiceFilme,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorioFilme.Atualiza(indiceFilme, atualizeFilme);
            Console.WriteLine();
         }
          private static void ExcluirFilme()
        {
            Console.WriteLine("Digite o ID do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());
            Console.WriteLine();

            repositorioFilme.Exclui(indiceFilme);  
            Console.WriteLine();  
        }
        private static void VisualizarFilme()
        {
            Console.WriteLine("Digite o ID do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());
            Console.WriteLine();

            var filme = repositorioFilme.RetornaPorId(indiceFilme);            
            Console.WriteLine(filme);
            Console.WriteLine();
        }
        
        //SERIES
        private static void ListarSerie()
        {
            Console.WriteLine("Listar Séries ");
            Console.WriteLine();
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Série Cadastrada. ");
                Console.WriteLine();
                return;
            }
            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();             
                Console.WriteLine("#ID {0}: - {1} - {2} ",
                serie.retornaId(), serie.retornaTitulo(),
                ( excluido ? "Excluido" : " "));
                Console.WriteLine();
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir Nova Série");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o Genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Digite o Ano de inicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();
            Console.WriteLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Insere(novaSerie);
            Console.WriteLine();
        }

         private static void AtualizarSerie()
         {
            Console.WriteLine("Digite o ID da Série");
            int indiceSerie = int.Parse(Console.ReadLine());
            Console.WriteLine();
             
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o Genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Digite o Ano de inicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();
            Console.WriteLine();

            Serie atualizeSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Atualiza(indiceSerie, atualizeSerie);
            Console.WriteLine();
         }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o ID da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);    
            Console.WriteLine();
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o ID da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            Console.WriteLine();
            var serie = repositorio.RetornaPorId(indiceSerie);            
            Console.WriteLine(serie);
            Console.WriteLine();
        }
        private static string opcoesFilmes()
        {
            Console.WriteLine(" =====CLAINET FILMES=====");
            Console.WriteLine(" informe a opção desejada:");
            Console.WriteLine(" 1 - Listar Filmes");
            Console.WriteLine(" 2 - Inserir Novo Filme");
            Console.WriteLine(" 3 - Atualizar Filme");
            Console.WriteLine(" 4 - Excluir Filme");
            Console.WriteLine(" 5 - Visualizar Filme");
            Console.WriteLine(" C - Limpar Tela");
            Console.WriteLine(" X - Sair");
            string opcaoFilme = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoFilme;
        }

        private static string opcoesSeries()
        {
            Console.WriteLine(" =====CLAINET SÉRIES=====");
            Console.WriteLine(" informe a opção desejada:");
            Console.WriteLine(" 1 - Listar Séries");
            Console.WriteLine(" 2 - Inserir Nova Séries");
            Console.WriteLine(" 3 - Atualizar Séries");
            Console.WriteLine(" 4 - Excluir Séries");
            Console.WriteLine(" 5 - Visualizar Séries");
            Console.WriteLine(" C - Limpar Tela");
            Console.WriteLine(" X - Sair");
            string opcaoSerie = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoSerie;
        }

        private static string cadastroUsuario()
        {
            Console.WriteLine(" ====CLAINET USUARIOS====");
            Console.WriteLine(" informe a opção desejada:");
            Console.WriteLine(" 1 - Listar Usuário");
            Console.WriteLine(" 2 - Cadastrar Usuário");
            Console.WriteLine(" 3 - Atualizar Usuário");
            Console.WriteLine(" 4 - Excluir Usuário");
            Console.WriteLine(" 5 - Visualizar Usuário");
            Console.WriteLine(" C - Limpar Tela");
            Console.WriteLine(" X - Sair");
            string usuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return usuario;
        }
    }
}
