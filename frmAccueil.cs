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
    public partial class frmAccueil : Form
    {
        public frmAccueil()
        {
            InitializeComponent();
        }

        private void btnJouer_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmJeu frmJ = new frmJeu();
            frmJ.ShowDialog();
            this.Close();
        }

        private void btnInscription_Click(object sender, EventArgs e)
        {
            frmAjoutJoueur frmAJ = new frmAjoutJoueur();
            frmAJ.ShowDialog();
            this.Close();
        }
    }
}
