﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarquesAnimation.Modelo
{
    class LojaDAO
    {
        public string Mensagem { get; private set; }
        SqlCommand cmd = new SqlCommand();
        Conexao con = new Conexao();
        //Armazena o retorno de uma consulta feita no banco.
        SqlDataReader dr;

        public string Adicionar(Loja loja)
        {
            //Comandos para inserir novo usuário no banco.
            //Comando SQL
            cmd.CommandText = "insert into Loja (FK_CPFFuncionarios, FK_NomeProjetos, FK_CNPJDistribuicao) values (@CPFF, @NomeP, @CNPJD)";
            //parametros
            cmd.Parameters.AddWithValue("CPFF", loja.CPFF);
            cmd.Parameters.AddWithValue("NomeP", loja.NomeP);
            cmd.Parameters.AddWithValue("CNPJD", loja.CNPJD);
            //conectar com banco
            try
            {
                //Receber o endereço de onde vou me conectar.
                cmd.Connection = con.Conectar();
                //Executar comando.
                cmd.ExecuteNonQuery();
                //Exibe mensagem;
                Mensagem = "Cadastrado com sucesso!!!";
            }
            catch (SqlException ex)
            {
                //Captura a mensagem de erro gerada.
                Mensagem = ex.Message;
            }
            return Mensagem;
        }

        public SqlDataReader RetornaLoja()
        {
            //Comandos SQL para verificar se existe o usuário no banco.
            cmd.CommandText = "select * from Loja";
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

        public string Deletar(int indice)
        {
            //Comandos para inserir novo usuário no banco.
            //Comando SQL
            cmd.CommandText = "delete from Loja where ID = @id";
            //parametros
            cmd.Parameters.AddWithValue("id", indice);

            //conectar com banco
            try
            {
                //Receber o endereço de onde vou me conectar.
                cmd.Connection = con.Conectar();
                //Executar comando.
                cmd.ExecuteNonQuery();
                //Exibe mensagem;
                Mensagem = "Deletado com sucesso!!!";
            }
            catch (SqlException ex)
            {
                //Captura a mensagem de erro gerada.
                Mensagem = ex.Message;
            }
            return Mensagem;
        }

        
    }
}
