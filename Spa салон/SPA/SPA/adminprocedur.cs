using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Data.OleDb;

namespace SPA
{
    public partial class adminprocedur : Form
    {

        public SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings.Get("ServerConnectionString"));

     //   OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=SPA.mdb");

        public adminprocedur()
        {
            InitializeComponent();
            con.Open();

            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Процедуры.[ID_Процедур], Процедуры.[Название], Процедуры.[Стоимость], Процедуры.[Описание], Процедуры.[Тип] FROM Процедуры", con);
            DataTable DT = new DataTable();
            sqlDa.Fill(DT);
            bunifuCustomDataGrid1.DataSource = DT;

            //OleDbCommand cmd = con.CreateCommand();
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "SELECT Процедуры.[ID_Процедур], Процедуры.[Название], Процедуры.[Стоимость], Процедуры.[Описание], Процедуры.[Тип] FROM Процедуры";
            //cmd.ExecuteNonQuery();
            //DataTable dt = new DataTable();
            //OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //da.Fill(dt);
            //bunifuCustomDataGrid1.DataSource = dt;
            con.Close();
            bunifuCustomDataGrid1.Columns[0].Visible = false;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            procedureadd s = new procedureadd();

            s.bunifuCustomLabel2.Visible = false;
            s.bunifuCustomLabel1.Visible = true;
            s.bunifuFlatButton1.Visible = true;
            s.bunifuFlatButton2.Visible = false;
            s.ShowDialog();
            con.Open();

            //OleDbCommand cmd = con.CreateCommand();
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "SELECT Процедуры.[ID_Процедур], Процедуры.[Название], Процедуры.[Стоимость], Процедуры.[Описание], Процедуры.[Тип] FROM Процедуры";
            //cmd.ExecuteNonQuery();
            //DataTable dt = new DataTable();
            //OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //da.Fill(dt);
            //bunifuCustomDataGrid1.DataSource = dt;
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Процедуры.[ID_Процедур], Процедуры.[Название], Процедуры.[Стоимость], Процедуры.[Описание], Процедуры.[Тип] FROM Процедуры", con);
            DataTable DT = new DataTable();
            sqlDa.Fill(DT);
            bunifuCustomDataGrid1.DataSource = DT;

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
                cmd.CommandText = "Delete  From Процедуры Where ID_Процедур  =" + bunifuCustomDataGrid1.CurrentRow.Cells[0].Value + "";
                cmd.ExecuteNonQuery();
                con.Close();
                con.Open();
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "SELECT Процедуры.[ID_Процедур], Процедуры.[Название], Процедуры.[Стоимость], Процедуры.[Описание], Процедуры.[Тип] FROM Процедуры";
                cmd1.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                da.Fill(dt);
                bunifuCustomDataGrid1.DataSource = dt;
                con.Close();
                bunifuCustomDataGrid1.Columns[0].Visible = false;


                //con.Open();
                //SqlCommand cmd = con.CreateCommand();
                //SqlDataAdapter sqlDa = new SqlDataAdapter("Delete  From Процедуры Where ID_Процедур =" + bunifuCustomDataGrid1.CurrentRow.Cells[0].Value + "", con);
                //DataTable DT = new DataTable();
                //sqlDa.Fill(DT);
                //bunifuCustomDataGrid1.DataSource = DT;
                //cmd.ExecuteNonQuery();
                //SqlDataAdapter sqlDa1 = new SqlDataAdapter("SELECT Процедуры.[ID_Процедур], Процедуры.[Название], Процедуры.[Стоимость], Процедуры.[Описание], Процедуры.[Тип] FROM Процедуры", con);
                //DataTable DT1 = new DataTable();
                //sqlDa.Fill(DT1);
                //bunifuCustomDataGrid1.DataSource = DT1;

                ////con.Close();
                ////bunifuCustomDataGrid1.Columns[0].Visible = false;

                //con.Close();
                //bunifuCustomDataGrid1.Columns[0].Visible = false;

                ////OleDbCommand cmd = con.CreateCommand();
                ////cmd.CommandType = CommandType.Text;
                ////cmd.CommandText = "Delete  From Процедуры Where ID_Процедур =" + bunifuCustomDataGrid1.CurrentRow.Cells[0].Value + "";
                ////cmd.ExecuteNonQuery();
                ////con.Close();


                ////con.Open();
                ////OleDbCommand cmd1 = con.CreateCommand();
                ////cmd1.CommandType = CommandType.Text;
                ////cmd1.CommandText = "SELECT Процедуры.[ID_Процедур], Процедуры.[Название], Процедуры.[Стоимость], Процедуры.[Описание], Процедуры.[Тип] FROM Процедуры";
                ////cmd1.ExecuteNonQuery();
                ////DataTable dt = new DataTable();
                ////OleDbDataAdapter da = new OleDbDataAdapter(cmd1);
                ////da.Fill(dt);
                ////bunifuCustomDataGrid1.DataSource = dt;
                ////con.Close();
                ////bunifuCustomDataGrid1.Columns[0].Visible = false;
            }
        }

        private void imgS_Click(object sender, EventArgs e)
        {
            SearchTextBox.Text = "";
            con.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Процедуры.[ID_Процедур], Процедуры.[Название], Процедуры.[Стоимость], Процедуры.[Описание], Процедуры.[Тип] FROM Процедуры", con);
            SqlCommandBuilder cb = new SqlCommandBuilder(sqlDa);
            DataSet ds = new DataSet();
            sqlDa.Fill(ds);
            bunifuCustomDataGrid1.DataSource = ds;
            bunifuCustomDataGrid1.DataSource = ds;
            bunifuCustomDataGrid1.DataSource = ds.Tables[0].DefaultView;
            con.Close();


            //OleDbCommand cmd = con.CreateCommand();
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "SELECT Материалы.[ID_Материалов], Материалы.[Название], Материалы.[Цена], Материалы.[Количество], Материалы.[Описание] FROM Материалы";
            //cmd.ExecuteNonQuery();
            //DataTable dt = new DataTable();
            //OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //da.Fill(dt);
            //bunifuCustomDataGrid1.DataSource = dt;

            bunifuCustomDataGrid1.Columns[0].Visible = false;
            imgS.Enabled = false;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "Select Процедуры.[ID_Процедур], Процедуры.[Название], Процедуры.[Стоимость], Процедуры.[Описание], Процедуры.[Тип]" +
                          "From Процедуры " +
                          "Where " +
                           "Название like '%" + SearchTextBox.Text + "%' OR " +
                           "Стоимость like '%" + SearchTextBox.Text + "%' OR " +
                           "Описание like '%" + SearchTextBox.Text + "%' OR " +
                           "Тип like '%" + SearchTextBox.Text + "%' ";
            imgS.Enabled = true;


            SqlCommand cmd = new SqlCommand(query, con);
            //con.Open();
            SqlDataAdapter SomeAdapter = new SqlDataAdapter(cmd);
            DataSet SomeDataSet = new DataSet();
            DataSet ds = new DataSet();
            SomeAdapter.Fill(ds);
            // bunifuCustomDataGrid1.DataSource = ds;

            //OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, con);
            //DataSet SomeDataSet = new DataSet();
            //dataAdapter.Fill(SomeDataSet);
            bunifuCustomDataGrid1.DataSource = ds;
            bunifuCustomDataGrid1.DataSource = ds.Tables[0].DefaultView;
            con.Close();
            bunifuCustomDataGrid1.Columns[0].Visible = false;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            procedureadd sa = new procedureadd();
            sa.bunifuCustomLabel1.Visible = false;
            sa.bunifuCustomLabel2.Visible = true;
            sa.bunifuFlatButton1.Visible = false;
            sa.bunifuFlatButton2.Visible = true;
            sa.tempid = Convert.ToInt32(bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString());
            sa.textBox1.Text = bunifuCustomDataGrid1.CurrentRow.Cells[1].Value.ToString();
            sa.textBox2.Text = bunifuCustomDataGrid1.CurrentRow.Cells[2].Value.ToString();
            sa.textBox3.Text = bunifuCustomDataGrid1.CurrentRow.Cells[3].Value.ToString();
            sa.textBox4.Text = bunifuCustomDataGrid1.CurrentRow.Cells[4].Value.ToString();
            sa.ShowDialog();
            con.Open();

            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Процедуры.[ID_Процедур], Процедуры.[Название], Процедуры.[Стоимость], Процедуры.[Описание], Процедуры.[Тип] FROM Процедуры", con);
            DataTable DT = new DataTable();
            sqlDa.Fill(DT);
            bunifuCustomDataGrid1.DataSource = DT;

            //OleDbCommand cmd = con.CreateCommand();
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "SELECT Процедуры.[ID_Процедур], Процедуры.[Название], Процедуры.[Стоимость], Процедуры.[Описание], Процедуры.[Тип] FROM Процедуры";
            //cmd.ExecuteNonQuery();
            //DataTable dt = new DataTable();
            //OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //da.Fill(dt);
            //bunifuCustomDataGrid1.DataSource = dt;
            con.Close();
            bunifuCustomDataGrid1.Columns[0].Visible = false;
        }
    }
}
