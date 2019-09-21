using MarquesAnimation.Controle;
using MarquesAnimation.Modelo;
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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            FadeOut(this, 100);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Usuario projeto = new Usuario(textBox1.Text, textBox2.Text);
            ControleUsuario cu = new ControleUsuario();
            string mensagem = cu.AdicionarUsuario(projeto); //Chama o método que realiza a inserção no banco.

            MessageBox.Show(mensagem);
            panel2.Visible = false;
            panel1.Visible = true;
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = false;
        }

        private void Form6_Load_1(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            
            SqlDataReader dr; //Objeto para armazenar o retorno do banco. 
            ControleUsuario cp = new ControleUsuario();
            dr = cp.RetornarUsuario(); //Chama o método responsável pela realização da consulta. 

            if (dr != null) //Verifico 
            {
                while (dr.Read())
                {
                    if (textBox1.Text == dr.GetString(1) && textBox2.Text == dr.GetString(2))
                    {
                        this.Hide();
                        Form1 f1 = new Form1();
                        f1.ShowDialog();
                    }
                    
                }
            }
            else
            {
                string mensagem = "Usuário não encontrado. Tente novamente.";
                MessageBox.Show(mensagem);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FadeOut(this, 20);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private async void FadeIn(Form o, int interval = 80)
        {
            //Object is not fully invisible. Fade it in
            while (o.Opacity < 1.0)
            {
                await Task.Delay(interval);
                o.Opacity += 0.05;
            }
            o.Opacity = 1; //make fully visible       
        }

        private async void FadeOut(Form o, int interval = 80)
        {
            //Object is fully visible. Fade it out
            while (o.Opacity > 0.0)
            {
                await Task.Delay(interval);
                o.Opacity -= 0.05;
            }
            o.Opacity = 0; //make fully invisible  
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Usuario projeto = new Usuario(textBox3.Text, textBox4.Text);
            ControleUsuario cu = new ControleUsuario();
            string mensagem = cu.AdicionarUsuario(projeto); //Chama o método que realiza a inserção no banco.

            MessageBox.Show(mensagem);
            panel2.Visible = false;
            panel1.Visible = true;
            LimparCampos();
        }

        private void LimparCampos()
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
        }
    }
}
