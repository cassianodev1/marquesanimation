using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarquesAnimation.Modelo
{
    public class Conexao
    {
        SqlConnection con = new SqlConnection();

        //Construtor
        public Conexao()
        {
            con.ConnectionString = @"Data Source=LAB01-PC15\SQLEXPRESS; Initial Catalog=MarquesitoAnimation; Integrated Security=True";
        }
        //Conectar ao banco de dados
        public SqlConnection Conectar()
        {
            //Verifica se o estado da conexão é igual a fechado, então posso abrir.
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }
        //Desconectar do banco de dados
        public void Desconectar()
        {
            //Verifica se o estado da conexão é aberto, então fecho.
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
