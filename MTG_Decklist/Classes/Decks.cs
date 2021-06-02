using System;

namespace MTG_Decklist
{
    public class Decks : EntidadeBase
    {
        //Atributos
        private string Nome { get; set; }
        private string Formato { get; set; }
        private string Descricao { get; set; }
        private bool Excluido { get; set; }

        public Decks(int id, string nome, string formato, string descricao)
        {
            this.Id = id;
            this.Nome = nome;
            this.Formato = formato;
            this.Descricao = descricao;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Nome do Deck: " + this.Nome + Environment.NewLine;
            retorno += "Formato Principal: " + this.Formato + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Excluido" + this.Excluido;
            return retorno;
        }
        public string retornaNome()
        {
            return this.Nome;
        }
        public int retornaId()
        {
            return this.Id;
        }
        public void Excluir()
        {
            this.Excluido = true;
        }
        public bool retornaExcluido()
        {
            return this.Excluido;
        }

    }
}