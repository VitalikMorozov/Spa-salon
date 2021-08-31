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
    public partial class selectorklient : Form
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings.Get("ServerConnectionString"));

        public selectorklient()
        {
            InitializeComponent();

            InitializeComponent();
            string query = "SELECT * FROM Клиент";
            SqlCommand SqlCom = new SqlCommand(query, con);
            SqlDataAdapter sqlDa = new SqlDataAdapter(SqlCom);
            DataTable DT = new DataTable();
            sqlDa.Fill(DT);
            bunifuCustomDataGrid1.DataSource = DT;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            help.clientID = Convert.ToInt32(bunifuCustomDataGrid1.CurrentRow.Cells[0].Value);
            this.Close();
        }
    }
}
