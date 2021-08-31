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
    
    public partial class uslugAdd : Form
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings.Get("ServerConnectionString"));
        public class idHelper
        {
            public int ID;
            public int procID;
            public string procName;
            public int matID;
            public string matName;
            public int count;
            public idHelper(int ID, string procName, string matName, int a, int b, int c)
            {
                this.ID = ID;
                this.procID = a;
                this.matID = b;
                this.count = c;
                this.procName = procName;
                this.matName = matName;
            }
        }

     //   public SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings.Get("ServerConnectionString"));

        public uslugAdd()
        {
            InitializeComponent();
        }
        public List<idHelper> IDs = new List<idHelper>();
        private void uslugAdd_Load(object sender, EventArgs e)
        {
            if (help.isEdit)
            {
                
                
                    string query = "SELECT OAK.ID_Клиента as 'cli_ID', OAK.ID_Персонала as 'Pers_ID', P.ID_процедур as 'Proc_ID', M.ID_Материалов as 'Mat_ID', P.Название as 'pName', M.Название as 'mName', M.Количество as 'Cou' " +
                                   "FROM Процедуры AS P, " +
                                        "[Оказание услуги клиенту] AS OAK, " +
                                        "[Выполненные процедуры] as CP, " +
                                        "Материалы as M, " +
                                        "[Затраченные материалы] as LM " +
                                    "WHERE " +
                                        "OAK.ID_Оказание_услуги_клиенту = CP.ID_Оказание_услуги_клиенту AND " +
                                        "CP.ID_Процедур = LM.[ID_Затраченных материалов] AND " +
                                        "LM.ID_Материалов = M.ID_Материалов AND " +
                                       $"LM.ID_Процедур = P.ID_Процедур AND CP.ID_Оказание_услуги_клиенту = {help.uslugaID}";
                    //SqlConnection SqlCon = new SqlConnection(ConnectionString);
                    //SqlCon.Open();
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter UserDataAdapter = new SqlDataAdapter(cmd);
                    DataTable usl = new DataTable();
                    UserDataAdapter.Fill(usl);
                    con.Close();

                   help.clientID = usl.Rows[0].Field<int>("cli_ID");
                    help.persID = usl.Rows[0].Field<int>("Pers_ID");

                    for (int i = 0; i < usl.Rows.Count; i++)
                    {
                        int ID = IDs.Count + 1;
                        dataGridView1.Rows.Add(ID, usl.Rows[i].Field<string>("pName"), usl.Rows[i].Field<string>("mName"), usl.Rows[i].Field<int>("cou"));
                        idHelper item = new idHelper(ID, usl.Rows[i].Field<string>("pName"), usl.Rows[i].Field<string>("mName"), usl.Rows[i].Field<int>("Proc_ID"), usl.Rows[i].Field<int>("Mat_ID"), usl.Rows[i].Field<int>("cou"));
                        IDs.Add(item);
                        string query123 = $"SELECT Клиент.Фамилия as 'cliName', Персонал.Фамилия + ' ' + Персонал.Имя as 'persName' From Персонал, Клиент Where ID_Персонала = {usl.Rows[0].Field<int>("Pers_ID")} AND ID_Клиента = {usl.Rows[0].Field<int>("cli_ID")}";

                        con.Open();
                        cmd = new SqlCommand(query123, con);
                        UserDataAdapter = new SqlDataAdapter(cmd);
                        DataTable usl2 = new DataTable();
                        UserDataAdapter.Fill(usl2);
                        con.Close();
                        ClientBox.Text = usl2.Rows[0].Field<string>("cliName");
                        PersBox.Text = usl2.Rows[0].Field<string>("persName");
                    }

                    label5.Text = "";
                
               
            }
            else
            {
                string query = "SELECT MAX(ID_Оказание_услуги_клиенту) as 'QQ' FROM [Оказание услуги клиенту]";
                //SqlConnection SqlCon = new SqlConnection(con);
                //SqlCon.Open();
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter UserDataAdapter = new SqlDataAdapter(cmd);
                DataTable usl = new DataTable();
                UserDataAdapter.Fill(usl);
                con.Close();
                help.uslugaID = usl.Rows[0].Field<int>("QQ");
            }

        }

        private void label5_TextChanged(object sender, EventArgs e)
        {
            double trouble = 0;
            double itog = 0;
            foreach (idHelper item in IDs)
            {
                string query1 = "SELECT Стоимость FROM Процедуры WHERE ID_Процедур = " + item.procID;
                string query2 = "SELECT Цена FROM Материалы WHERE ID_Материалов = " + item.matID;
                SqlCommand SqlCom = new SqlCommand(query1, con);
                SqlCommand SqlCom2 = new SqlCommand(query2, con);
                SqlDataAdapter sqlDa = new SqlDataAdapter(SqlCom);
                SqlDataAdapter sqlDa2 = new SqlDataAdapter(SqlCom2);
                DataTable DT = new DataTable();
                DataTable DT2 = new DataTable();
                sqlDa.Fill(DT);
                sqlDa2.Fill(DT2);
                for(int i = 0; i < DT.Rows.Count; i++)
                {
                    trouble = DT.Rows[i].Field<Double>("Стоимость") + DT2.Rows[i].Field<Double>("Цена") * IDs[i].count;
                    itog += trouble;
                }
            }
            label5.Text = itog.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            UslugaProcedureEditor UPE = new UslugaProcedureEditor();
            UPE.ShowDialog();
            if (UPE.DialogResult == DialogResult.OK)
            {
                int ID = IDs.Count + 1;
                string query = $"SELECT Материалы.Название as 'mName', Процедуры.Название as 'pName' From Процедуры, Материалы Where ID_Материалов = {help.id3mat} AND ID_Процедур = {help.id2proc}";
                //SqlConnection SqlCon = new SqlConnection(help.ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter UserDataAdapter = new SqlDataAdapter(cmd);
                DataTable usl = new DataTable();
                UserDataAdapter.Fill(usl);
                con.Close();
                idHelper item = new idHelper(ID, usl.Rows[0].Field<string>("pName"), usl.Rows[0].Field<string>("mName"), help.id2proc, help.id3mat, help.prCount);
                IDs.Add(item);
                dataGridView1.Rows.Add(ID, usl.Rows[0].Field<string>("pName"), usl.Rows[0].Field<string>("mName"), help.prCount);
                label5.Text = "";
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < IDs.Count; i++)
            {
                if (IDs[i].ID == Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value))
                {
                    IDs.Remove(IDs[i]);
                }
            }
            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
            label5.Text = "";
        }

        private void ClientSelBtn_Click(object sender, EventArgs e)
        {
           
                selectorklient s1 = new selectorklient();
                s1.ShowDialog();
                if (s1.DialogResult == DialogResult.OK)
                {
                    string query = "SELECT * FROM Клиент Where ID_Клиента = " + help.clientID;
                    SqlCommand SqlCom = new SqlCommand(query, con);
                    SqlDataAdapter sqlDa = new SqlDataAdapter(SqlCom);
                    DataTable DT = new DataTable();
                    sqlDa.Fill(DT);
                    ClientBox.Text = Convert.ToString(DT.Rows[0].Field<string>("Фамилия"));
                }
            
        }

        private void PersSelBtn_Click(object sender, EventArgs e)
        {
            
                selectorpers s1 = new selectorpers();
                s1.ShowDialog();
                if (s1.DialogResult == DialogResult.OK)
                {
                    string query = "SELECT * FROM Персонал Where ID_Персонала = " + help.persID;
                    SqlCommand SqlCom = new SqlCommand(query, con);
                    SqlDataAdapter sqlDa = new SqlDataAdapter(SqlCom);
                    DataTable DT = new DataTable();
                    sqlDa.Fill(DT);
                    PersBox.Text = Convert.ToString(DT.Rows[0].Field<string>("Фамилия"));
                }
            
            
        }
        public string trueDate;
        private void AcceptBtn_Click(object sender, EventArgs e)
        { 
            if (DateBox.Value.Month < 10)
            {
                trueDate = $"{DateBox.Value.Year}0{DateBox.Value.Month}{DateBox.Value.Day}";
            }
            else
            if (DateBox.Value.Day < 10)
            {
                trueDate = $"{DateBox.Value.Year}{DateBox.Value.Month}0{DateBox.Value.Day}";
            }
            if (help.isEdit)
            {
                ClientSelBtn.Enabled = false;
                string uslQuery = $"UPDATE [Оказание услуги клиенту] SET [Дата и время] = '{ trueDate}', [Стоимость]= {label5.Text} where ID_Оказание_услуги_клиенту = " + Convert.ToInt32( help.uslugaID) +  "";
                con.Open();
                //[ID_Клиента] = {help.clientID} ,
                SqlCommand cmd = new SqlCommand(uslQuery, con);
                SqlDataAdapter UserDataAdapter = new SqlDataAdapter(cmd);
             //   DataTable usl = new DataTable();
               // UserDataAdapter.Fill(usl);
                SqlCommand SqlCom3 = new SqlCommand(uslQuery, con);
                SqlCom3.ExecuteNonQuery();
                con.Close();


                this.DialogResult = DialogResult.OK;
                this.Close();
                ClientSelBtn.Enabled = true;
            }
            else
            {
                foreach (idHelper item in IDs)
                {
                   
                   
                        string matQuery = $"INSERT INTO [Затраченные материалы] VALUES ({item.matID}, {item.procID}, {item.count})";
                       string uslQuery = $"INSERT INTO [Оказание услуги клиенту]  VALUES ({help.clientID},{help.persID},'{trueDate}',{label5.Text})";
                    //       string uslQuery = $"INSERT INTO [Оказание услуги клиенту] ([ID_Клиента],[ID_Персонала],[Дата и время],[Стоимость])" +
               //     "VALUES('" + Convert.ToInt32( help.clientID) + "','" + Convert.ToInt32(help.persID) + "', "  + '{trueDate}' + ",'" +Convert.ToDouble( label5.Text )+ "')";

                    string query = "SELECT MAX([ID_Затраченных материалов]) as 'QQ' FROM [Затраченные материалы]";
                        //SqlConnection SqlCon = new SqlConnection(help.ConnectionString);
                        con.Open();
                        SqlCommand cmd = new SqlCommand(query, con);
                        SqlDataAdapter UserDataAdapter = new SqlDataAdapter(cmd);
                        DataTable usl = new DataTable();
                        UserDataAdapter.Fill(usl);
                        con.Close();
                        int QQ = usl.Rows[0].Field<int>("QQ");
                        string procQuery = $"INSERT INTO [Выполненные процедуры] VALUES ({help.uslugaID}, {QQ})";
                        SqlCommand SqlCom = new SqlCommand(matQuery, con);
                        SqlCommand SqlCom2 = new SqlCommand(procQuery, con);
                        SqlCommand SqlCom3 = new SqlCommand(uslQuery, con);
                        con.Open();
                        SqlCom.ExecuteNonQuery();
                        SqlCom2.ExecuteNonQuery();
                        SqlCom3.ExecuteNonQuery();
                        con.Close();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                   
                    
                   
                    con.Close();
                    this.Close();
                }
            }
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
