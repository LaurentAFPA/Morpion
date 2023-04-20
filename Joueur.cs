using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morpion
{
    internal class Joueur
    {
        /// <summary>
        /// Préom du joueur
        /// </summary>
        private string prenom;
        /// <summary>
        /// Obtient et définit le prénom du joueur
        /// </summary>
        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }
        /// <summary>
        /// Nom du joueur
        /// </summary>
        private string nom;
        /// <summary>
        /// Obtient et définit le nom du joueur
        /// </summary>
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        /// <summary>
        /// Pseudo du joueur
        /// </summary>
        private string pseudo;
        /// <summary>
        /// Obtient et définit le pseudo du joueur
        /// </summary>
        public string Pseudo
        {
            get { return pseudo; }
            set { pseudo = value; }
        }

        public Joueur(string Prenom, string Nom, string Pseudo)
        {
            this.Prenom = Prenom;
            this.Nom = Nom;
            this.Pseudo = Pseudo;
        }
        internal static Joueur unJoueur = new Joueur("", "", "Joueur 1");
        internal static Joueur deuxJoueur = new Joueur("", "", "Joueur 2");
    }
}
