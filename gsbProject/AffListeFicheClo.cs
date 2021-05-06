using Devart.Data.MySql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gsbProject
{
    public partial class AffListeFicheClo : Form
    {
        public AffListeFicheClo()
        {
            InitializeComponent();
        }


        //affichage liste des fiches de frais clôturées
        private void Form1_Load(object sender, EventArgs e)
        {
            MySqlDataAdapter msda1 = new MySqlDataAdapter("SELECT visiteur.NOM as 'v_nom', visiteur.PRENOM as 'v_prenom', fichedefrais.ID as 'fiche_id', fichedefrais.DATEDEBUT as 'f_date', etat.LIBELLE as 'e_libelle', " +
                "CONCAT(fichedefrais.id, ' - ',visiteur.NOM, ' ', visiteur.PRENOM, ' - ', fichedefrais.DATEDEBUT) as 'v_all' FROM visiteur INNER JOIN fichedefrais ON visiteur.ID = fichedefrais.ID_POSSEDER " +
                "INNER JOIN etat on fichedefrais.ID_ETRE_DE2 = etat.ID WHERE etat.LIBELLE = 'Clôturée' ORDER BY visiteur.NOM; ", Program.mydb.connection);


            DataSet DS1 = new DataSet();
            msda1.Fill(DS1);

            lboxLstFicheClo.DataSource = DS1.Tables[0];  // lie le jeu de données à la combo
            lboxLstFicheClo.DisplayMember = "v_all"; // colonne de la table apparaissant dans la liste
            lboxLstFicheClo.ValueMember = "fiche_id";    // valeur retournée lorsqu'un élément est sélectionné

            MySqlDataAdapter msda2 = new MySqlDataAdapter("SELECT ID as 'visiteur_id', NOM as 'visiteur_nom',PRENOM as 'visiteur_prenom', CONCAT(NOM, ' ', PRENOM) as 'v_all' FROM visiteur ORDER BY ID", Program.mydb.connection);
            DataSet DS2 = new DataSet();
            msda2.Fill(DS2);

            cboxName.DataSource = DS2.Tables[0];  // lie le jeu de données à la combo
            cboxName.DisplayMember = "v_all"; // colonne de la table apparaissant dans la liste
            cboxName.ValueMember = "visiteur_id";    // valeur retournée lorsqu'un élément est sélectionné

           
        }

        //remplissage des quantités de frais forfaitisés selon la fiche
        private void lboxLstFicheClo_Click(object sender, EventArgs e)
        {
            

            MySqlCommand command1 = Program.mydb.connection.CreateCommand();
            command1.CommandText = "select QUANTITE from forfaitise where ID_COMPOSER = " + lboxLstFicheClo.SelectedValue + " and ID_ETRE_DE=1;";         
            command1.Parameters.AddWithValue("@id", lboxLstFicheClo.SelectedValue.ToString());    
            

            using (MySqlDataReader reader = command1.ExecuteReader())
            {
                reader.Read();
                tboxRepasMidi.Text = reader["QUANTITE"].ToString();
            }

            MySqlCommand command2 = Program.mydb.connection.CreateCommand();
            command2.CommandText = "select QUANTITE from forfaitise where ID_COMPOSER = " + lboxLstFicheClo.SelectedValue + "  and ID_ETRE_DE=2;";
            command2.Parameters.AddWithValue("@id", lboxLstFicheClo.SelectedValue.ToString());    
            

            using (MySqlDataReader reader = command2.ExecuteReader())
            {
                reader.Read();
                tboxRelaisEtape.Text = reader["QUANTITE"].ToString();
            }

            MySqlCommand command3 = Program.mydb.connection.CreateCommand();
            command3.CommandText = "select QUANTITE from forfaitise where ID_COMPOSER = " + lboxLstFicheClo.SelectedValue + "  and ID_ETRE_DE=3;";        
            command3.Parameters.AddWithValue("@id", lboxLstFicheClo.SelectedValue.ToString());    
            

            using (MySqlDataReader reader = command3.ExecuteReader())
            {
                reader.Read();
                tboxNuitee.Text = reader["QUANTITE"].ToString();
            }

            MySqlCommand command4 = Program.mydb.connection.CreateCommand();
            command4.CommandText = "select QUANTITE from forfaitise where ID_COMPOSER = " + lboxLstFicheClo.SelectedValue + "  and ID_ETRE_DE=4;";     
            command4.Parameters.AddWithValue("@id", lboxLstFicheClo.SelectedValue.ToString());    
           

            using (MySqlDataReader reader = command4.ExecuteReader())
            {
                reader.Read();
                tboxKilometrage.Text = reader["QUANTITE"].ToString();
            }

            //affichage liste frais hors-forfait selon la fiche de frais

            MySqlDataAdapter msda2 = new MySqlDataAdapter("select ID as 'h_id', LIBELLE as 'h_libelle' from horsforfait where ID_COMPOSER2= " + lboxLstFicheClo.SelectedValue + " ; ", Program.mydb.connection);


            DataSet DS2 = new DataSet();
            msda2.Fill(DS2);

            lboxFHF.DataSource = DS2.Tables[0];  // lie le jeu de données à la combo
            lboxFHF.DisplayMember = "h_libelle"; // colonne de la table apparaissant dans la liste
            lboxFHF.ValueMember = "h_id";    // valeur retournée lorsqu'un élément est sélectionné

            

        }

        //remplissage des champs selon le frais hors-forfait
        private void lboxFHF_Click(object sender, EventArgs e)
        {
            MySqlCommand command5 = Program.mydb.connection.CreateCommand();
            command5.CommandText = "SELECT libelle, montant, date_format(date, '%d-%m-%Y') as 'date' from horsforfait where id_composer2 = " + lboxLstFicheClo.SelectedValue + " and ID = " + lboxFHF.SelectedValue + " ; ";
            command5.Parameters.AddWithValue("@id", lboxFHF.SelectedValue.ToString());

            MySqlCommand command51 = Program.mydb.connection.CreateCommand();
            command51.CommandText = "SELECT validation from horsforfait where id_composer2 = " + lboxLstFicheClo.SelectedValue + " and ID = " + lboxFHF.SelectedValue + " ; ";
            var boxval = Convert.ToInt32(command51.ExecuteScalar());
            if (boxval == 1)
            {
                chboxValideon.Checked = true;
            }
            else
            {
                chboxValideon.Checked = false;
            }


            using (MySqlDataReader reader = command5.ExecuteReader())
            {
                reader.Read();
                tboxHFLibelle.Text = reader["libelle"].ToString();
                tboxHFMontant.Text = reader["montant"].ToString();
                tboxHFDate.Text = reader["date"].ToString();
            }
        }

        //update des champs dans la base après la modification
        private void tboxRepasMidi_Leave(object sender, EventArgs e)
        {
            MySqlCommand command6 = Program.mydb.connection.CreateCommand();
            command6.CommandText = "update forfaitise set QUANTITE = " + tboxRepasMidi.Text + " where ID_COMPOSER = " + lboxLstFicheClo.SelectedValue + " and ID_ETRE_DE = 1 ;";
            command6.ExecuteNonQuery();
        }

        private void tboxRelaisEtape_Leave(object sender, EventArgs e)
        {
            MySqlCommand command7 = Program.mydb.connection.CreateCommand();
            command7.CommandText = "update forfaitise set QUANTITE = " + tboxRelaisEtape.Text + " where ID_COMPOSER = " + lboxLstFicheClo.SelectedValue + " and ID_ETRE_DE = 2 ;";
            command7.ExecuteNonQuery();
        }

        private void tboxNuitee_Leave(object sender, EventArgs e)
        {
            MySqlCommand command8 = Program.mydb.connection.CreateCommand();
            command8.CommandText = "update forfaitise set QUANTITE = " + tboxNuitee.Text + " where ID_COMPOSER = " + lboxLstFicheClo.SelectedValue + " and ID_ETRE_DE = 3 ;";
            command8.ExecuteNonQuery();
        }

        private void tboxKilometrage_Leave(object sender, EventArgs e)
        {
            MySqlCommand command9 = Program.mydb.connection.CreateCommand();
            command9.CommandText = "update forfaitise set QUANTITE = " + tboxKilometrage.Text + " where ID_COMPOSER = " + lboxLstFicheClo.SelectedValue + " and ID_ETRE_DE = 4 ;";
            command9.ExecuteNonQuery();
        }

        //update si le frais hors-forfait est validé par le comptable
        private void chboxValideon_CheckedChanged(object sender, EventArgs e)
        {
            MySqlCommand command10 = Program.mydb.connection.CreateCommand();

            if (chboxValideon.Checked)
            {
                command10.CommandText = "update horsforfait set VALIDATION = true where ID = " + lboxFHF.SelectedValue + " ; ";
                command10.ExecuteNonQuery();
            }
            else
            {
                command10.CommandText = "update horsforfait set VALIDATION = false where ID = " + lboxFHF.SelectedValue + " ; ";
                command10.ExecuteNonQuery();
            }
        }

        //update des champs du frais hors-forfait
        private void tboxHFMontant_Leave(object sender, EventArgs e)
        {
            MySqlCommand command11 = Program.mydb.connection.CreateCommand();
            command11.CommandText = "update horsforfait set MONTANT = " + tboxHFMontant.Text + " where ID = " + lboxFHF.SelectedValue + " ;";
            command11.ExecuteNonQuery();
        }

        private void tboxHFDate_Leave(object sender, EventArgs e)
        {
            MySqlCommand command12 = Program.mydb.connection.CreateCommand();
            command12.CommandText = "update horsforfait set DATE = " + DateTime.ParseExact(tboxHFDate.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) + " where ID = " + lboxFHF.SelectedValue + " ;";
            command12.ExecuteNonQuery();
        }

        public void updateForm()
        {
            MySqlDataAdapter msda1 = new MySqlDataAdapter("SELECT visiteur.NOM as 'v_nom', visiteur.PRENOM as 'v_prenom', fichedefrais.ID as 'fiche_id', fichedefrais.DATEDEBUT as 'f_date', etat.LIBELLE as 'e_libelle', " +
                "CONCAT(fichedefrais.id, ' - ',visiteur.NOM, ' ', visiteur.PRENOM, ' - ', fichedefrais.DATEDEBUT) as 'v_all' FROM visiteur INNER JOIN fichedefrais ON visiteur.ID = fichedefrais.ID_POSSEDER " +
                "INNER JOIN etat on fichedefrais.ID_ETRE_DE2 = etat.ID WHERE etat.LIBELLE = 'Clôturée' ORDER BY visiteur.NOM; ", Program.mydb.connection);


            DataSet DS1 = new DataSet();
            msda1.Fill(DS1);

            lboxLstFicheClo.DataSource = DS1.Tables[0];  // lie le jeu de données à la combo
            lboxLstFicheClo.DisplayMember = "v_all"; // colonne de la table apparaissant dans la liste
            lboxLstFicheClo.ValueMember = "fiche_id";    // valeur retournée lorsqu'un élément est sélectionné

            MySqlDataAdapter msda2 = new MySqlDataAdapter("SELECT ID as 'visiteur_id', NOM as 'visiteur_nom',PRENOM as 'visiteur_prenom', CONCAT(NOM, ' ', PRENOM) as 'v_all' FROM visiteur ORDER BY ID", Program.mydb.connection);
            DataSet DS2 = new DataSet();
            msda2.Fill(DS2);

            cboxName.DataSource = DS2.Tables[0];  // lie le jeu de données à la combo
            cboxName.DisplayMember = "v_all"; // colonne de la table apparaissant dans la liste
            cboxName.ValueMember = "visiteur_id";    // valeur retournée lorsqu'un élément est sélectionné
        }

        private void btnValiderFiche_Click(object sender, EventArgs e)
        {
            MySqlCommand command13 = Program.mydb.connection.CreateCommand();
            command13.CommandText = "update fichedefrais set ID_ETRE_DE2 = 3 where id = "+ lboxLstFicheClo.SelectedValue + "; ";
            command13.ExecuteNonQuery();

            updateForm();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            MySqlDataAdapter msda3 = new MySqlDataAdapter("SELECT visiteur.NOM as 'v_nom', visiteur.PRENOM as 'v_prenom', fichedefrais.ID as 'fiche_id', fichedefrais.DATEDEBUT as 'f_date', etat.LIBELLE as 'e_libelle', " +
                "CONCAT(fichedefrais.id, ' - ',visiteur.NOM, ' ', visiteur.PRENOM, ' - ', fichedefrais.DATEDEBUT) as 'v_all' FROM visiteur INNER JOIN fichedefrais ON visiteur.ID = fichedefrais.ID_POSSEDER " +
                "INNER JOIN etat on fichedefrais.ID_ETRE_DE2 = etat.ID WHERE etat.LIBELLE = 'Clôturée' and visiteur.ID = " + cboxName.SelectedValue + " ORDER BY fichedefrais.DATEDEBUT; ", Program.mydb.connection);

            DataSet DS3 = new DataSet();
            msda3.Fill(DS3);

            lboxLstFicheClo.DataSource = DS3.Tables[0];  // lie le jeu de données à la combo
            lboxLstFicheClo.DisplayMember = "v_all"; // colonne de la table apparaissant dans la liste
            lboxLstFicheClo.ValueMember = "fiche_id";    // valeur retournée lorsqu'un élément est sélectionné
        }
    }
}
