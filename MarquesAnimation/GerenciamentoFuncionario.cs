using MarquesAnimation.Controle;
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
    public partial class GerenciarFuncionario : Form2
    {
        public int operacao;  //1 - inserção, 2 - Edição
        public GerenciarFuncionario()
        {
            InitializeComponent();
            operacao = 1;
        }
        public void AtualizarLView()
        {
            listView1.Items.Clear();

            int qdtUsuario = Program.GU.GetContador();
            if (qdtUsuario > 0)
            {
                Funcionario aux;
                for (int i = 0; i < qdtUsuario; i++)
                {
                    aux = Program.GU.GetUsuario(i);
                    ListViewItem lv = new ListViewItem(i.ToString());
                    lv.SubItems.Add(aux.Nome);
                    lv.SubItems.Add(aux.Email);
                    lv.SubItems.Add(aux.Telefone);
                    lv.SubItems.Add(aux.Matricula);
                    lv.SubItems.Add(aux.CPF);
                    lv.SubItems.Add(aux.RG);
                    int tipo = aux.Tipo;
                    if (tipo == 1)
                    {
                        lv.SubItems.Add("Aluno");
                    }
                    else
                    {
                        if (tipo == 2)
                        {
                            lv.SubItems.Add("Professor");
                        }
                        else
                        {
                            lv.SubItems.Add("Técnico");
                        }
                    }
                    listView1.Items.Add(lv);
                }
            }
        }

        public void AtualizarLViewBanco()
        {
            listView1.Items.Clear();

            ControleUsuario c = new ControleUsuario();
            SqlDataReader dr = c.RetornarUsuario();
            while (dr.Read())
            {
                ListViewItem lv = new ListViewItem(dr.GetInt32(0).ToString());
                lv.SubItems.Add(dr.GetString(1));
                lv.SubItems.Add(dr.GetString(2));
                lv.SubItems.Add(dr.GetString(3));
                lv.SubItems.Add(dr.GetString(4));
                lv.SubItems.Add(dr.GetString(5));
                lv.SubItems.Add(dr.GetString(6));
                int tipo = dr.GetInt32(7);
                if (tipo == 1)
                {
                    lv.SubItems.Add("Aluno");
                }
                else
                {
                    if (tipo == 2)
                    {
                        lv.SubItems.Add("Professor");
                    }
                    else
                    {
                        lv.SubItems.Add("Técnico");
                    }
                }
                listView1.Items.Add(lv);
            }
        }
        private void GerenciarUsuario_Load(object sender, EventArgs e)
        {
            AtualizarLView();
        }

        public void LimparCampos()
        {
            textBox1.Clear();
            maskedTextBox1.Clear();
            textBox3.Clear();
            maskedTextBox2.Clear();
            comboBox1.SelectedIndex = -1;

        }

        private void btConfirmar_Click(object sender, EventArgs e)
        {
            int tipo;
            if (comboBox1.SelectedIndex == 0)
            {
                tipo = 1;
            }
            else
            {
                if (comboBox1.SelectedIndex == 1)
                {
                    tipo = 2;
                }
                else
                {
                    tipo = 3;
                }
            }
            if (operacao == 1)
            {
                Funcionario user = new Funcionario(textBox1.Text, maskedTextBox1.Text, textBox3.Text, maskedTextBox2.Text, comboBox1.Text, tipo);
                bool retorno = Program.GU.AddFuncionario(user);
                if (retorno)
                {
                    MessageBox.Show("Usuário adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Problemas ao adicionar usuário!\nPreencha novamente os campos e repita a operação!", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Cadastro no banco de dados
                ControleFuncionario cFunc = new ControleFuncionario();
                string mensagem = cFunc.AddFuncionario(user);
                MessageBox.Show(mensagem, "Operação Cadastrar", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                Funcionario user = new Funcionario(textBox1.Text, maskedTextBox1.Text, textBox3.Text, maskedTextBox2.Text, comboBox1.Text, tipo);
                bool retorno = Program.GU.UpdateUsuario(user, int.Parse(listView1.SelectedItems[0].SubItems[0].Text));
                if (retorno)
                {
                    MessageBox.Show("Usuário atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Problemas ao atualizar usuário!\nPreencha novamente os campos e repita a operação!", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                operacao = 1;
                button1.Text = "Cadastrar";
            }
            textBox1.Focus();
            LimparCampos();
            AtualizarLViewBanco();

        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            operacao = 2;
            button1.Text = "Atualizar";
            textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            maskedTextBox1.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[3].Text;
            maskedTextBox2.Text = listView1.SelectedItems[0].SubItems[4].Text;
            comboBox1.ResetText();
            comboBox1.SelectedText = listView1.SelectedItems[0].SubItems[5].Text;
        }
    }
}
