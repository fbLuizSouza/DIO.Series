using DIO.Series.Entidades;
using System;

namespace DIO.Series
{
    class Program
    {
        private static SerieRepositorio repositorio = new SerieRepositorio(); 
        static void Main(string[] args)
        {
            string opcaoUsuario = opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {    
                switch (opcaoUsuario)
                {
                    case "1":                     
                        ListarSeries();
                        break;
                    case "2":                        
                        InserirNovaSerie();
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
                        break;
                    case "X":              
                        break;
                    default:
                        Console.WriteLine("Saindo...");
                        break;
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("Digite a opção desejada:");
            Console.WriteLine("1 - Listar todas as series");
            Console.WriteLine("2 - Inserir uma nova serie");
            Console.WriteLine("3 - Atualizar uma serie");
            Console.WriteLine("4 - Excluir uma serie");
            Console.WriteLine("5 - Visualizar informações de uma serie");
            Console.WriteLine("C - Limpar a tela");
            Console.WriteLine("X - Sair");

            return Console.ReadLine();
        }

        private static void ListarSeries()
        {
            
            var lista = repositorio.GetSeries();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada!");
                return;
            }

            Console.WriteLine("Lista de series:");
            foreach (var serie in lista)
            {
                Console.WriteLine("#ID {0}: - Título: {1} - Situação: ", serie.Id, serie.Titulo, (serie.Excluido ? "Excluída*" : "Cadastrada*"));
            }
        }

        private static void InserirNovaSerie()
        {
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.Write(" {0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Inserir nova série:");
            Serie novaSerie = lerDadosUsuario(repositorio.GetProximoId());

            repositorio.Inserir(novaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Informe o id da série");
            int idSerie = int.Parse(Console.ReadLine());
            var obj = repositorio.GetSeriePorID(idSerie);
           
            if(obj != null)
            {
                repositorio.Atualizar(lerDadosUsuario(idSerie));
            }

            return;
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Informe o código da série a excluir:");
            int idSerie = int.Parse(Console.ReadLine());
            var obj = repositorio.GetSeriePorID(idSerie);

            if(obj != null)
            {
                Console.WriteLine("Tem certeza que deseja excluir série: {0} s/n?", obj.Titulo);
                string opcaoUsuario = Console.ReadLine();
                if (opcaoUsuario.ToUpper() == "S")
                {
                    repositorio.Excluir(idSerie);
                }
            }           

            return;
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Informe o código da série:");
            int idSerie = int.Parse(Console.ReadLine());
            Console.WriteLine(repositorio.GetSeriePorID(idSerie));
        }
        private static Serie lerDadosUsuario(int id)
        {
            Console.WriteLine("Informe o código do gêneros:");
            int generoSerie = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o título da série:");
            string tituloSerie = Console.ReadLine();

            Console.WriteLine("Informe o ano da série:");
            int anoSerie = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe a descrição da série:");
            string descricaoSerie = Console.ReadLine();

            Serie objSerie = new Serie(id,
                                        (Genero)generoSerie,
                                        tituloSerie,
                                        descricaoSerie,
                                        anoSerie);

            return objSerie;
        }
    }
}
