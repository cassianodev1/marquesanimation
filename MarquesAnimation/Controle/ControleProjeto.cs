using MarquesAnimation.Modelo;
using MarquesAnimation.Visao;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarquesAnimation.Controle
{
    class ControleProjeto
    {
        public string AdicionarProj(Projetos proj)
        {
            ProjetosDAO projeto = new ProjetosDAO();
            string mensagem = projeto.Adicionar(proj);
            return mensagem;
        }

        public SqlDataReader RetornarProj()
        {
            ProjetosDAO projeto = new ProjetosDAO();
            return projeto.RetornaProjetos();
        }
        public SqlDataReader RetornarProj(int indice)
        {
            ProjetosDAO projeto = new ProjetosDAO();
            return projeto.RetornaProjetos();
        }

        public string DeletarProj(int indice)
        {
            ProjetosDAO projeto = new ProjetosDAO();
            string mensagem = projeto.Deletar(indice);
            return mensagem;
        }
    }
}
