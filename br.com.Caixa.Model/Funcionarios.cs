using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemVendas.br.com.Caixa.Model
{
    public class Funcionarios: Clientes
    {
        private string _Senha;
        private string _Cargo;
        private string _Nivel_Acesso;

        public string Senha { get => _Senha; set => _Senha = value; }
        public string Cargo { get => _Cargo; set => _Cargo = value; }
        public string Nivel_Acesso { get => _Nivel_Acesso; set => _Nivel_Acesso = value; }

        public Funcionarios()
        {

        }

        public Funcionarios(string senha, string cargo, string nivel_Acesso)
        {
            Senha = senha;
            Cargo = cargo;
            Nivel_Acesso = nivel_Acesso;
          
        }
    }
}
