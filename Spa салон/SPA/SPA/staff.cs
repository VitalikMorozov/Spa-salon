using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
namespace SPA
{
    
    public partial class staff : Form
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings.Get("ServerConnectionString"));

     //   OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=SPA.mdb");
        public staff()
        {
            InitializeComponent();


            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Материалы.[ID_Материалов], Материалы.[Название], Материалы.[Цена], Материалы.[Количество], Материалы.[Описание] FROM Материалы";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            bunifuCustomDataGrid1.DataSource = dt;
            con.Close();
            bunifuCustomDataGrid1.Columns[0].Visible = false;
        }

        private void imgS_Click(object sender, EventArgs e)
        {
            SearchTextBox.Text = "";
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Материалы.[ID_Материалов], Материалы.[Название], Материалы.[Цена], Материалы.[Количество], Материалы.[Описание] FROM Материалы";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            bunifuCustomDataGrid1.DataSource = dt;
            con.Close();
            bunifuCustomDataGrid1.Columns[0].Visible = false;
            imgS.Enabled = false;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "Select Материалы.[ID_Материалов], Материалы.[Название], Материалы.[Цена], Материалы.[Количество], Материалы.[Описание]" +
                          "From Материалы " +
                          "Where " +
                           "Название like '%" + SearchTextBox.Text + "%' OR " +
                           "Цена like '%" + SearchTextBox.Text + "%' OR " +
                           "Количество like '%" + SearchTextBox.Text + "%' OR " +
                           "Описание like '%" + SearchTextBox.Text + "%'";
            imgS.Enabled = true;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, con);
            DataSet SomeDataSet = new DataSet();
            dataAdapter.Fill(SomeDataSet);
            bunifuCustomDataGrid1.DataSource = SomeDataSet;
            bunifuCustomDataGrid1.DataSource = SomeDataSet.Tables[0].DefaultView;
            con.Close();
            bunifuCustomDataGrid1.Columns[0].Visible = false;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Вы действительно хотите удалить эту запись?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Delete  From Материалы Where ID_Материалов =" + bunifuCustomDataGrid1.CurrentRow.Cells[0].Value + "";
                cmd.ExecuteNonQuery();
                con.Close();
                con.Open();
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "SELECT Материалы.[ID_Материалов], Материалы.[Название], Материалы.[Цена], Материалы.[Количество], Материалы.[Описание] FROM Материалы";
                cmd1.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                da.Fill(dt);
                bunifuCustomDataGrid1.DataSource = dt;
                con.Close();
                bunifuCustomDataGrid1.Columns[0].Visible = false;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            staffadd s = new staffadd();

            s.bunifuCustomLabel2.Visible = false;
            s.bunifuCustomLabel1.Visible = true;
            s.bunifuFlatButton1.Visible = true;
            s.bunifuFlatButton2.Visible = false;
            s.ShowDialog();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Материалы.[ID_Материалов], Материалы.[Название], Материалы.[Цена], Материалы.[Количество], Материалы.[Описание] FROM Материалы";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            bunifuCustomDataGrid1.DataSource = dt;
            con.Close();
            bunifuCustomDataGrid1.Columns[0].Visible = false;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            staffadd sa = new staffadd();
            sa.bunifuCustomLabel1.Visible = false;
            sa.bunifuCustomLabel2.Visible = true;
            sa.bunifuFlatButton1.Visible = false;
            sa.bunifuFlatButton2.Visible = true;
            sa.tempid = Convert.ToInt32(bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString());
            sa.textBox1.Text = bunifuCustomDataGrid1.CurrentRow.Cells[1].Value.ToString();
            sa.textBox2.Text = bunifuCustomDataGrid1.CurrentRow.Cells[2].Value.ToString();
            sa.textBox5.Text = bunifuCustomDataGrid1.CurrentRow.Cells[3].Value.ToString();
            sa.textBox3.Text = bunifuCustomDataGrid1.CurrentRow.Cells[4].Value.ToString();
            sa.ShowDialog();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Материалы.[ID_Материалов], Материалы.[Название], Материалы.[Цена], Материалы.[Количество], Материалы.[Описание] FROM Материалы";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            bunifuCustomDataGrid1.DataSource = dt;
            con.Close();
            bunifuCustomDataGrid1.Columns[0].Visible = false;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = null;
            worksheet = workbook.Sheets["Лист1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "Выполненные процедуры";

            for (int i = 1; i < bunifuCustomDataGrid1.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = bunifuCustomDataGrid1.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < bunifuCustomDataGrid1.Rows.Count; i++)
            {
                for (int j = 0; j < bunifuCustomDataGrid1.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = bunifuCustomDataGrid1.Rows[i].Cells[j].Value;
                }
            }

            var saveFileDialoge = new SaveFileDialog();
            saveFileDialoge.FileName = "output";
            saveFileDialoge.DefaultExt = ".xlsx";
            if (saveFileDialoge.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialoge.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            app.Quit();
        }
    }
}
