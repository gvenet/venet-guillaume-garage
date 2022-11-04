namespace ft
{
    [Serializable]
    public class Camion : Vehicule
    {
        private int _nbEssieu;

        private int _poids;

        private int _volume;

        public Camion(
            String nom,
            Decimal prixHT,
            Marque marque,
            Moteur moteur,
            int nbEssieu,
            int poids,
            int volume
        ) : base(nom,prixHT,marque,moteur)
        {
            _nbEssieu = nbEssieu;
            _poids = poids;
            _volume = volume;
        }

        public Camion(Camion cpy) : base(cpy._nom,cpy._prixHT,cpy._marque,cpy._moteur)
        {
            _nbEssieu = cpy._nbEssieu;
            _poids = cpy._poids;
            _volume = cpy._volume;
        }

        public override decimal CalculerTaxe()
        {
            return _nbEssieu * 50M;
        }

        public new void Afficher()
        {
            Console.WriteLine("\n**********************************************************");
            Console.WriteLine(
                "Type de vehicule : Camion\nnombre d'essieu {0}, poids {1}, volume {2}",
                _nbEssieu,
                _poids,
                _volume
            );
            base.Afficher();
        }
    }
}
