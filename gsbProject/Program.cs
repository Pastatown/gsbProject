using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gsbProject
{
    static class Program
    {
        public static DB mydb;
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            mydb = new DB("192.168.30.205", "gsb", "normal", "");

            if (Program.mydb.OpenConnection() != true)
            {
                MessageBox.Show("Connexion à la base de données impossible: vérifiez les paramètres.",
                    "Connexion à la base de données impossible", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu());
        }
    }
}
