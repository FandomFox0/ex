using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shevchenko
{
    public partial class authorisation : Form
    {
        private bool passchar = false;
        public authorisation()
        {
            InitializeComponent();
            Captcha();
        }
        Random random = new Random();
        string captchaText;

        private void Captcha()
        {
            Random rand = new Random();
            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            captchaText = string.Empty;
            for (int i = 0; i < 4; i++)
            {
                captchaText += characters[rand.Next(characters.Length)];
            }
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics graphics = Graphics.FromImage(bmp);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; graphics.Clear(Color.White);
            Font font = new Font("Arial", 40, FontStyle.Strikeout);
            for (int i = 0; i < 4; i++)
            {
                PointF point = new PointF(i * 20, 0);
                graphics.TranslateTransform(100, 50);
                graphics.RotateTransform(random.Next(-10, 10));
                graphics.DrawString(captchaText[i].ToString(), font, Brushes.Pink, point);
                graphics.ResetTransform();
            }
            pictureBox2.Image = bmp;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Логин")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "Логин";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Пароль")
            {
                textBox2.Text = "";
            }
            if (passchar) { textBox2.PasswordChar = '●'; }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Пароль";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            passchar = !passchar;
            if (passchar) { textBox2.PasswordChar = '●'; }
            else { textBox2.PasswordChar = '\0'; }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "user" && textBox2.Text == "user")
            {
                MessageBox.Show("Добро пожаловать!", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                main m = new main();
                this.Hide();
                m.ShowDialog();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Text = "";
                textBox2.Text = "";
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                //330
                //750
                this.Width = 750;
                this.Height = 550;

                textBox2.PasswordChar = '●';

                Captcha();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
