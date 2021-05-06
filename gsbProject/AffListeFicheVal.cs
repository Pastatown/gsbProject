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
    public partial class AffListeFicheVal : Form
    {
        public AffListeFicheVal()
        {
            InitializeComponent();
        }

        //affichage liste des fiches de frais validées
        private void AffListeFiche_Load(object sender, EventArgs e)
        {
            MySqlDataAdapter msda = new MySqlDataAdapter("SELECT visiteur.NOM as 'v_nom', visiteur.PRENOM as 'v_prenom', fichedefrais.ID as 'fiche_id', fichedefrais.DATEDEBUT as 'f_date', etat.LIBELLE as 'e_libelle', CONCAT(visiteur.NOM, ' ', visiteur.PRENOM, ' - ', fichedefrais.DATEDEBUT) as 'v_all' FROM visiteur INNER JOIN fichedefrais ON visiteur.ID = fichedefrais.ID_POSSEDER INNER JOIN etat on fichedefrais.ID_ETRE_DE2 = etat.ID WHERE etat.LIBELLE = 'Validée' ORDER BY visiteur.NOM; ", Program.mydb.connection);
            
            
            DataSet DS = new DataSet();
            msda.Fill(DS);

            lboxLstFicheVal.DataSource = DS.Tables[0];  // lie le jeu de données à la combo
            lboxLstFicheVal.DisplayMember = "v_all"; // colonne de la table apparaissant dans la liste
            lboxLstFicheVal.ValueMember = "fiche_id";    // valeur retournée lorsqu'un élément est sélectionné


            MySqlDataAdapter msda2 = new MySqlDataAdapter("SELECT ID as 'visiteur_id', NOM as 'visiteur_nom',PRENOM as 'visiteur_prenom', CONCAT(NOM, ' ', PRENOM) as 'v_all' FROM visiteur ORDER BY ID", Program.mydb.connection);
            DataSet DS2 = new DataSet();
            msda2.Fill(DS2);

            cboxName.DataSource = DS2.Tables[0];  // lie le jeu de données à la combo
            cboxName.DisplayMember = "v_all"; // colonne de la table apparaissant dans la liste
            cboxName.ValueMember = "visiteur_id";    // valeur retournée lorsqu'un élément est sélectionné
        }



        //remplissage des quantités de frais forfaitisés selon la fiche
        private void lboxLstFicheVal_Click(object sender, EventArgs e)
        {
            MySqlCommand command1 = Program.mydb.connection.CreateCommand();
            command1.CommandText = "select QUANTITE from forfaitise where ID_COMPOSER = " + lboxLstFicheVal.SelectedValue + " and ID_ETRE_DE=1;";
            command1.Parameters.AddWithValue("@id", lboxLstFicheVal.SelectedValue.ToString());


            using (MySqlDataReader reader = command1.ExecuteReader())
            {
                reader.Read();
                tboxRepasMidi.Text = reader["QUANTITE"].ToString();
            }

            MySqlCommand command2 = Program.mydb.connection.CreateCommand();
            command2.CommandText = "select QUANTITE from forfaitise where ID_COMPOSER = " + lboxLstFicheVal.SelectedValue + "  and ID_ETRE_DE=2;";
            command2.Parameters.AddWithValue("@id", lboxLstFicheVal.SelectedValue.ToString());


            using (MySqlDataReader reader = command2.ExecuteReader())
            {
                reader.Read();
                tboxRelaisEtape.Text = reader["QUANTITE"].ToString();
            }

            MySqlCommand command3 = Program.mydb.connection.CreateCommand();
            command3.CommandText = "select QUANTITE from forfaitise where ID_COMPOSER = " + lboxLstFicheVal.SelectedValue + "  and ID_ETRE_DE=3;";
            command3.Parameters.AddWithValue("@id", lboxLstFicheVal.SelectedValue.ToString());


            using (MySqlDataReader reader = command3.ExecuteReader())
            {
                reader.Read();
                tboxNuitee.Text = reader["QUANTITE"].ToString();
            }

            MySqlCommand command4 = Program.mydb.connection.CreateCommand();
            command4.CommandText = "select QUANTITE from forfaitise where ID_COMPOSER = " + lboxLstFicheVal.SelectedValue + "  and ID_ETRE_DE=4;";
            command4.Parameters.AddWithValue("@id", lboxLstFicheVal.SelectedValue.ToString());

            using (MySqlDataReader reader = command4.ExecuteReader())
            {
                reader.Read();
                tboxKilometrage.Text = reader["QUANTITE"].ToString();
            }

            //affichage liste frais hors-forfait selon la fiche de frais
            MySqlDataAdapter msda2 = new MySqlDataAdapter("select ID as 'h_id', LIBELLE as 'h_libelle' from horsforfait where ID_COMPOSER2= " + lboxLstFicheVal.SelectedValue + " ; ", Program.mydb.connection);


            DataSet DS2 = new DataSet();
            msda2.Fill(DS2);

            lboxFHF.DataSource = DS2.Tables[0];  // lie le jeu de données à la combo
            lboxFHF.DisplayMember = "h_libelle"; // colonne de la table apparaissant dans la liste
            lboxFHF.ValueMember = "h_id";    // valeur retournée lorsqu'un élément est sélectionné

            //calcul de montant total
            MySqlCommand command5 = Program.mydb.connection.CreateCommand();

            try
            {
                command5.CommandText = "select (sum(quantite*typeforfait.montant)+ horsforfait.MONTANT) as 'montant_total' from forfaitise " +
                "inner join typeforfait on forfaitise.ID_ETRE_DE = typeforfait.ID " +
                "inner join fichedefrais on forfaitise.ID_COMPOSER = fichedefrais.ID " +
                "inner join horsforfait on fichedefrais.ID = horsforfait.ID_COMPOSER2 " +
                "where fichedefrais.id = " + lboxLstFicheVal.SelectedValue + " ;";
                command5.Parameters.AddWithValue("@id", lboxLstFicheVal.SelectedValue.ToString());
            }

            catch(InvalidCastException a)
            {
                command5.CommandText = "select sum(quantite*typeforfait.montant) as 'montant_total' from forfaitise " +
                "inner join typeforfait on forfaitise.ID_ETRE_DE = typeforfait.ID " +
                "inner join fichedefrais on forfaitise.ID_COMPOSER = fichedefrais.ID " +
                "inner join horsforfait on fichedefrais.ID = horsforfait.ID_COMPOSER2 " +
                "where fichedefrais.id = " + lboxLstFicheVal.SelectedValue + " ;";
                command5.Parameters.AddWithValue("@id", lboxLstFicheVal.SelectedValue.ToString());
            }
            


            using (MySqlDataReader reader = command5.ExecuteReader())
            {
                reader.Read();
                tboxMTotal.Text = reader["montant_total"].ToString();
            }
        }

        //remplissage des champs selon le frais hors-forfait
        private void lboxFHF_Click(object sender, EventArgs e)
        {
            MySqlCommand command6 = Program.mydb.connection.CreateCommand();
            command6.CommandText = "SELECT libelle, montant, date_format(date, '%d-%m-%Y') as 'date' from horsforfait where id_composer2 = " + lboxLstFicheVal.SelectedValue + " and ID = " + lboxFHF.SelectedValue + " ; ";
            command6.Parameters.AddWithValue("@id", lboxFHF.SelectedValue.ToString());

            MySqlCommand command51 = Program.mydb.connection.CreateCommand();
            command51.CommandText = "SELECT validation from horsforfait where id_composer2 = " + lboxLstFicheVal.SelectedValue + " and ID = " + lboxFHF.SelectedValue + " ; ";
            var boxval = Convert.ToInt32(command51.ExecuteScalar());
            if (boxval == 1)
            {
                chboxValideon.Checked = true;
            }
            else
            {
                chboxValideon.Checked = false;
            }


            using (MySqlDataReader reader = command6.ExecuteReader())
            {
                reader.Read();
                tboxHFLibelle.Text = reader["libelle"].ToString();
                tboxHFMontant.Text = reader["montant"].ToString();
                tboxHFDate.Text = reader["date"].ToString();
            }

            /*MySqlCommand command7 = Program.mydb.connection.CreateCommand();
            command7.CommandText = "SELECT validation from horsforfait where id_composer2 = " + lboxLstFicheVal.SelectedValue + " and ID = " + lboxFHF.SelectedValue + " ; ";
            command7.Parameters.AddWithValue("@id", lboxFHF.SelectedValue.ToString());*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlDataAdapter msda3 = new MySqlDataAdapter("SELECT visiteur.NOM as 'v_nom', visiteur.PRENOM as 'v_prenom', fichedefrais.ID as 'fiche_id', fichedefrais.DATEDEBUT as 'f_date', etat.LIBELLE as 'e_libelle', " +
                "CONCAT(fichedefrais.id, ' - ',visiteur.NOM, ' ', visiteur.PRENOM, ' - ', fichedefrais.DATEDEBUT) as 'v_all' FROM visiteur INNER JOIN fichedefrais ON visiteur.ID = fichedefrais.ID_POSSEDER " +
                "INNER JOIN etat on fichedefrais.ID_ETRE_DE2 = etat.ID WHERE etat.LIBELLE = 'Validée' and visiteur.ID = " + cboxName.SelectedValue + " ORDER BY fichedefrais.DATEDEBUT; ", Program.mydb.connection);

            DataSet DS3 = new DataSet();
            msda3.Fill(DS3);

            lboxLstFicheVal.DataSource = DS3.Tables[0];  // lie le jeu de données à la combo
            lboxLstFicheVal.DisplayMember = "v_all"; // colonne de la table apparaissant dans la liste
            lboxLstFicheVal.ValueMember = "fiche_id";    // valeur retournée lorsqu'un élément est sélectionné
        }
    }
}
