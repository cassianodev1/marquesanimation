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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        int idCliente;
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void AddUsuario()
        {
            ListViewItem item = new ListViewItem(textBox1.Text);
            item.SubItems.Add(maskedTextBox1.Text);
            item.SubItems.Add(textBox3.Text);
            item.SubItems.Add(maskedTextBox2.Text);
            listView1.Items.Add(item);

            LimparCampos();
        }

        public void LimparCampos()
        {
            textBox1.Clear();
            maskedTextBox1.Clear();
            textBox3.Clear();
            maskedTextBox2.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Distribuicao dist = new Distribuicao(textBox1.Text, maskedTextBox1.Text, textBox3.Text, maskedTextBox2.Text);
            ControleDistribuicao cd = new ControleDistribuicao();
            string mensagem = cd.AdicionarDist(dist);

            MessageBox.Show(mensagem);
            PreencherListView();

        }

        public void PreencherListView()
        {
            listView1.Items.Clear();

            SqlDataReader dr;
            ControleDistribuicao cd = new ControleDistribuicao();
            dr = cd.RetornarDistribuicao();

            if (dr != null)
            {
                while (dr.Read())
                {
                    ListViewItem lv = new ListViewItem(dr.GetInt32(0).ToString());
                    lv.SubItems.Add(dr.GetString(1));
                    lv.SubItems.Add(dr.GetString(2));
                    lv.SubItems.Add(dr.GetString(3));
                    lv.SubItems.Add(dr.GetString(4));
                    listView1.Items.Add(lv);
                }
            }

        }
        private void listView1_Click(object sender, EventArgs e)
        {
            idCliente = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            ControleDistribuicao cd = new ControleDistribuicao();
            SqlDataReader dr = cd.RetornarDistribuicao(idCliente);

            if (dr != null)
            {
                while (dr.Read())
                {
                    textBox1.Text = dr.GetString(1);
                    maskedTextBox1.Text = dr.GetString(2);
                    maskedTextBox2.Text = dr.GetString(3);
                    textBox3.Text = dr.GetString(4);
                }
            }

            //Ativa o botão de exlusão.
            /*btnRemover.Enabled = true;
            btnAtualizar.Enabled = true;*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Distribuicao dist = new Distribuicao(textBox1.Text, maskedTextBox1.Text, maskedTextBox2.Text, textBox3.Text);
            SqlDataReader dr; //Objeto para armazenar o retorno do banco. 
            ControleDistribuicao cd = new ControleDistribuicao();
            dr = cd.RetornarDistribuicao(); //Chama o método responsável pela realização da consulta. 

            if (dr != null) //Verifico 
            {
                while (dr.Read())
                {
                    idCliente = dr.GetInt32(0);
                }
            }

            cd.DeletarDist(idCliente);
            LimparCampos();
            PreencherListView();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            PreencherListView();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
