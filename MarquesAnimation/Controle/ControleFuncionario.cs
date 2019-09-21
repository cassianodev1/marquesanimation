using MarquesAnimation.Modelo;
using MarquesAnimation.Controle;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using MarquesAnimation.Visao;

namespace MarquesAnimation.Controle
{
    class ControleFuncionario
    {

            public string AdicionarFunc(Funcionario func)
            {
                FuncionarioDAO funcionario = new FuncionarioDAO();
                string mensagem = funcionario.Adicionar(func);
                return mensagem;
            }

            public SqlDataReader RetornarFuncionarios()
            {
                FuncionarioDAO fun = new FuncionarioDAO();
                return fun.RetornaFuncionarios();
            }
            public SqlDataReader RetornarFuncionarios(int indice)
        {
            FuncionarioDAO fun = new FuncionarioDAO();
            return fun.RetornaFuncionarios();
        }

            public string DeletarFunc(int indice)
        {
            FuncionarioDAO funcionario = new FuncionarioDAO();
            string mensagem = funcionario.Deletar(indice);
            return mensagem;
        }
    }
}

