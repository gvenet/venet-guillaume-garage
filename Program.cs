namespace ft
{
    [Serializable]
    internal class Program
    {
        static void Moteurs(Garage garage)
        {
            garage.AjouterMoteur(new Moteur("moteur1",67,TypeMoteur.essence));
            garage.AjouterMoteur(new Moteur("moteur2",50,TypeMoteur.diesel));
            garage.AjouterMoteur(new Moteur("moteur3",250,TypeMoteur.hybride));
        }
        static void Vehicules(Garage garage)
        {
            garage.AjouterVehicule(new Camion("c1",60842.3M,Marque.ferrari,garage.Moteurs[0],6,400,4242));
            garage.AjouterVehicule(new Moto("m1",7000.2M,Marque.ferrari,garage.Moteurs[1],550));
            garage.AjouterVehicule(new Voiture("v2",24842.3M,Marque.ferrari,garage.Moteurs[2],120,3,2,42));
        }
        static void Options(Garage garage)
        {
            garage.AjouterOption(new Option("jantes_alu",650));
            garage.AjouterOption(new Option("boite_auto",500));
            garage.AjouterOption(new Option("anti_derapant",128));
        }
        static void Main(string[] args)
        {
            Garage garage = new Garage();
            // Moteurs(garage);
            // Vehicules(garage);
            // Options(garage);
            Menu menu = new Menu(garage);
            menu.Start();
        }
    }
}
