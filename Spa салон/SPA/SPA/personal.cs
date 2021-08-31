using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
namespace SPA
{
    public partial class personal : Form
    {

        public SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings.Get("ServerConnectionString"));

        //  public string CmdText = "SELECT Персонал.[Фамилия], Персонал.[Имя], Персонал.[Отчество], Персонал.[Стаж работы], Персонал.[Номер телефона], Персонал.[Должность] FROM Персонал;";
        // public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=SPA.mdb;";
     //   OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=SPA.mdb");


        //OleDbDataAdapter da = new OleDbDataAdapter();
        //BindingSource bs = new BindingSource();
        //DataSet ds = new DataSet();



        public personal()
        {
            InitializeComponent();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT ID_Персонала, Персонал.[Фамилия], Персонал.[Имя], Персонал.[Отчество], Персонал.[Стаж работы], Персонал.[Номер телефона], Персонал.[Должность] FROM Персонал";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            bunifuCustomDataGrid1.DataSource = dt;
            con.Close();
            bunifuCustomDataGrid1.Columns[0].Visible = false;
        }



   
        private void personal_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "Select ID_Персонала, Персонал.[Фамилия], Персонал.[Имя], Персонал.[Отчество], Персонал.[Стаж работы], Персонал.[Номер телефона], Персонал.[Должность]" +
                          "From Персонал " +
                          "Where " +
                           "Фамилия like '%" + SearchTextBox.Text + "%' OR " +
                           "Имя like '%" + SearchTextBox.Text + "%' OR " +
                           "Отчество like '%" + SearchTextBox.Text + "%' OR " +
                           "[Стаж работы] like '%" + SearchTextBox.Text + "%' OR " +
                           "[Номер телефона] like '%" + SearchTextBox.Text + "%' OR " +
                           "Должность like '%" + SearchTextBox.Text + "%'";
            imgS.Enabled = true;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, con);

            DataSet SomeDataSet = new DataSet();
            dataAdapter.Fill(SomeDataSet);

            bunifuCustomDataGrid1.DataSource = SomeDataSet;
            bunifuCustomDataGrid1.DataSource = SomeDataSet.Tables[0].DefaultView;
            con.Close();
            bunifuCustomDataGrid1.Columns[0].Visible = false;
        }

        private void imgS_Click(object sender, EventArgs e)
        {
            SearchTextBox.Text = "";
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT ID_Персонала, Персонал.[Фамилия], Персонал.[Имя], Персонал.[Отчество], Персонал.[Стаж работы], Персонал.[Номер телефона], Персонал.[Должность] FROM Персонал";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            bunifuCustomDataGrid1.DataSource = dt;
            con.Close();
            bunifuCustomDataGrid1.Columns[0].Visible = false;
            imgS.Enabled = false;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Вы действительно хотите удалить эту запись?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Delete  From Персонал Where ID_Персонала =" + bunifuCustomDataGrid1.CurrentRow.Cells[0].Value +"" ;
                cmd.ExecuteNonQuery();
                con.Close();
                con.Open();
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "SELECT ID_Персонала, Персонал.[Фамилия], Персонал.[Имя], Персонал.[Отчество], Персонал.[Стаж работы], Персонал.[Номер телефона], Персонал.[Должность] FROM Персонал";
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
            
            personaladd s = new personaladd();
            
            s.bunifuCustomLabel2.Visible = false;
            s.bunifuCustomLabel1.Visible = true;
            s.bunifuFlatButton1.Visible = true;
            s.bunifuFlatButton2.Visible = false;
            




            s.ShowDialog();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT ID_Персонала, Персонал.[Фамилия], Персонал.[Имя], Персонал.[Отчество], Персонал.[Стаж работы], Персонал.[Номер телефона], Персонал.[Должность] FROM Персонал";
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
            personaladd sa = new personaladd();
            sa.bunifuCustomLabel1.Visible = false;
            sa.bunifuCustomLabel2.Visible = true;
            sa.bunifuFlatButton1.Visible = false;
            sa.bunifuFlatButton2.Visible = true;
            sa.tempid = Convert.ToInt32(bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString()); 
            sa.textBox1.Text = bunifuCustomDataGrid1.CurrentRow.Cells[1].Value.ToString();
            sa.textBox2.Text = bunifuCustomDataGrid1.CurrentRow.Cells[2].Value.ToString();
            sa.textBox3.Text = bunifuCustomDataGrid1.CurrentRow.Cells[3].Value.ToString();
            sa.textBox4.Text = bunifuCustomDataGrid1.CurrentRow.Cells[4].Value.ToString();
            sa.maskedTextBox1.Text = bunifuCustomDataGrid1.CurrentRow.Cells[5].Value.ToString();
            sa.textBox6.Text = bunifuCustomDataGrid1.CurrentRow.Cells[6].Value.ToString();
            sa.ShowDialog();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT ID_Персонала, Персонал.[Фамилия], Персонал.[Имя], Персонал.[Отчество], Персонал.[Стаж работы], Персонал.[Номер телефона], Персонал.[Должность] FROM Персонал";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            bunifuCustomDataGrid1.DataSource = dt;
            con.Close();
            bunifuCustomDataGrid1.Columns[0].Visible = false;
        }
    }
}
