using MarquesAnimation.Controle;
using MarquesAnimation.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarquesAnimation
{
    public partial class Form5 : Form
    {
        int idCliente;
        string CPFF;
        string FNome;
        string CNPJD;
        string DNome;
        
        public Form5()
        {
            InitializeComponent();
        }
        /*public void CarregaLoja()
        {
            idCliente = int.Parse(comboBox1.SelectedItem.ToString());
            ControleLoja cl = new ControleLoja();
            SqlDataReader dr = cl.RetornarLoja(idCliente);

            if (dr != null)
            {
                while (dr.Read())
                {
                    lblNomeFunc.Text = dr.GetString(1);
                    lblNomeProjeto.Text = dr.GetString(2);
                    lblNomeProjeto.Text = dr.GetString(3);
                }
            }
        } */

        public void CarregaCombo1()
        {
            SqlDataReader dr; //Objeto para armazenar o retorno do banco. 
            ControleProjeto cc = new ControleProjeto();
            dr = cc.RetornarProj(); //Chama o método responsável pela realização da consulta. 

            if (dr != null) //Verifico 
            {
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr.GetString(1));
                }
            }
        }

        public void CarregaCombo2()
        {
            SqlDataReader dr; //Objeto para armazenar o retorno do banco. 
            ControleFuncionario cf = new ControleFuncionario();
            dr = cf.RetornarFuncionarios(); //Chama o método responsável pela realização da consulta. 

            if (dr != null) //Verifico 
            {
                while (dr.Read())
                {
                    comboBox2.Items.Add(dr.GetString(1));
                }
            }
        }

        public void CarregaCombo3()
        {
            SqlDataReader dr; //Objeto para armazenar o retorno do banco. 
            ControleDistribuicao cd = new ControleDistribuicao();
            dr = cd.RetornarDistribuicao(); //Chama o método responsável pela realização da consulta. 

            if (dr != null) //Verifico 
            {
                while (dr.Read())
                {
                    comboBox3.Items.Add(dr.GetString(1));
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //CarregaLoja();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            //CarregaLoja();
            CarregaCombo1();
            CarregaCombo2();
            CarregaCombo3();
            PreencherListView();
        }

        public void VerificaFunc()
        {
            SqlDataReader dr;
            ControleFuncionario cf = new ControleFuncionario();
            dr = cf.RetornarFuncionarios(); //Chama o método responsável pela realização da consulta. 

            if (dr != null) //Verifico 
            {
                while (dr.Read())
                {
                        CPFF = dr.GetString(2);
                        FNome = dr.GetString(1);
                }
            }
        }

        public void VerificaDist()
        {
            SqlDataReader dr;
            ControleDistribuicao cf = new ControleDistribuicao();
            dr = cf.RetornarDistribuicao(); //Chama o método responsável pela realização da consulta. 

            if (dr != null) //Verifico 
            {
                while (dr.Read())
                {
                        CNPJD = dr.GetString(2);
                        DNome = dr.GetString(1);
                }
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            VerificaFunc();
            VerificaDist();

            Loja loja = new Loja(idCliente, CPFF, comboBox2.Text, CNPJD);
            ControleLoja cl = new ControleLoja();
            string mensagem = cl.AdicionarLoja(loja);

            MessageBox.Show(mensagem);
            PreencherListView();
            LimparCampos();
        }

        public void PreencherListView()
        {
            listView1.Items.Clear();
            SqlDataReader dr; //Objeto para armazenar o retorno do banco. 
            ControleLoja cl = new ControleLoja();
            dr = cl.RetornarLoja(); //Chama o método responsável pela realização da consulta. 

            if (dr != null) //Verifico 
            {
                while (dr.Read())
                {
                    ListViewItem lv = new ListViewItem(dr.GetInt32(0).ToString());
                    lv.SubItems.Add(dr.GetString(1));
                    lv.SubItems.Add(dr.GetString(2));
                    lv.SubItems.Add(dr.GetString(3));
                    listView1.Items.Add(lv);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlDataReader dr; //Objeto para armazenar o retorno do banco. 
            ControleLoja cl = new ControleLoja();
            dr = cl.RetornarLoja(); //Chama o método responsável pela realização da consulta. 

            if (dr != null) //Verifico 
            {
                while (dr.Read())
                {
                    idCliente = dr.GetInt32(0);
                }
            }

            cl.DeletarLoja(idCliente);
            PreencherListView();
        }

        public void LimparCampos()
        {
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
        }

        
    }
}
