using System;
using System.Collections.Generic;
using MTG_Decklist.Interfaces;

namespace MTG_Decklist
{
    public class DecksRepositorio : IRepositorioDecks<Decks>
    {
        private List<Decks> listaDecks = new List<Decks>();
        public void AtualizaDeck(int id, Decks entidade)
        {
            listaDecks[id] = entidade;
        }

        public void ExcluiDeck(int id)
        {
            listaDecks[id].Excluir();
        }

        public void InsereDeck(Decks entidade)
        {
            listaDecks.Add(entidade);
        }

        public List<Decks> Lista()
        {
            return listaDecks;
        }

        public int ProximoId()
        {
            return listaDecks.Count;
        }

        public Decks RetornaPorId(int id)
        {
            return listaDecks[id];
        }
    }
}