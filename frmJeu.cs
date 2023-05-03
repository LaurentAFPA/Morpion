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
    public partial class frmJeu : Form
    {
        public static bool inscription;
        int SJ1 = 0;
        int SJ2 = 0;
        int actP;
        int comptCoup = 0;
        int comptManche = 0;
        bool MS = false;
        public frmJeu()
        {
            InitializeComponent();
            lblJ1.Text = Joueur.unJoueur.Pseudo + " (O)";
            lblJ2.Text = Joueur.deuxJoueur.Pseudo + " (X)";
            lblSJ1.Text = Convert.ToString(SJ1);
            lblSJ2.Text = Convert.ToString(SJ2);
            if (inscription == true)
            {
                this.btnILJ.Hide();
            }
            Random rand = new Random();
            actP = rand.Next(1, 3);
            if (actP == 1)
            {
                lblSP.Text = lblJ1.Text + ", veuillez commencer.";
            }
            else if (actP == 2)
            {
                lblSP.Text = lblJ2.Text + ", veuillez commencer.";
            }
        }


        /// <summary>
        /// Remplit les cases et guette la victoire
        /// </summary>
        /// <param name="b"></param>
        public void Jouer(Button b)
        {
            comptCoup++;
            if (actP == 1)
            {
                b.Text = "O";
                b.BackColor = Color.LightSeaGreen;
                actP = 2;
                lblSP.Text = lblJ2.Text + ", c'est à vous.";
            }
            else if (actP == 2)
            {
                b.Text = "X";
                b.BackColor = Color.PaleVioletRed;
                actP = 1;
                lblSP.Text = lblJ1.Text + ", c'est à vous.";
            }
            if
            (
                btn1.Text != "" && btn1.Text == btn2.Text && btn2.Text == btn3.Text ||
                btn4.Text != "" && btn4.Text == btn5.Text && btn5.Text == btn6.Text ||
                btn7.Text != "" && btn7.Text == btn8.Text && btn8.Text == btn9.Text ||
                btn1.Text != "" && btn1.Text == btn4.Text && btn4.Text == btn7.Text ||
                btn2.Text != "" && btn2.Text == btn5.Text && btn5.Text == btn8.Text ||
                btn3.Text != "" && btn3.Text == btn6.Text && btn6.Text == btn9.Text ||
                btn1.Text != "" && btn1.Text == btn5.Text && btn5.Text == btn9.Text ||
                btn3.Text != "" && btn3.Text == btn5.Text && btn5.Text == btn7.Text 
            )
            {
                if (actP == 2)
                {
                    lblInfo.ForeColor = Color.LightSeaGreen;
                    lblSP.Text = "";
                    if (MS == true)
                    {
                        lblInfo.Text = "Bravo " + lblJ1.Text + ", vous avez arraché la partie!";
                        MessageBox.Show("Merci d'avoir joué, à bientôt.");
                        Application.Restart();
                    }
                    else if (MS == false)
                    {
                        lblInfo.Text = "Bravo " + lblJ1.Text + ": 1 point pour vous.";
                        SJ1++;
                        lblSJ1.Text = Convert.ToString(SJ1);
                    }
                }
                else if (actP == 1)
                {
                    lblInfo.ForeColor = Color.PaleVioletRed;
                    lblSP.Text = "";
                    if (MS == true)
                    {
                        lblInfo.Text = "Bravo " + lblJ2.Text + ", vous avez arraché la partie!";
                        MessageBox.Show("Merci d'avoir joué, à bientôt.");
                        Application.Restart();
                    }
                    else if (MS == false)
                    {
                        lblInfo.Text = "Bravo " + lblJ2.Text + ": 1 point pour vous.";
                        SJ2++;
                        lblSJ2.Text = Convert.ToString(SJ2);
                    }
                }
                comptCoup = 0;
                comptManche++;
                ViderG();
            }
            else if (comptCoup == 9)
            {
                lblInfo.ForeColor = Color.Black;
                lblInfo.Text = "Dommage, pas de gagnant sur cette manche.";
                comptCoup = 0;
                comptManche++;
                ViderG();
            }
            if (comptManche == 6 || SJ1 == 4 || SJ2 == 4)
            {
                if (SJ1 > SJ2)
                {
                    lblInfo.ForeColor = Color.LightSeaGreen;
                    lblInfo.Text = "Bravo " + lblJ1.Text + ", vous avez gagné " + SJ1 + " à " + SJ2 + " !";
                    MessageBox.Show("Merci d'avoir joué, à bientôt.");
                    Application.Restart();
                }
                else if (SJ1 < SJ2)
                {

                    lblInfo.ForeColor = Color.PaleVioletRed;
                    lblInfo.Text = "Bravo " + lblJ2.Text + ", vous avez gagné " + SJ2 + " à " + SJ1 + " !";
                    MessageBox.Show("Merci d'avoir joué, à bientôt.");
                    Application.Restart();
                }
                else if (SJ1 == SJ2)
                {
                    lblInfo.ForeColor = Color.Red;
                    lblInfo.Text = lblJ1.Text + ", " + lblJ2.Text + ", vous êtes toujous à égalité,\nla MORT SUBITE vous départagera!";
                    MS = true;
                }
            }
            if (comptManche == 12)
            {
                lblInfo.ForeColor = Color.IndianRed;
                lblInfo.Text = lblJ1.Text + ", " + lblJ2.Text + ", vous êtes le Yin et le Yang incarnés,\nRIEN ne vous départagera!";
                MessageBox.Show("Merci d'avoir joué, à bientôt.");
                Application.Restart();
            }
        }

        /// <summary>
        /// Vide la grille
        /// </summary>
        public void ViderG()
        {
            MessageBox.Show("Vider la grille ?");
            lblInfo.ForeColor = Color.Black;
            lblInfo.Text = "";
            foreach (Control b in this.Controls)
            {
                if (b is Button && b.Name != "btnMS" && b.Name != "btnILJ")
                {
                    b.Text = "";
                    b.BackColor = Color.White;
                }
            }
            if (actP == 1)
            {
                lblSP.Text = lblJ1.Text + ", c'est à vous.";
            }
            else if (actP == 2)
            {
                lblSP.Text = lblJ2.Text + ", c'est à vous.";
            }
        }

        /// <summary>
        /// Détectent les clics sur la grille
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn1_Click_1(object sender, EventArgs e)
        {
            Jouer(btn1);
        }

        private void btn2_Click_1(object sender, EventArgs e)
        {
            Jouer(btn2);
        }

        private void btn3_Click_1(object sender, EventArgs e)
        {
            Jouer(btn3);
        }

        private void btn4_Click_1(object sender, EventArgs e)
        {
            Jouer(btn4);
        }

        private void btn5_Click_1(object sender, EventArgs e)
        {
            Jouer(btn5);
        }

        private void btn6_Click_1(object sender, EventArgs e)
        {
            Jouer(btn6);
        }

        private void btn7_Click_1(object sender, EventArgs e)
        {
            Jouer(btn7);
        }

        private void btn8_Click_1(object sender, EventArgs e)
        {
            Jouer(btn8);
        }

        private void btn9_Click_1(object sender, EventArgs e)
        {
            Jouer(btn9);
        }

        /// <summary>
        /// Détecte le clic sur le bouton "Inscrire les joueurs"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnILJ_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmAjoutJoueur frmAJ = new frmAjoutJoueur();
            frmAJ.ShowDialog();
            this.Close();
        }
    }
}
