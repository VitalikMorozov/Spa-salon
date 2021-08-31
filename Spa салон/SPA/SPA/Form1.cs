using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Data.OleDb;
namespace SPA
{
    public partial class Form1 : Form
    {
      

        public Form1()
        {
            InitializeComponent();
           

            // открываем соединение с БД
     
          

        }


     
        private void timer1_Tick(object sender, EventArgs e)
        {

            bunifuTransition1.HideSync(firstUC1);
            bunifuTransition2.ShowSync(secondUC1);
            bunifuTransition1.HideSync(firstUC2);
            bunifuTransition2.ShowSync(secondUC2);
            bunifuTransition1.HideSync(firstUC3);
            bunifuTransition2.ShowSync(secondUC3);
            bunifuTransition1.HideSync(firstUC4);
            bunifuTransition2.ShowSync(secondUC4);

            bunifuTransition2.HideSync(secondUC1);
            bunifuTransition1.ShowSync(firstUC1);
            bunifuTransition2.HideSync(secondUC2);
            bunifuTransition1.ShowSync(firstUC2);
            bunifuTransition2.HideSync(secondUC3);
            bunifuTransition1.ShowSync(firstUC3);
            bunifuTransition2.HideSync(secondUC4);
            bunifuTransition1.ShowSync(firstUC4);

            
        }

      
        private void Form1_Load(object sender, EventArgs e)
        {

            bunifuTransition1.Show(firstUC1);
            bunifuTransition1.Show(firstUC2);
            bunifuTransition1.Show(firstUC3);
            bunifuTransition1.Show(firstUC4);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите закрыть приложение ? ", "Внимание! ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bunifuTransition1.HideSync(firstUC1); bunifuTransition2.ShowSync(secondUC1);
            bunifuTransition1.HideSync(firstUC2); bunifuTransition2.ShowSync(secondUC2);
            bunifuTransition1.HideSync(firstUC3); bunifuTransition2.ShowSync(secondUC3);
            bunifuTransition1.HideSync(firstUC4); bunifuTransition2.ShowSync(secondUC4);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bunifuTransition2.HideSync(secondUC1); bunifuTransition1.ShowSync(firstUC1);
            bunifuTransition2.HideSync(secondUC2); bunifuTransition1.ShowSync(firstUC2);
            bunifuTransition2.HideSync(secondUC3); bunifuTransition1.ShowSync(firstUC3);
            bunifuTransition2.HideSync(secondUC4); bunifuTransition1.ShowSync(firstUC4);
        }



        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://wellness-spa.by");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://vk.com/wellnessbeautyspa");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/wellnessbeautyspanovopolotsk/");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/wellness_beauty_spaa/");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Procedur s = new Procedur();
            s.ShowDialog();
            if (Procedur.flagprocedure == false)
            {

                this.Hide();
            }
            Procedur.flagprocedure = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            aut s = new aut();
            s.ShowDialog();
            timer1.Stop();
           
            if (aut.flag == false) {
            
            this.Hide();
            }
             aut.flag = false;    
            
        }

   
    }
}
