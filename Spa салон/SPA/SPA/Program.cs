using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPA
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        
    }
    public static class help
    {
        public static string a;
        public static string a1;
        public static string a2;

        public static int IDKLASS;
        public static int id;
        public static int id2proc;
        public static int id3mat;
        public static int id4;
        public static int id5;
        public static int id6;
        public static int id7;
        public static int idREBOBSLED;

        public static int prMatID;
        public static int prProcID;
        public static int prCount;
        public static int clientID;
        public static int persID;
        public static int uslugaID;
        public static bool isEdit;

   //     public static string ConnectionString = "Data Source=DESKTOP-H8J4IK0;Initial Catalog=Kukuku;Integrated Security=True";
    }
}
