			var id = this.cboxName.SelectedIndex + 1;
            MySqlDataAdapter msda = new MySqlDataAdapter("SELECT visiteur.ID, visiteur.NOM as 'v_nom', visiteur.PRENOM as 'v_prenom', fichedefrais.ID as 'fiche_id', fichedefrais.DATEDEBUT as 'f_date', etat.LIBELLE as 'e_libelle', " +
                "CONCAT(visiteur.NOM, ' ', visiteur.PRENOM, ' - ', fichedefrais.DATEDEBUT, ' - ', etat.LIBELLE) as 'v_all' FROM visiteur INNER JOIN fichedefrais ON visiteur.ID = fichedefrais.ID_POSSEDER INNER JOIN etat on fichedefrais.ID_ETRE_DE2 = etat.ID " +
                "where visiteur.ID=" + id + " ORDER BY fichedefrais.DATEDEBUT; ", Program.mydb.connection);



            DataSet DS = new DataSet();
            msda.Fill(DS);

            lboxFicheVis.DataSource = DS.Tables[0];  // lie le jeu de données à la combo

            lboxFicheVis.DisplayMember = "v_all"; // colonne de la table apparaissant dans la liste
            lboxFicheVis.ValueMember = "fiche_id";    // valeur retournée lorsqu'un élément est sélectionné