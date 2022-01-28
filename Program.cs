using System;
using static System.Console;
using DIO.Musicas.src.Classes;
using DIO.Musicas.src.Interfaces;
using DIO.Musicas.src.Enum;
class Program
{
    static MusicaRepositorio repositorio = new();
    static void Main(string[] args)
    {
        string opcaoUsuario = ObterOpcaoUsuario();

        while (opcaoUsuario.ToUpper() != "X")
        {
            switch (opcaoUsuario)
            {
                case "1":
                    ListarMusica();
                    break;
                case "2":
                    InserirMusica();
                    break;
                case "3":
                    AtualizarMusica();
                    break;
                case "4":
                    ExcluirMusica();
                    break;
                case "5":
                    VisualizarMusica();
                    break;
                case "C":
                    Clear();
                    break;

                default:
                    throw new ArgumentOutOfRangeException();

            }
            opcaoUsuario = ObterOpcaoUsuario();
        }
    }

    private static void InserirMusica()
    {
        Console.WriteLine("Inserir nova música");

        // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
        // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
        }
        Console.Write("Digite o gênero entre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("Digite o Título da música: ");
        string entradaTitulo = Console.ReadLine();

        Console.Write("Digite o Ano de lançamento da música: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Digite a Descrição da música: ");
        string entradaDescricao = Console.ReadLine();

        Musicas novaMusica = new Musicas(id: repositorio.ProximoId(),
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);

        repositorio.Insere(novaMusica);
    }
    private static void ExcluirMusica()
    {
        Console.Write("Digite o id da música: ");
        int indiceMusica = int.Parse(Console.ReadLine());

        repositorio.Exclui(indiceMusica);
    }

    private static void VisualizarMusica()
    {
        Console.Write("Digite o id da música: ");
        int indiceMusicas = int.Parse(Console.ReadLine());

        var musica = repositorio.RetornaPorId(indiceMusicas);

        Console.WriteLine(musica);
    }

    private static void AtualizarMusica()
    {
        Console.Write("Digite o id da música: ");
        int indiceMusica = int.Parse(Console.ReadLine());

        // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
        // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
        }


        int entradaGenero;

        try
        {
            Console.Write("Digite o gênero entre as opções acima: ");
            entradaGenero = int.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
            Console.WriteLine("Gênero inválido");
            return;
        }


        Console.Write("Digite o Título da música: ");
        string entradaTitulo = Console.ReadLine();


        int entradaAno;

        try
        {
            Console.Write("Digite o Ano da música: ");
            entradaAno = int.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
            Console.WriteLine("Data inválida");
            return;
        }

        Console.Write("Digite a Descrição da música: ");
        string entradaDescricao = Console.ReadLine();

        Musicas atualizaMusica = new Musicas(id: indiceMusica,
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);

        repositorio.Atualiza(indiceMusica, atualizaMusica);
    }

    private static void ListarMusica()
    {
        WriteLine("Listar Musicas");
        var lista = repositorio.Lista();

        if (lista.Count == 0)
        {
            WriteLine("Nenhuma música cadastrada.");
            return;
        }
        foreach (var musica in lista)
        {
            var excluido = musica.retornaExcluido();
            WriteLine("#ID {0}: - {1} {2}", musica.retornaId(), musica.retornaTitulo(), (excluido ? "*EXCLUÍDO*" : ""));
        }
    }

    private static string ObterOpcaoUsuario()
    {
        WriteLine();
        WriteLine("Fernando Discos a seu dispor!!!");
        WriteLine("Informe a opção desejada:");
        WriteLine("1- Listar Músicas");
        WriteLine("2 - Inserir nova música");
        WriteLine("3 - Atualizar música");
        WriteLine("4 - Excluir música");
        WriteLine("5 - Visualizar música");
        WriteLine("C - Limpar Tela");
        WriteLine("X - Sair");

        string opcaoUsuario = ReadLine().ToUpper();
        WriteLine();
        return opcaoUsuario;
    }
}