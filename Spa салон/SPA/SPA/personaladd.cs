using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;


namespace SPA
{
    public partial class personaladd : Form
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings.Get("ServerConnectionString"));

       // OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=SPA.mdb");
        public personaladd()
        {
            InitializeComponent();
       
        }
        public int tempid = 0;
        private void Salir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите закрыть окно добавления персонала ? ", "Внимание! ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();

            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            
            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = ("INSERT INTO Персонал ( Фамилия, Имя, Отчество, [Стаж работы], [Номер телефона], Должность )" +
                "VALUES('" + textBox1.Text + "','" + textBox2.Text + "', '" + textBox3.Text + "','" + Convert.ToInt32( textBox4.Text )+ "','" +  maskedTextBox1.Text + "','" +  textBox6.Text + "')");
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно сохранены!");
                con.Close();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = ("Update Персонал set Фамилия ='" + textBox1.Text + "' , Имя ='" + textBox2.Text + "', Отчество ='" + textBox3.Text + "', [Стаж работы] =" + Convert.ToInt32(textBox4.Text) + ", [Номер телефона] ='" + maskedTextBox1.Text + "', Должность ='" + textBox6.Text + "' where(ID_Персонала=" + Convert.ToInt32(tempid) + ")");
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно узменены!");
                con.Close();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void MenuTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }



        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && (e.KeyChar != 8) && (e.KeyChar != ' '))
            {
                e.Handled = true;
                MessageBox.Show("Ввод только русских букв!", "ERROR");
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8) && (e.KeyChar != ' ') && (e.KeyChar < '0' || e.KeyChar > '9'))
            {
                e.Handled = true;
                MessageBox.Show("Ошибка ввода данных!", "ERROR");
            }
        }
    }
}