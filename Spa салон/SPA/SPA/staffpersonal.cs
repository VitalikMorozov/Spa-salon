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
    public partial class staffpersonal : Form
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings.Get("ServerConnectionString"));

        //   OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=SPA.mdb");
        public staffpersonal()
        {




            InitializeComponent();
            con.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Материалы.[ID_Материалов], Материалы.[Название], Материалы.[Цена], Материалы.[Количество], Материалы.[Описание] FROM Материалы",con);
            DataTable DT = new DataTable();
            sqlDa.Fill(DT);
            bunifuCustomDataGrid1.DataSource = DT;

         
            //OleDbCommand cmd = con.CreateCommand();
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "SELECT Материалы.[ID_Материалов], Материалы.[Название], Материалы.[Цена], Материалы.[Количество], Материалы.[Описание] FROM Материалы";
            //cmd.ExecuteNonQuery();
            //DataTable dt = new DataTable();
            //OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //da.Fill(dt);
            //bunifuCustomDataGrid1.DataSource = dt;
            con.Close();
            bunifuCustomDataGrid1.Columns[0].Visible = false;
        }

        private void imgS_Click(object sender, EventArgs e)
        {   SearchTextBox.Text = "";
            con.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Материалы.[ID_Материалов], Материалы.[Название], Материалы.[Цена], Материалы.[Количество], Материалы.[Описание] FROM Материалы", con);
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
            string query = "Select Материалы.[ID_Материалов], Материалы.[Название], Материалы.[Цена], Материалы.[Количество], Материалы.[Описание]" +
                          "From Материалы " +
                          "Where " +
                           "Название like '%" + SearchTextBox.Text + "%' OR " +
                           "Цена like '%" + SearchTextBox.Text + "%' OR " +
                           "Количество like '%" + SearchTextBox.Text + "%' OR " +
                           "Описание like '%" + SearchTextBox.Text + "%'";
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
    }
}
