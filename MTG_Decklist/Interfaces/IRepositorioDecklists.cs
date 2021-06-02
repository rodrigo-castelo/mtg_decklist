using System.Collections.Generic;

namespace MTG_Decklist.Interfaces
{
    public interface IRepositorioDecklists<T>
    {
         List<T> ListaCartas();
         T RetornaDecklistPorIdDeck(int id);
         void InsereCarta(T entidade);
         void ExcluiCarta(int idcarta);
         void AtualizaCarta(int idcarta, T entidade);
        int proximoIdCarta();

    }
}