namespace ft
{
    [Serializable]
    public class Moto : Vehicule
    {
        private int _cylindre { get; }

        public Moto(String nom,Decimal prixHT,Marque marque,Moteur moteur,int cylindre)
            : base(nom,prixHT,marque,moteur)
        {
            _cylindre = cylindre;
        }

        public Moto(Moto cpy) : base(cpy._nom,cpy._prixHT,cpy._marque,cpy._moteur)
        {
            _cylindre = cpy._cylindre;
        }

        public override decimal CalculerTaxe()
        {
            return Math.Truncate(_cylindre * 0.3M);
        }

        public new void Afficher()
        {
            Console.WriteLine("\n**********************************************************");
            Console.WriteLine("Type de vehicule : Moto\ncylindre {0}",_cylindre);
            base.Afficher();
        }
    }
}
