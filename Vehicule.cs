namespace ft
{
    [Serializable]
    public abstract class Vehicule : IComparable
    {
        protected static int incrementid = 0;
        protected int _id;

        public int Id
        {
            get => _id;
        }
        protected String _nom { get; }
        protected Decimal _prixHT { get; }
        protected Marque _marque { get; }
        protected Moteur _moteur { get; }

        protected List<Option> _options = new List<Option>();

        public List<Option> Option
        {
            get
            {
                return _options;
            }
        }

        public Vehicule(String nom,Decimal prixHT,Marque marque,Moteur moteur)
        {
            _id = incrementid++;
            _nom = nom;
            _prixHT = prixHT;
            _marque = marque;
            _moteur = moteur;
        }

        public void AfficherOptions()
        {
            if (!_options.Count.Equals(0))
            {
                Console.WriteLine("Options : ");
                foreach (Option option in _options)
                    option.Afficher();
            }
            else
            {
                Console.WriteLine("Ce vehicule ne possede pas d'options");
            }
        }

        public void Afficher()
        {
            Console.WriteLine(
                "Id : {3}\nNom : {0}\nMarque : {1}\nPrix de baseHT : {2} Є",
                _nom,
                _marque.ToString(),
                _prixHT,
                _id
            );
            _moteur.Afficher();
            AfficherOptions();
            Console.WriteLine("Prix Total : {0} Є",PrixTotal());
        }

        public void AjouterOption(Option option)
        {
            _options.Add(option);
        }

        public void SupprimerOption(Option option)
        {
            _options.Remove(option);
        }

        public abstract Decimal CalculerTaxe();

        public Decimal PrixTotal()
        {
            Decimal totalPrixOptions = 0;
            foreach (Option option in _options)
            {
                totalPrixOptions += option.Prix;
            }
            return CalculerTaxe() + _prixHT + totalPrixOptions;
        }

        public int CompareTo(object? obj)
        {
            if (obj == null)
                return 1;

            Vehicule? vehicule = obj as Vehicule;
            if (vehicule != null)
                return _prixHT.CompareTo(vehicule._prixHT);
            else
                throw new ArgumentException("Object is not a Vehicule");
        }
    }
}
