namespace ft
{
    [Serializable]
    public class Option
    {
        private static int incrementid = 0;

        private int _id;

        public int Id
        {
            get => _id;
        }

        private String _nom;

        private Decimal _prix;

        public Decimal Prix
        {
            get => _prix;
        }

        public Option(String nom,Decimal prix)
        {
            _id = incrementid++;
            _nom = nom;
            _prix = prix;
        }

        public void majIdApresChargement()
        {
            incrementid = _id + 1;
        }

        public void Afficher()
        {
            Console.WriteLine(" + option => Id : {0} => {1} : {2} Є",_id,_nom,_prix);
        }
    }
}
