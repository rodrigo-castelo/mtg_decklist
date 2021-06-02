using System;

namespace MTG_Decklist
{
    class Program
    {
        static DecksRepositorio repositorio = new DecksRepositorio();
        static DecklistsRepositorio repositorioCartas = new DecklistsRepositorio();
        static void Main(string[] args)
        {
            string opcaoUser = obterOpcaoUser();
            while(opcaoUser.ToUpper() != "X")
            {
                switch(opcaoUser)
                {
                    case "1":
                        ListarDecks();
                        break;
                    case "2":
                        CadastrarDeck();
                        break;
                    case "3":
                        CadastrarCartaDecklist();
                        break;
                    case "4":
                        AtualizarDeck();
                        break;
                    case "5":
                        AtualizarCartaDecklist();
                        break;
                    case "6":
                        ExcluirDeck();
                        break;
                    case "7":
                        ExcluirCartaDecklist();
                        break;
                    case "8":
                        VisualizarCartaDecklist();
                        break;
                    case "9":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUser = obterOpcaoUser();
            }
            Console.WriteLine("Obrigado por usar nossos serviços");
            Console.ReadLine();
        }

        private static void ListarDecks()
        {
            Console.WriteLine("Lista de Decks Cadastrados");
            var lista = repositorio.Lista();
            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhum Deck Cadastrado");
                return;
            }
            foreach(var deck in lista)
            {
                var excluido = deck.retornaExcluido();
                Console.WriteLine("ID {0}: {1} {2}", deck.retornaId(),deck.retornaNome(),(excluido ? "*Deck Excluído*" : ""));
            }
        }

        private static void CadastrarDeck()
        {
            Console.WriteLine("Cadastrar novo Deck");
            Console.WriteLine();
            
            Console.WriteLine("Nome do Deck: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Formato Principal do Deck: ");
            string entradaFormato = Console.ReadLine();

            Console.WriteLine("Descrição do Deck: ");
            string entradaDescricao = Console.ReadLine();

            Decks novoDeck = new Decks(id: repositorio.ProximoId(), nome: entradaNome, formato: entradaFormato, descricao: entradaDescricao);

            repositorio.InsereDeck(novoDeck);

        }
        private static void AtualizarDeck()
        {
            Console.WriteLine("Digite o Id do Deck: ");
            int indiceDeck = int.Parse(Console.ReadLine());

            Console.WriteLine("Nome do Deck: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Formato Principal do Deck: ");
            string entradaFormato = Console.ReadLine();

            Console.WriteLine("Descrição do Deck: ");
            string entradaDescricao = Console.ReadLine();

            Decks atualizaDeck = new Decks(id: indiceDeck, nome: entradaNome, formato: entradaFormato, descricao: entradaDescricao);

            repositorio.AtualizaDeck(indiceDeck, atualizaDeck);
        }

