using System;
using System.Collections.Generic;
namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio serieRepositorio = new SerieRepositorio();
        static FilmeRepositorio filmeRepositorio = new FilmeRepositorio();
        static List<Serie> series = new List<Serie>();
        static List<Filme> filmes = new List<Filme>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X") 
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeriesFilmes();
                        break;
                    case "2":
                        ManutencaoSerie();
                        break;
                    case "3":
                        ManutencaoFilme();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
                Console.WriteLine(opcaoUsuario);
            }
        }

        static void ManutencaoSerie()
        {
            string opcaoSerie = ObterOpcaoSerie();

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
                opcaoSerie = ObterOpcaoSerie();
                Console.WriteLine(opcaoSerie);
            }
        }

        static void ManutencaoFilme()
        {
            string opcaoFilme = ObterOpcaoFilme();

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
                opcaoFilme = ObterOpcaoFilme();
                Console.WriteLine(opcaoFilme);
            }
        }

        private static void ListarSeriesFilmes() 
        {
            ListarSerie();
            ListarFilme();;
        }

        private static void ListarSerie() 
        {
            Console.WriteLine("Listar Series");
            series = serieRepositorio.Lista();
            if (series.Count == 0) {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
            foreach (var serie in series) 
            {
                Console.WriteLine("#ID {0}: {1} - Excluido(a): {2}", serie.retornaId(), serie.retornaTitulo(), serie.retornaExcluido() ? "Sim" : "Não");
            }
        }

        private static void ListarFilme() 
        {
            Console.WriteLine("Listar Filmes");
            filmes = filmeRepositorio.Lista();
            if (filmes.Count == 0) {
                Console.WriteLine("Nenhum filme cadastrado.");
                return;
            }
            foreach (var filme in filmes) 
            {
                Console.WriteLine("#ID {0}: {1} - Excluido(a): {2}", filme.retornaId(), filme.retornaTitulo(), filme.retornaExcluido() ? "Sim" : "Não");
            }
        }

        public static void InserirSerie() 
        {
            Console.WriteLine("Inserir nova Série");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: serieRepositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            serieRepositorio.Insere(novaSerie);
        }

        public static void InserirFilme() 
        {
            Console.WriteLine("Inserir novo Filme");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título do Filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início do Filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do Filme: ");
            string entradaDescricao = Console.ReadLine();

            Filme novoFilme = new Filme(id: filmeRepositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            filmeRepositorio.Insere(novoFilme);
        }

        public static void AtualizarSerie() 
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            Console.WriteLine("Atualizar serie");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            serieRepositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        public static void AtualizarFilme() 
        {
            Console.Write("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            Console.WriteLine("Atualizar filme");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título do Filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início do Filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do Filme: ");
            string entradaDescricao = Console.ReadLine();

            Filme atualizaFilme = new Filme(id: indiceFilme,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            filmeRepositorio.Atualiza(indiceFilme, atualizaFilme);
        }
        public static void ExcluirSerie() 
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            serieRepositorio.Excluir(indiceSerie);
        }

        public static void ExcluirFilme() 
        {
            Console.Write("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            filmeRepositorio.Excluir(indiceFilme);
        }

        public static void VisualizarSerie() 
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            Console.Write(serieRepositorio.RetornaPorId(indiceSerie));
        }

        public static void VisualizarFilme() 
        {
            Console.Write("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            Console.Write(filmeRepositorio.RetornaPorId(indiceFilme));
        }


        private static string ObterOpcaoUsuario() {
            Console.WriteLine();
            Console.WriteLine("DIO Séries e Filmes seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Lista séries e filmes");
            Console.WriteLine("2 - Manutenção séries");
            Console.WriteLine("3 - Manutenção filmes");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    
        private static string ObterOpcaoSerie() {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Lista séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - voltar tela anterior");

            string opcaoSerie = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoSerie;
        }

        private static string ObterOpcaoFilme() {
            Console.WriteLine();
            Console.WriteLine("DIO Filmes a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Lista filmes");
            Console.WriteLine("2 - Inserir novo filme");
            Console.WriteLine("3 - Atualizar filme");
            Console.WriteLine("4 - Excluir filme");
            Console.WriteLine("5 - Visualizar filme");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - voltar tela anterior");

            string opcaoFilme = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoFilme;
        }

    }    
}
