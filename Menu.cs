
namespace ft
{
    [Serializable]
    public class Menu
    {
        private Garage _garage;
        private Utils utls = new Utils();
        private String[] menuStrings = {
            "0. Afficher les véhicules",
            "1. Ajouter un véhicule",
            "2. Supprimer un véhicule",
            "3. Sélectionner un véhicule",
            "4. Afficher les options d'un véhicule",
            "5. Ajouter des options à un véhicule",
            "6. Supprimer des options à un véhicule",
            "7. Afficher les options",
            "8. Afficher les moteurs",
            "9. Afficher les marques",
            "10. Afficher les types de moteurs",
            "11. Charger le garage",
            "12. Sauvegarder le garage",
            "13. Ajouter Moteur",
            "14. Ajouter Option",
            "15. Trier les vehicules",
            "16. Quitter l'application\n",
        };

        public Menu(Garage garage)
        {
            _garage = garage;
        }

        public void Start()
        {
            while (true)
            {
                utls.printBlue("Menu principal");
                try
                {
                    int menuNb = utls.GetChoix<int>(
                        String.Join("\n",menuStrings),
                        new List<int>(new int[] { 0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16 })
                    );
                    switch (menuNb)
                    {
                        case 0:
                            utls.printBlue("Menu principal - 0. Afficher les véhicules");
                            _garage.Afficher();
                            break;
                        case 1:
                            utls.printBlue("Menu principal - 1. Ajouter un vehicule");
                            AjouterVehicule();
                            break;
                        case 2:
                            utls.printBlue("Menu principal - 2. Supprimer un véhicule");
                            SupprimerVehicule();
                            break;
                        case 3:
                            utls.printBlue("Menu principal - 3. Sélectionner un véhicule");
                            SelectionnerVehicule();
                            break;
                        case 4:
                            utls.printBlue("Menu principal - 4. Afficher les options d'un véhicule");
                            _garage.AfficherOptionsVehicule();
                            break;
                        case 5:
                            utls.printBlue("Menu principal - 5. Ajouter des options à un véhicule");
                            AjouterOptionVehicule();
                            break;
                        case 6:
                            utls.printBlue("Menu principal - 6. Supprimer des options à un véhicule");
                            SupprimerOptionVehicule();
                            break;
                        case 7:
                            utls.printBlue("Menu principal - 7. Afficher les options");
                            _garage.AfficherOptions();
                            break;
                        case 8:
                            utls.printBlue("Menu principal - 8. Afficher les moteurs");
                            _garage.AfficherMoteurs();
                            break;
                        case 9:
                            utls.printBlue("Menu principal - 9. Afficher les marques");
                            _garage.AfficherMarques();
                            break;
                        case 10:
                            utls.printBlue("Menu principal - 10. Afficher les types de moteurs");
                            _garage.AfficherTypesMoteurs();
                            break;
                        case 11:
                            utls.printBlue("Menu principal - 11. Charger le garage");
                            _garage = _garage.Charger<Garage>();
                            break;
                        case 12:
                            utls.printBlue("Menu principal - 12. Sauvegarder le garage");
                            _garage.Enregistrer();
                            break;
                        case 13:
                            utls.printBlue("Menu principal - 13. Ajouter moteur");
                            AjouterMoteur();
                            break;
                        case 14:
                            utls.printBlue("Menu principal - 14. Ajouter option");
                            AjouterOption();
                            break;
                        case 15:
                            utls.printBlue("Menu principal - 15. Trier les vehicules");
                            _garage.TrierVehicule();
                            break;
                        case 16:
                            utls.printBlue("Menu principal - 16. Quitter l'application\n");
                            System.Environment.Exit(0);
                            break;
                    }
                }
                catch (Exception e)
                {
                    utls.printRed(e.ToString());
                }
            }


        }

        public void AjouterOption()
        {
            String optName = utls.GetChoix<String>("Nom : ");
            Decimal optPrice = utls.GetChoix<Decimal>("Prix : ");
            _garage.Options.Add(new Option(optName,optPrice));
        }

        public void AjouterMoteur()
        {
            String motorName = utls.GetChoix<String>("Nom : ");
            int puissance = utls.GetChoix<int>("Puissance : ");
            int typeMoteur = utls.GetChoix<int>(
                "Type de moteur (0 - diesel | 1 - essence | 2 - electrique | 3 - hybride) : ",
                new List<int>(new int[] { 0,1,2,3 })
            );
            _garage.Moteurs.Add(new Moteur(motorName,puissance,(TypeMoteur)typeMoteur));
        }

        public void SupprimerOption()
        {
            List<int> index = new List<int>();
            foreach (Option option in _garage.Options)
            {
                option.Afficher();
                index.Add(option.Id);
            }
            int deleteId = utls.GetChoix<int>("Saisir l'id de l'option a supprimer : ",index);
            _garage.Options = _garage.Options.Where(option => option.Id != deleteId).ToList();
        }

