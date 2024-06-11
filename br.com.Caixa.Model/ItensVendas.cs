using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemVendas.br.com.Caixa.Model
{
    public class ItensVendas
    {
        private int _Id;
        private int _Venda_Id;
        private int _Produto_Id;
        private int _Qtd;
        private decimal _Subtotal;

        public int Id { get => _Id; set => _Id = value; }
        public int Venda_Id { get => _Venda_Id; set => _Venda_Id = value; }
        public int Produto_Id { get => _Produto_Id; set => _Produto_Id = value; }
        public int Qtd { get => _Qtd; set => _Qtd = value; }
        public decimal Subtotal { get => _Subtotal; set => _Subtotal = value; }

        public ItensVendas()
        {

        }

        public ItensVendas(int id, int venda_Id, int produto_Id, int qtd, decimal subtotal)
        {
            Id = id;
            Venda_Id = venda_Id;
            Produto_Id = produto_Id;
            Qtd = qtd;
            Subtotal = subtotal;           
        }
    }


}
