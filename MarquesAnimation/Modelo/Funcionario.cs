using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarquesAnimation.Modelo
{
    class Funcionario
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Telefone{ get; set; }
        public string Funcao { get; set; }

        public Funcionario(string Nome, string CPF, string Email, string Telefone, string Funcao)
        {
            this.Nome = Nome;
            this.CPF = CPF;
            this.Email = Email;
            this.Telefone = Telefone;
            this.Funcao = Funcao;
        }
    }
}
