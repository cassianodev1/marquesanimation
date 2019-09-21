using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarquesAnimation.Modelo
{
    class Distribuicao
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public Distribuicao(string Nome, string CPF, string Email, string Telefone)
        {
            this.Nome = Nome;
            this.CNPJ = CPF;
            this.Email = Email;
            this.Telefone = Telefone;
        }
    }
}