        public void AjouterVehicule()
        {
            int idVehicule = utls.GetChoix<int>(
                "type de vehicule (0 - Moto | 1 - Voiture | 2 - Camion) : ",
                new List<int>(new int[] { 0,1,2 })
            );
            String nameVehicule = utls.GetChoix<String>("Nom : ");
            Decimal prixVehicule = utls.GetChoix<Decimal>("Prix : ");
            int indexMarque = utls.GetChoix<int>(
                "Marque (0 - peugeot | 1 - renaud | 2 - citroen | 3 - audi | 4 - ferrari) : ",
                new List<int>(new int[] { 0,1,2,3,4 })
            );
            Marque marque = (Marque)(indexMarque);
            Console.WriteLine("Selectionner un moteur par id");
            List<int> index = new List<int>();
            foreach (Moteur moteur in _garage.Moteurs)
            {
                moteur.Afficher();
                index.Add(moteur.Id);
            }
            int idMoteur = utls.GetChoix<int>("",index);
            Moteur moteurVehicule = new Moteur();
            foreach (Moteur moteur in _garage.Moteurs)
                if (idMoteur == moteur.Id)
                    moteurVehicule = moteur;
            switch (idVehicule)
            {
                case 0:
                    int cylindreVehicule = utls.GetChoix<int>("cylindre : ");
                    _garage.Vehicules.Add(
                        new Moto(
                            nameVehicule,
                            prixVehicule,
                            marque,
                            moteurVehicule,
                            cylindreVehicule
                        )
                    );
                    break;
                case 1:
                    int chevauxFiscaux = utls.GetChoix<int>("chevaux fiscaux : ");
                    int nbPorte = utls.GetChoix<int>("nombre de porte : ");
                    int nbSiege = utls.GetChoix<int>("nombre de siege : ");
                    int tailleCoffre = utls.GetChoix<int>("taille du coffre : ");
                    _garage.Vehicules.Add(
                        new Voiture(
                            nameVehicule,
                            prixVehicule,
                            marque,
                            moteurVehicule,
                            chevauxFiscaux,
                            nbPorte,
                            nbSiege,
                            tailleCoffre
                        )
                    );
                    break;
                case 2:
                    int nbEssieu = utls.GetChoix<int>("nomnbre d'essieux : ");
                    int poids = utls.GetChoix<int>("poids : ");
                    int volume = utls.GetChoix<int>("volume : ");
                    _garage.Vehicules.Add(
                        new Camion(
                            nameVehicule,
                            prixVehicule,
                            marque,
                            moteurVehicule,
                            nbEssieu,
                            poids,
                            volume
                        )
                    );
                    break;
            }
        }
        public void SupprimerVehicule()
        {
            _garage.Afficher();
            List<int> index = new List<int>();
            foreach (Vehicule vehicule in _garage.Vehicules)
                index.Add(vehicule.Id);
            int deleteId = utls.GetChoix<int>("Saisir l'id du vehicule a supprimer : ",index);
            if (_garage.Current != null && deleteId == _garage.Current.Id)
                _garage.Current = null!;
            _garage.Vehicules = _garage.Vehicules.Where(vehicule => vehicule.Id != deleteId).ToList();



        }
        public void SelectionnerVehicule()
        {
            _garage.Afficher();
            List<int> index = new List<int>();
            foreach (Vehicule vehicule in _garage.Vehicules)
                index.Add(vehicule.Id);
            int selectedId = utls.GetChoix<int>("Saisir l'id du vehicule a selectionner : ",index);
            foreach (Vehicule vehicule in _garage.Vehicules)
                if (vehicule.Id == selectedId)
                    _garage.Current = vehicule;
        }
        public void AjouterOptionVehicule()
        {
            if (_garage.Current == null)
                throw new Exception("Veuillez selectionner un vehicule");
            else
            {
                List<int> index = new List<int>();
                foreach (Option option in _garage.Options)
                {
                    option.Afficher();
                    index.Add(option.Id);
                }
                int optionId = utls.GetChoix<int>("Saisir l'id de l'option a ajouter : ",index);
                foreach (Option option in _garage.Options)
                    if (option.Id == optionId)
                        _garage.Current.AjouterOption(option);
            }
        }
        public void SupprimerOptions()
        {
            List<int> index = new List<int>();
            foreach (Option option in _garage.Options)
            {
                option.Afficher();
                index.Add(option.Id);
            }
            int deleteId = utls.GetChoix<int>("Saisir l'id de l'option a supprimer : ",index);
            _garage.Vehicules = _garage.Vehicules.Where(vehicule => vehicule.Id != deleteId).ToList();
        }
        public void SupprimerOptionVehicule()
        {
            List<int> index = new List<int>();
            if (_garage.Current == null)
                throw new Exception("Veuillez selectionner un vehicule");
            else
            {
                foreach (Option option in _garage.Options)
                {
                    option.Afficher();
                    index.Add(option.Id);
                }
            }
            int optionId = utls.GetChoix<int>("Saisir l'id de l'option a supprimer : ",index);
            foreach (Option option in _garage.Options)
                if (option.Id == optionId)
                    _garage.Current.SupprimerOption(option);
        }

    }
}
