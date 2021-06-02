using System.Collections.Generic;

namespace MTG_Decklist.Interfaces
{
    public interface IRepositorioDecks<T>
    {
        List<T> Lista();
        T RetornaPorId(int id);
        void InsereDeck(T entidade);
        void ExcluiDeck(int id);
        void AtualizaDeck(int id, T entidade);
        int ProximoId();
    }
}