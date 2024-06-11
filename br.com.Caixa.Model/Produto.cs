using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemVendas.br.com.Caixa.Model
{
    public class Produto
    {
        private int _Id;
        private string _Nome;
        private decimal _Preco;
        private int _Qtd_Estoque;
        private int _for_Id;

        public int Id {  get => _Id; set => _Id = value; }
        public string Nome { get => _Nome; set => _Nome = value; }
        public decimal Preco { get => _Preco; set => _Preco = value; }
        public int Qtd_Estoque { get => _Qtd_Estoque; set => _Qtd_Estoque = value; }
        public int For_Id { get => _for_Id; set => _for_Id = value; }

        public Produto()
        {

        }


        public Produto( int id, string nome, decimal preco, int qtd_Estoque, int for_Id)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            Qtd_Estoque = qtd_Estoque;
            For_Id = for_Id;
        }
    }
}
