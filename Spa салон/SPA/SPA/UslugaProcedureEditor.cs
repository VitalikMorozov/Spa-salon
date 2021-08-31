using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPA
{
    public partial class UslugaProcedureEditor : Form
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings.Get("ServerConnectionString"));
        public UslugaProcedureEditor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            help.prCount = Convert.ToInt32(textBox3.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
