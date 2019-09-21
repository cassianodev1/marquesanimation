using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarquesAnimation.Modelo
{
    class Usuario
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }


        public Usuario(string Nome, string Senha)
        {
            this.Nome = Nome;
            this.Senha = Senha;
        }
    }
}
