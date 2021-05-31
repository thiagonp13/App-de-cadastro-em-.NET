using System;
namespace DIO.PRODUTOS

{
    public class Produto : EntidadeBase
    {
        // ATRIBUTOS
        
        private Marca Marca { get; set; }
        private string Modelo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido {get; set; }

        //METODDS
        public Produto(int Id, Marca marca, string Modelo, string Descricao, int Ano)
        {
            this.Id = Id;
            this.Marca = marca;
            this.Modelo = Modelo;
            this.Descricao = Descricao;
            this.Ano = Ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Marca: " + this.Marca + Environment.NewLine;
            retorno += "Modelo: " + this.Modelo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano: " + this.Ano + Environment.NewLine;
            retorno += "Excluído: " + this.Excluido ;
            return retorno;
        }


        public string retornaModelo()
        {
            return this.Modelo;
        }

        public int rertornaId()
        {
            return this.Id;
        }
        public bool retornaExcluido()
		{
			return this.Excluido;
		}
        public void Excluir()
        {
            this.Excluido= true;
        }
    }
}