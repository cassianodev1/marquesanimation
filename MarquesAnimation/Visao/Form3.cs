using MarquesAnimation.Controle;
using MarquesAnimation.Visao;
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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public int idCliente;



        private void Form1_Load(object sender, EventArgs e)
        {
            PreencherListView();

        }

        public void PreencherListView()
        {
            listView1.Items.Clear();

            SqlDataReader dr; //Objeto para armazenar o retorno do banco. 
            ControleProjeto cc = new ControleProjeto();
            dr = cc.RetornarProj(); //Chama o método responsável pela realização da consulta. 

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



        private void button2_Click_1(object sender, EventArgs e)
        {


            Projetos projeto = new Projetos(idCliente, textBox1.Text, dateTimePicker1.Text, comboBox1.Text);
            ControleProjeto cp = new ControleProjeto();
            string mensagem = cp.AdicionarProj(projeto); //Chama o método que realiza a inserção no banco.

            MessageBox.Show(mensagem);
            PreencherListView();
            LimparCampos();
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            idCliente = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            ControleProjeto cp = new ControleProjeto();
            SqlDataReader dr = cp.RetornarProj(idCliente);

            if (dr != null)
            {
                while (dr.Read())
                {
                    textBox1.Text = dr.GetString(1);
                    dateTimePicker1.Text = dr.GetString(2);
                    comboBox1.Text = dr.GetString(3);
                }
            }

        }

        public void LimparCampos()
        {
            textBox1.Text = String.Empty;
            dateTimePicker1.Text = String.Empty;
            comboBox1.Text = String.Empty;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRemover_Click_1(object sender, EventArgs e)
        {
            idCliente = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            ControleProjeto cp = new ControleProjeto();
            cp.DeletarProj(idCliente);
            PreencherListView();
            LimparCampos();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            PreencherListView();
        }

        private void Form3_Load_1(object sender, EventArgs e)
        {
            PreencherListView();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            idCliente = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            ControleProjeto cp = new ControleProjeto();
            cp.DeletarProj(idCliente);
            PreencherListView();
            LimparCampos();
        }
    }
}
