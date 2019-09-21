using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarquesAnimation
{
    public partial class Form1 : Form
    {

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Opacity = 0;      //first the opacity is 0

        }



        private void panel2_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void AbrirFormNoPanel<Forms>() where Forms : Form, new()
        {
            Form formulario;
            formulario = panel1.Controls.OfType<Forms>().FirstOrDefault();

            if (formulario == null)
            {
                formulario = new Forms();
                formulario.TopLevel = false;
                //formulario.FormBorderStyle = FormBorderStyle.None;
                //formulario.Dock = DockStyle.Fill;
                panel1.Controls.Add(formulario);
                panel1.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
            }
            else
            {
                if (formulario.WindowState == FormWindowState.Minimized)
                    formulario.WindowState = FormWindowState.Normal;
                formulario.BringToFront();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

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
            LoadNextImage();
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
            Environment.Exit(-1);
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            FadeOut(this, 20);
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnRestaurar.Visible = true;

        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            //btnRestaurar.Visible = false;
            //btnMaximizar.Visible = true;
        }

        private void btnFunc_Click(object sender, EventArgs e)
        {
            panel1.Show();
            pictureBox1.Hide();
            AbrirFormNoPanel<Form2>();
            label1.Text = "Controle de usuários";
        }

        private void btnProjetos_Click(object sender, EventArgs e)
        {
            panel1.Show();
            pictureBox1.Hide();
            AbrirFormNoPanel<Form3>();
            label1.Text = "Controle de projetos";
        }

        private void btnDistri_Click_1(object sender, EventArgs e)
        {
            panel1.Show();
            pictureBox1.Hide();
            AbrirFormNoPanel<Form4>();
            label1.Text = "Controle de distribuições";
        }

        private void lbMenu_Click(object sender, EventArgs e)
        {

        }

        private void btnLoja_Click(object sender, EventArgs e)
        {
            pictureBox1.Hide();
            panel1.Show();
            AbrirFormNoPanel<Form5>();
            label1.Text = "Controle da loja";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private int imageNumber = 1;

        private void LoadNextImage()
        {
            if (imageNumber == 11)
            {
                imageNumber = 1;
            }
            pictureBox1.ImageLocation = string.Format(@"C:\Users\CJ1850211\Downloads\marques\MarquesAnimation\MarquesAnimation\MarquesAnimation\bin\Debug\img\{0}.jpg", imageNumber);
            imageNumber++;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadNextImage();
        }


        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Show();
            pictureBox1.BringToFront();
            button1.BringToFront();
            label1.Text = "";
        }
    }
}
