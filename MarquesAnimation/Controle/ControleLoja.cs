using MarquesAnimation.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarquesAnimation.Controle
{
    class ControleLoja
    {
        public string AdicionarLoja(Loja loja)
        {
            LojaDAO lj = new LojaDAO();
            string mensagem = lj.Adicionar(loja);
            return mensagem;
        }

        public SqlDataReader RetornarLoja()
        {
            LojaDAO lj = new LojaDAO();
            return lj.RetornaLoja();
        }

        public string DeletarLoja(int indice)
        {
            LojaDAO lj = new LojaDAO();
            string mensagem = lj.Deletar(indice);
            return mensagem;
        }
    }
}
