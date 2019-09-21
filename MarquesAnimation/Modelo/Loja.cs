using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarquesAnimation.Modelo
{
    class Loja
    {
        public int ID { get; set; }
        public string CPFF { get; set; }
        public string NomeP { get; set; }
        public string CNPJD { get; set; }

        public Loja(int ID, string CPFF, string NomeP, string CNPJD)
        {
            this.ID = ID;
            this.CPFF = CPFF;
            this.NomeP = NomeP;
            this.CNPJD = CNPJD;
        }
    }
}
