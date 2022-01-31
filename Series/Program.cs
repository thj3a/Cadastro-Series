using static System.Console;
namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        
        static void Main(string[] args)
        {
            string opcao = ObterOpcoes();
            while (opcao != "X")
            {
                switch (opcao)
                {
                    case "1":
                        Inserir();
                        break;
                    case "2":
                        Atualizar();
                        break;
                    case "3":
                        Excluir();
                        break;
                    case "4":
                        ListarTodas();
                        break;
                    case "5":
                        ListarPorGenero();
                        break;
                    case "6":
                        ListarPorQuantidadeDeTemporadas();
                        break;
                    case "7":
                        ListarPorQuantidadeDeEpisodios();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        WriteLine("Opção inválida!");
                        break;
                }
                opcao = ObterOpcoes();
            }
        }
        private static string ObterOpcoes()
        {
            WriteLine();
            WriteLine("Bem vindo ao sistema de séries!");
            WriteLine("Por favor, escolha uma das opções abaixo: ");
            WriteLine("1 - Inserir uma nova série");
            WriteLine("2 - Atualizar uma série");
            WriteLine("3 - Excluir uma série");
            WriteLine("4 - Listar todas as séries");
            WriteLine("5 - Listar por gênero");
            WriteLine("6 - Listar por quantidade de temporadas");
            WriteLine("7 - Listar por quantidade de episódios");
            WriteLine("C - Limpar tela");
            WriteLine("X - Sair");
            WriteLine();

            string opcao = ReadLine().ToUpper();
            WriteLine();
            return opcao;
        }
        private static void Inserir()
        {
            WriteLine("Índice de gênero: ");	
            foreach (int i in Enum.GetValues(typeof(E_Genero)))
            {
                WriteLine($"{i} - {Enum.GetName(typeof(E_Genero), i)}");
            }
            WriteLine("Informe o gênero da série entre as opções acima: ");
            int idgenero = int.Parse(ReadLine());
            WriteLine("Informe o titulo da série: ");
            string titulo = ReadLine();
            WriteLine("Informe o número de temporadas: ");
            int temporadas = int.Parse(ReadLine());
            WriteLine("Informe o número de episódios: ");
            int episodios = int.Parse(ReadLine());
            repositorio.Inserir(new Serie(repositorio.ProximoId(), (E_Genero)idgenero, titulo, temporadas, episodios));
        }
        private static void Atualizar()
        {
            WriteLine("Informe o id da série que deseja atualizar: ");
            int idInformado = int.Parse(ReadLine());
            WriteLine("Índice de gênero - Gênero");	
            foreach (int i in Enum.GetValues(typeof(E_Genero)))
            {
                WriteLine($"{i} - {Enum.GetName(typeof(E_Genero), i)}");
            }
            WriteLine("Informe o gênero da série entre as opções acima: ");
            int idgenero = int.Parse(ReadLine());
            WriteLine("Informe o titulo da série: ");
            string titulo = ReadLine();
            WriteLine("Informe o número de temporadas: ");
            int temporadas = int.Parse(ReadLine());
            WriteLine("Informe o número de episódios: ");
            int episodios = int.Parse(ReadLine());
            repositorio.Atualizar(idInformado, new Serie(idInformado, (E_Genero)idgenero, titulo, temporadas, episodios));
        }
        private static void Excluir()
        {
            WriteLine("Informe o id da série que deseja excluir: ");
            int idInformado = int.Parse(ReadLine());
            repositorio.Excluir(idInformado);
        }
        private static void ListarTodas()
        {
            var lista = repositorio.RetornarTodos();
            if (lista.Count == 0)
            {
                WriteLine("Não há séries cadastradas!");
            }
            else
            {
                WriteLine("Lista de séries cadastradas:");
                foreach (var s in lista)
                {
                    if (s.retornaExcluido() == false)
                    {
                        WriteLine(s.ToString());
                    }

                }
            }
        }
        private static void ListarPorGenero()
        {
            WriteLine("Índice de gênero - Gênero");	
            foreach (int i in Enum.GetValues(typeof(E_Genero)))
            {
                WriteLine($"{i} - {Enum.GetName(typeof(E_Genero), i)}");
            }
            WriteLine("Informe o gênero que deseja listar: ");
            int idgenero = int.Parse(ReadLine());
            var lista = repositorio.RetornarTodos();
            WriteLine();
            WriteLine("Lista de séries do gênero consultado: ");
            foreach (var s in lista)
            {
                if (s.retornaGenero() == (E_Genero)idgenero && s.retornaExcluido() == false)
                {
                    WriteLine(s.ToString());
                }
            }
        }
        private static void ListarPorQuantidadeDeTemporadas()
        {
            WriteLine("Informe o número minimo de temporadas que a serie deve ter: ");
            var minimo = int.Parse(ReadLine());
            var lista = repositorio.RetornarTodos();
            WriteLine();
            WriteLine("Lista de séries com a quantidade de temporadas acima ou igual a informada: ");
            foreach (var s in lista)
            {
                if (s.retornaTemporadas() >= minimo && s.retornaExcluido() == false)
                {
                    WriteLine(s.ToString());
                }
            }
        }
        private static void ListarPorQuantidadeDeEpisodios()
        {
            WriteLine("Informe o número minimo de episódios que a serie deve ter: ");
            var minimo = int.Parse(ReadLine());
            var lista = repositorio.RetornarTodos();
            WriteLine();
            WriteLine("Lista de séries com a quantidade de episódios acima ou igual a informada: ");
            foreach (var s in lista)
            {
                if (s.retornaEpisodios() >= minimo && s.retornaExcluido() == false)
                {
                    WriteLine(s.ToString());
                }
            }
        }
    }
}
