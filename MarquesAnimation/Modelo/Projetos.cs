using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarquesAnimation.Visao
{
    class Projetos
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Prazo { get; set; }
        public string FEtaria { get; set; }

        public Projetos(int ID, string Nome, string Prazo, string FEtaria)
        {
            this.ID = ID;
            this.Nome = Nome;
            this.Prazo = Prazo;
            this.FEtaria = FEtaria;
        }
    }
}
