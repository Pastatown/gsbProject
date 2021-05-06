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
    public partial class AffListeFicheRemBis : Form
    {
        public AffListeFicheRemBis()
        {
            InitializeComponent();
        }

        private void AffListeFicheRemBis_Load(object sender, EventArgs e)
        {
            
        }

        private void btnVoirDetails_Click(object sender, EventArgs e)
        {
            /*Menu f = new Menu();
           
   
            MySqlCommand command1 = Program.mydb.connection.CreateCommand();
            command1.CommandText = "select QUANTITE from forfaitise where ID_COMPOSER = " + MainMenu. + " and ID_ETRE_DE=1;";
            command1.Parameters.AddWithValue("@id", f.Id.ToString());


            using (MySqlDataReader reader = command1.ExecuteReader())
            {
                reader.Read();
                tboxRepasMidi.Text = reader["QUANTITE"].ToString();
            }

            MySqlCommand command2 = Program.mydb.connection.CreateCommand();
            command2.CommandText = "select QUANTITE from forfaitise where ID_COMPOSER = " + f.Id + "  and ID_ETRE_DE=2;";
            command2.Parameters.AddWithValue("@id", f.Id.ToString());


            using (MySqlDataReader reader = command2.ExecuteReader())
            {
                reader.Read();
                tboxRelaisEtape.Text = reader["QUANTITE"].ToString();
            }

            MySqlCommand command3 = Program.mydb.connection.CreateCommand();
            command3.CommandText = "select QUANTITE from forfaitise where ID_COMPOSER = " + f.Id + "  and ID_ETRE_DE=3;";
            command3.Parameters.AddWithValue("@id", f.Id.ToString());


            using (MySqlDataReader reader = command3.ExecuteReader())
            {
                reader.Read();
                tboxNuitee.Text = reader["QUANTITE"].ToString();
            }

            MySqlCommand command4 = Program.mydb.connection.CreateCommand();
            command4.CommandText = "select QUANTITE from forfaitise where ID_COMPOSER = " + f.Id + "  and ID_ETRE_DE=4;";
            command4.Parameters.AddWithValue("@id", f.Id.ToString());

            using (MySqlDataReader reader = command4.ExecuteReader())
            {
                reader.Read();
                tboxKilometrage.Text = reader["QUANTITE"].ToString();
            }

            //affichage liste frais hors-forfait selon la fiche de frais
            MySqlDataAdapter msda2 = new MySqlDataAdapter("select ID as 'h_id', LIBELLE as 'h_libelle' from horsforfait where ID_COMPOSER2= " + f.Id + " ; ", Program.mydb.connection);


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
                "where fichedefrais.id = " + f.Id + " ;";
                command5.Parameters.AddWithValue("@id", f.Id.ToString());
            }

            catch (InvalidCastException a)
            {
                command5.CommandText = "select sum(quantite*typeforfait.montant) as 'montant_total' from forfaitise " +
                "inner join typeforfait on forfaitise.ID_ETRE_DE = typeforfait.ID " +
                "inner join fichedefrais on forfaitise.ID_COMPOSER = fichedefrais.ID " +
                "inner join horsforfait on fichedefrais.ID = horsforfait.ID_COMPOSER2 " +
                "where fichedefrais.id = " + f.Id + " ;";
                command5.Parameters.AddWithValue("@id", f.Id.ToString());
            }



            using (MySqlDataReader reader = command5.ExecuteReader())
            {
                reader.Read();
                tboxMTotal.Text = reader["montant_total"].ToString();
            }*/
        }
    }
}
