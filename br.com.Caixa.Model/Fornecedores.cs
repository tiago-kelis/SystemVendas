using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemVendas.br.com.Caixa.Model
{
    public class Fornecedores
    {
        private int _Id;
        private string _Name;
        private string _Cnpj;
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
        public string Name { get => _Name; set => _Name = value; }
        public string Cnpj { get => _Cnpj; set => _Cnpj = value; }
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

        public Fornecedores()
        {

        }

        public Fornecedores(int id, string name, string cnpj, string email, string telefone, string celular, string cep, string endereco, int numero, string complemento, string bairro, string cidade, string estado)
        {
            Id = id;
            Name = name;
            Cnpj = cnpj;
            Email = email;
            Telefone = telefone;
            Celular = celular;
            Cep = cep;
            Endereco = endereco;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
           
        }
    }
}