        private static void ExcluirDeck()
        {
            Console.WriteLine("Digite o Id do Deck: ");
            int indiceDeck = int.Parse(Console.ReadLine());

            Console.WriteLine("Tem certeza que quer excluir o deck?");
            Console.WriteLine("1 - Excluir");
            Console.WriteLine("2 - Cancelar");
            int opcaoExclusao = int.Parse(Console.ReadLine());
            if(opcaoExclusao == 1)
            {
                repositorio.ExcluiDeck(indiceDeck);
            }
            else if(opcaoExclusao == 2)
            {
                return;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        private static void CadastrarCartaDecklist()
        {
            Console.WriteLine("Cadastrar uma nova decklist!");
            Console.WriteLine();
            Console.WriteLine("Qual o ID do Deck?");
            int indiceDeck = int.Parse(Console.ReadLine());
            
            bool continuar = true;
            while(continuar)
            {
                Console.WriteLine("Nome da Carta: ");
                string entradaNomeCarta = Console.ReadLine();

                Console.WriteLine("Tipo da Carta: ");
                string entradaTipoCarta = Console.ReadLine();

                Console.WriteLine("Quantas cartas vão no deck?");
                int entradaQtdCarta = int.Parse(Console.ReadLine());

                Console.WriteLine("Main Deck ou Sideboard?");
                string entradaMainSide = Console.ReadLine();

                Decklists novaCarta = new Decklists(iddeck: indiceDeck, idcarta: repositorioCartas.proximoIdCarta(), nome: entradaNomeCarta, tipo: entradaTipoCarta, qtd: entradaQtdCarta, mainside: entradaMainSide);

                repositorioCartas.InsereCarta(novaCarta);

                Console.WriteLine("Deseja cadastrar outra carta ao Deck?");
                Console.WriteLine("1 - Sim");
                Console.WriteLine("2 - Não");
                int entradaOpcao = int.Parse(Console.ReadLine());

                if(entradaOpcao == 1)
                {
                    continuar = true;
                }
                else
                {
                    continuar = false;
                }

            }
        }
        private static void AtualizarCartaDecklist()
        {
            Console.WriteLine("Atualizar decklist!");
            Console.WriteLine("Qual o ID do Deck?");
            int indiceDeck = int.Parse(Console.ReadLine());
            
            bool continuar = true;
            while(continuar)
            {
                Console.WriteLine("Qual o ID da Carta? ");
                int indiceIdCarta = int.Parse(Console.ReadLine());

                Console.WriteLine("Nome da Carta: ");
                string entradaNomeCarta = Console.ReadLine();

                Console.WriteLine("Tipo da Carta: ");
                string entradaTipoCarta = Console.ReadLine();

                Console.WriteLine("Quantas cartas vão no deck? ");
                int entradaQtdCarta = int.Parse(Console.ReadLine());

                Console.WriteLine("Main Deck ou Sideboard? ");
                string entradaMainSide = Console.ReadLine();

                Decklists atualizaCarta = new Decklists(iddeck: indiceDeck, idcarta: indiceIdCarta, nome: entradaNomeCarta, tipo: entradaTipoCarta, qtd: entradaQtdCarta, mainside: entradaMainSide);

                repositorioCartas.AtualizaCarta(indiceIdCarta, atualizaCarta);

                Console.WriteLine("Deseja atualizar outra carta da Decklist?");
                Console.WriteLine("1 - Sim");
                Console.WriteLine("2 - Não");
                int entradaOpcao = int.Parse(Console.ReadLine());

                if(entradaOpcao == 1)
                {
                    continuar = true;
                }
                else
                {
                    continuar = false;
                }

            }

        }

        private static void ExcluirCartaDecklist()
        {
            Console.WriteLine("Digite o Id do Deck: ");
            int indiceDeck = int.Parse(Console.ReadLine());
            Console.WriteLine("Qual o ID da Carta?");
            int indiceIdCarta = int.Parse(Console.ReadLine());

            Console.WriteLine("Tem certeza que quer excluir a carta dessa decklist?");
            Console.WriteLine("1 - Excluir");
            Console.WriteLine("2 - Cancelar");
            int opcaoExclusao = int.Parse(Console.ReadLine());
            if(opcaoExclusao == 1)
            {
                repositorioCartas.ExcluiCarta(indiceIdCarta);
            }
            else if(opcaoExclusao == 2)
            {
                return;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

        }
        private static void VisualizarCartaDecklist()
        {
            Console.WriteLine("Digite o Id do Deck: ");
            int indiceDeck = int.Parse(Console.ReadLine());
            var lista = repositorioCartas.ListaCartas();
            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma decklist encontrada");
            }

            foreach(var carta in lista)
            {
                if(lista[0] == repositorioCartas.RetornaDecklistPorIdDeck(indiceDeck))
                {
                    var excluido = carta.RetornaCartaExcluida();
                    Console.WriteLine("ID {0} - {1} - {2} - {3} - {4} - {5}", carta.RetornaIdCarta(),carta.RetornaNomeCarta(),carta.RetornaTipoCarta(),carta.RetornaQtdCarta(),carta.RetornaMainSide(),(excluido ? "*Deck Excluído*" : ""));
                }
            }
        }

        private static string obterOpcaoUser()
        {
            Console.WriteLine("Catálogo de Decks MTG");
            Console.WriteLine("Informe a opção desejada");
            Console.WriteLine();
            Console.WriteLine("1 - Listar Decks");
            Console.WriteLine("2 - Cadastrar novo Deck");
            Console.WriteLine("3 - Cadastrar Decklist");
            Console.WriteLine("4 - Atualizar Deck");
            Console.WriteLine("5 - Atualizar Decklist");
            Console.WriteLine("6 - Excluir Deck");
            Console.WriteLine("7 - Excluir Decklist");
            Console.WriteLine("8 - Visualizar Decklist");
            Console.WriteLine("9 - Limpar Tela");
            Console.WriteLine("X - Sair do Programa");
            Console.WriteLine();

            string opcaoUser = Console.ReadLine();
            Console.WriteLine();
            return opcaoUser;
        }
    }
}
