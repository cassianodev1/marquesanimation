using MarquesAnimation.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarquesAnimation.Controle
{
    class ControleUsuario
    {
        public string AdicionarUsuario(Usuario usuario)
        {
            UsuarioDAO us = new UsuarioDAO();
            string mensagem = us.Adicionar(usuario);
            return mensagem;
        }

        public SqlDataReader RetornarUsuario()
        {
            UsuarioDAO us = new UsuarioDAO();
            return us.RetornaUsuario();
        }
    }
}
