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
    public partial class uslugi : Form
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings.Get("ServerConnectionString"));

        public uslugi()
        {
            InitializeComponent();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM [Оказание услуги клиенту]";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            bunifuCustomDataGrid1.DataSource = dt;
            con.Close();
            bunifuCustomDataGrid1.Columns[0].Visible = false;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            help.isEdit = false;
            uslugAdd UA = new uslugAdd();
            if(UA.ShowDialog() == DialogResult.OK)
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM [Оказание услуги клиенту]";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                bunifuCustomDataGrid1.DataSource = dt;
                con.Close();
                bunifuCustomDataGrid1.Columns[0].Visible = false;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            help.isEdit = true;
            uslugAdd UA = new uslugAdd();
            help.uslugaID = Convert.ToInt32(bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString());
            
            if (UA.ShowDialog() == DialogResult.OK)
            {
            //    UA.ClientBox = ;
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM [Оказание услуги клиенту]";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                bunifuCustomDataGrid1.DataSource = dt;
                con.Close();
                bunifuCustomDataGrid1.Columns[0].Visible = false;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

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
