namespace ft
{
    [Serializable]
    public class Moteur
    {
        private static int incrementid = 0;
        private int _id;

        public int Id
        {
            get => _id;
        }
        private String _nom;
        private int _puissance { get; }
        private ft.TypeMoteur _typemoteur { get; }

        public Moteur()
        {
            _id = incrementid++;
            _nom = "";
            _puissance = 0;
        }

        public Moteur(String nom,int puissance,ft.TypeMoteur typemoteur)
        {
            _id = incrementid++;
            _nom = nom;
            _puissance = puissance;
            _typemoteur = typemoteur;
        }

        public void Afficher()
        {
            Console.WriteLine(
                "Nom: {0}, id: {1}, Puissance : {2}, Type : {3}",
                _nom,
                _id,
                _puissance,
                _typemoteur.ToString()
            );
        }
    }
}
