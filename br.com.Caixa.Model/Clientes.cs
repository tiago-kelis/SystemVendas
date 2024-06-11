using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemVendas.br.com.Caixa.Model
{
    public class Clientes
    {
        private int _Id;
        private string _Nome;
        private string _Rg;
        private string _Cpf;
        private string _Email;
        private string _Telefone;
        private string _Celular;
        private string _Cep;
        private string _Endereco;
        private int _Numero;
        private string _Complemento;
        private string _Bairro;
        private string _Cidade;
        private string _Estado;

        public int Id { get => _Id; set => _Id = value; }
        public string Nome { get => _Nome; set => _Nome = value; }
        public string Rg { get => _Rg; set => _Rg = value; }
        public string Cpf { get => _Cpf; set => _Cpf = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Telefone { get => _Telefone; set => _Telefone = value; }
        public string Celular { get => _Celular; set => _Celular = value; }
        public string Cep { get => _Cep; set => _Cep = value; }
        public string Endereco { get => _Endereco; set => _Endereco = value; }
        public int Numero { get => _Numero; set => _Numero = value; }
        public string Complemento { get => _Complemento; set => _Complemento = value; }
        public string Bairro { get => _Bairro; set => _Bairro = value; }
        public string Cidade { get => _Cidade; set => _Cidade = value; }
        public string Estado { get => _Estado; set => _Estado = value; }

        public Clientes()
        {

        }


        public Clientes(int id, string nome, string rg, string cpf, string email, string telefone, string celular, string cep, string endereco, int numero, string complemento, string bairro, string cidade, string estado) 
        {
            this.Id = id;
            this.Nome = nome;
            this.Rg = rg;
            this.Cpf = cpf;
            this.Email = email;
            this.Telefone = telefone;
            this.Celular = celular;
            this.Cep = cep;
            this.Endereco = endereco;
            this.Numero = numero;
            this.Complemento = complemento;
            this.Bairro = bairro;
            this.Cidade = cidade;
            this.Estado = estado;       

        }




    }
}
