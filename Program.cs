using System;

namespace DIO.PRODUTOS
{
    class Program
    {
        static ProdutosRepositorio repositorio = new  ProdutosRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarRelogios();
						break;
					case "2":
						InserirModelos();
						break;
					case "3":
						AtualizarModelos();
						break;
					case "4":
						ExcluirModelos();
						break;
					case "5":
						VisualizarModelos();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }
        private static void ExcluirModelos()
		{
			Console.Write("Digite o id do modelo: ");
			int indiceProduto = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceProduto);
		}
        private static void VisualizarModelos()
		{
			Console.Write("Digite o id do modelo: ");
			int indiceProduto = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceProduto);

			Console.WriteLine(serie);
		}
        private static void AtualizarModelos()
		{
			Console.Write("Digite o id do modelo: ");
			int indiceProduto = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Marca)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Marca), i));
			}
			Console.Write("Digite a marca entre as opções acima: ");
			int entradaMarca = int.Parse(Console.ReadLine());

			Console.Write("Digite o nome do modelo: ");
			string entradaModelo = Console.ReadLine();

			Console.Write("Digite o Ano do modelo: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do relógio: ");
			string entradaDescricao = Console.ReadLine();
            

			Produto atualizaProduto = new Produto(Id: indiceProduto,
										marca: (Marca)entradaMarca,
										Modelo: entradaModelo,
										Ano: entradaAno,
										Descricao: entradaDescricao);

			repositorio.Atualiza(indiceProduto, atualizaProduto);
		}

        private static void ListarRelogios()
		{
			Console.WriteLine("Listar Relógios");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum modelo cadastrado.");
				return;
			}

			foreach (var Produto in lista)
			{
                var excluido = Produto.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}",Produto.rertornaId(), Produto.retornaModelo(), (excluido ? "*Excluído*" : ""));
			}
		}
        private static void InserirModelos()
		{
			Console.WriteLine("Inserir novo Relógio");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Marca)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Marca), i));
			}
			Console.Write("Digite a marca entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o nome do modelo: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano do modelo: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do relógio: ");
			string entradaDescricao = Console.ReadLine();

			Produto novaSerie = new Produto(Id: repositorio.ProximoId(),
										marca: (Marca)entradaGenero,
										Modelo: entradaTitulo,
										Ano: entradaAno,
										Descricao: entradaDescricao);

			repositorio.Insere(novaSerie);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Bem vindo á Dio Watches");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar Relógios");
			Console.WriteLine("2- Inserir novo modelo");
			Console.WriteLine("3- Atualizar modelo");
			Console.WriteLine("4- Excluir modelos");
			Console.WriteLine("5- Visualizar modelos");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
