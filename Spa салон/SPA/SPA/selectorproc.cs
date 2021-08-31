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
    public partial class selectorproc : Form
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings.Get("ServerConnectionString"));

        public selectorproc(string table)
        {
            InitializeComponent();
            string query = "SELECT * FROM " + table;
            SqlCommand SqlCom = new SqlCommand(query, con);
            SqlDataAdapter sqlDa = new SqlDataAdapter(SqlCom);
            DataTable DT = new DataTable();
            sqlDa.Fill(DT);
            bunifuCustomDataGrid1.DataSource = DT;
            bunifuCustomDataGrid1.Columns[0].Visible = false;
            bunifuCustomDataGrid1.Columns[2].Visible = false;
            bunifuCustomDataGrid1.Columns[3].Visible = false;
            bunifuCustomDataGrid1.Columns[4].Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            help.id2proc = Convert.ToInt32(bunifuCustomDataGrid1.CurrentRow.Cells[0].Value);
            this.Close();
        }
    }
}
