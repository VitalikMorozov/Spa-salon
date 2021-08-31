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
    public class idHelper
    {
        public int procID;
        public int matID;
        public int count;
        public idHelper(int a, int b, int c)
        {
            this.procID = a;
            this.matID = b;
            this.count = c;
        }
    }
    public partial class UslugaAdd : Form
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings.Get("ServerConnectionString"));
        public UslugaAdd()
        {
            InitializeComponent();
        }
        public List<idHelper> IDs = new List<idHelper>();
        private void button1_Click(object sender, EventArgs e)
        {
            UslugaProcedureEditor UPE = new UslugaProcedureEditor();
            UPE.ShowDialog();
            if(UPE.DialogResult == DialogResult.OK)
            {
                idHelper item = new idHelper(help.id2proc, help.id3mat, help.prCount);
                IDs.Add(item);
                dataGridView1.Rows.Add(help.id3mat, help.id2proc, help.prCount);
            }
        }

        private void PriceCalculate()
        {

            string query = "SELECT Стоимость FROM Процедуры WHERE ID_Процедур = " + help.id2proc;
            SqlCommand SqlCom = new SqlCommand(query, con);
            SqlDataAdapter sqlDa = new SqlDataAdapter(SqlCom);
            DataTable DT = new DataTable();
            sqlDa.Fill(DT);
            //for
        }
    }
}
