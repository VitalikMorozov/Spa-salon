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
namespace SPA
{
    public partial class usingstaff : Form
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings.Get("ServerConnectionString"));

        public usingstaff()
        {
            InitializeComponent();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT        dbo.Процедуры.Название AS Процедура, dbo.Материалы.Название AS Материал, dbo.Материалы.Цена AS Стоимость,                          dbo.[Затраченные материалы].Количество AS [Количество затраченнных мтериалов], dbo.[Затраченные материалы].[ID_Затраченных материалов] FROM dbo.[Затраченные материалы] INNER JOIN                          dbo.Процедуры ON dbo.[Затраченные материалы].ID_Процедур = dbo.Процедуры.ID_Процедур INNER JOIN dbo.Материалы ON dbo.[Затраченные материалы].ID_Материалов = dbo.Материалы.ID_Материалов";

 cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            bunifuCustomDataGrid1.DataSource = dt;
            con.Close();
            bunifuCustomDataGrid1.Columns[4].Visible = false;

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            usingstaffadd s = new usingstaffadd();

            s.bunifuCustomLabel2.Visible = false;
            s.bunifuCustomLabel1.Visible = true;
            s.bunifuFlatButton1.Visible = true;
            s.bunifuFlatButton2.Visible = false;
            s.ShowDialog();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT        dbo.Процедуры.Название AS Процедура, dbo.Материалы.Название AS Материал, dbo.Материалы.Цена AS Стоимость,                          dbo.[Затраченные материалы].Количество AS [Количество затраченнных мтериалов], dbo.[Затраченные материалы].[ID_Затраченных материалов] FROM dbo.[Затраченные материалы] INNER JOIN                          dbo.Процедуры ON dbo.[Затраченные материалы].ID_Процедур = dbo.Процедуры.ID_Процедур INNER JOIN dbo.Материалы ON dbo.[Затраченные материалы].ID_Материалов = dbo.Материалы.ID_Материалов";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            bunifuCustomDataGrid1.DataSource = dt;
            con.Close();
            bunifuCustomDataGrid1.Columns[4].Visible = false;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            usingstaffadd sa = new usingstaffadd();
            sa.bunifuCustomLabel1.Visible = false;
            sa.bunifuCustomLabel2.Visible = true;
            sa.bunifuFlatButton1.Visible = false;
            sa.bunifuFlatButton2.Visible = true;
            sa.tempid = Convert.ToInt32(bunifuCustomDataGrid1.CurrentRow.Cells[4].Value.ToString());
            sa.textBox1.Text = bunifuCustomDataGrid1.CurrentRow.Cells[1].Value.ToString();
            sa.textBox2.Text = bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString();
            sa.textBox3.Text = bunifuCustomDataGrid1.CurrentRow.Cells[3].Value.ToString();
          
            sa.ShowDialog();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT        dbo.Процедуры.Название AS Процедура, dbo.Материалы.Название AS Материал, dbo.Материалы.Цена AS Стоимость,                          dbo.[Затраченные материалы].Количество AS [Количество затраченнных мтериалов], dbo.[Затраченные материалы].[ID_Затраченных материалов] FROM dbo.[Затраченные материалы] INNER JOIN                          dbo.Процедуры ON dbo.[Затраченные материалы].ID_Процедур = dbo.Процедуры.ID_Процедур INNER JOIN dbo.Материалы ON dbo.[Затраченные материалы].ID_Материалов = dbo.Материалы.ID_Материалов";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            bunifuCustomDataGrid1.DataSource = dt;
            con.Close();
            bunifuCustomDataGrid1.Columns[4].Visible = false;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "SELECT        dbo.Процедуры.Название AS Процедура, dbo.Материалы.Название AS Материал, dbo.Материалы.Цена AS Стоимость,                          dbo.[Затраченные материалы].Количество AS [Количество затраченнных мтериалов], dbo.[Затраченные материалы].[ID_Затраченных материалов] " +
                          "FROM dbo.[Затраченные материалы] INNER JOIN  dbo.Процедуры ON dbo.[Затраченные материалы].ID_Процедур = dbo.Процедуры.ID_Процедур INNER JOIN dbo.Материалы ON dbo.[Затраченные материалы].ID_Материалов = dbo.Материалы.ID_Материалов" +
                          "Where " +
                           "Процедура like '%" + SearchTextBox.Text + "%' OR " +
                           "Материал like '%" + SearchTextBox.Text + "%' OR " +
                           "Стоимость like '%" + SearchTextBox.Text + "%' OR " +
                           "[Количество затраченнных мтериалов] like '%" + SearchTextBox.Text + "%'  " ;
            imgS.Enabled = true;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, con);

            DataSet SomeDataSet = new DataSet();
            dataAdapter.Fill(SomeDataSet);

            bunifuCustomDataGrid1.DataSource = SomeDataSet;
            bunifuCustomDataGrid1.DataSource = SomeDataSet.Tables[0].DefaultView;
            con.Close();
            bunifuCustomDataGrid1.Columns[4].Visible = false;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Вы действительно хотите удалить эту запись?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Delete  From [Затраченные материалы] Where [ID_Затраченных материалов]=" + bunifuCustomDataGrid1.CurrentRow.Cells[4].Value + "";
                cmd.ExecuteNonQuery();
                con.Close();
                con.Open();
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "SELECT        dbo.Процедуры.Название AS Процедура, dbo.Материалы.Название AS Материал, dbo.Материалы.Цена AS Стоимость,                          dbo.[Затраченные материалы].Количество AS [Количество затраченнных мтериалов], dbo.[Затраченные материалы].[ID_Затраченных материалов] FROM dbo.[Затраченные материалы] INNER JOIN                          dbo.Процедуры ON dbo.[Затраченные материалы].ID_Процедур = dbo.Процедуры.ID_Процедур INNER JOIN dbo.Материалы ON dbo.[Затраченные материалы].ID_Материалов = dbo.Материалы.ID_Материалов";
                cmd1.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                da.Fill(dt);
                bunifuCustomDataGrid1.DataSource = dt;
                con.Close();
                bunifuCustomDataGrid1.Columns[4].Visible = false;
            }
        }

        private void imgS_Click(object sender, EventArgs e)
        {
            SearchTextBox.Text = "";
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT        dbo.Процедуры.Название AS Процедура, dbo.Материалы.Название AS Материал, dbo.Материалы.Цена AS Стоимость,                          dbo.[Затраченные материалы].Количество AS [Количество затраченнных мтериалов], dbo.[Затраченные материалы].[ID_Затраченных материалов] FROM dbo.[Затраченные материалы] INNER JOIN                          dbo.Процедуры ON dbo.[Затраченные материалы].ID_Процедур = dbo.Процедуры.ID_Процедур INNER JOIN dbo.Материалы ON dbo.[Затраченные материалы].ID_Материалов = dbo.Материалы.ID_Материалов";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            bunifuCustomDataGrid1.DataSource = dt;
            con.Close();
            bunifuCustomDataGrid1.Columns[0].Visible = false;
            imgS.Enabled = false;
        }
    }
}
