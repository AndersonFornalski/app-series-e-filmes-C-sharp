using System;
using Series.Classes;

namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static FilmeRepositorio repositorioFilme = new FilmeRepositorio();
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
            } 
             string sim = mensagem();            
             while (sim.ToUpper() != "S")
            {
                switch (sim)
                {
                        case "S":
                            break;
                        case "N":
                            menu();
                            break;
                        default:
                        throw new ArgumentOutOfRangeException();
                };
                sim = mensagem(); 
            }
        }

        private static string mensagem()  
        {
            Console.WriteLine(" tem certeza que deseja sair ?");
            Console.WriteLine(" S - Sim");
            Console.WriteLine(" N - Não");
            Console.WriteLine();
            string sim = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return sim;
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
                        //ListarFilme();
                        break;
                    case "2":
                        //InserirFilme();
                        break;
                    case "3":
                        //AtualizarFilme();
                        break;
                    case "4":
                        //ExcluirFilme();
                        break;
                    case "5":
                        //VisualizarFilme();
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
                        //ListarFilme();
                        break;
                    case "2":
                        //InserirFilme();
                        break;
                    case "3":
                        //AtualizarFilme();
                        break;
                    case "4":
                        //ExcluirFilme();
                        break;
                    case "5":
                        //VisualizarFilme();
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









        private static void ListarSerie()
        {
            Console.WriteLine("Listar Séries ");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Série Cadastrada. ");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
             
                Console.Write("#ID {0}: - {1} - {2} ",
                serie.retornaId(), serie.retornaTitulo(),
                ( excluido ? "Excluido" : " "));
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

            Console.WriteLine("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de inicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Insere(novaSerie);
        }

         private static void AtualizarSerie()
         {
            Console.WriteLine("Digite o ID da Série");
            int indiceSerie = int.Parse(Console.ReadLine());
             
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o Genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de inicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizeSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Atualiza(indiceSerie, atualizeSerie);
         }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o ID da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);    
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o ID da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);
            
            Console.WriteLine(serie);
        }
        private static string opcoesFilmes()
        {
            Console.WriteLine(" Clainet Filmes:");
            Console.WriteLine(" informe a opção desejada:");

            Console.WriteLine(" 1 - Listar Filmes");
            Console.WriteLine(" 2 - Inserir Novo Filme");
            Console.WriteLine(" 3 - Atualizar Filme");
            Console.WriteLine(" 4 - Excluir Filme");
            Console.WriteLine(" 5 - Visualizar Filme");
            Console.WriteLine(" 6 - Limpar Tela");
            Console.WriteLine(" X - Sair");

            string opcaoFilme = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoFilme;

        }

        private static string opcoesSeries()
        {
            Console.WriteLine(" Clainet Séries:");
            Console.WriteLine(" informe a opção desejada:");

            Console.WriteLine(" 1 - Listar Séries");
            Console.WriteLine(" 2 - Inserir Nova Séries");
            Console.WriteLine(" 3 - Atualizar Séries");
            Console.WriteLine(" 4 - Excluir Séries");
            Console.WriteLine(" 5 - Visualizar Séries");
            Console.WriteLine(" 6 - Limpar Tela");
            Console.WriteLine(" X - Sair");

            string opcaoSerie = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoSerie;

        }

        private static string cadastroUsuario()
        {
            Console.WriteLine(" Clainet Cadastro de Usuário:");
            Console.WriteLine(" informe a opção desejada:");

            Console.WriteLine(" 1 - Listar Usuário");
            Console.WriteLine(" 2 - Cadastrar Usuário");
            Console.WriteLine(" 3 - Atualizar Usuário");
            Console.WriteLine(" 4 - Excluir Usuário");
            Console.WriteLine(" 5 - Visualizar Usuário");
            Console.WriteLine(" 6 - Limpar Tela");
            Console.WriteLine(" X - Sair");

            string usuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return usuario;

        }

    }
}
