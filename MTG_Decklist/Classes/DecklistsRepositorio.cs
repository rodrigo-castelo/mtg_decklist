using System;
using System.Collections.Generic;
using MTG_Decklist.Interfaces;

namespace MTG_Decklist
{
    public class DecklistsRepositorio : IRepositorioDecklists<Decklists>
    {
        private List<Decklists> listaCartas = new List<Decklists>();
        public void AtualizaCarta(int idcarta, Decklists entidade)
        {
            listaCartas[idcarta] = entidade;
        }

        public void ExcluiCarta(int idcarta)
        {
            listaCartas[idcarta].ExcluiCarta();
        }

        public void InsereCarta(Decklists entidade)
        {
            listaCartas.Add(entidade);
        }

        public List<Decklists> ListaCartas()
        {
            return listaCartas;
        }

        public int proximoIdCarta()
        {
            return listaCartas.Count;
        }

        public Decklists RetornaDecklistPorIdDeck(int id)
        {
            return listaCartas[id];
        }
    }
}