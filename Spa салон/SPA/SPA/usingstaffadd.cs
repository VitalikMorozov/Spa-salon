using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Runtime.InteropServices;

namespace SPA
{
    public partial class usingstaffadd : Form
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings.Get("ServerConnectionString"));
        public int tempid = 0;
        public usingstaffadd()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            try
            {
                selectormat s1 = new selectormat("Материалы");
                s1.ShowDialog();
                if (s1.DialogResult == DialogResult.OK)
                {
                    string query = "SELECT * FROM Материалы Where ID_Материалов = " + help.id3mat;
                    SqlCommand SqlCom = new SqlCommand(query, con);
                    SqlDataAdapter sqlDa = new SqlDataAdapter(SqlCom);
                    DataTable DT = new DataTable();
                    sqlDa.Fill(DT);
                    textBox1.Text = Convert.ToString(DT.Rows[0].Field<string>("Название"));
                }
            }
            catch
            {
                MessageBox.Show("Не верный ввод данных", "ERROR");
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            try
            {
                selectorproc s1 = new selectorproc("Процедуры");
                s1.ShowDialog();
                if (s1.DialogResult == DialogResult.OK)
                {
                    string query = "SELECT * FROM Процедуры Where ID_Процедур = " + help.id2proc;
                    SqlCommand SqlCom = new SqlCommand(query, con);
                    SqlDataAdapter sqlDa = new SqlDataAdapter(SqlCom);
                    DataTable DT = new DataTable();
                    sqlDa.Fill(DT);
                    textBox2.Text = Convert.ToString(DT.Rows[0].Field<string>("Название"));
                }
            }
            catch
            {
                MessageBox.Show("Не верный ввод данных", "ERROR");
            }
        }

        private void MenuTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите закрыть окно  ? ", "Внимание! ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();

            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8) && (e.KeyChar != ' ') && (e.KeyChar < '0' || e.KeyChar > '9'))
            {
                e.Handled = true;
                MessageBox.Show("Ошибка ввода данных!", "ERROR");
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = ("INSERT INTO [Затраченные материалы] ([ID_Материалов],[ID_Процедур],[Количество])" +
                "VALUES('" + help.id3mat + "','" + help.id2proc + "', '" + Convert.ToInt32( textBox3.Text) + "')");
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
                cmd.CommandText = ("Update [Затраченные материалы] set [ID_Материалов] ='" + help.id3mat + "' , [ID_Процедур] ='" + help.id2proc + "', [Количество] ='" + Convert.ToInt32(textBox3.Text) + "' where([ID_Затраченных материалов]=" + Convert.ToInt32(tempid) + ")");
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
    }
}
