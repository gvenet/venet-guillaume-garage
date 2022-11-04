namespace ft
{
    [Serializable]
    public class Voiture : Vehicule
    {
        private int _chevauxFiscaux { get; }
        private int _nbPorte { get; }
        private int _nbSiege { get; }
        private int _tailleCoffre { get; }

        public Voiture(
            String nom,
            Decimal prixHT,
            Marque marque,
            Moteur moteur,
            int chevauxFiscaux,
            int nbPorte,
            int nbSiege,
            int tailleCoffre
        ) : base(nom,prixHT,marque,moteur)
        {
            _chevauxFiscaux = chevauxFiscaux;
            _nbPorte = nbPorte;
            _nbSiege = nbSiege;
            _tailleCoffre = tailleCoffre;
        }

        public Voiture(Voiture cpy) : base(cpy._nom,cpy._prixHT,cpy._marque,cpy._moteur)
        {
            _chevauxFiscaux = cpy._chevauxFiscaux;
            _nbPorte = cpy._nbPorte;
            _nbSiege = cpy._nbSiege;
            _tailleCoffre = cpy._tailleCoffre;
        }

        public override decimal CalculerTaxe()
        {
            return _chevauxFiscaux * 10;
        }

        public new void Afficher()
        {
            Console.WriteLine("\n**********************************************************");
            Console.WriteLine(
                "Type de vehicule : Voiture\nchevaux fiscaux {0}, nombre de porte {1}, nombre de siege {2}, taille du coffre {3}",
                _chevauxFiscaux,
                _nbPorte,
                _nbSiege,
                _tailleCoffre
            );
            base.Afficher();
        }
    }
}
