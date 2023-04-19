using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Morpion
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmAccueil());
        }
        internal static Joueur unJoueur = new Joueur("", "", "Joueur 1");
        internal static Joueur deuxJoueur = new Joueur("", "", "Joueur 2");
    }
}
