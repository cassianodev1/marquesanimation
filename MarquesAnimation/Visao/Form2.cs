using MarquesAnimation.Controle;
using MarquesAnimation.Modelo;
//using MarquesAnimation.Visao;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

        }
        public int idCliente;
        private void Form2_Load(object sender, EventArgs e)
        {
            PreencherListView();
        }

        public void PreencherListView()
        {
            listView1.Items.Clear();

            SqlDataReader dr;
            ControleFuncionario cf = new ControleFuncionario();
            dr = cf.RetornarFuncionarios();

            if (dr != null)
            {
                while (dr.Read())
                {
                    ListViewItem lv = new ListViewItem(dr.GetInt32(0).ToString());
                    lv.SubItems.Add(dr.GetString(1));
                    lv.SubItems.Add(dr.GetString(2));
                    lv.SubItems.Add(dr.GetString(3));
                    lv.SubItems.Add(dr.GetString(4));
                    lv.SubItems.Add(dr.GetString(5));
                    listView1.Items.Add(lv);
                }
            }

        }
        public void LimparCampos()
        {
            textBox1.Clear();
            maskedTextBox1.Clear();
            textBox3.Clear();
            maskedTextBox2.Clear();
            comboBox1.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Funcionario funcionario = new Funcionario(textBox1.Text, maskedTextBox1.Text, textBox3.Text, maskedTextBox2.Text, comboBox1.Text);
            ControleFuncionario cf = new ControleFuncionario();
            string mensagem = cf.AdicionarFunc(funcionario);

            MessageBox.Show(mensagem);
            PreencherListView();
            LimparCampos();
            //AddUsuario();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlDataReader dr; //Objeto para armazenar o retorno do banco. 
            ControleFuncionario cf = new ControleFuncionario();
            dr = cf.RetornarFuncionarios(); //Chama o método responsável pela realização da consulta. 

            if (dr != null) //Verifico 
            {
                while (dr.Read())
                {
                    idCliente = dr.GetInt32(0);
                }
            }

            cf.DeletarFunc(idCliente);
            LimparCampos();
            PreencherListView();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void listView1_Click(object sender, EventArgs e)
        {
            idCliente = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            ControleFuncionario cf = new ControleFuncionario();
            SqlDataReader dr = cf.RetornarFuncionarios(idCliente);

            if (dr != null)
            {
                while (dr.Read())
                {
                    textBox1.Text = dr.GetString(1);
                    maskedTextBox1.Text = dr.GetString(2);
                    textBox3.Text = dr.GetString(3);
                    maskedTextBox2.Text = dr.GetString(4);
                    comboBox1.Text = dr.GetString(5);
                }
            }
        }
    }
}