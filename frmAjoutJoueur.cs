using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Morpion
{
    public partial class frmAjoutJoueur : Form
    {
        public bool insc = false;
        public frmAjoutJoueur()
        {
            InitializeComponent();
            lblIdJoueur.Text = "Joueur 1";
        }
        public void AjoutJoueur()
        {
            if (insc == false)
            {
                Joueur.unJoueur.Prenom = txtPrenom.Text;
                Joueur.unJoueur.Nom = txtNom.Text;
                Joueur.unJoueur.Pseudo = txtPseudo.Text;
                lblIdJoueur.Text = "Joueur 2";
                insc = true;
            }
            else if (insc == true)
            {
                Joueur.deuxJoueur.Prenom = txtPrenom.Text;
                Joueur.deuxJoueur.Nom = txtNom.Text;
                Joueur.deuxJoueur.Pseudo = txtPseudo.Text;
                frmJeu.inscription = true;
                frmJeu frmJ = new frmJeu();
                frmJ.ShowDialog();
                this.Close();
            }
        }

        public void ViderC()
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
                this.txtPrenom.Focus();
            }
        }

        private void btnValider_Click_1(object sender, EventArgs e)
        {
            AjoutJoueur();
            ViderC();
        }

        private void btnVider_Click_1(object sender, EventArgs e)
        {
            ViderC();
        }
    }
}

