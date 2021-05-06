using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Devart.Data.MySql;

namespace gsbProject
{
    public partial class Menu : Form
    {
        private static int id;

        public static int Id { get => id; set => id = value; }

        public Menu()
        {
            InitializeComponent();
            Form f = Application.OpenForms["Menu"];
            
        }

        //affichage liste des visiteurs
        private void Form1_Load(object sender, EventArgs e)
        {
            MySqlDataAdapter msda = new MySqlDataAdapter("SELECT ID as 'visiteur_id', NOM as 'visiteur_nom',PRENOM as 'visiteur_prenom', CONCAT(NOM, ' ', PRENOM) as 'v_all' FROM visiteur ORDER BY ID", Program.mydb.connection);
            DataSet DS = new DataSet();
            msda.Fill(DS);

            cboxName.DataSource = DS.Tables[0];  // lie le jeu de données à la combo
            cboxName.DisplayMember = "v_all"; // colonne de la table apparaissant dans la liste
            cboxName.ValueMember = "visiteur_id";    // valeur retournée lorsqu'un élément est sélectionné


            //gère le changement d'état des fiches en fonction de la date
            DateTime Now = DateTime.Now;
            if (Now.Day >= 20)
            {
                MySqlCommand command = Program.mydb.connection.CreateCommand();

                command.CommandText = "UPDATE fichedefrais SET ID_ETRE_DE2 = 4 WHERE ID_ETRE_DE2 = 3 ";
                command.ExecuteNonQuery();
            }

            MySqlCommand command2 = Program.mydb.connection.CreateCommand();

            command2.CommandText = "select MONTH(fichedefrais.DATEDEBUT) from fichedefrais where ID_ETRE_DE2 = 1";
            var req = command2.ExecuteNonQuery();


            DateTime NowMonth = DateTime.Now;
            if (NowMonth.Month != req)
            {
                MySqlCommand command3 = Program.mydb.connection.CreateCommand();

                command3.CommandText = "UPDATE fichedefrais SET ID_ETRE_DE2 = 2 WHERE ID_ETRE_DE2 = 1 ";
                command3.ExecuteNonQuery();
            }

        }

        //redirection page selon le statut de la fiche
        private void btnVal_Click(object sender, EventArgs e)
        {
            var AffListeFicheVal = new AffListeFicheVal();    
            AffListeFicheVal.ShowDialog();
        }

        private void btnClo_Click(object sender, EventArgs e)
        {
            var AffListeFicheClo = new AffListeFicheClo();    
            AffListeFicheClo.ShowDialog();
        }

        private void btnRem_Click(object sender, EventArgs e)
        {
            var AffListeFicheRem = new AffListeFicheRem();    
            AffListeFicheRem.ShowDialog();
        }

        //affichage des fiches par visiteur
        private void cboxName_SelectedValueChanged(object sender, EventArgs e)
        {
            var id = this.cboxName.SelectedIndex + 1;
            MySqlDataAdapter msda = new MySqlDataAdapter("SELECT visiteur.ID, visiteur.NOM as 'v_nom', visiteur.PRENOM as 'v_prenom', fichedefrais.ID as 'fiche_id', fichedefrais.DATEDEBUT as 'f_date', etat.LIBELLE as 'e_libelle', " +
                "CONCAT(visiteur.NOM, ' ', visiteur.PRENOM, ' - ', fichedefrais.DATEDEBUT, ' - ', etat.LIBELLE) as 'v_all' FROM visiteur INNER JOIN fichedefrais ON visiteur.ID = fichedefrais.ID_POSSEDER INNER JOIN etat on fichedefrais.ID_ETRE_DE2 = etat.ID " +
                "where visiteur.ID=" + id + " ORDER BY fichedefrais.DATEDEBUT; ", Program.mydb.connection);



            DataSet DS = new DataSet();
            msda.Fill(DS);

            lboxFicheVis.DataSource = DS.Tables[0];  // lie le jeu de données à la combo
            lboxFicheVis.DisplayMember = "v_all"; // colonne de la table apparaissant dans la liste
            lboxFicheVis.ValueMember = "fiche_id";    // valeur retournée lorsqu'un élément est sélectionné
        }

        //redirection vers une fiche en particulier selon son état et le visiteur choisi
        private void lboxFicheVis_Click(object sender, EventArgs e)
        {
            
            MySqlCommand command51 = Program.mydb.connection.CreateCommand();
            command51.CommandText = "SELECT id_etre_de2 from fichedefrais where id = " + lboxFicheVis.SelectedValue + " ; ";
            var a = Convert.ToInt32(command51.ExecuteScalar());
            if (a == 2)
            {
                var AffListeFicheCloBis = new AffListeFicheCloBis();
                AffListeFicheCloBis.ShowDialog();
            }
            else if (a == 3)
            {
                var AffListeFicheValBis = new AffListeFicheValBis();
                AffListeFicheValBis.ShowDialog();
            }
            else if (a == 5)
            {
                var AffListeFicheRemBis = new AffListeFicheRemBis();
                AffListeFicheRemBis.ShowDialog();
            }

            /*using (AffListeFicheRemBis f = new AffListeFicheRemBis())
            {
                if (AffListeFicheRemBis.ShowDialog() == DialogResult.OK)
                {
                    lboxFicheVis.SelectedValue = AffListeFicheRemBis.TheValue;
                }
            }*/

            Id = Convert.ToInt32(lboxFicheVis.SelectedValue);
        }
     
    }
}
