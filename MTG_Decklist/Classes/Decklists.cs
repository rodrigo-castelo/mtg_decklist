using System;

namespace MTG_Decklist
{
    public class Decklists
    {
        private int IdDeck { get; set; }
        private int IdCarta { get; set; }
        private string NomeCarta { get; set; }
        private string TipoCarta { get; set; }
        private int QtdCarta { get; set; }
        private string MainSide { get; set; }
        private bool CartaExcluida { get; set; }

        public Decklists(int iddeck, int idcarta, string nome, string tipo, int qtd, string mainside)
    {
        this.IdDeck = iddeck;
        //this.NomeDeck = nomedeck;
        this.IdCarta = idcarta;
        this.NomeCarta = nome;
        this.TipoCarta = tipo;
        this.QtdCarta = qtd;
        this.MainSide = mainside;
        this.CartaExcluida = false;

    }
        public override string ToString()
        {
            string retorno = "";
            //retorno += "Nome do Deck: " + this.NomeDeck + Environment.NewLine;
            retorno += "Nome da Carta: " + this.NomeCarta + Environment.NewLine;
            retorno += "Tipo da Carta: " + this.TipoCarta + Environment.NewLine;
            retorno += "Quantidade de Cartas: " + this.QtdCarta + Environment.NewLine;
            retorno += "Maindeck ou Sidedeck? " + this.MainSide + Environment.NewLine;
            retorno += "Excluída: " + this.CartaExcluida;
            return retorno;
        }

        public string RetornaNomeCarta()
        {
            return this.NomeCarta;
        }
        public int RetornaIdCarta()
        {
            return this.IdCarta;
        }
        public string RetornaTipoCarta()
        {
            return this.TipoCarta;
        }
        public int RetornaQtdCarta()
        {
            return this.QtdCarta;
        }
        public string RetornaMainSide()
        {
            return this.MainSide;
        }
        public void ExcluiCarta()
        {
            this.CartaExcluida = true;
        }
        public bool RetornaCartaExcluida()
        {
            return this.CartaExcluida;
        }


    }

}