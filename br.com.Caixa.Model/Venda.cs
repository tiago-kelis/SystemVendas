using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemVendas.br.com.Caixa.Model
{
    public class Venda
    {
        private int _Id;
        private int _Client_Id;
        private DateTime _Data_Venda;
        private decimal _Total_Venda;
        private string _Observacoes;

        public int Id { get => _Id; set => _Id = value; }
        public int Client_Id { get => _Client_Id; set => _Client_Id = value; }
        public DateTime Data_Venda { get => _Data_Venda; set => _Data_Venda = value; }
        public decimal Total_Venda { get => _Total_Venda; set => _Total_Venda = value; }
        public string Observacoes { get => _Observacoes; set => _Observacoes = value; }

        public Venda()
        {

        }

        public Venda(int id, int client_Id, DateTime data_Venda, decimal total_Venda, string observacoes)
        {
            Id = id;
            Client_Id = client_Id;
            Data_Venda = data_Venda;
            Total_Venda = total_Venda;
            Observacoes = observacoes;
        }
    }
}
