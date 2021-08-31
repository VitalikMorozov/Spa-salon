using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPA
{
    public partial class personalform : Form
    {
        public personalform()
        {
            InitializeComponent();
        }

        private void MenuSidebar_Click(object sender, EventArgs e)
        {
            if (Sidebar.Width == 270)
            {
                Sidebar.Visible = false;
                Sidebar.Width = 68;
                SidebarWrapper.Width = 90;
                LineaSidebar.Width = 52;
                AnimacionSidebar.Show(Sidebar);
            }
            else
            {
                Sidebar.Visible = false;
                Sidebar.Width = 270;
                SidebarWrapper.Width = 300;
                LineaSidebar.Width = 252;
                AnimacionSidebarBack.Show(Sidebar);
            }
        }

        private void Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void Salir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите закрыть приложение ? ", "Внимание! ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();

            }
        }

        private void Restaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            Maximizar.Visible = true;
            Restaurar.Visible = false;
        }

        private void Maximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Maximizar.Visible = false;
            Restaurar.Visible = true;
        }

        public void FullFormEnPanel(object formfull) //full form data
        {
            if (this.panelcontent.Controls.Count > 0)
                this.panelcontent.Controls.RemoveAt(0);
            Form fh = formfull as Form;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            this.panelcontent.Controls.Add(fh);
            this.panelcontent.Tag = fh;
            fh.Show();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            klient pe = new klient();
            FullFormEnPanel(pe);

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            staffpersonal pe = new staffpersonal();
            FullFormEnPanel(pe);
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            uslugi usl = new uslugi();
            FullFormEnPanel(usl);
        }
    }
}
