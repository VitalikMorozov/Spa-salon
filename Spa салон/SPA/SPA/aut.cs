using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPA
{
    public partial class aut : Form
    {
        public aut()
        {
            InitializeComponent();
        }
        public static bool flag = false;
        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin")
            {
                if (textBox2.Text == "admin") {
                    this.Close();
                    adminforms s1 = new adminforms();
                    s1.Show();
                }
                else { MessageBox.Show("Не правильный логин или пароль"); textBox1.Text = string.Empty; textBox2.Text = string.Empty; }
            }
            else
            {
                if (textBox1.Text == "person")
                {
                    if (textBox2.Text == "person") {
                        this.Close();
                        personalform s = new personalform();
                        s.Show();
                    }
                    else { MessageBox.Show("Не правильный логин или пароль"); textBox1.Text = ""; textBox2.Text = string.Empty; }
                }
                else { MessageBox.Show("Не правильный логин или пароль"); textBox1.Text = ""; textBox2.Text = string.Empty; }
            }





            //this.Close();
            //personalform  s = new personalform();
            //s.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
            flag = true;
        }

 
    }
}
