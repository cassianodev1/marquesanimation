using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarquesAnimation.Modelo
{
    class UsuarioDAO
    {
        public string Mensagem { get; private set; }
        SqlCommand cmd = new SqlCommand();
        Conexao con = new Conexao();
        //Armazena o retorno de uma consulta feita no banco.
        SqlDataReader dr;

        public string Adicionar(Usuario usuario)
        {
            //Comandos para inserir novo usuário no banco.
            //Comando SQL
            cmd.CommandText = "insert into Usuarios (Nome,Senha) values (@Nome, @Senha)";
            //parametros
            cmd.Parameters.AddWithValue("nome", usuario.Nome);
            cmd.Parameters.AddWithValue("senha", usuario.Senha);
            //conectar com banco
            try
            {
                //Receber o endereço de onde vou me conectar.
                cmd.Connection = con.Conectar();
                //Executar comando.
                cmd.ExecuteNonQuery();
                //Exibe mensagem;
                Mensagem = "Usuário cadastrado";
            }
            catch (SqlException ex)
            {
                //Captura a mensagem de erro gerada.
                Mensagem = ex.Message;
            }
            return Mensagem;
        }

        public SqlDataReader RetornaUsuario()
        {
            //Comandos SQL para verificar se existe o usuário no banco.
            cmd.CommandText = "select * from Usuarios";
            //Parametros que serão substituídos no CommandText.


            try
            {
                cmd.Connection = con.Conectar();
                dr = cmd.ExecuteReader();
                //Verifica se existe algum retorno na consulta do banco.
                if (dr.HasRows)
                {
                    return dr;
                }
            }
            catch (SqlException)
            {
                //Não é a mensagem mais apropriada!
                Console.WriteLine("Algo errado não está certo!");
            }
            con.Desconectar();
            return null;
        }
    }
}
