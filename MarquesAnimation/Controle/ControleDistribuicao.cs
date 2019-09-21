using MarquesAnimation.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarquesAnimation.Controle
{
    class ControleDistribuicao
    {
        public string AdicionarDist(Distribuicao dist)
        {
            DistribuicaoDAO funcionario = new DistribuicaoDAO();
            string mensagem = funcionario.Adicionar(dist);
            return mensagem;
        }

        public SqlDataReader RetornarDistribuicao()
        {
            DistribuicaoDAO fun = new DistribuicaoDAO();
            return fun.RetornaFuncionarios();
        }
        public SqlDataReader RetornarDistribuicao(int indice)
        {
            DistribuicaoDAO fun = new DistribuicaoDAO();
            return fun.RetornaFuncionarios();
        }

        public string DeletarDist(int indice)
        {
            DistribuicaoDAO distr = new DistribuicaoDAO();
            string mensagem = distr.Deletar(indice);
            return mensagem;
        }
    }
}
